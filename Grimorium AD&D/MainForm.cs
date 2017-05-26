/*
 * Created by SharpDevelop.
 * User: Ohmnibus
 * Date: 20/05/2017
 * Time: 00:13
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;

using System.Data.SQLite;

using net.ohmnibus.grimorium.database;
using Cnt = net.ohmnibus.grimorium.database.GrimoriumContract;
using SplTbl = net.ohmnibus.grimorium.database.GrimoriumContract.SpellTable;

namespace Grimorium.ADnD
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form {
		
		private const string connString = @"data source=.\Resources\Grimorium.db;read only=True";
		
		SpellDecoder mDecoder = new SpellDecoder();
		SpellFilter mFilter = new SpellFilter();

		public MainForm() {
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			initFilter(mFilter);
			loadData();
			resetSpell();
		}
		
		private void loadData() {
			loadData(mFilter);
		}
		
		private void loadData(SpellFilter filter) {
			using (SQLiteConnection conn = new SQLiteConnection(connString)) {
				using (SQLiteCommand cmd = new SQLiteCommand(conn)) {
					conn.Open();
					
					cmd.CommandText = "Select " + getColumnChain() + " " +
						"From " + SplTbl.TABLE_NAME + " " +
						"Where " + SplTbl.COLUMN_NAME_SOURCE + " <> 1 " +
						//(string.IsNullOrEmpty(filter) ? "" : "And " + SplTbl.COLUMN_NAME_NAME + " Like @filter ") +
						(filter.isEmpty() ? "" : "And " + SpellFilter.getWhereClause(filter)) +
						"Order By " + SplTbl.COLUMN_NAME_TYPE +
						", " + SplTbl.COLUMN_NAME_LEVEL+ 
						", " + SplTbl.COLUMN_NAME_NAME;
					
					if (! string.IsNullOrEmpty(filter.query)) {
						cmd.Parameters.AddWithValue("@filter", "%" + filter.query + "%");
					}
					
					using (SQLiteDataReader dr = cmd.ExecuteReader()) {
						//DataTable dt = new DataTable();
						//dt.Load(dr);
						DataTable dt = fillTable(dr);
						
						dgMain.DataSource = dt;
						dgMain.Columns[IDX_COL_ID].Visible = false;
						dgMain.Columns[IDX_COL_TYPE].Width = 40;
						dgMain.Columns[IDX_COL_NAME].Width = 150;
						dgMain.Columns[IDX_COL_LEVEL].Width = 40;
						dgMain.Columns[IDX_COL_SCHOOLS_BITFIELD].Width = 150;
						dgMain.Columns[IDX_COL_COMPONENTS_BITFIELD].Width = 60;
					}
				}
			}
		}
		
		private readonly string[] columns = {
			SplTbl._ID,
			SplTbl.COLUMN_NAME_TYPE,
			SplTbl.COLUMN_NAME_LEVEL,
			SplTbl.COLUMN_NAME_NAME,
			SplTbl.COLUMN_NAME_SCHOOLS_BITFIELD,
			SplTbl.COLUMN_NAME_COMPONENTS_BITFIELD
		};
		
		private const int IDX_COL_ID = 0;
		private const int IDX_COL_TYPE = 1;
		private const int IDX_COL_LEVEL = 2;
		private const int IDX_COL_NAME = 3;
		private const int IDX_COL_SCHOOLS_BITFIELD = 4;
		private const int IDX_COL_COMPONENTS_BITFIELD = 5;
		
		private string getColumnChain() {
			string retVal = "";
			string sep = "";
			foreach (string column in columns) {
				retVal += sep + column;
				sep = ",";
			}
			return retVal;
		}
		
		private DataTable fillTable(SQLiteDataReader dr) {
			DataTable retVal = new DataTable();
			
			retVal.Columns.Add(new DataColumn(SplTbl._ID, typeof(long)));
			retVal.Columns.Add(new DataColumn("Type", typeof(string)));
			retVal.Columns.Add(new DataColumn("Level", typeof(string)));
			retVal.Columns.Add(new DataColumn("Name", typeof(string)));
			retVal.Columns.Add(new DataColumn("Schools", typeof(string)));
			retVal.Columns.Add(new DataColumn("Compo.", typeof(string)));
			
			SpellDecoder decoder = new SpellDecoder();
			
			retVal.BeginLoadData();
			while (dr.Read()) {
				DataRow row = retVal.NewRow();
				row[SplTbl._ID] = (long)dr[IDX_COL_ID];
				row["Type"] = decoder.GetSpellType((decimal)dr[IDX_COL_TYPE]);
				row["Name"] = dr.GetString(IDX_COL_NAME);
				row["Level"] = decoder.GetSpellLevel((decimal)dr[IDX_COL_LEVEL]);
				row["Schools"] = decoder.GetSchools((decimal)dr[IDX_COL_SCHOOLS_BITFIELD]);
				row["Compo."] = decoder.GetCompos((decimal)dr[IDX_COL_COMPONENTS_BITFIELD]);
				
				retVal.Rows.Add(row);
			}
			retVal.EndLoadData();
			
			return retVal;
		}
		
		private void setSpell(long id) {
			using (SQLiteConnection conn = new SQLiteConnection(connString)) {
				using (SQLiteCommand cmd = new SQLiteCommand(conn)) {
					conn.Open();
					
					cmd.CommandText = "Select * " +
						"From " + SplTbl.TABLE_NAME + " " +
						"Where " + SplTbl._ID + " = " + id + " ";
					
					using (SQLiteDataReader dr = cmd.ExecuteReader()) {
						
						if (dr.Read()) {
							setSpell(dr);
						} else {
							resetSpell();
						}
					}
				}
			}
		}
		
		private void setSpell(SQLiteDataReader dr) {
			lblTitle.Text = (string)dr[SplTbl.COLUMN_NAME_NAME];
			decimal spellType = (decimal)dr[SplTbl.COLUMN_NAME_TYPE];
			lblLevel.Text = mDecoder.GetSpellAttrib(
				spellType,
				(decimal)dr[SplTbl.COLUMN_NAME_LEVEL],
				((decimal)dr[SplTbl.COLUMN_NAME_REVERSIBLE]) != 0
			);
			lblSchools.Text = mDecoder.GetSchools((decimal)dr[SplTbl.COLUMN_NAME_SCHOOLS_BITFIELD], true);
			if (spellType == SpellDecoder.TYPE_CLERICS) {
				lblSpheres.Text = "Spheres: " + mDecoder.GetSpheres((decimal)dr[SplTbl.COLUMN_NAME_SCHOOLS_BITFIELD]);
			} else {
				lblSpheres.Text = "";
			}
			lblRange.Text = "Range: " + (string)dr[SplTbl.COLUMN_NAME_RANGE];
			lblCompos.Text = "Components: " + mDecoder.GetCompos((decimal)dr[SplTbl.COLUMN_NAME_COMPONENTS_BITFIELD]);
			lblDuration.Text = "Duration: " + (string)dr[SplTbl.COLUMN_NAME_DURATION];
			lblCastTime.Text = "Casting Time: " + (string)dr[SplTbl.COLUMN_NAME_CAST_TIME];
			lblArea.Text = "Area of Effect: " + (string)dr[SplTbl.COLUMN_NAME_AOE];
			lblSaving.Text = "Saving Throw: " + (string)dr[SplTbl.COLUMN_NAME_SAVING];
			string book = (string)dr[SplTbl.COLUMN_NAME_BOOK];
			if (! string.IsNullOrEmpty(book)) {
				lblBook.Text = "-" + book + "-";
			} else {
				lblBook.Text = "";
			}
			wbBody.DocumentText = mDecoder.getDescription((string)dr[SplTbl.COLUMN_NAME_DESCRIPTION]);
		}
		
		private void resetSpell() {
			lblTitle.Text = "";
			lblLevel.Text = "";
			lblSchools.Text = "";
			lblSpheres.Text = "";
			lblRange.Text = "";
			lblCompos.Text = "";
			lblDuration.Text = "";
			lblCastTime.Text = "";
			lblArea.Text = "";
			lblSaving.Text = "";
			lblBook.Text = "";
			wbBody.DocumentText = mDecoder.getDescription("");
			wbBody.Document.BackColor = Color.Gray;
			wbBody.Document.ForeColor = Color.Red;
		}
		
		private void initFilter(SpellFilter filter) {

			if (filter.types == SpellDecoder.TYPE_WIZARDS) {
				rbSpellTypeWizard.Checked = true;
			} else if (filter.types == SpellDecoder.TYPE_CLERICS) {
				rbSpellTypePriest.Checked = true;
			} else {
				rbSpellTypeBoth.Checked = true;
			}
			rbSpellTypeWizard.CheckedChanged += new System.EventHandler(rbSpellTypeCheckedChanged);
			rbSpellTypePriest.CheckedChanged += new System.EventHandler(rbSpellTypeCheckedChanged);
			rbSpellTypeBoth.CheckedChanged += new System.EventHandler(rbSpellTypeCheckedChanged);
			
			cbCompoVerbal.Checked = filter.Verbal;
			cbCompoSomatic.Checked = filter.Somatic;
			cbCompoMaterial.Checked = filter.Material;

			cbCompoVerbal.CheckedChanged += new System.EventHandler(cbCompoCheckedChanged);
			cbCompoSomatic.CheckedChanged += new System.EventHandler(cbCompoCheckedChanged);
			cbCompoMaterial.CheckedChanged += new System.EventHandler(cbCompoCheckedChanged);
		}
		
		void DgMainCellClick(object sender, DataGridViewCellEventArgs e) {
			DataGridViewRow row = dgMain.Rows[e.RowIndex];
			setSpell((long)row.Cells["_id"].Value);
		}
		
		void TbQueryTextChanged(object sender, EventArgs e) {
			mFilter.query = tbQuery.Text;
			loadData();
		}
		
		void CmdClearClick(object sender, EventArgs e) {
			tbQuery.Clear();
		}
		
		void rbSpellTypeCheckedChanged(object sender, EventArgs e) {
			if (! ((RadioButton)sender).Checked) {
				return;
			}
			if (rbSpellTypeWizard.Checked) {
				mFilter.types = SpellDecoder.TYPE_WIZARDS;
			} else if (rbSpellTypePriest.Checked) {
				mFilter.types = SpellDecoder.TYPE_CLERICS;
			} else if (rbSpellTypeBoth.Checked) {
				mFilter.types = SpellDecoder.TYPE_ALL;
			} else {
				//?!?
				return;
			}
			loadData();
		}
		
		void cbCompoCheckedChanged(object sender, EventArgs e) {
//			if (sender == cbCompoVerbal) {
//				mFilter.compos = SpellFilter.setValue(
//					mFilter.compos,
//					SpellDecoder.COMP_VERBAL,
//					cbCompoVerbal.Checked
//				);
//			} else if (sender == cbCompoSomatic) {
//				mFilter.compos = SpellFilter.setValue(
//					mFilter.compos,
//					SpellDecoder.COMP_SOMATIC,
//					cbCompoSomatic.Checked
//				);
//			} else if (sender == cbCompoMaterial) {
//				mFilter.compos = SpellFilter.setValue(
//					mFilter.compos,
//					SpellDecoder.COMP_MATERIAL,
//					cbCompoMaterial.Checked
//				);
//			} else {
//				//?!?
//				return;
//			}
			if (cbCompoVerbal.Checked
			    && cbCompoSomatic.Checked
			    && cbCompoMaterial.Checked) {
				
				mFilter.compos = SpellDecoder.COMP_ALL;
			} else {
				mFilter.compos = SpellDecoder.COMP_NONE;
				mFilter.Verbal = cbCompoVerbal.Checked;
				mFilter.Somatic = cbCompoSomatic.Checked;
				mFilter.Material = cbCompoMaterial.Checked;
			}
			loadData();
		}

	}
}
