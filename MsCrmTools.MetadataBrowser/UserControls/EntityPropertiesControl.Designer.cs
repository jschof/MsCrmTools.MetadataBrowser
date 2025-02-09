﻿using System;

namespace MsCrmTools.MetadataBrowser.UserControls
{
    partial class EntityPropertiesControl
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EntityPropertiesControl));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.entityPropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.entityToolStrip = new System.Windows.Forms.ToolStrip();
            this.tsbHideEntityPanel = new System.Windows.Forms.ToolStripButton();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.attributesSplitContainer = new System.Windows.Forms.SplitContainer();
            this.attributeListView = new System.Windows.Forms.ListView();
            this.cmsAttributes = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiAttributesCopyLogicalName = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAttributesCopySchemaName = new System.Windows.Forms.ToolStripMenuItem();
            this.copyNameForWebApiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scMetadata = new System.Windows.Forms.SplitContainer();
            this.pgOptionSet = new System.Windows.Forms.PropertyGrid();
            this.cmsOptionSet = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyValueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyLabelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.attributePropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.attributeToolStrip = new System.Windows.Forms.ToolStrip();
            this.tsbHideAttributePanel = new System.Windows.Forms.ToolStripButton();
            this.tsbAttributeColumns = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tslSearchAttr = new System.Windows.Forms.ToolStripLabel();
            this.tstxtSearchContact = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbOpenInWebApp = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbExportAttributesExcel = new System.Windows.Forms.ToolStripButton();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.keySplitContainer = new System.Windows.Forms.SplitContainer();
            this.keyListView = new System.Windows.Forms.ListView();
            this.keyPropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.keysToolStrip = new System.Windows.Forms.ToolStrip();
            this.tsbHideKeyPanel = new System.Windows.Forms.ToolStripButton();
            this.tsbKeyColumns = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbExportKeysExcel = new System.Windows.Forms.ToolStripButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.oneToManySplitContainer = new System.Windows.Forms.SplitContainer();
            this.OneToManyListView = new System.Windows.Forms.ListView();
            this.cmsRelationships = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiRelationshipCopySchemaName = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRelationshipCopyReferencedNavigationProperty = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRelationshipCopyReferencingNavigationProperty = new System.Windows.Forms.ToolStripMenuItem();
            this.OneToManyPropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.manyToOneToolStrip = new System.Windows.Forms.ToolStrip();
            this.tsbHideOneToManyPanel = new System.Windows.Forms.ToolStripButton();
            this.tsbOneToManyColumns = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tstxtSearchOtm = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbExportOmRelsExcel = new System.Windows.Forms.ToolStripButton();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.manyToOneSplitContainer = new System.Windows.Forms.SplitContainer();
            this.manyToOneListView = new System.Windows.Forms.ListView();
            this.manyToOnePropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.tsbHideManyToOnePanel = new System.Windows.Forms.ToolStripButton();
            this.tsbManyToOneColumns = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.tstxtSearchMtO = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbExportMoRelsExcel = new System.Windows.Forms.ToolStripButton();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.manyToManySplitContainer = new System.Windows.Forms.SplitContainer();
            this.manyToManyListView = new System.Windows.Forms.ListView();
            this.cmsNNRelationship = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiRelNNCopySchemaName = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRelNNCopyEntity1NavigationProperty = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRelNNCopyEntity2NavigationProperty = new System.Windows.Forms.ToolStripMenuItem();
            this.manyToManyPropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.manyToManyToolStrip = new System.Windows.Forms.ToolStrip();
            this.tsbHideManyToManyPanel = new System.Windows.Forms.ToolStripButton();
            this.tsbManyToManyColumns = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.tstxtSearchM2M = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbExportMmRelsExcel = new System.Windows.Forms.ToolStripButton();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.privilegeSplitContainer = new System.Windows.Forms.SplitContainer();
            this.privilegeListView = new System.Windows.Forms.ListView();
            this.privilegePropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.privilegeToolStrip = new System.Windows.Forms.ToolStrip();
            this.tsbHidePrivilegePanel = new System.Windows.Forms.ToolStripButton();
            this.tsbPrivilegeColumns = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbExportPrivExcel = new System.Windows.Forms.ToolStripButton();
            this.tpSolutions = new System.Windows.Forms.TabPage();
            this.lvSolutions = new System.Windows.Forms.ListView();
            this.chSolutionFriendlyName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSolutionUniqueName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSolutionVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSolutionType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSolutionEntity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSolutionBehavior = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbExportExcelSolutions = new System.Windows.Forms.ToolStripButton();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.entityToolStrip.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.attributesSplitContainer)).BeginInit();
            this.attributesSplitContainer.Panel1.SuspendLayout();
            this.attributesSplitContainer.Panel2.SuspendLayout();
            this.attributesSplitContainer.SuspendLayout();
            this.cmsAttributes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scMetadata)).BeginInit();
            this.scMetadata.Panel1.SuspendLayout();
            this.scMetadata.Panel2.SuspendLayout();
            this.scMetadata.SuspendLayout();
            this.cmsOptionSet.SuspendLayout();
            this.attributeToolStrip.SuspendLayout();
            this.tabPage7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.keySplitContainer)).BeginInit();
            this.keySplitContainer.Panel1.SuspendLayout();
            this.keySplitContainer.Panel2.SuspendLayout();
            this.keySplitContainer.SuspendLayout();
            this.keysToolStrip.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.oneToManySplitContainer)).BeginInit();
            this.oneToManySplitContainer.Panel1.SuspendLayout();
            this.oneToManySplitContainer.Panel2.SuspendLayout();
            this.oneToManySplitContainer.SuspendLayout();
            this.cmsRelationships.SuspendLayout();
            this.manyToOneToolStrip.SuspendLayout();
            this.tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.manyToOneSplitContainer)).BeginInit();
            this.manyToOneSplitContainer.Panel1.SuspendLayout();
            this.manyToOneSplitContainer.Panel2.SuspendLayout();
            this.manyToOneSplitContainer.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.manyToManySplitContainer)).BeginInit();
            this.manyToManySplitContainer.Panel1.SuspendLayout();
            this.manyToManySplitContainer.Panel2.SuspendLayout();
            this.manyToManySplitContainer.SuspendLayout();
            this.cmsNNRelationship.SuspendLayout();
            this.manyToManyToolStrip.SuspendLayout();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.privilegeSplitContainer)).BeginInit();
            this.privilegeSplitContainer.Panel1.SuspendLayout();
            this.privilegeSplitContainer.Panel2.SuspendLayout();
            this.privilegeSplitContainer.SuspendLayout();
            this.privilegeToolStrip.SuspendLayout();
            this.tpSolutions.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tpSolutions);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(861, 547);
            this.tabControl1.TabIndex = 4;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.TabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.entityPropertyGrid);
            this.tabPage1.Controls.Add(this.entityToolStrip);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage1.Size = new System.Drawing.Size(853, 521);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Table";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // entityPropertyGrid
            // 
            this.entityPropertyGrid.CommandsDisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))));
            this.entityPropertyGrid.CommandsForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))));
            this.entityPropertyGrid.DisabledItemForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))));
            this.entityPropertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.entityPropertyGrid.Location = new System.Drawing.Point(2, 27);
            this.entityPropertyGrid.Margin = new System.Windows.Forms.Padding(2);
            this.entityPropertyGrid.Name = "entityPropertyGrid";
            this.entityPropertyGrid.Size = new System.Drawing.Size(849, 492);
            this.entityPropertyGrid.TabIndex = 5;
            this.entityPropertyGrid.ViewForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))));
            // 
            // entityToolStrip
            // 
            this.entityToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbHideEntityPanel});
            this.entityToolStrip.Location = new System.Drawing.Point(2, 2);
            this.entityToolStrip.Name = "entityToolStrip";
            this.entityToolStrip.Size = new System.Drawing.Size(849, 25);
            this.entityToolStrip.TabIndex = 4;
            this.entityToolStrip.Text = "toolStrip2";
            // 
            // tsbHideEntityPanel
            // 
            this.tsbHideEntityPanel.Image = ((System.Drawing.Image)(resources.GetObject("tsbHideEntityPanel.Image")));
            this.tsbHideEntityPanel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbHideEntityPanel.Name = "tsbHideEntityPanel";
            this.tsbHideEntityPanel.Size = new System.Drawing.Size(56, 22);
            this.tsbHideEntityPanel.Text = "Close";
            this.tsbHideEntityPanel.Click += new System.EventHandler(this.tsbHidePanel_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.attributesSplitContainer);
            this.tabPage4.Controls.Add(this.attributeToolStrip);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage4.Size = new System.Drawing.Size(853, 521);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Columns";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // attributesSplitContainer
            // 
            this.attributesSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.attributesSplitContainer.Location = new System.Drawing.Point(2, 27);
            this.attributesSplitContainer.Margin = new System.Windows.Forms.Padding(2);
            this.attributesSplitContainer.Name = "attributesSplitContainer";
            // 
            // attributesSplitContainer.Panel1
            // 
            this.attributesSplitContainer.Panel1.Controls.Add(this.attributeListView);
            // 
            // attributesSplitContainer.Panel2
            // 
            this.attributesSplitContainer.Panel2.Controls.Add(this.scMetadata);
            this.attributesSplitContainer.Size = new System.Drawing.Size(849, 492);
            this.attributesSplitContainer.SplitterDistance = 371;
            this.attributesSplitContainer.SplitterWidth = 3;
            this.attributesSplitContainer.TabIndex = 3;
            // 
            // attributeListView
            // 
            this.attributeListView.ContextMenuStrip = this.cmsAttributes;
            this.attributeListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.attributeListView.FullRowSelect = true;
            this.attributeListView.GridLines = true;
            this.attributeListView.HideSelection = false;
            this.attributeListView.Location = new System.Drawing.Point(0, 0);
            this.attributeListView.Margin = new System.Windows.Forms.Padding(2);
            this.attributeListView.Name = "attributeListView";
            this.attributeListView.Size = new System.Drawing.Size(371, 492);
            this.attributeListView.TabIndex = 1;
            this.attributeListView.UseCompatibleStateImageBehavior = false;
            this.attributeListView.View = System.Windows.Forms.View.Details;
            this.attributeListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView_ColumnClick);
            this.attributeListView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.attributeListView_ItemSelectionChanged);
            this.attributeListView.DoubleClick += new System.EventHandler(this.attributeListView_DoubleClick);
            // 
            // cmsAttributes
            // 
            this.cmsAttributes.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.cmsAttributes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAttributesCopyLogicalName,
            this.tsmiAttributesCopySchemaName,
            this.copyNameForWebApiToolStripMenuItem});
            this.cmsAttributes.Name = "cmsAttributes";
            this.cmsAttributes.Size = new System.Drawing.Size(198, 70);
            this.cmsAttributes.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.cmsAttributes_ItemClicked);
            // 
            // tsmiAttributesCopyLogicalName
            // 
            this.tsmiAttributesCopyLogicalName.Name = "tsmiAttributesCopyLogicalName";
            this.tsmiAttributesCopyLogicalName.Size = new System.Drawing.Size(197, 22);
            this.tsmiAttributesCopyLogicalName.Text = "Copy Logical name";
            // 
            // tsmiAttributesCopySchemaName
            // 
            this.tsmiAttributesCopySchemaName.Name = "tsmiAttributesCopySchemaName";
            this.tsmiAttributesCopySchemaName.Size = new System.Drawing.Size(197, 22);
            this.tsmiAttributesCopySchemaName.Text = "Copy Schema name";
            // 
            // copyNameForWebApiToolStripMenuItem
            // 
            this.copyNameForWebApiToolStripMenuItem.Name = "copyNameForWebApiToolStripMenuItem";
            this.copyNameForWebApiToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.copyNameForWebApiToolStripMenuItem.Text = "Copy name for web api";
            // 
            // scMetadata
            // 
            this.scMetadata.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMetadata.Location = new System.Drawing.Point(0, 0);
            this.scMetadata.Margin = new System.Windows.Forms.Padding(2);
            this.scMetadata.Name = "scMetadata";
            this.scMetadata.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scMetadata.Panel1
            // 
            this.scMetadata.Panel1.Controls.Add(this.pgOptionSet);
            this.scMetadata.Panel1Collapsed = true;
            // 
            // scMetadata.Panel2
            // 
            this.scMetadata.Panel2.Controls.Add(this.attributePropertyGrid);
            this.scMetadata.Size = new System.Drawing.Size(475, 492);
            this.scMetadata.SplitterWidth = 3;
            this.scMetadata.TabIndex = 3;
            // 
            // pgOptionSet
            // 
            this.pgOptionSet.ContextMenuStrip = this.cmsOptionSet;
            this.pgOptionSet.DisabledItemForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))));
            this.pgOptionSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgOptionSet.HelpVisible = false;
            this.pgOptionSet.Location = new System.Drawing.Point(0, 0);
            this.pgOptionSet.Margin = new System.Windows.Forms.Padding(2);
            this.pgOptionSet.Name = "pgOptionSet";
            this.pgOptionSet.Size = new System.Drawing.Size(150, 50);
            this.pgOptionSet.TabIndex = 1;
            this.pgOptionSet.ToolbarVisible = false;
            this.pgOptionSet.ViewForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))));
            // 
            // cmsOptionSet
            // 
            this.cmsOptionSet.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.cmsOptionSet.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyValueToolStripMenuItem,
            this.copyLabelToolStripMenuItem});
            this.cmsOptionSet.Name = "cmsOptionSet";
            this.cmsOptionSet.Size = new System.Drawing.Size(134, 48);
            this.cmsOptionSet.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.cmsOptionSet_ItemClicked);
            // 
            // copyValueToolStripMenuItem
            // 
            this.copyValueToolStripMenuItem.Name = "copyValueToolStripMenuItem";
            this.copyValueToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.copyValueToolStripMenuItem.Text = "Copy value";
            // 
            // copyLabelToolStripMenuItem
            // 
            this.copyLabelToolStripMenuItem.Name = "copyLabelToolStripMenuItem";
            this.copyLabelToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.copyLabelToolStripMenuItem.Text = "Copy label";
            // 
            // attributePropertyGrid
            // 
            this.attributePropertyGrid.DisabledItemForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))));
            this.attributePropertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.attributePropertyGrid.Location = new System.Drawing.Point(0, 0);
            this.attributePropertyGrid.Margin = new System.Windows.Forms.Padding(2);
            this.attributePropertyGrid.Name = "attributePropertyGrid";
            this.attributePropertyGrid.Size = new System.Drawing.Size(475, 492);
            this.attributePropertyGrid.TabIndex = 2;
            this.attributePropertyGrid.ViewForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))));
            // 
            // attributeToolStrip
            // 
            this.attributeToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbHideAttributePanel,
            this.tsbAttributeColumns,
            this.toolStripSeparator1,
            this.tslSearchAttr,
            this.tstxtSearchContact,
            this.toolStripSeparator2,
            this.tsbOpenInWebApp,
            this.toolStripSeparator3,
            this.tsbExportAttributesExcel});
            this.attributeToolStrip.Location = new System.Drawing.Point(2, 2);
            this.attributeToolStrip.Name = "attributeToolStrip";
            this.attributeToolStrip.Size = new System.Drawing.Size(849, 25);
            this.attributeToolStrip.TabIndex = 2;
            this.attributeToolStrip.Text = "toolStrip3";
            // 
            // tsbHideAttributePanel
            // 
            this.tsbHideAttributePanel.Image = ((System.Drawing.Image)(resources.GetObject("tsbHideAttributePanel.Image")));
            this.tsbHideAttributePanel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbHideAttributePanel.Name = "tsbHideAttributePanel";
            this.tsbHideAttributePanel.Size = new System.Drawing.Size(84, 22);
            this.tsbHideAttributePanel.Text = "Hide panel";
            this.tsbHideAttributePanel.Visible = false;
            this.tsbHideAttributePanel.Click += new System.EventHandler(this.tsbHidePanel_Click);
            // 
            // tsbAttributeColumns
            // 
            this.tsbAttributeColumns.Image = ((System.Drawing.Image)(resources.GetObject("tsbAttributeColumns.Image")));
            this.tsbAttributeColumns.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAttributeColumns.Name = "tsbAttributeColumns";
            this.tsbAttributeColumns.Size = new System.Drawing.Size(84, 22);
            this.tsbAttributeColumns.Text = "Columns...";
            this.tsbAttributeColumns.Click += new System.EventHandler(this.tsbColumns_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tslSearchAttr
            // 
            this.tslSearchAttr.Name = "tslSearchAttr";
            this.tslSearchAttr.Size = new System.Drawing.Size(42, 22);
            this.tslSearchAttr.Text = "Search";
            // 
            // tstxtSearchContact
            // 
            this.tstxtSearchContact.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tstxtSearchContact.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.tstxtSearchContact.Name = "tstxtSearchContact";
            this.tstxtSearchContact.Size = new System.Drawing.Size(200, 25);
            this.tstxtSearchContact.Text = "Logical/Display Name or GUID";
            this.tstxtSearchContact.Enter += new System.EventHandler(this.tstxtSearch_Enter);
            this.tstxtSearchContact.TextChanged += new System.EventHandler(this.tstxtSearch_TextChanged);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbOpenInWebApp
            // 
            this.tsbOpenInWebApp.Image = ((System.Drawing.Image)(resources.GetObject("tsbOpenInWebApp.Image")));
            this.tsbOpenInWebApp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOpenInWebApp.Name = "tsbOpenInWebApp";
            this.tsbOpenInWebApp.Size = new System.Drawing.Size(117, 22);
            this.tsbOpenInWebApp.Text = "Open in web app";
            this.tsbOpenInWebApp.Click += new System.EventHandler(this.tsbOpenInWebApp_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbExportAttributesExcel
            // 
            this.tsbExportAttributesExcel.Image = ((System.Drawing.Image)(resources.GetObject("tsbExportAttributesExcel.Image")));
            this.tsbExportAttributesExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExportAttributesExcel.Name = "tsbExportAttributesExcel";
            this.tsbExportAttributesExcel.Size = new System.Drawing.Size(105, 22);
            this.tsbExportAttributesExcel.Text = "Export to Excel";
            this.tsbExportAttributesExcel.Click += new System.EventHandler(this.tsbExportAttributesExcel_Click);
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.keySplitContainer);
            this.tabPage7.Controls.Add(this.keysToolStrip);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage7.Size = new System.Drawing.Size(853, 521);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Text = "Keys";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // keySplitContainer
            // 
            this.keySplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.keySplitContainer.Location = new System.Drawing.Point(2, 27);
            this.keySplitContainer.Margin = new System.Windows.Forms.Padding(2);
            this.keySplitContainer.Name = "keySplitContainer";
            // 
            // keySplitContainer.Panel1
            // 
            this.keySplitContainer.Panel1.Controls.Add(this.keyListView);
            // 
            // keySplitContainer.Panel2
            // 
            this.keySplitContainer.Panel2.Controls.Add(this.keyPropertyGrid);
            this.keySplitContainer.Size = new System.Drawing.Size(849, 492);
            this.keySplitContainer.SplitterDistance = 281;
            this.keySplitContainer.SplitterWidth = 3;
            this.keySplitContainer.TabIndex = 5;
            // 
            // keyListView
            // 
            this.keyListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.keyListView.FullRowSelect = true;
            this.keyListView.GridLines = true;
            this.keyListView.HideSelection = false;
            this.keyListView.Location = new System.Drawing.Point(0, 0);
            this.keyListView.Margin = new System.Windows.Forms.Padding(2);
            this.keyListView.Name = "keyListView";
            this.keyListView.Size = new System.Drawing.Size(281, 492);
            this.keyListView.TabIndex = 2;
            this.keyListView.UseCompatibleStateImageBehavior = false;
            this.keyListView.View = System.Windows.Forms.View.Details;
            this.keyListView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.keyListView_ItemSelectionChanged);
            this.keyListView.DoubleClick += new System.EventHandler(this.keyListView_DoubleClick);
            // 
            // keyPropertyGrid
            // 
            this.keyPropertyGrid.DisabledItemForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))));
            this.keyPropertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.keyPropertyGrid.Location = new System.Drawing.Point(0, 0);
            this.keyPropertyGrid.Margin = new System.Windows.Forms.Padding(2);
            this.keyPropertyGrid.Name = "keyPropertyGrid";
            this.keyPropertyGrid.Size = new System.Drawing.Size(565, 492);
            this.keyPropertyGrid.TabIndex = 1;
            this.keyPropertyGrid.ViewForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))));
            // 
            // keysToolStrip
            // 
            this.keysToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbHideKeyPanel,
            this.tsbKeyColumns,
            this.toolStripSeparator4,
            this.tsbExportKeysExcel});
            this.keysToolStrip.Location = new System.Drawing.Point(2, 2);
            this.keysToolStrip.Name = "keysToolStrip";
            this.keysToolStrip.Size = new System.Drawing.Size(849, 25);
            this.keysToolStrip.TabIndex = 4;
            this.keysToolStrip.Text = "toolStrip3";
            // 
            // tsbHideKeyPanel
            // 
            this.tsbHideKeyPanel.Image = ((System.Drawing.Image)(resources.GetObject("tsbHideKeyPanel.Image")));
            this.tsbHideKeyPanel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbHideKeyPanel.Name = "tsbHideKeyPanel";
            this.tsbHideKeyPanel.Size = new System.Drawing.Size(84, 22);
            this.tsbHideKeyPanel.Text = "Hide panel";
            this.tsbHideKeyPanel.Visible = false;
            this.tsbHideKeyPanel.Click += new System.EventHandler(this.tsbHidePanel_Click);
            // 
            // tsbKeyColumns
            // 
            this.tsbKeyColumns.Image = ((System.Drawing.Image)(resources.GetObject("tsbKeyColumns.Image")));
            this.tsbKeyColumns.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbKeyColumns.Name = "tsbKeyColumns";
            this.tsbKeyColumns.Size = new System.Drawing.Size(84, 22);
            this.tsbKeyColumns.Text = "Columns...";
            this.tsbKeyColumns.Click += new System.EventHandler(this.tsbColumns_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbExportKeysExcel
            // 
            this.tsbExportKeysExcel.Image = ((System.Drawing.Image)(resources.GetObject("tsbExportKeysExcel.Image")));
            this.tsbExportKeysExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExportKeysExcel.Name = "tsbExportKeysExcel";
            this.tsbExportKeysExcel.Size = new System.Drawing.Size(105, 22);
            this.tsbExportKeysExcel.Text = "Export to Excel";
            this.tsbExportKeysExcel.Click += new System.EventHandler(this.tsbExportKeysExcel_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.oneToManySplitContainer);
            this.tabPage2.Controls.Add(this.manyToOneToolStrip);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage2.Size = new System.Drawing.Size(853, 521);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "OneToManyRelationships";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // oneToManySplitContainer
            // 
            this.oneToManySplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.oneToManySplitContainer.Location = new System.Drawing.Point(2, 27);
            this.oneToManySplitContainer.Margin = new System.Windows.Forms.Padding(2);
            this.oneToManySplitContainer.Name = "oneToManySplitContainer";
            // 
            // oneToManySplitContainer.Panel1
            // 
            this.oneToManySplitContainer.Panel1.Controls.Add(this.OneToManyListView);
            // 
            // oneToManySplitContainer.Panel2
            // 
            this.oneToManySplitContainer.Panel2.Controls.Add(this.OneToManyPropertyGrid);
            this.oneToManySplitContainer.Size = new System.Drawing.Size(849, 492);
            this.oneToManySplitContainer.SplitterDistance = 277;
            this.oneToManySplitContainer.SplitterWidth = 3;
            this.oneToManySplitContainer.TabIndex = 4;
            // 
            // OneToManyListView
            // 
            this.OneToManyListView.ContextMenuStrip = this.cmsRelationships;
            this.OneToManyListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OneToManyListView.FullRowSelect = true;
            this.OneToManyListView.GridLines = true;
            this.OneToManyListView.HideSelection = false;
            this.OneToManyListView.Location = new System.Drawing.Point(0, 0);
            this.OneToManyListView.Margin = new System.Windows.Forms.Padding(2);
            this.OneToManyListView.Name = "OneToManyListView";
            this.OneToManyListView.Size = new System.Drawing.Size(277, 492);
            this.OneToManyListView.TabIndex = 1;
            this.OneToManyListView.UseCompatibleStateImageBehavior = false;
            this.OneToManyListView.View = System.Windows.Forms.View.Details;
            this.OneToManyListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView_ColumnClick);
            this.OneToManyListView.SelectedIndexChanged += new System.EventHandler(this.OneToManyListView_SelectedIndexChanged);
            this.OneToManyListView.DoubleClick += new System.EventHandler(this.OneToManyListView_DoubleClick);
            // 
            // cmsRelationships
            // 
            this.cmsRelationships.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.cmsRelationships.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiRelationshipCopySchemaName,
            this.tsmiRelationshipCopyReferencedNavigationProperty,
            this.tsmiRelationshipCopyReferencingNavigationProperty});
            this.cmsRelationships.Name = "cmsAttributes";
            this.cmsRelationships.Size = new System.Drawing.Size(326, 70);
            this.cmsRelationships.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.cmsRelationships_ItemClicked);
            // 
            // tsmiRelationshipCopySchemaName
            // 
            this.tsmiRelationshipCopySchemaName.Name = "tsmiRelationshipCopySchemaName";
            this.tsmiRelationshipCopySchemaName.Size = new System.Drawing.Size(325, 22);
            this.tsmiRelationshipCopySchemaName.Text = "Copy Schema name";
            // 
            // tsmiRelationshipCopyReferencedNavigationProperty
            // 
            this.tsmiRelationshipCopyReferencedNavigationProperty.Name = "tsmiRelationshipCopyReferencedNavigationProperty";
            this.tsmiRelationshipCopyReferencedNavigationProperty.Size = new System.Drawing.Size(325, 22);
            this.tsmiRelationshipCopyReferencedNavigationProperty.Text = "Copy Referenced navigation property (children)";
            // 
            // tsmiRelationshipCopyReferencingNavigationProperty
            // 
            this.tsmiRelationshipCopyReferencingNavigationProperty.Name = "tsmiRelationshipCopyReferencingNavigationProperty";
            this.tsmiRelationshipCopyReferencingNavigationProperty.Size = new System.Drawing.Size(325, 22);
            this.tsmiRelationshipCopyReferencingNavigationProperty.Text = "Copy Referencing navigation property (parent)";
            // 
            // OneToManyPropertyGrid
            // 
            this.OneToManyPropertyGrid.DisabledItemForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))));
            this.OneToManyPropertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OneToManyPropertyGrid.Location = new System.Drawing.Point(0, 0);
            this.OneToManyPropertyGrid.Margin = new System.Windows.Forms.Padding(2);
            this.OneToManyPropertyGrid.Name = "OneToManyPropertyGrid";
            this.OneToManyPropertyGrid.Size = new System.Drawing.Size(569, 492);
            this.OneToManyPropertyGrid.TabIndex = 0;
            this.OneToManyPropertyGrid.ViewForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))));
            // 
            // manyToOneToolStrip
            // 
            this.manyToOneToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbHideOneToManyPanel,
            this.tsbOneToManyColumns,
            this.toolStripSeparator10,
            this.toolStripLabel1,
            this.tstxtSearchOtm,
            this.toolStripSeparator5,
            this.tsbExportOmRelsExcel});
            this.manyToOneToolStrip.Location = new System.Drawing.Point(2, 2);
            this.manyToOneToolStrip.Name = "manyToOneToolStrip";
            this.manyToOneToolStrip.Size = new System.Drawing.Size(849, 25);
            this.manyToOneToolStrip.TabIndex = 3;
            this.manyToOneToolStrip.Text = "toolStrip3";
            // 
            // tsbHideOneToManyPanel
            // 
            this.tsbHideOneToManyPanel.Image = ((System.Drawing.Image)(resources.GetObject("tsbHideOneToManyPanel.Image")));
            this.tsbHideOneToManyPanel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbHideOneToManyPanel.Name = "tsbHideOneToManyPanel";
            this.tsbHideOneToManyPanel.Size = new System.Drawing.Size(84, 22);
            this.tsbHideOneToManyPanel.Text = "Hide panel";
            this.tsbHideOneToManyPanel.Visible = false;
            this.tsbHideOneToManyPanel.Click += new System.EventHandler(this.tsbHidePanel_Click);
            // 
            // tsbOneToManyColumns
            // 
            this.tsbOneToManyColumns.Image = ((System.Drawing.Image)(resources.GetObject("tsbOneToManyColumns.Image")));
            this.tsbOneToManyColumns.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOneToManyColumns.Name = "tsbOneToManyColumns";
            this.tsbOneToManyColumns.Size = new System.Drawing.Size(84, 22);
            this.tsbOneToManyColumns.Text = "Columns...";
            this.tsbOneToManyColumns.Click += new System.EventHandler(this.tsbColumns_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(42, 22);
            this.toolStripLabel1.Text = "Search";
            // 
            // tstxtSearchOtm
            // 
            this.tstxtSearchOtm.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tstxtSearchOtm.Name = "tstxtSearchOtm";
            this.tstxtSearchOtm.Size = new System.Drawing.Size(200, 25);
            this.tstxtSearchOtm.TextChanged += new System.EventHandler(this.tstxtSearch_TextChanged);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbExportOmRelsExcel
            // 
            this.tsbExportOmRelsExcel.Image = ((System.Drawing.Image)(resources.GetObject("tsbExportOmRelsExcel.Image")));
            this.tsbExportOmRelsExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExportOmRelsExcel.Name = "tsbExportOmRelsExcel";
            this.tsbExportOmRelsExcel.Size = new System.Drawing.Size(105, 22);
            this.tsbExportOmRelsExcel.Text = "Export to Excel";
            this.tsbExportOmRelsExcel.Click += new System.EventHandler(this.tsbExportOmRelsExcel_Click);
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.manyToOneSplitContainer);
            this.tabPage6.Controls.Add(this.toolStrip2);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage6.Size = new System.Drawing.Size(853, 521);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "ManyToOneRelationships";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // manyToOneSplitContainer
            // 
            this.manyToOneSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.manyToOneSplitContainer.Location = new System.Drawing.Point(2, 27);
            this.manyToOneSplitContainer.Margin = new System.Windows.Forms.Padding(2);
            this.manyToOneSplitContainer.Name = "manyToOneSplitContainer";
            // 
            // manyToOneSplitContainer.Panel1
            // 
            this.manyToOneSplitContainer.Panel1.Controls.Add(this.manyToOneListView);
            // 
            // manyToOneSplitContainer.Panel2
            // 
            this.manyToOneSplitContainer.Panel2.Controls.Add(this.manyToOnePropertyGrid);
            this.manyToOneSplitContainer.Size = new System.Drawing.Size(849, 492);
            this.manyToOneSplitContainer.SplitterDistance = 277;
            this.manyToOneSplitContainer.SplitterWidth = 3;
            this.manyToOneSplitContainer.TabIndex = 6;
            // 
            // manyToOneListView
            // 
            this.manyToOneListView.ContextMenuStrip = this.cmsRelationships;
            this.manyToOneListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.manyToOneListView.FullRowSelect = true;
            this.manyToOneListView.GridLines = true;
            this.manyToOneListView.HideSelection = false;
            this.manyToOneListView.Location = new System.Drawing.Point(0, 0);
            this.manyToOneListView.Margin = new System.Windows.Forms.Padding(2);
            this.manyToOneListView.Name = "manyToOneListView";
            this.manyToOneListView.Size = new System.Drawing.Size(277, 492);
            this.manyToOneListView.TabIndex = 1;
            this.manyToOneListView.UseCompatibleStateImageBehavior = false;
            this.manyToOneListView.View = System.Windows.Forms.View.Details;
            this.manyToOneListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView_ColumnClick);
            this.manyToOneListView.SelectedIndexChanged += new System.EventHandler(this.manyToOneListView_SelectedIndexChanged);
            this.manyToOneListView.DoubleClick += new System.EventHandler(this.manyToOneListView_DoubleClick);
            // 
            // manyToOnePropertyGrid
            // 
            this.manyToOnePropertyGrid.DisabledItemForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))));
            this.manyToOnePropertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.manyToOnePropertyGrid.Location = new System.Drawing.Point(0, 0);
            this.manyToOnePropertyGrid.Margin = new System.Windows.Forms.Padding(2);
            this.manyToOnePropertyGrid.Name = "manyToOnePropertyGrid";
            this.manyToOnePropertyGrid.Size = new System.Drawing.Size(569, 492);
            this.manyToOnePropertyGrid.TabIndex = 0;
            this.manyToOnePropertyGrid.ViewForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))));
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbHideManyToOnePanel,
            this.tsbManyToOneColumns,
            this.toolStripSeparator9,
            this.toolStripLabel2,
            this.tstxtSearchMtO,
            this.toolStripSeparator11,
            this.tsbExportMoRelsExcel});
            this.toolStrip2.Location = new System.Drawing.Point(2, 2);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(849, 25);
            this.toolStrip2.TabIndex = 5;
            this.toolStrip2.Text = "toolStrip3";
            // 
            // tsbHideManyToOnePanel
            // 
            this.tsbHideManyToOnePanel.Image = ((System.Drawing.Image)(resources.GetObject("tsbHideManyToOnePanel.Image")));
            this.tsbHideManyToOnePanel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbHideManyToOnePanel.Name = "tsbHideManyToOnePanel";
            this.tsbHideManyToOnePanel.Size = new System.Drawing.Size(84, 22);
            this.tsbHideManyToOnePanel.Text = "Hide panel";
            this.tsbHideManyToOnePanel.Visible = false;
            this.tsbHideManyToOnePanel.Click += new System.EventHandler(this.tsbHidePanel_Click);
            // 
            // tsbManyToOneColumns
            // 
            this.tsbManyToOneColumns.Image = ((System.Drawing.Image)(resources.GetObject("tsbManyToOneColumns.Image")));
            this.tsbManyToOneColumns.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbManyToOneColumns.Name = "tsbManyToOneColumns";
            this.tsbManyToOneColumns.Size = new System.Drawing.Size(84, 22);
            this.tsbManyToOneColumns.Text = "Columns...";
            this.tsbManyToOneColumns.Click += new System.EventHandler(this.tsbColumns_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(42, 22);
            this.toolStripLabel2.Text = "Search";
            // 
            // tstxtSearchMtO
            // 
            this.tstxtSearchMtO.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tstxtSearchMtO.Name = "tstxtSearchMtO";
            this.tstxtSearchMtO.Size = new System.Drawing.Size(200, 25);
            this.tstxtSearchMtO.TextChanged += new System.EventHandler(this.tstxtSearch_TextChanged);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbExportMoRelsExcel
            // 
            this.tsbExportMoRelsExcel.Image = ((System.Drawing.Image)(resources.GetObject("tsbExportMoRelsExcel.Image")));
            this.tsbExportMoRelsExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExportMoRelsExcel.Name = "tsbExportMoRelsExcel";
            this.tsbExportMoRelsExcel.Size = new System.Drawing.Size(105, 22);
            this.tsbExportMoRelsExcel.Text = "Export to Excel";
            this.tsbExportMoRelsExcel.Click += new System.EventHandler(this.tsbExportMoRelsExcel_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.manyToManySplitContainer);
            this.tabPage3.Controls.Add(this.manyToManyToolStrip);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage3.Size = new System.Drawing.Size(853, 521);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "ManyToManyRelationships";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // manyToManySplitContainer
            // 
            this.manyToManySplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.manyToManySplitContainer.Location = new System.Drawing.Point(2, 27);
            this.manyToManySplitContainer.Margin = new System.Windows.Forms.Padding(2);
            this.manyToManySplitContainer.Name = "manyToManySplitContainer";
            // 
            // manyToManySplitContainer.Panel1
            // 
            this.manyToManySplitContainer.Panel1.Controls.Add(this.manyToManyListView);
            // 
            // manyToManySplitContainer.Panel2
            // 
            this.manyToManySplitContainer.Panel2.Controls.Add(this.manyToManyPropertyGrid);
            this.manyToManySplitContainer.Size = new System.Drawing.Size(849, 492);
            this.manyToManySplitContainer.SplitterDistance = 277;
            this.manyToManySplitContainer.SplitterWidth = 3;
            this.manyToManySplitContainer.TabIndex = 4;
            // 
            // manyToManyListView
            // 
            this.manyToManyListView.ContextMenuStrip = this.cmsNNRelationship;
            this.manyToManyListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.manyToManyListView.FullRowSelect = true;
            this.manyToManyListView.GridLines = true;
            this.manyToManyListView.HideSelection = false;
            this.manyToManyListView.Location = new System.Drawing.Point(0, 0);
            this.manyToManyListView.Margin = new System.Windows.Forms.Padding(2);
            this.manyToManyListView.Name = "manyToManyListView";
            this.manyToManyListView.Size = new System.Drawing.Size(277, 492);
            this.manyToManyListView.TabIndex = 1;
            this.manyToManyListView.UseCompatibleStateImageBehavior = false;
            this.manyToManyListView.View = System.Windows.Forms.View.Details;
            this.manyToManyListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView_ColumnClick);
            this.manyToManyListView.SelectedIndexChanged += new System.EventHandler(this.manyToManyListView_SelectedIndexChanged);
            this.manyToManyListView.DoubleClick += new System.EventHandler(this.manyToManyListView_DoubleClick);
            // 
            // cmsNNRelationship
            // 
            this.cmsNNRelationship.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.cmsNNRelationship.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiRelNNCopySchemaName,
            this.tsmiRelNNCopyEntity1NavigationProperty,
            this.tsmiRelNNCopyEntity2NavigationProperty});
            this.cmsNNRelationship.Name = "cmsAttributes";
            this.cmsNNRelationship.Size = new System.Drawing.Size(252, 70);
            this.cmsNNRelationship.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.cmsNNRelationship_ItemClicked);
            // 
            // tsmiRelNNCopySchemaName
            // 
            this.tsmiRelNNCopySchemaName.Name = "tsmiRelNNCopySchemaName";
            this.tsmiRelNNCopySchemaName.Size = new System.Drawing.Size(251, 22);
            this.tsmiRelNNCopySchemaName.Text = "Copy Schema name";
            // 
            // tsmiRelNNCopyEntity1NavigationProperty
            // 
            this.tsmiRelNNCopyEntity1NavigationProperty.Name = "tsmiRelNNCopyEntity1NavigationProperty";
            this.tsmiRelNNCopyEntity1NavigationProperty.Size = new System.Drawing.Size(251, 22);
            this.tsmiRelNNCopyEntity1NavigationProperty.Text = "Copy Entity 1 navigation property";
            // 
            // tsmiRelNNCopyEntity2NavigationProperty
            // 
            this.tsmiRelNNCopyEntity2NavigationProperty.Name = "tsmiRelNNCopyEntity2NavigationProperty";
            this.tsmiRelNNCopyEntity2NavigationProperty.Size = new System.Drawing.Size(251, 22);
            this.tsmiRelNNCopyEntity2NavigationProperty.Text = "Copy Entity 2 navigation property";
            // 
            // manyToManyPropertyGrid
            // 
            this.manyToManyPropertyGrid.DisabledItemForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))));
            this.manyToManyPropertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.manyToManyPropertyGrid.Location = new System.Drawing.Point(0, 0);
            this.manyToManyPropertyGrid.Margin = new System.Windows.Forms.Padding(2);
            this.manyToManyPropertyGrid.Name = "manyToManyPropertyGrid";
            this.manyToManyPropertyGrid.Size = new System.Drawing.Size(569, 492);
            this.manyToManyPropertyGrid.TabIndex = 0;
            this.manyToManyPropertyGrid.ViewForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))));
            // 
            // manyToManyToolStrip
            // 
            this.manyToManyToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbHideManyToManyPanel,
            this.tsbManyToManyColumns,
            this.toolStripSeparator12,
            this.toolStripLabel3,
            this.tstxtSearchM2M,
            this.toolStripSeparator7,
            this.tsbExportMmRelsExcel});
            this.manyToManyToolStrip.Location = new System.Drawing.Point(2, 2);
            this.manyToManyToolStrip.Name = "manyToManyToolStrip";
            this.manyToManyToolStrip.Size = new System.Drawing.Size(849, 25);
            this.manyToManyToolStrip.TabIndex = 3;
            this.manyToManyToolStrip.Text = "toolStrip3";
            // 
            // tsbHideManyToManyPanel
            // 
            this.tsbHideManyToManyPanel.Image = ((System.Drawing.Image)(resources.GetObject("tsbHideManyToManyPanel.Image")));
            this.tsbHideManyToManyPanel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbHideManyToManyPanel.Name = "tsbHideManyToManyPanel";
            this.tsbHideManyToManyPanel.Size = new System.Drawing.Size(84, 22);
            this.tsbHideManyToManyPanel.Text = "Hide panel";
            this.tsbHideManyToManyPanel.Visible = false;
            this.tsbHideManyToManyPanel.Click += new System.EventHandler(this.tsbHidePanel_Click);
            // 
            // tsbManyToManyColumns
            // 
            this.tsbManyToManyColumns.Image = ((System.Drawing.Image)(resources.GetObject("tsbManyToManyColumns.Image")));
            this.tsbManyToManyColumns.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbManyToManyColumns.Name = "tsbManyToManyColumns";
            this.tsbManyToManyColumns.Size = new System.Drawing.Size(84, 22);
            this.tsbManyToManyColumns.Text = "Columns...";
            this.tsbManyToManyColumns.Click += new System.EventHandler(this.tsbColumns_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(42, 22);
            this.toolStripLabel3.Text = "Search";
            // 
            // tstxtSearchM2M
            // 
            this.tstxtSearchM2M.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tstxtSearchM2M.Name = "tstxtSearchM2M";
            this.tstxtSearchM2M.Size = new System.Drawing.Size(200, 25);
            this.tstxtSearchM2M.TextChanged += new System.EventHandler(this.tstxtSearch_TextChanged);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbExportMmRelsExcel
            // 
            this.tsbExportMmRelsExcel.Image = ((System.Drawing.Image)(resources.GetObject("tsbExportMmRelsExcel.Image")));
            this.tsbExportMmRelsExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExportMmRelsExcel.Name = "tsbExportMmRelsExcel";
            this.tsbExportMmRelsExcel.Size = new System.Drawing.Size(105, 22);
            this.tsbExportMmRelsExcel.Text = "Export to Excel";
            this.tsbExportMmRelsExcel.Click += new System.EventHandler(this.tsbExportMmRelsExcel_Click);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.privilegeSplitContainer);
            this.tabPage5.Controls.Add(this.privilegeToolStrip);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage5.Size = new System.Drawing.Size(853, 521);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Privileges";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // privilegeSplitContainer
            // 
            this.privilegeSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.privilegeSplitContainer.Location = new System.Drawing.Point(2, 27);
            this.privilegeSplitContainer.Margin = new System.Windows.Forms.Padding(2);
            this.privilegeSplitContainer.Name = "privilegeSplitContainer";
            // 
            // privilegeSplitContainer.Panel1
            // 
            this.privilegeSplitContainer.Panel1.Controls.Add(this.privilegeListView);
            // 
            // privilegeSplitContainer.Panel2
            // 
            this.privilegeSplitContainer.Panel2.Controls.Add(this.privilegePropertyGrid);
            this.privilegeSplitContainer.Size = new System.Drawing.Size(849, 492);
            this.privilegeSplitContainer.SplitterDistance = 277;
            this.privilegeSplitContainer.SplitterWidth = 3;
            this.privilegeSplitContainer.TabIndex = 4;
            // 
            // privilegeListView
            // 
            this.privilegeListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.privilegeListView.FullRowSelect = true;
            this.privilegeListView.GridLines = true;
            this.privilegeListView.HideSelection = false;
            this.privilegeListView.Location = new System.Drawing.Point(0, 0);
            this.privilegeListView.Margin = new System.Windows.Forms.Padding(2);
            this.privilegeListView.Name = "privilegeListView";
            this.privilegeListView.Size = new System.Drawing.Size(277, 492);
            this.privilegeListView.TabIndex = 1;
            this.privilegeListView.UseCompatibleStateImageBehavior = false;
            this.privilegeListView.View = System.Windows.Forms.View.Details;
            this.privilegeListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView_ColumnClick);
            this.privilegeListView.SelectedIndexChanged += new System.EventHandler(this.privilegeListView_SelectedIndexChanged);
            this.privilegeListView.DoubleClick += new System.EventHandler(this.privilegeListView_DoubleClick);
            // 
            // privilegePropertyGrid
            // 
            this.privilegePropertyGrid.DisabledItemForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))));
            this.privilegePropertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.privilegePropertyGrid.Location = new System.Drawing.Point(0, 0);
            this.privilegePropertyGrid.Margin = new System.Windows.Forms.Padding(2);
            this.privilegePropertyGrid.Name = "privilegePropertyGrid";
            this.privilegePropertyGrid.Size = new System.Drawing.Size(569, 492);
            this.privilegePropertyGrid.TabIndex = 0;
            this.privilegePropertyGrid.ViewForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))));
            // 
            // privilegeToolStrip
            // 
            this.privilegeToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbHidePrivilegePanel,
            this.tsbPrivilegeColumns,
            this.toolStripSeparator8,
            this.tsbExportPrivExcel});
            this.privilegeToolStrip.Location = new System.Drawing.Point(2, 2);
            this.privilegeToolStrip.Name = "privilegeToolStrip";
            this.privilegeToolStrip.Size = new System.Drawing.Size(849, 25);
            this.privilegeToolStrip.TabIndex = 3;
            this.privilegeToolStrip.Text = "toolStrip3";
            // 
            // tsbHidePrivilegePanel
            // 
            this.tsbHidePrivilegePanel.Image = ((System.Drawing.Image)(resources.GetObject("tsbHidePrivilegePanel.Image")));
            this.tsbHidePrivilegePanel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbHidePrivilegePanel.Name = "tsbHidePrivilegePanel";
            this.tsbHidePrivilegePanel.Size = new System.Drawing.Size(84, 22);
            this.tsbHidePrivilegePanel.Text = "Hide panel";
            this.tsbHidePrivilegePanel.Visible = false;
            this.tsbHidePrivilegePanel.Click += new System.EventHandler(this.tsbHidePanel_Click);
            // 
            // tsbPrivilegeColumns
            // 
            this.tsbPrivilegeColumns.Image = ((System.Drawing.Image)(resources.GetObject("tsbPrivilegeColumns.Image")));
            this.tsbPrivilegeColumns.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPrivilegeColumns.Name = "tsbPrivilegeColumns";
            this.tsbPrivilegeColumns.Size = new System.Drawing.Size(84, 22);
            this.tsbPrivilegeColumns.Text = "Columns...";
            this.tsbPrivilegeColumns.Click += new System.EventHandler(this.tsbColumns_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbExportPrivExcel
            // 
            this.tsbExportPrivExcel.Image = ((System.Drawing.Image)(resources.GetObject("tsbExportPrivExcel.Image")));
            this.tsbExportPrivExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExportPrivExcel.Name = "tsbExportPrivExcel";
            this.tsbExportPrivExcel.Size = new System.Drawing.Size(105, 22);
            this.tsbExportPrivExcel.Text = "Export to Excel";
            this.tsbExportPrivExcel.Click += new System.EventHandler(this.tsbExportPrivExcel_Click);
            // 
            // tpSolutions
            // 
            this.tpSolutions.Controls.Add(this.lvSolutions);
            this.tpSolutions.Controls.Add(this.toolStrip1);
            this.tpSolutions.Location = new System.Drawing.Point(4, 22);
            this.tpSolutions.Margin = new System.Windows.Forms.Padding(2);
            this.tpSolutions.Name = "tpSolutions";
            this.tpSolutions.Padding = new System.Windows.Forms.Padding(2);
            this.tpSolutions.Size = new System.Drawing.Size(853, 521);
            this.tpSolutions.TabIndex = 7;
            this.tpSolutions.Text = "Solutions";
            this.tpSolutions.UseVisualStyleBackColor = true;
            // 
            // lvSolutions
            // 
            this.lvSolutions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chSolutionFriendlyName,
            this.chSolutionUniqueName,
            this.chSolutionVersion,
            this.chSolutionType,
            this.chSolutionEntity,
            this.chSolutionBehavior});
            this.lvSolutions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvSolutions.FullRowSelect = true;
            this.lvSolutions.HideSelection = false;
            this.lvSolutions.Location = new System.Drawing.Point(2, 27);
            this.lvSolutions.Margin = new System.Windows.Forms.Padding(2);
            this.lvSolutions.Name = "lvSolutions";
            this.lvSolutions.Size = new System.Drawing.Size(849, 492);
            this.lvSolutions.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvSolutions.TabIndex = 5;
            this.lvSolutions.UseCompatibleStateImageBehavior = false;
            this.lvSolutions.View = System.Windows.Forms.View.Details;
            // 
            // chSolutionFriendlyName
            // 
            this.chSolutionFriendlyName.Text = "Name";
            this.chSolutionFriendlyName.Width = 400;
            // 
            // chSolutionUniqueName
            // 
            this.chSolutionUniqueName.Text = "Unique name";
            this.chSolutionUniqueName.Width = 200;
            // 
            // chSolutionVersion
            // 
            this.chSolutionVersion.Text = "Version";
            this.chSolutionVersion.Width = 100;
            // 
            // chSolutionType
            // 
            this.chSolutionType.Text = "Type";
            this.chSolutionType.Width = 100;
            // 
            // chSolutionEntity
            // 
            this.chSolutionEntity.Text = "Entity";
            this.chSolutionEntity.Width = 150;
            // 
            // chSolutionBehavior
            // 
            this.chSolutionBehavior.Text = "Behavior";
            this.chSolutionBehavior.Width = 400;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbExportExcelSolutions});
            this.toolStrip1.Location = new System.Drawing.Point(2, 2);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(849, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip3";
            // 
            // tsbExportExcelSolutions
            // 
            this.tsbExportExcelSolutions.Image = ((System.Drawing.Image)(resources.GetObject("tsbExportExcelSolutions.Image")));
            this.tsbExportExcelSolutions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExportExcelSolutions.Name = "tsbExportExcelSolutions";
            this.tsbExportExcelSolutions.Size = new System.Drawing.Size(105, 22);
            this.tsbExportExcelSolutions.Text = "Export to Excel";
            this.tsbExportExcelSolutions.Click += new System.EventHandler(this.tsbExportExcelSolutions_Click);
            // 
            // EntityPropertiesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "EntityPropertiesControl";
            this.Size = new System.Drawing.Size(861, 547);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.entityToolStrip.ResumeLayout(false);
            this.entityToolStrip.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.attributesSplitContainer.Panel1.ResumeLayout(false);
            this.attributesSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.attributesSplitContainer)).EndInit();
            this.attributesSplitContainer.ResumeLayout(false);
            this.cmsAttributes.ResumeLayout(false);
            this.scMetadata.Panel1.ResumeLayout(false);
            this.scMetadata.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMetadata)).EndInit();
            this.scMetadata.ResumeLayout(false);
            this.cmsOptionSet.ResumeLayout(false);
            this.attributeToolStrip.ResumeLayout(false);
            this.attributeToolStrip.PerformLayout();
            this.tabPage7.ResumeLayout(false);
            this.tabPage7.PerformLayout();
            this.keySplitContainer.Panel1.ResumeLayout(false);
            this.keySplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.keySplitContainer)).EndInit();
            this.keySplitContainer.ResumeLayout(false);
            this.keysToolStrip.ResumeLayout(false);
            this.keysToolStrip.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.oneToManySplitContainer.Panel1.ResumeLayout(false);
            this.oneToManySplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.oneToManySplitContainer)).EndInit();
            this.oneToManySplitContainer.ResumeLayout(false);
            this.cmsRelationships.ResumeLayout(false);
            this.manyToOneToolStrip.ResumeLayout(false);
            this.manyToOneToolStrip.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            this.manyToOneSplitContainer.Panel1.ResumeLayout(false);
            this.manyToOneSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.manyToOneSplitContainer)).EndInit();
            this.manyToOneSplitContainer.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.manyToManySplitContainer.Panel1.ResumeLayout(false);
            this.manyToManySplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.manyToManySplitContainer)).EndInit();
            this.manyToManySplitContainer.ResumeLayout(false);
            this.cmsNNRelationship.ResumeLayout(false);
            this.manyToManyToolStrip.ResumeLayout(false);
            this.manyToManyToolStrip.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.privilegeSplitContainer.Panel1.ResumeLayout(false);
            this.privilegeSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.privilegeSplitContainer)).EndInit();
            this.privilegeSplitContainer.ResumeLayout(false);
            this.privilegeToolStrip.ResumeLayout(false);
            this.privilegeToolStrip.PerformLayout();
            this.tpSolutions.ResumeLayout(false);
            this.tpSolutions.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.PropertyGrid entityPropertyGrid;
        private System.Windows.Forms.ToolStrip entityToolStrip;
        private System.Windows.Forms.ToolStripButton tsbHideEntityPanel;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.SplitContainer attributesSplitContainer;
        public System.Windows.Forms.ListView attributeListView;
        private System.Windows.Forms.ToolStrip attributeToolStrip;
        private System.Windows.Forms.ToolStripButton tsbHideAttributePanel;
        private System.Windows.Forms.ToolStripButton tsbAttributeColumns;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.SplitContainer oneToManySplitContainer;
        public System.Windows.Forms.ListView OneToManyListView;
        private System.Windows.Forms.PropertyGrid OneToManyPropertyGrid;
        private System.Windows.Forms.ToolStrip manyToOneToolStrip;
        private System.Windows.Forms.ToolStripButton tsbHideOneToManyPanel;
        private System.Windows.Forms.ToolStripButton tsbOneToManyColumns;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.SplitContainer manyToOneSplitContainer;
        public System.Windows.Forms.ListView manyToOneListView;
        private System.Windows.Forms.PropertyGrid manyToOnePropertyGrid;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton tsbHideManyToOnePanel;
        private System.Windows.Forms.ToolStripButton tsbManyToOneColumns;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.SplitContainer manyToManySplitContainer;
        public System.Windows.Forms.ListView manyToManyListView;
        private System.Windows.Forms.PropertyGrid manyToManyPropertyGrid;
        private System.Windows.Forms.ToolStrip manyToManyToolStrip;
        private System.Windows.Forms.ToolStripButton tsbHideManyToManyPanel;
        private System.Windows.Forms.ToolStripButton tsbManyToManyColumns;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.SplitContainer privilegeSplitContainer;
        public System.Windows.Forms.ListView privilegeListView;
        private System.Windows.Forms.PropertyGrid privilegePropertyGrid;
        private System.Windows.Forms.ToolStrip privilegeToolStrip;
        private System.Windows.Forms.ToolStripButton tsbHidePrivilegePanel;
        private System.Windows.Forms.ToolStripButton tsbPrivilegeColumns;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel tslSearchAttr;
        private System.Windows.Forms.ToolStripTextBox tstxtSearchContact;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.SplitContainer keySplitContainer;
        public System.Windows.Forms.ListView keyListView;
        private System.Windows.Forms.PropertyGrid keyPropertyGrid;
        private System.Windows.Forms.ToolStrip keysToolStrip;
        private System.Windows.Forms.ToolStripButton tsbHideKeyPanel;
        private System.Windows.Forms.ToolStripButton tsbKeyColumns;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbOpenInWebApp;
        private System.Windows.Forms.ToolStripButton tsbExportAttributesExcel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tsbExportKeysExcel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton tsbExportOmRelsExcel;
        private System.Windows.Forms.ToolStripButton tsbExportMoRelsExcel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton tsbExportMmRelsExcel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton tsbExportPrivExcel;
        private System.Windows.Forms.SplitContainer scMetadata;
        private System.Windows.Forms.PropertyGrid pgOptionSet;
        private System.Windows.Forms.PropertyGrid attributePropertyGrid;
        private System.Windows.Forms.ContextMenuStrip cmsAttributes;
        private System.Windows.Forms.ToolStripMenuItem tsmiAttributesCopyLogicalName;
        private System.Windows.Forms.ToolStripMenuItem tsmiAttributesCopySchemaName;
        private System.Windows.Forms.ContextMenuStrip cmsRelationships;
        private System.Windows.Forms.ToolStripMenuItem tsmiRelationshipCopySchemaName;
        private System.Windows.Forms.ToolStripMenuItem tsmiRelationshipCopyReferencedNavigationProperty;
        private System.Windows.Forms.ToolStripMenuItem tsmiRelationshipCopyReferencingNavigationProperty;
        private System.Windows.Forms.ContextMenuStrip cmsNNRelationship;
        private System.Windows.Forms.ToolStripMenuItem tsmiRelNNCopySchemaName;
        private System.Windows.Forms.ToolStripMenuItem tsmiRelNNCopyEntity1NavigationProperty;
        private System.Windows.Forms.ToolStripMenuItem tsmiRelNNCopyEntity2NavigationProperty;
        private System.Windows.Forms.TabPage tpSolutions;
        public System.Windows.Forms.ListView lvSolutions;
        private System.Windows.Forms.ColumnHeader chSolutionFriendlyName;
        private System.Windows.Forms.ColumnHeader chSolutionUniqueName;
        private System.Windows.Forms.ColumnHeader chSolutionVersion;
        private System.Windows.Forms.ColumnHeader chSolutionType;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbExportExcelSolutions;
        private System.Windows.Forms.ColumnHeader chSolutionEntity;
        private System.Windows.Forms.ColumnHeader chSolutionBehavior;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox tstxtSearchOtm;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox tstxtSearchMtO;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripTextBox tstxtSearchM2M;
        private System.Windows.Forms.ToolStripMenuItem copyNameForWebApiToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmsOptionSet;
        private System.Windows.Forms.ToolStripMenuItem copyValueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyLabelToolStripMenuItem;
    }
}
