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
using System.Linq;

//using System.Data.SQLite;

using net.ohmnibus.grimorium.database;
using Cnt = net.ohmnibus.grimorium.database.GrimoriumContract;
using SplTbl = net.ohmnibus.grimorium.database.GrimoriumContract.SpellTable;

namespace Grimorium.ADnD
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form {
		
		private const string FilterFileName = "filter.cfg";
		
		SpellDB mSpellDB = new SpellDB();
		SpellDecoder mDecoder = new SpellDecoder();
		SpellFilter mFilter; // = new SpellFilter();
		//long[] unofficialSources;

		public MainForm() {
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			InitApp();
		}
		
		protected override void OnClosed(EventArgs e){
			base.OnClosed(e);
			mFilter.WriteToFile(FilterFileName);
		}
		
		private void InitApp() {
			
			SpellFilter.UNOFFICIAL_SOURCES = mSpellDB.GetUnofficialSources();
			
			mFilter = SpellFilter.ReadFromFile(FilterFileName);
			
			initFilter(mFilter);
			
			loadData();
			
			dgMain.Columns[SpellDB.COLUMN_INDEX_ID].Visible = false;
			dgMain.Columns[SpellDB.COLUMN_INDEX_TYPE].Width = 40;
			dgMain.Columns[SpellDB.COLUMN_INDEX_NAME].Width = 150;
			dgMain.Columns[SpellDB.COLUMN_INDEX_LEVEL].Width = 40;
			dgMain.Columns[SpellDB.COLUMN_INDEX_SCHOOLS].Width = 150;
			dgMain.Columns[SpellDB.COLUMN_INDEX_COMPONENTS].Width = 60;

			resetSpell();
			
			//this.dgMain.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgMainCellClick);
			this.dgMain.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgMainRowEnter);
		}
		
//		private void writeFilter(SpellFilter filter) {
//			try {
//				using (FileStream fs = File.OpenWrite(FilterFileName)) {
//					using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8)) {
//						sw.WriteLine(filter.Serialize());
//					}
//				}
//			} catch (Exception ex) {
//				//Uh oh....
//				Console.WriteLine(ex);
//			}
//		}
		
//		private SpellFilter readFilter() {
//			SpellFilter retVal;
//			try {
//				using (FileStream fs = File.OpenRead(FilterFileName)) {
//					using (StreamReader sr = new StreamReader(fs, Encoding.UTF8)) {
//						retVal = SpellFilter.Deserialize(
//							sr.ReadLine()
//						);
//					}
//				}
//			} catch (Exception ex) {
//				//Uh oh....
//				Console.WriteLine(ex);
//				retVal = new SpellFilter();
//			}
//			return retVal;
//		}
			
//		private readonly string[] columns = {
//			SplTbl._ID,
//			SplTbl.COLUMN_NAME_TYPE,
//			SplTbl.COLUMN_NAME_LEVEL,
//			SplTbl.COLUMN_NAME_NAME,
//			SplTbl.COLUMN_NAME_SCHOOLS_BITFIELD,
//			SplTbl.COLUMN_NAME_COMPONENTS_BITFIELD
//		};
//		
//		private const int IDX_COL_ID = 0;
//		private const int IDX_COL_TYPE = 1;
//		private const int IDX_COL_LEVEL = 2;
//		private const int IDX_COL_NAME = 3;
//		private const int IDX_COL_SCHOOLS_BITFIELD = 4;
//		private const int IDX_COL_COMPONENTS_BITFIELD = 5;
		
//		private string getColumnChain() {
//			string retVal = "";
//			string sep = "";
//			foreach (string column in columns) {
//				retVal += sep + column;
//				sep = ",";
//			}
//			return retVal;
//		}
		

		private void loadData() {
			loadData(mFilter);
		}
		
		private void loadData(SpellFilter filter) {
			//DataTable dt = fillTable(dr);
			
			//dgMain.DataSource = dt;
			
			dgMain.DataSource = mSpellDB.GetSpellTable(filter);
		}
		
//		private void loadData(SpellFilter filter) {
//			using (SQLiteConnection conn = new SQLiteConnection(connString)) {
//				using (SQLiteCommand cmd = new SQLiteCommand(conn)) {
//					conn.Open();
//					
//					cmd.CommandText = "Select " + getColumnChain() + " " +
//						"From " + SplTbl.TABLE_NAME + " " +
//						"Where " + SplTbl.COLUMN_NAME_SOURCE + " <> 1 " +
//						//(string.IsNullOrEmpty(filter) ? "" : "And " + SplTbl.COLUMN_NAME_NAME + " Like @filter ") +
//						(filter.isEmpty() ? "" : "And " + SpellFilter.getWhereClause(filter)) +
//						"Order By " + SplTbl.COLUMN_NAME_TYPE +
//						", " + SplTbl.COLUMN_NAME_LEVEL+ 
//						", " + SplTbl.COLUMN_NAME_NAME;
//					
//					if (! string.IsNullOrEmpty(filter.query)) {
//						cmd.Parameters.AddWithValue("@filter", "%" + filter.query + "%");
//					}
//					
//					using (SQLiteDataReader dr = cmd.ExecuteReader()) {
//						//DataTable dt = new DataTable();
//						//dt.Load(dr);
//						DataTable dt = fillTable(dr);
//						
//						dgMain.DataSource = dt;
//						dgMain.Columns[IDX_COL_ID].Visible = false;
//						dgMain.Columns[IDX_COL_TYPE].Width = 40;
//						dgMain.Columns[IDX_COL_NAME].Width = 150;
//						dgMain.Columns[IDX_COL_LEVEL].Width = 40;
//						dgMain.Columns[IDX_COL_SCHOOLS_BITFIELD].Width = 150;
//						dgMain.Columns[IDX_COL_COMPONENTS_BITFIELD].Width = 60;
//					}
//				}
//			}
//		}
		
//		private DataTable fillTable(SQLiteDataReader dr) {
//			DataTable retVal = new DataTable();
//			
//			retVal.Columns.Add(new DataColumn(SplTbl._ID, typeof(long)));
//			retVal.Columns.Add(new DataColumn("Type", typeof(string)));
//			retVal.Columns.Add(new DataColumn("Level", typeof(string)));
//			retVal.Columns.Add(new DataColumn("Name", typeof(string)));
//			retVal.Columns.Add(new DataColumn("Schools", typeof(string)));
//			retVal.Columns.Add(new DataColumn("Compo.", typeof(string)));
//			
//			SpellDecoder decoder = new SpellDecoder();
//			
//			retVal.BeginLoadData();
//			while (dr.Read()) {
//				DataRow row = retVal.NewRow();
//				row[SplTbl._ID] = (long)dr[IDX_COL_ID];
//				row["Type"] = decoder.GetSpellType((decimal)dr[IDX_COL_TYPE]);
//				row["Name"] = dr.GetString(IDX_COL_NAME);
//				row["Level"] = decoder.GetSpellLevel((decimal)dr[IDX_COL_LEVEL]);
//				row["Schools"] = decoder.GetSchools((decimal)dr[IDX_COL_SCHOOLS_BITFIELD]);
//				row["Compo."] = decoder.GetCompos((decimal)dr[IDX_COL_COMPONENTS_BITFIELD]);
//				
//				retVal.Rows.Add(row);
//			}
//			retVal.EndLoadData();
//			
//			return retVal;
//		}
		
//		private void setSpell(long id) {
//			using (SQLiteConnection conn = new SQLiteConnection(connString)) {
//				using (SQLiteCommand cmd = new SQLiteCommand(conn)) {
//					conn.Open();
//					
//					cmd.CommandText = "Select * " +
//						"From " + SplTbl.TABLE_NAME + " " +
//						"Where " + SplTbl._ID + " = " + id + " ";
//					
//					using (SQLiteDataReader dr = cmd.ExecuteReader()) {
//						if (dr.Read()) {
//							setSpell(dr);
//						} else {
//							resetSpell();
//						}
//					}
//				}
//			}
//		}
		
//		private void setSpell(SQLiteDataReader dr) {
//			lblTitle.Text = (string)dr[SplTbl.COLUMN_NAME_NAME];
//			decimal spellType = (decimal)dr[SplTbl.COLUMN_NAME_TYPE];
//			lblLevel.Text = mDecoder.GetSpellAttrib(
//				spellType,
//				(decimal)dr[SplTbl.COLUMN_NAME_LEVEL],
//				((decimal)dr[SplTbl.COLUMN_NAME_REVERSIBLE]) != 0
//			);
//			lblSchools.Text = mDecoder.GetSchools((decimal)dr[SplTbl.COLUMN_NAME_SCHOOLS_BITFIELD], true);
//			if (spellType == SpellDecoder.TYPE_CLERICS) {
//				lblSpheres.Text = "Spheres: " + mDecoder.GetSpheres((decimal)dr[SplTbl.COLUMN_NAME_SPHERES_BITFIELD]);
//				//lblSpheres.Text += " (" + (string)dr[SplTbl.COLUMN_NAME_SPHERES] + ")";
//			} else {
//				lblSpheres.Text = "";
//			}
//			lblRange.Text = "Range: " + (string)dr[SplTbl.COLUMN_NAME_RANGE];
//			lblCompos.Text = "Components: " + mDecoder.GetCompos((decimal)dr[SplTbl.COLUMN_NAME_COMPONENTS_BITFIELD]);
//			lblDuration.Text = "Duration: " + (string)dr[SplTbl.COLUMN_NAME_DURATION];
//			lblCastTime.Text = "Casting Time: " + (string)dr[SplTbl.COLUMN_NAME_CAST_TIME];
//			lblArea.Text = "Area of Effect: " + (string)dr[SplTbl.COLUMN_NAME_AOE];
//			lblSaving.Text = "Saving Throw: " + (string)dr[SplTbl.COLUMN_NAME_SAVING];
//			string book = (string)dr[SplTbl.COLUMN_NAME_BOOK];
//			if (! string.IsNullOrEmpty(book)) {
//				lblBook.Text = "-" + book + "-";
//			} else {
//				lblBook.Text = "";
//			}
//			wbBody.DocumentText = mDecoder.getDescription((string)dr[SplTbl.COLUMN_NAME_DESCRIPTION]);
//		}
		
		private void setSpell(long id) {
			DataTable dt = mSpellDB.GetSpell(id);
			if (dt != null && dt.Rows.Count > 0) {
				setSpell(dt);
			} else {
				resetSpell();
			}
		}
		
		private void setSpell(DataTable dt) {
			DataRow dr = dt.Rows[0];
			lblTitle.Text = (string)dr[SplTbl.COLUMN_NAME_NAME];
			decimal spellType = (decimal)dr[SplTbl.COLUMN_NAME_TYPE];
			lblLevel.Text = mDecoder.GetSpellAttrib(
				spellType,
				(decimal)dr[SplTbl.COLUMN_NAME_LEVEL],
				((decimal)dr[SplTbl.COLUMN_NAME_REVERSIBLE]) != 0
			);
			lblSchools.Text = mDecoder.GetSchools((decimal)dr[SplTbl.COLUMN_NAME_SCHOOLS_BITFIELD], true);
			if (spellType == SpellDecoder.TYPE_CLERICS) {
				lblSpheres.Text = "Spheres: " + mDecoder.GetSpheres((decimal)dr[SplTbl.COLUMN_NAME_SPHERES_BITFIELD]);
				//lblSpheres.Text += " (" + (string)dr[SplTbl.COLUMN_NAME_SPHERES] + ")";
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
		}
		
		private void initFilter(SpellFilter filter) {
			cbUnofficial.Checked = (filter.filteredSources == null || filter.filteredSources.Length == 0);
			cbUnofficial.CheckedChanged += new System.EventHandler(cbUnofficialCheckedChanged);

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
			
			clbSchools.Items.Clear();
			string[] schools = mDecoder.GetSchoolArray(SpellDecoder.SCHOOL_ALL & 0x0effffff);
			foreach (string school in schools) {
				uint sid = mDecoder.GetSchoolIdByName(school);
				bool value = filter.IsSchool(sid);
				clbSchools.Items.Add(school, value);
			}
			clbSchools.SelectedIndexChanged += new System.EventHandler(clbCheckedChanged);
			
			clbSpheres.Items.Clear();
			string[] spheres = mDecoder.GetSphereArray(SpellDecoder.SPHERE_ALL & 0x0effffff);
			foreach (string sphere in spheres) {
				uint sid = mDecoder.GetSphereIdByName(sphere);
				bool value = filter.IsSchool(sid);
				clbSpheres.Items.Add(sphere, true);
			}
			clbSpheres.SelectedIndexChanged += new System.EventHandler(clbCheckedChanged);
		}
		
		void DgMainCellClick(object sender, DataGridViewCellEventArgs e) {
//			DataGridViewRow row = dgMain.Rows[e.RowIndex];
//			setSpell((long)row.Cells["_id"].Value);
		}
		
		void DgMainRowEnter(object sender, DataGridViewCellEventArgs e) {
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
		
		void cbUnofficialCheckedChanged(object sender, EventArgs e) {
			if (cbUnofficial.Checked) {
				mFilter.filteredSources = new long[0];
			} else {
				mFilter.filteredSources = SpellFilter.UNOFFICIAL_SOURCES;
			}
			loadData();
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
		
		void clbCheckedChanged(object sender, EventArgs e) {
			if (sender == clbSchools) {
				if (clbSchools.CheckedItems.Count == clbSchools.Items.Count) {
					mFilter.schools = SpellDecoder.SCHOOL_ALL;
				} else {
					mFilter.schools = SpellDecoder.SCHOOL_NONE;
					foreach(string school in clbSchools.CheckedItems) {
						uint sid = mDecoder.GetSchoolIdByName(school);
						mFilter.schools |= sid;
					}
				}
				loadData();
			} else if (sender == clbSpheres) {
				if (clbSpheres.CheckedItems.Count == clbSpheres.Items.Count) {
					mFilter.spheres = SpellDecoder.SPHERE_ALL;
				} else {
					mFilter.spheres = SpellDecoder.SPHERE_NONE;
					foreach(string sphere in clbSpheres.CheckedItems) {
						uint sid = mDecoder.GetSphereIdByName(sphere);
						mFilter.spheres |= sid;
					}
				}
				loadData();
			}
		}

	}
}
