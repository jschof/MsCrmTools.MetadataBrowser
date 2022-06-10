namespace MsCrmTools.MetadataBrowser
{
    partial class MainControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainControl));
            this.scMetadata = new System.Windows.Forms.SplitContainer();
            this.pgOptionSetValues = new System.Windows.Forms.PropertyGrid();
            this.cmsPicklist = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyValueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyDisplayNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pgOptionSet = new System.Windows.Forms.PropertyGrid();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tssbLoadEntities = new System.Windows.Forms.ToolStripSplitButton();
            this.tsmiLoadEntitiesFromSolution = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbDeselectAllTables = new System.Windows.Forms.ToolStripButton();
            this.tsbSelectAllTables = new System.Windows.Forms.ToolStripButton();
            this.tsbSelectInverseTables = new System.Windows.Forms.ToolStripButton();
            this.tsbViewTables = new System.Windows.Forms.ToolStripButton();
            this.tbsCloseTabs = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbEntityColumns = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tslSearch = new System.Windows.Forms.ToolStripLabel();
            this.tstxtFilter = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbOpenInWebApp = new System.Windows.Forms.ToolStripButton();
            this.tsbExportExcel = new System.Windows.Forms.ToolStripSplitButton();
            this.exportOpenedTabsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportSelectedTablesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsEntity = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiEntityCopyLogicalName = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEntityCopyLogicalCollectionName = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEntityCopySchemaName = new System.Windows.Forms.ToolStripMenuItem();
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.tpOptionSet = new System.Windows.Forms.TabPage();
            this.scOptionSet = new System.Windows.Forms.SplitContainer();
            this.lvChoices = new System.Windows.Forms.ListView();
            this.entityListView = new System.Windows.Forms.ListView();
            this.tbEntitiesList = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.scMetadata)).BeginInit();
            this.scMetadata.Panel1.SuspendLayout();
            this.scMetadata.Panel2.SuspendLayout();
            this.scMetadata.SuspendLayout();
            this.cmsPicklist.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.cmsEntity.SuspendLayout();
            this.mainTabControl.SuspendLayout();
            this.tpOptionSet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scOptionSet)).BeginInit();
            this.scOptionSet.Panel1.SuspendLayout();
            this.scOptionSet.Panel2.SuspendLayout();
            this.scOptionSet.SuspendLayout();
            this.tbEntitiesList.SuspendLayout();
            this.SuspendLayout();
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
            this.scMetadata.Panel1.Controls.Add(this.pgOptionSetValues);
            // 
            // scMetadata.Panel2
            // 
            this.scMetadata.Panel2.Controls.Add(this.pgOptionSet);
            this.scMetadata.Size = new System.Drawing.Size(509, 474);
            this.scMetadata.SplitterDistance = 236;
            this.scMetadata.SplitterWidth = 3;
            this.scMetadata.TabIndex = 3;
            // 
            // pgOptionSetValues
            // 
            this.pgOptionSetValues.ContextMenuStrip = this.cmsPicklist;
            this.pgOptionSetValues.DisabledItemForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))));
            this.pgOptionSetValues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgOptionSetValues.HelpVisible = false;
            this.pgOptionSetValues.Location = new System.Drawing.Point(0, 0);
            this.pgOptionSetValues.Margin = new System.Windows.Forms.Padding(2);
            this.pgOptionSetValues.Name = "pgOptionSetValues";
            this.pgOptionSetValues.Size = new System.Drawing.Size(509, 236);
            this.pgOptionSetValues.TabIndex = 1;
            this.pgOptionSetValues.ToolbarVisible = false;
            this.pgOptionSetValues.ViewForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))));
            // 
            // cmsPicklist
            // 
            this.cmsPicklist.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.cmsPicklist.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyValueToolStripMenuItem,
            this.copyDisplayNameToolStripMenuItem});
            this.cmsPicklist.Name = "cmsPicklist";
            this.cmsPicklist.Size = new System.Drawing.Size(134, 48);
            this.cmsPicklist.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.cmsPicklist_ItemClicked);
            // 
            // copyValueToolStripMenuItem
            // 
            this.copyValueToolStripMenuItem.Name = "copyValueToolStripMenuItem";
            this.copyValueToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.copyValueToolStripMenuItem.Text = "Copy value";
            // 
            // copyDisplayNameToolStripMenuItem
            // 
            this.copyDisplayNameToolStripMenuItem.Name = "copyDisplayNameToolStripMenuItem";
            this.copyDisplayNameToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.copyDisplayNameToolStripMenuItem.Text = "Copy label";
            // 
            // pgOptionSet
            // 
            this.pgOptionSet.DisabledItemForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))));
            this.pgOptionSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgOptionSet.Location = new System.Drawing.Point(0, 0);
            this.pgOptionSet.Margin = new System.Windows.Forms.Padding(2);
            this.pgOptionSet.Name = "pgOptionSet";
            this.pgOptionSet.Size = new System.Drawing.Size(509, 235);
            this.pgOptionSet.TabIndex = 2;
            this.pgOptionSet.ViewForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))));
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbClose,
            this.toolStripSeparator1,
            this.tssbLoadEntities,
            this.tsbDeselectAllTables,
            this.tsbSelectAllTables,
            this.tsbSelectInverseTables,
            this.tsbViewTables,
            this.tbsCloseTabs,
            this.toolStripSeparator2,
            this.tsbEntityColumns,
            this.toolStripSeparator3,
            this.tslSearch,
            this.tstxtFilter,
            this.toolStripSeparator4,
            this.tsbOpenInWebApp,
            this.tsbExportExcel,
            this.toolStripSeparator5});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStrip1.Size = new System.Drawing.Size(993, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbClose
            // 
            this.tsbClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbClose.Image = ((System.Drawing.Image)(resources.GetObject("tsbClose.Image")));
            this.tsbClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClose.Name = "tsbClose";
            this.tsbClose.Size = new System.Drawing.Size(23, 22);
            this.tsbClose.Text = "Close this tool";
            this.tsbClose.Click += new System.EventHandler(this.tsbClose_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tssbLoadEntities
            // 
            this.tssbLoadEntities.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiLoadEntitiesFromSolution});
            this.tssbLoadEntities.Image = global::MsCrmTools.MetadataBrowser.Properties.Resources.ico_16_9801;
            this.tssbLoadEntities.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tssbLoadEntities.Name = "tssbLoadEntities";
            this.tssbLoadEntities.Size = new System.Drawing.Size(100, 22);
            this.tssbLoadEntities.Text = "Load Tables";
            this.tssbLoadEntities.ToolTipText = "Load all tables from the connected organization";
            this.tssbLoadEntities.ButtonClick += new System.EventHandler(this.tssbLoadEntities_ButtonClick);
            // 
            // tsmiLoadEntitiesFromSolution
            // 
            this.tsmiLoadEntitiesFromSolution.Name = "tsmiLoadEntitiesFromSolution";
            this.tsmiLoadEntitiesFromSolution.Size = new System.Drawing.Size(223, 22);
            this.tsmiLoadEntitiesFromSolution.Text = "Load Tables from solution(s)";
            this.tsmiLoadEntitiesFromSolution.Click += new System.EventHandler(this.tsmiLoadEntitiesFromSolution_Click);
            // 
            // tsbDeselectAllTables
            // 
            this.tsbDeselectAllTables.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDeselectAllTables.Image = global::MsCrmTools.MetadataBrowser.Properties.Resources.Deselect;
            this.tsbDeselectAllTables.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbDeselectAllTables.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDeselectAllTables.Name = "tsbDeselectAllTables";
            this.tsbDeselectAllTables.Size = new System.Drawing.Size(23, 22);
            this.tsbDeselectAllTables.Text = "Deselect All Tables";
            this.tsbDeselectAllTables.ToolTipText = "Deselect All Tables";
            this.tsbDeselectAllTables.Click += new System.EventHandler(this.tsbDeselectAllTables_Click);
            // 
            // tsbSelectAllTables
            // 
            this.tsbSelectAllTables.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSelectAllTables.Image = global::MsCrmTools.MetadataBrowser.Properties.Resources.Select;
            this.tsbSelectAllTables.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbSelectAllTables.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSelectAllTables.Name = "tsbSelectAllTables";
            this.tsbSelectAllTables.Size = new System.Drawing.Size(23, 22);
            this.tsbSelectAllTables.Text = "Select All Tables";
            this.tsbSelectAllTables.Click += new System.EventHandler(this.tsbSelectAllTables_Click);
            // 
            // tsbSelectInverseTables
            // 
            this.tsbSelectInverseTables.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSelectInverseTables.Image = global::MsCrmTools.MetadataBrowser.Properties.Resources.SelectInverse;
            this.tsbSelectInverseTables.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbSelectInverseTables.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSelectInverseTables.Name = "tsbSelectInverseTables";
            this.tsbSelectInverseTables.Size = new System.Drawing.Size(23, 22);
            this.tsbSelectInverseTables.Text = "Select Inverse Tables";
            this.tsbSelectInverseTables.Click += new System.EventHandler(this.tsbSelectInverseTables_Click);
            // 
            // tsbViewTables
            // 
            this.tsbViewTables.Image = global::MsCrmTools.MetadataBrowser.Properties.Resources.View;
            this.tsbViewTables.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbViewTables.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbViewTables.Name = "tsbViewTables";
            this.tsbViewTables.Size = new System.Drawing.Size(52, 22);
            this.tsbViewTables.Text = "View";
            this.tsbViewTables.ToolTipText = "View Selected Tables";
            this.tsbViewTables.Click += new System.EventHandler(this.tsbViewTables_Click);
            // 
            // tbsCloseTabs
            // 
            this.tbsCloseTabs.Image = global::MsCrmTools.MetadataBrowser.Properties.Resources.DeleteTab;
            this.tbsCloseTabs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbsCloseTabs.Name = "tbsCloseTabs";
            this.tbsCloseTabs.Size = new System.Drawing.Size(82, 22);
            this.tbsCloseTabs.Text = "Close Tabs";
            this.tbsCloseTabs.ToolTipText = "Close Opened Tabs";
            this.tbsCloseTabs.Click += new System.EventHandler(this.tbsCloseTabs_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbEntityColumns
            // 
            this.tsbEntityColumns.Image = ((System.Drawing.Image)(resources.GetObject("tsbEntityColumns.Image")));
            this.tsbEntityColumns.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEntityColumns.Name = "tsbEntityColumns";
            this.tsbEntityColumns.Size = new System.Drawing.Size(84, 22);
            this.tsbEntityColumns.Text = "Columns...";
            this.tsbEntityColumns.Click += new System.EventHandler(this.tsbColumns_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tslSearch
            // 
            this.tslSearch.Name = "tslSearch";
            this.tslSearch.Size = new System.Drawing.Size(42, 22);
            this.tslSearch.Text = "Search";
            // 
            // tstxtFilter
            // 
            this.tstxtFilter.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tstxtFilter.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.tstxtFilter.Name = "tstxtFilter";
            this.tstxtFilter.Size = new System.Drawing.Size(200, 25);
            this.tstxtFilter.Text = "Logical/Display Name or GUID";
            this.tstxtFilter.Enter += new System.EventHandler(this.tstxtFilter_Enter);
            this.tstxtFilter.TextChanged += new System.EventHandler(this.tstxtFilter_TextChanged);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
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
            // tsbExportExcel
            // 
            this.tsbExportExcel.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportOpenedTabsToolStripMenuItem,
            this.exportSelectedTablesToolStripMenuItem});
            this.tsbExportExcel.Image = ((System.Drawing.Image)(resources.GetObject("tsbExportExcel.Image")));
            this.tsbExportExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExportExcel.Name = "tsbExportExcel";
            this.tsbExportExcel.Size = new System.Drawing.Size(73, 22);
            this.tsbExportExcel.Text = "Export";
            this.tsbExportExcel.ToolTipText = "Export to Excel";
            this.tsbExportExcel.ButtonClick += new System.EventHandler(this.tsbExportExcel_ButtonClick);
            // 
            // exportOpenedTabsToolStripMenuItem
            // 
            this.exportOpenedTabsToolStripMenuItem.Name = "exportOpenedTabsToolStripMenuItem";
            this.exportOpenedTabsToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.exportOpenedTabsToolStripMenuItem.Text = "Export Opened Tabs";
            this.exportOpenedTabsToolStripMenuItem.Click += new System.EventHandler(this.exportOpenedTabsToolStripMenuItem_Click);
            // 
            // exportSelectedTablesToolStripMenuItem
            // 
            this.exportSelectedTablesToolStripMenuItem.Name = "exportSelectedTablesToolStripMenuItem";
            this.exportSelectedTablesToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.exportSelectedTablesToolStripMenuItem.Text = "Export Selected Tables";
            this.exportSelectedTablesToolStripMenuItem.Click += new System.EventHandler(this.exportSelectedTablesToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // cmsEntity
            // 
            this.cmsEntity.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.cmsEntity.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiEntityCopyLogicalName,
            this.tsmiEntityCopyLogicalCollectionName,
            this.tsmiEntityCopySchemaName});
            this.cmsEntity.Name = "cmsAttributes";
            this.cmsEntity.Size = new System.Drawing.Size(234, 70);
            this.cmsEntity.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.cmsEntity_ItemClicked);
            // 
            // tsmiEntityCopyLogicalName
            // 
            this.tsmiEntityCopyLogicalName.Name = "tsmiEntityCopyLogicalName";
            this.tsmiEntityCopyLogicalName.Size = new System.Drawing.Size(233, 22);
            this.tsmiEntityCopyLogicalName.Text = "Copy Logical name";
            // 
            // tsmiEntityCopyLogicalCollectionName
            // 
            this.tsmiEntityCopyLogicalCollectionName.Name = "tsmiEntityCopyLogicalCollectionName";
            this.tsmiEntityCopyLogicalCollectionName.Size = new System.Drawing.Size(233, 22);
            this.tsmiEntityCopyLogicalCollectionName.Text = "Copy Logical Collection name";
            // 
            // tsmiEntityCopySchemaName
            // 
            this.tsmiEntityCopySchemaName.Name = "tsmiEntityCopySchemaName";
            this.tsmiEntityCopySchemaName.Size = new System.Drawing.Size(233, 22);
            this.tsmiEntityCopySchemaName.Text = "Copy Schema name";
            // 
            // mainTabControl
            // 
            this.mainTabControl.Controls.Add(this.tbEntitiesList);
            this.mainTabControl.Controls.Add(this.tpOptionSet);
            this.mainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTabControl.Location = new System.Drawing.Point(0, 25);
            this.mainTabControl.Margin = new System.Windows.Forms.Padding(2);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(993, 504);
            this.mainTabControl.TabIndex = 7;
            this.mainTabControl.SelectedIndexChanged += new System.EventHandler(this.mainTabControl_SelectedIndexChanged);
            // 
            // tpOptionSet
            // 
            this.tpOptionSet.Controls.Add(this.scOptionSet);
            this.tpOptionSet.Location = new System.Drawing.Point(4, 22);
            this.tpOptionSet.Margin = new System.Windows.Forms.Padding(2);
            this.tpOptionSet.Name = "tpOptionSet";
            this.tpOptionSet.Padding = new System.Windows.Forms.Padding(2);
            this.tpOptionSet.Size = new System.Drawing.Size(985, 478);
            this.tpOptionSet.TabIndex = 1;
            this.tpOptionSet.Text = "Choices";
            this.tpOptionSet.UseVisualStyleBackColor = true;
            // 
            // scOptionSet
            // 
            this.scOptionSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scOptionSet.Location = new System.Drawing.Point(2, 2);
            this.scOptionSet.Margin = new System.Windows.Forms.Padding(2);
            this.scOptionSet.Name = "scOptionSet";
            // 
            // scOptionSet.Panel1
            // 
            this.scOptionSet.Panel1.Controls.Add(this.lvChoices);
            // 
            // scOptionSet.Panel2
            // 
            this.scOptionSet.Panel2.Controls.Add(this.scMetadata);
            this.scOptionSet.Size = new System.Drawing.Size(981, 474);
            this.scOptionSet.SplitterDistance = 469;
            this.scOptionSet.SplitterWidth = 3;
            this.scOptionSet.TabIndex = 3;
            // 
            // lvChoices
            // 
            this.lvChoices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvChoices.FullRowSelect = true;
            this.lvChoices.GridLines = true;
            this.lvChoices.HideSelection = false;
            this.lvChoices.Location = new System.Drawing.Point(0, 0);
            this.lvChoices.Margin = new System.Windows.Forms.Padding(2);
            this.lvChoices.Name = "lvChoices";
            this.lvChoices.Size = new System.Drawing.Size(469, 474);
            this.lvChoices.TabIndex = 0;
            this.lvChoices.UseCompatibleStateImageBehavior = false;
            this.lvChoices.View = System.Windows.Forms.View.Details;
            this.lvChoices.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView_ColumnClick);
            this.lvChoices.SelectedIndexChanged += new System.EventHandler(this.entityListView_SelectedIndexChanged);
            this.lvChoices.DoubleClick += new System.EventHandler(this.entityListView_DoubleClick);
            // 
            // entityListView
            // 
            this.entityListView.ContextMenuStrip = this.cmsEntity;
            this.entityListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.entityListView.FullRowSelect = true;
            this.entityListView.GridLines = true;
            this.entityListView.HideSelection = false;
            this.entityListView.Location = new System.Drawing.Point(2, 2);
            this.entityListView.Margin = new System.Windows.Forms.Padding(2);
            this.entityListView.Name = "entityListView";
            this.entityListView.Size = new System.Drawing.Size(981, 474);
            this.entityListView.TabIndex = 0;
            this.entityListView.UseCompatibleStateImageBehavior = false;
            this.entityListView.View = System.Windows.Forms.View.Details;
            this.entityListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView_ColumnClick);
            this.entityListView.SelectedIndexChanged += new System.EventHandler(this.entityListView_SelectedIndexChanged);
            this.entityListView.DoubleClick += new System.EventHandler(this.entityListView_DoubleClick);
            // 
            // tbEntitiesList
            // 
            this.tbEntitiesList.Controls.Add(this.entityListView);
            this.tbEntitiesList.Location = new System.Drawing.Point(4, 22);
            this.tbEntitiesList.Margin = new System.Windows.Forms.Padding(2);
            this.tbEntitiesList.Name = "tbEntitiesList";
            this.tbEntitiesList.Padding = new System.Windows.Forms.Padding(2);
            this.tbEntitiesList.Size = new System.Drawing.Size(985, 478);
            this.tbEntitiesList.TabIndex = 0;
            this.tbEntitiesList.Text = "Tables";
            this.tbEntitiesList.UseVisualStyleBackColor = true;
            // 
            // MainControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainTabControl);
            this.Controls.Add(this.toolStrip1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainControl";
            this.Size = new System.Drawing.Size(993, 529);
            this.scMetadata.Panel1.ResumeLayout(false);
            this.scMetadata.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMetadata)).EndInit();
            this.scMetadata.ResumeLayout(false);
            this.cmsPicklist.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.cmsEntity.ResumeLayout(false);
            this.mainTabControl.ResumeLayout(false);
            this.tpOptionSet.ResumeLayout(false);
            this.scOptionSet.Panel1.ResumeLayout(false);
            this.scOptionSet.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scOptionSet)).EndInit();
            this.scOptionSet.ResumeLayout(false);
            this.tbEntitiesList.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbEntityColumns;
        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel tslSearch;
        private System.Windows.Forms.ToolStripTextBox tstxtFilter;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tsbOpenInWebApp;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSplitButton tssbLoadEntities;
        private System.Windows.Forms.ToolStripMenuItem tsmiLoadEntitiesFromSolution;
        private System.Windows.Forms.ContextMenuStrip cmsEntity;
        private System.Windows.Forms.ToolStripMenuItem tsmiEntityCopyLogicalName;
        private System.Windows.Forms.ToolStripMenuItem tsmiEntityCopyLogicalCollectionName;
        private System.Windows.Forms.ToolStripMenuItem tsmiEntityCopySchemaName;
        private System.Windows.Forms.TabPage tpOptionSet;
        private System.Windows.Forms.SplitContainer scOptionSet;
        private System.Windows.Forms.ListView lvChoices;
        private System.Windows.Forms.PropertyGrid pgOptionSet;
        private System.Windows.Forms.PropertyGrid pgOptionSetValues;
        private System.Windows.Forms.ContextMenuStrip cmsPicklist;
        private System.Windows.Forms.ToolStripMenuItem copyValueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyDisplayNameToolStripMenuItem;
        private System.Windows.Forms.SplitContainer scMetadata;
        private System.Windows.Forms.ToolStripButton tsbDeselectAllTables;
        private System.Windows.Forms.ToolStripButton tsbSelectAllTables;
        private System.Windows.Forms.ToolStripButton tsbSelectInverseTables;
        private System.Windows.Forms.ToolStripButton tsbViewTables;
        private System.Windows.Forms.ToolStripSplitButton tsbExportExcel;
        private System.Windows.Forms.ToolStripMenuItem exportSelectedTablesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportOpenedTabsToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton tbsCloseTabs;
        private System.Windows.Forms.TabPage tbEntitiesList;
        private System.Windows.Forms.ListView entityListView;
    }
}
