/*
 * Created by SharpDevelop.
 * User: Ohmnibus
 * Date: 27/05/2017
 * Time: 21:53
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Data;
using System.Data.SQLite;

using System.Collections.Generic;

using SplTbl = net.ohmnibus.grimorium.database.GrimoriumContract.SpellTable;
using SourceTable = net.ohmnibus.grimorium.database.GrimoriumContract.SourceTable;

namespace Grimorium.ADnD {
	
	/// <summary>
	/// Description of SpellDB.
	/// </summary>
	public class SpellDB {

		private const string connString = @"data source=.\Resources\Grimorium.db;read only=True";
		
		private readonly string[] TABLE_COLUMNS = {
			SplTbl._ID,
			SplTbl.COLUMN_NAME_TYPE,
			SplTbl.COLUMN_NAME_LEVEL,
			SplTbl.COLUMN_NAME_NAME,
			SplTbl.COLUMN_NAME_SCHOOLS_BITFIELD,
			SplTbl.COLUMN_NAME_COMPONENTS_BITFIELD
		};
		
		public const int COLUMN_INDEX_ID = 0;
		public const int COLUMN_INDEX_TYPE = 1;
		public const int COLUMN_INDEX_LEVEL = 2;
		public const int COLUMN_INDEX_NAME = 3;
		public const int COLUMN_INDEX_SCHOOLS = 4;
		public const int COLUMN_INDEX_COMPONENTS = 5;
		
		private readonly SpellDecoder mDecoder = new SpellDecoder();
		
		public SpellDB() {
		}
		
		public long[] GetUnofficialSources() {
			List<long> retVal = new List<long>();
			using (SQLiteConnection conn = new SQLiteConnection(connString)) {
				using (SQLiteCommand cmd = new SQLiteCommand(conn)) {
					conn.Open();
					
					cmd.CommandText = "Select " + SourceTable._ID + " " +
						"From " + SourceTable.TABLE_NAME + " " +
						"Where " + SourceTable.COLUMN_NAME_NAMESPACE + " Not In (" +
						"'official.wizards.all', " +
						"'official.priests.all' " +
						") ";
					
					using (SQLiteDataReader dr = cmd.ExecuteReader()) {
						while (dr.Read()) {
							retVal.Add((long)dr[0]);
						}
					}
				}
			}
			return retVal.ToArray();
		}
		
		public DataTable GetSpell(long ID) {
			DataTable retVal = new DataTable();
			using (SQLiteConnection conn = new SQLiteConnection(connString)) {
				using (SQLiteCommand cmd = new SQLiteCommand(conn)) {
					conn.Open();
					
					cmd.CommandText = "Select * " +
						"From " + SplTbl.TABLE_NAME + " " +
						"Where " + SplTbl._ID + " = " + ID + " ";
					
					using (SQLiteDataReader dr = cmd.ExecuteReader()) {
						retVal.Load(dr);
					}
				}
			}
			return retVal;
		}
		
		public DataTable GetSpellTable(SpellFilter filter) {
			DataTable retVal;
			using (SQLiteConnection conn = new SQLiteConnection(connString)) {
				using (SQLiteCommand cmd = new SQLiteCommand(conn)) {
					conn.Open();
					
					cmd.CommandText = "Select " + getColumnChain() + " " +
						"From " + SplTbl.TABLE_NAME + " " +
						//"Where " + SplTbl.COLUMN_NAME_SOURCE + " <> 1 " +
						//(string.IsNullOrEmpty(filter) ? "" : "And " + SplTbl.COLUMN_NAME_NAME + " Like @filter ") +
						//(filter.isEmpty() ? "" : "And " + SpellFilter.getWhereClause(filter)) +
						"Where " + (filter.IsEmpty() ? "1=1 " : SpellFilter.GetWhereClause(filter)) + " " +
						"Order By " + SplTbl.COLUMN_NAME_TYPE +
						", " + SplTbl.COLUMN_NAME_LEVEL+ 
						", " + SplTbl.COLUMN_NAME_NAME;
					
					if (! string.IsNullOrEmpty(filter.query)) {
						cmd.Parameters.AddWithValue("@filter", "%" + filter.query + "%");
					}
					
					using (SQLiteDataReader dr = cmd.ExecuteReader()) {
						retVal = fillTable(dr);
					}
				}
			}
			return retVal;
		}
		
		private string TABLE_COLUMNS_CHAIN = null;
		
		private string getColumnChain() {
			if (TABLE_COLUMNS_CHAIN == null) {
				TABLE_COLUMNS_CHAIN = "";
				string sep = "";
				foreach (string column in TABLE_COLUMNS) {
					TABLE_COLUMNS_CHAIN += sep + column;
					sep = ",";
				}
			}
			return TABLE_COLUMNS_CHAIN;
		}
		
		private DataTable fillTable(SQLiteDataReader dr) {
			DataTable retVal = new DataTable();
			
			//These columns must follow same order as in TABLE_COLUMNS
			retVal.Columns.Add(new DataColumn(SplTbl._ID, typeof(long)));
			retVal.Columns.Add(new DataColumn("Type", typeof(string)));
			retVal.Columns.Add(new DataColumn("Level", typeof(string)));
			retVal.Columns.Add(new DataColumn("Name", typeof(string)));
			retVal.Columns.Add(new DataColumn("Schools", typeof(string)));
			retVal.Columns.Add(new DataColumn("Compo.", typeof(string)));
			
			retVal.BeginLoadData();
			while (dr.Read()) {
				DataRow row = retVal.NewRow();
				row[COLUMN_INDEX_ID] = (long)dr[COLUMN_INDEX_ID];
				row[COLUMN_INDEX_TYPE] = mDecoder.GetSpellType((decimal)dr[COLUMN_INDEX_TYPE]);
				row[COLUMN_INDEX_NAME] = dr.GetString(COLUMN_INDEX_NAME);
				row[COLUMN_INDEX_LEVEL] = mDecoder.GetSpellLevel((decimal)dr[COLUMN_INDEX_LEVEL]);
				row[COLUMN_INDEX_SCHOOLS] = mDecoder.GetSchools((decimal)dr[COLUMN_INDEX_SCHOOLS]);
				row[COLUMN_INDEX_COMPONENTS] = mDecoder.GetCompos((decimal)dr[COLUMN_INDEX_COMPONENTS]);
				
				retVal.Rows.Add(row);
			}
			retVal.EndLoadData();
			
			return retVal;
		}
	}
}
