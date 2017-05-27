/*
 * Created by SharpDevelop.
 * User: Ohmnibus
 * Date: 20/05/2017
 * Time: 00:13
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Grimorium.ADnD
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.TextBox tbQuery;
		private System.Windows.Forms.DataGridView dgMain;
		private System.Windows.Forms.SplitContainer splitContainer;
		private System.Windows.Forms.Label lblSaving;
		private System.Windows.Forms.Label lblArea;
		private System.Windows.Forms.Label lblCastTime;
		private System.Windows.Forms.Label lblDuration;
		private System.Windows.Forms.Label lblCompos;
		private System.Windows.Forms.Label lblRange;
		private System.Windows.Forms.Label lblSpheres;
		private System.Windows.Forms.Label lblSchools;
		private System.Windows.Forms.Label lblLevel;
		private System.Windows.Forms.Label lblTitle;
		private System.Windows.Forms.WebBrowser wbBody;
		private System.Windows.Forms.Label lblBook;
		private System.Windows.Forms.Button cmdClear;
		private System.Windows.Forms.CheckedListBox clbSchools;
		private System.Windows.Forms.GroupBox gbCompos;
		private System.Windows.Forms.CheckBox cbCompoMaterial;
		private System.Windows.Forms.CheckBox cbCompoSomatic;
		private System.Windows.Forms.CheckBox cbCompoVerbal;
		private System.Windows.Forms.GroupBox gbSpellType;
		private System.Windows.Forms.RadioButton rbSpellTypeBoth;
		private System.Windows.Forms.RadioButton rbSpellTypePriest;
		private System.Windows.Forms.RadioButton rbSpellTypeWizard;
		private System.Windows.Forms.CheckedListBox clbSpheres;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
		private System.Windows.Forms.CheckBox cbUnofficial;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.tbQuery = new System.Windows.Forms.TextBox();
			this.dgMain = new System.Windows.Forms.DataGridView();
			this.splitContainer = new System.Windows.Forms.SplitContainer();
			this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.gbSpellType = new System.Windows.Forms.GroupBox();
			this.rbSpellTypeBoth = new System.Windows.Forms.RadioButton();
			this.rbSpellTypePriest = new System.Windows.Forms.RadioButton();
			this.rbSpellTypeWizard = new System.Windows.Forms.RadioButton();
			this.clbSpheres = new System.Windows.Forms.CheckedListBox();
			this.gbCompos = new System.Windows.Forms.GroupBox();
			this.cbCompoMaterial = new System.Windows.Forms.CheckBox();
			this.cbCompoSomatic = new System.Windows.Forms.CheckBox();
			this.cbCompoVerbal = new System.Windows.Forms.CheckBox();
			this.clbSchools = new System.Windows.Forms.CheckedListBox();
			this.cmdClear = new System.Windows.Forms.Button();
			this.lblBook = new System.Windows.Forms.Label();
			this.lblSaving = new System.Windows.Forms.Label();
			this.lblArea = new System.Windows.Forms.Label();
			this.lblCastTime = new System.Windows.Forms.Label();
			this.lblDuration = new System.Windows.Forms.Label();
			this.lblCompos = new System.Windows.Forms.Label();
			this.lblRange = new System.Windows.Forms.Label();
			this.lblSpheres = new System.Windows.Forms.Label();
			this.lblSchools = new System.Windows.Forms.Label();
			this.lblLevel = new System.Windows.Forms.Label();
			this.lblTitle = new System.Windows.Forms.Label();
			this.wbBody = new System.Windows.Forms.WebBrowser();
			this.cbUnofficial = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.dgMain)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
			this.splitContainer.Panel1.SuspendLayout();
			this.splitContainer.Panel2.SuspendLayout();
			this.splitContainer.SuspendLayout();
			this.tableLayoutPanel.SuspendLayout();
			this.gbSpellType.SuspendLayout();
			this.gbCompos.SuspendLayout();
			this.SuspendLayout();
			// 
			// tbQuery
			// 
			this.tbQuery.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.tbQuery.Location = new System.Drawing.Point(3, 3);
			this.tbQuery.Name = "tbQuery";
			this.tbQuery.Size = new System.Drawing.Size(378, 20);
			this.tbQuery.TabIndex = 0;
			this.tbQuery.TextChanged += new System.EventHandler(this.TbQueryTextChanged);
			// 
			// dgMain
			// 
			this.dgMain.AllowUserToAddRows = false;
			this.dgMain.AllowUserToDeleteRows = false;
			this.dgMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.dgMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgMain.Location = new System.Drawing.Point(0, 132);
			this.dgMain.Name = "dgMain";
			this.dgMain.ReadOnly = true;
			this.dgMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgMain.Size = new System.Drawing.Size(522, 398);
			this.dgMain.TabIndex = 7;
			// 
			// splitContainer
			// 
			this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainer.Location = new System.Drawing.Point(12, 12);
			this.splitContainer.Name = "splitContainer";
			// 
			// splitContainer.Panel1
			// 
			this.splitContainer.Panel1.Controls.Add(this.cbUnofficial);
			this.splitContainer.Panel1.Controls.Add(this.tableLayoutPanel);
			this.splitContainer.Panel1.Controls.Add(this.cmdClear);
			this.splitContainer.Panel1.Controls.Add(this.dgMain);
			this.splitContainer.Panel1.Controls.Add(this.tbQuery);
			// 
			// splitContainer.Panel2
			// 
			this.splitContainer.Panel2.Controls.Add(this.lblBook);
			this.splitContainer.Panel2.Controls.Add(this.lblSaving);
			this.splitContainer.Panel2.Controls.Add(this.lblArea);
			this.splitContainer.Panel2.Controls.Add(this.lblCastTime);
			this.splitContainer.Panel2.Controls.Add(this.lblDuration);
			this.splitContainer.Panel2.Controls.Add(this.lblCompos);
			this.splitContainer.Panel2.Controls.Add(this.lblRange);
			this.splitContainer.Panel2.Controls.Add(this.lblSpheres);
			this.splitContainer.Panel2.Controls.Add(this.lblSchools);
			this.splitContainer.Panel2.Controls.Add(this.lblLevel);
			this.splitContainer.Panel2.Controls.Add(this.lblTitle);
			this.splitContainer.Panel2.Controls.Add(this.wbBody);
			this.splitContainer.Size = new System.Drawing.Size(839, 533);
			this.splitContainer.SplitterDistance = 525;
			this.splitContainer.TabIndex = 3;
			// 
			// tableLayoutPanel
			// 
			this.tableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel.ColumnCount = 4;
			this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel.Controls.Add(this.gbSpellType, 0, 0);
			this.tableLayoutPanel.Controls.Add(this.clbSpheres, 3, 0);
			this.tableLayoutPanel.Controls.Add(this.gbCompos, 1, 0);
			this.tableLayoutPanel.Controls.Add(this.clbSchools, 2, 0);
			this.tableLayoutPanel.Location = new System.Drawing.Point(3, 29);
			this.tableLayoutPanel.Name = "tableLayoutPanel";
			this.tableLayoutPanel.RowCount = 1;
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel.Size = new System.Drawing.Size(519, 100);
			this.tableLayoutPanel.TabIndex = 8;
			// 
			// gbSpellType
			// 
			this.gbSpellType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.gbSpellType.Controls.Add(this.rbSpellTypeBoth);
			this.gbSpellType.Controls.Add(this.rbSpellTypePriest);
			this.gbSpellType.Controls.Add(this.rbSpellTypeWizard);
			this.gbSpellType.Location = new System.Drawing.Point(3, 3);
			this.gbSpellType.Name = "gbSpellType";
			this.gbSpellType.Size = new System.Drawing.Size(123, 94);
			this.gbSpellType.TabIndex = 3;
			this.gbSpellType.TabStop = false;
			this.gbSpellType.Text = "Spell Type";
			// 
			// rbSpellTypeBoth
			// 
			this.rbSpellTypeBoth.AutoSize = true;
			this.rbSpellTypeBoth.Checked = true;
			this.rbSpellTypeBoth.Location = new System.Drawing.Point(6, 65);
			this.rbSpellTypeBoth.Name = "rbSpellTypeBoth";
			this.rbSpellTypeBoth.Size = new System.Drawing.Size(47, 17);
			this.rbSpellTypeBoth.TabIndex = 2;
			this.rbSpellTypeBoth.TabStop = true;
			this.rbSpellTypeBoth.Text = "Both";
			this.rbSpellTypeBoth.UseVisualStyleBackColor = true;
			// 
			// rbSpellTypePriest
			// 
			this.rbSpellTypePriest.AutoSize = true;
			this.rbSpellTypePriest.Location = new System.Drawing.Point(6, 42);
			this.rbSpellTypePriest.Name = "rbSpellTypePriest";
			this.rbSpellTypePriest.Size = new System.Drawing.Size(51, 17);
			this.rbSpellTypePriest.TabIndex = 1;
			this.rbSpellTypePriest.Text = "Priest";
			this.rbSpellTypePriest.UseVisualStyleBackColor = true;
			// 
			// rbSpellTypeWizard
			// 
			this.rbSpellTypeWizard.AutoSize = true;
			this.rbSpellTypeWizard.Location = new System.Drawing.Point(6, 19);
			this.rbSpellTypeWizard.Name = "rbSpellTypeWizard";
			this.rbSpellTypeWizard.Size = new System.Drawing.Size(58, 17);
			this.rbSpellTypeWizard.TabIndex = 0;
			this.rbSpellTypeWizard.Text = "Wizard";
			this.rbSpellTypeWizard.UseVisualStyleBackColor = true;
			// 
			// clbSpheres
			// 
			this.clbSpheres.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.clbSpheres.CheckOnClick = true;
			this.clbSpheres.FormattingEnabled = true;
			this.clbSpheres.Location = new System.Drawing.Point(390, 3);
			this.clbSpheres.Name = "clbSpheres";
			this.clbSpheres.Size = new System.Drawing.Size(126, 94);
			this.clbSpheres.Sorted = true;
			this.clbSpheres.TabIndex = 6;
			// 
			// gbCompos
			// 
			this.gbCompos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.gbCompos.Controls.Add(this.cbCompoMaterial);
			this.gbCompos.Controls.Add(this.cbCompoSomatic);
			this.gbCompos.Controls.Add(this.cbCompoVerbal);
			this.gbCompos.Location = new System.Drawing.Point(132, 3);
			this.gbCompos.Name = "gbCompos";
			this.gbCompos.Size = new System.Drawing.Size(123, 94);
			this.gbCompos.TabIndex = 4;
			this.gbCompos.TabStop = false;
			this.gbCompos.Text = "Components";
			// 
			// cbCompoMaterial
			// 
			this.cbCompoMaterial.AutoSize = true;
			this.cbCompoMaterial.Location = new System.Drawing.Point(6, 65);
			this.cbCompoMaterial.Name = "cbCompoMaterial";
			this.cbCompoMaterial.Size = new System.Drawing.Size(63, 17);
			this.cbCompoMaterial.TabIndex = 2;
			this.cbCompoMaterial.Text = "Material";
			this.cbCompoMaterial.UseVisualStyleBackColor = true;
			// 
			// cbCompoSomatic
			// 
			this.cbCompoSomatic.AutoSize = true;
			this.cbCompoSomatic.Location = new System.Drawing.Point(6, 42);
			this.cbCompoSomatic.Name = "cbCompoSomatic";
			this.cbCompoSomatic.Size = new System.Drawing.Size(64, 17);
			this.cbCompoSomatic.TabIndex = 1;
			this.cbCompoSomatic.Text = "Somatic";
			this.cbCompoSomatic.UseVisualStyleBackColor = true;
			// 
			// cbCompoVerbal
			// 
			this.cbCompoVerbal.AutoSize = true;
			this.cbCompoVerbal.Location = new System.Drawing.Point(6, 19);
			this.cbCompoVerbal.Name = "cbCompoVerbal";
			this.cbCompoVerbal.Size = new System.Drawing.Size(56, 17);
			this.cbCompoVerbal.TabIndex = 0;
			this.cbCompoVerbal.Text = "Verbal";
			this.cbCompoVerbal.UseVisualStyleBackColor = true;
			// 
			// clbSchools
			// 
			this.clbSchools.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.clbSchools.CheckOnClick = true;
			this.clbSchools.FormattingEnabled = true;
			this.clbSchools.Location = new System.Drawing.Point(261, 3);
			this.clbSchools.Name = "clbSchools";
			this.clbSchools.Size = new System.Drawing.Size(123, 94);
			this.clbSchools.Sorted = true;
			this.clbSchools.TabIndex = 5;
			// 
			// cmdClear
			// 
			this.cmdClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdClear.Location = new System.Drawing.Point(387, 3);
			this.cmdClear.Name = "cmdClear";
			this.cmdClear.Size = new System.Drawing.Size(26, 20);
			this.cmdClear.TabIndex = 1;
			this.cmdClear.Text = "X";
			this.cmdClear.UseVisualStyleBackColor = true;
			this.cmdClear.Click += new System.EventHandler(this.CmdClearClick);
			// 
			// lblBook
			// 
			this.lblBook.AutoSize = true;
			this.lblBook.Location = new System.Drawing.Point(3, 140);
			this.lblBook.Name = "lblBook";
			this.lblBook.Size = new System.Drawing.Size(102, 13);
			this.lblBook.TabIndex = 11;
			this.lblBook.Text = "-Player\'s Handbook-";
			// 
			// lblSaving
			// 
			this.lblSaving.AutoSize = true;
			this.lblSaving.Location = new System.Drawing.Point(3, 127);
			this.lblSaving.Name = "lblSaving";
			this.lblSaving.Size = new System.Drawing.Size(69, 13);
			this.lblSaving.TabIndex = 10;
			this.lblSaving.Text = "Saving throw";
			// 
			// lblArea
			// 
			this.lblArea.AutoSize = true;
			this.lblArea.Location = new System.Drawing.Point(3, 114);
			this.lblArea.Name = "lblArea";
			this.lblArea.Size = new System.Drawing.Size(72, 13);
			this.lblArea.TabIndex = 9;
			this.lblArea.Text = "Area of Effect";
			// 
			// lblCastTime
			// 
			this.lblCastTime.AutoSize = true;
			this.lblCastTime.Location = new System.Drawing.Point(3, 101);
			this.lblCastTime.Name = "lblCastTime";
			this.lblCastTime.Size = new System.Drawing.Size(68, 13);
			this.lblCastTime.TabIndex = 8;
			this.lblCastTime.Text = "Casting Time";
			// 
			// lblDuration
			// 
			this.lblDuration.AutoSize = true;
			this.lblDuration.Location = new System.Drawing.Point(3, 88);
			this.lblDuration.Name = "lblDuration";
			this.lblDuration.Size = new System.Drawing.Size(47, 13);
			this.lblDuration.TabIndex = 7;
			this.lblDuration.Text = "Duration";
			// 
			// lblCompos
			// 
			this.lblCompos.AutoSize = true;
			this.lblCompos.Location = new System.Drawing.Point(3, 75);
			this.lblCompos.Name = "lblCompos";
			this.lblCompos.Size = new System.Drawing.Size(96, 13);
			this.lblCompos.TabIndex = 6;
			this.lblCompos.Text = "Component: V,S,M";
			// 
			// lblRange
			// 
			this.lblRange.AutoSize = true;
			this.lblRange.Location = new System.Drawing.Point(3, 62);
			this.lblRange.Name = "lblRange";
			this.lblRange.Size = new System.Drawing.Size(59, 13);
			this.lblRange.TabIndex = 5;
			this.lblRange.Text = "Range: x ft";
			// 
			// lblSpheres
			// 
			this.lblSpheres.AutoSize = true;
			this.lblSpheres.Location = new System.Drawing.Point(3, 49);
			this.lblSpheres.Name = "lblSpheres";
			this.lblSpheres.Size = new System.Drawing.Size(46, 13);
			this.lblSpheres.TabIndex = 4;
			this.lblSpheres.Text = "Spheres";
			// 
			// lblSchools
			// 
			this.lblSchools.AutoSize = true;
			this.lblSchools.Location = new System.Drawing.Point(3, 36);
			this.lblSchools.Name = "lblSchools";
			this.lblSchools.Size = new System.Drawing.Size(51, 13);
			this.lblSchools.TabIndex = 3;
			this.lblSchools.Text = "(Schools)";
			// 
			// lblLevel
			// 
			this.lblLevel.AutoSize = true;
			this.lblLevel.Location = new System.Drawing.Point(3, 23);
			this.lblLevel.Name = "lblLevel";
			this.lblLevel.Size = new System.Drawing.Size(89, 13);
			this.lblLevel.TabIndex = 2;
			this.lblLevel.Text = "Level, Reversible";
			// 
			// lblTitle
			// 
			this.lblTitle.AutoEllipsis = true;
			this.lblTitle.AutoSize = true;
			this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTitle.Location = new System.Drawing.Point(3, 6);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(40, 17);
			this.lblTitle.TabIndex = 1;
			this.lblTitle.Text = "Title";
			// 
			// wbBody
			// 
			this.wbBody.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.wbBody.Location = new System.Drawing.Point(3, 156);
			this.wbBody.MinimumSize = new System.Drawing.Size(20, 20);
			this.wbBody.Name = "wbBody";
			this.wbBody.Size = new System.Drawing.Size(304, 374);
			this.wbBody.TabIndex = 0;
			// 
			// cbUnofficial
			// 
			this.cbUnofficial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cbUnofficial.AutoSize = true;
			this.cbUnofficial.Location = new System.Drawing.Point(419, 5);
			this.cbUnofficial.Name = "cbUnofficial";
			this.cbUnofficial.Size = new System.Drawing.Size(100, 17);
			this.cbUnofficial.TabIndex = 2;
			this.cbUnofficial.Text = "Show Unofficial";
			this.cbUnofficial.UseVisualStyleBackColor = true;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(863, 557);
			this.Controls.Add(this.splitContainer);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainForm";
			this.Text = "Grimorium AD&D";
			((System.ComponentModel.ISupportInitialize)(this.dgMain)).EndInit();
			this.splitContainer.Panel1.ResumeLayout(false);
			this.splitContainer.Panel1.PerformLayout();
			this.splitContainer.Panel2.ResumeLayout(false);
			this.splitContainer.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
			this.splitContainer.ResumeLayout(false);
			this.tableLayoutPanel.ResumeLayout(false);
			this.gbSpellType.ResumeLayout(false);
			this.gbSpellType.PerformLayout();
			this.gbCompos.ResumeLayout(false);
			this.gbCompos.PerformLayout();
			this.ResumeLayout(false);

		}
	}
}
