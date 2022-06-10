﻿using McTools.Xrm.Connection;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;
using MsCrmTools.MetadataBrowser.AppCode;
using MsCrmTools.MetadataBrowser.AppCode.AttributeMd;
using MsCrmTools.MetadataBrowser.AppCode.Excel;
using MsCrmTools.MetadataBrowser.AppCode.Keys;
using MsCrmTools.MetadataBrowser.AppCode.LabelMd;
using MsCrmTools.MetadataBrowser.AppCode.ManyToManyRelationship;
using MsCrmTools.MetadataBrowser.AppCode.OneToManyRelationship;
using MsCrmTools.MetadataBrowser.AppCode.OptionMd;
using MsCrmTools.MetadataBrowser.AppCode.SecurityPrivilege;
using MsCrmTools.MetadataBrowser.Forms;
using MsCrmTools.MetadataBrowser.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace MsCrmTools.MetadataBrowser.UserControls
{
    public partial class EntityPropertiesControl : UserControl
    {
        private ConnectionDetail connectionDetail;
        private EntityMetadata emd;
        private ListViewColumnsSettings lvcSettings;
        private Thread searchThread;

        public EntityPropertiesControl(EntityMetadata emd, EntityCollection components, ListViewColumnsSettings lvcSettings, ConnectionDetail connectionDetail)
        {
            InitializeComponent();

            if (new Version(connectionDetail.OrganizationVersion) < new Version(7, 1))
            {
                // Hide Keys tab if under CRM 2015 Update 1
                tabControl1.TabPages.Remove(tabPage7);
            }

            this.emd = emd;
            this.connectionDetail = connectionDetail;
            this.lvcSettings = (ListViewColumnsSettings)lvcSettings.Clone();

            ListViewColumnHelper.AddColumnsHeader(attributeListView, typeof(AttributeMetadataInfo), ListViewColumnsSettings.AttributeFirstColumns, this.lvcSettings.AttributeSelectedAttributes, new string[] { });
            ListViewColumnHelper.AddColumnsHeader(OneToManyListView, typeof(OneToManyRelationshipMetadataInfo), ListViewColumnsSettings.RelFirstColumns, this.lvcSettings.OtmRelSelectedAttributes, new string[] { });
            ListViewColumnHelper.AddColumnsHeader(manyToOneListView, typeof(OneToManyRelationshipMetadataInfo), ListViewColumnsSettings.RelFirstColumns, this.lvcSettings.OtmRelSelectedAttributes, new string[] { });
            ListViewColumnHelper.AddColumnsHeader(manyToManyListView, typeof(ManyToManyRelationshipMetadataInfo), ListViewColumnsSettings.RelFirstColumns, this.lvcSettings.MtmRelSelectedAttributes, new string[] { });
            ListViewColumnHelper.AddColumnsHeader(privilegeListView, typeof(SecurityPrivilegeInfo), ListViewColumnsSettings.PrivFirstColumns, this.lvcSettings.PrivSelectedAttributes, new string[] { });
            ListViewColumnHelper.AddColumnsHeader(keyListView, typeof(KeyMetadataInfo), ListViewColumnsSettings.KeyFirstColumns, this.lvcSettings.KeySelectedAttributes, new string[] { });

            attributesSplitContainer.Panel2Collapsed = true;
            manyToManySplitContainer.Panel2Collapsed = true;
            manyToOneSplitContainer.Panel2Collapsed = true;
            oneToManySplitContainer.Panel2Collapsed = true;
            privilegeSplitContainer.Panel2Collapsed = true;
            keySplitContainer.Panel2Collapsed = true;

            RefreshContent(emd, components);
        }

        public event EventHandler<ColumnSettingsUpdatedEventArgs> OnColumnSettingsUpdated;

        public event EventHandler<EventArgs> OnSelectedTabChanged;

        public int SelectedTabIndex => tabControl1.SelectedIndex;

        public void RefreshColumns(ListViewColumnsSettings lvcUpdatedSettings)
        {
            if (lvcSettings.AttributeSelectedAttributes != lvcUpdatedSettings.AttributeSelectedAttributes)
            {
                lvcSettings.AttributeSelectedAttributes = (string[])lvcUpdatedSettings.AttributeSelectedAttributes.Clone();
                attributeListView.Columns.Clear();
                ListViewColumnHelper.AddColumnsHeader(attributeListView, typeof(AttributeMetadataInfo), ListViewColumnsSettings.AttributeFirstColumns, lvcSettings.AttributeSelectedAttributes, new string[] { });
                LoadAttributes(emd.Attributes);
            }

            if (lvcSettings.OtmRelSelectedAttributes != lvcUpdatedSettings.OtmRelSelectedAttributes)
            {
                lvcSettings.OtmRelSelectedAttributes = (string[])lvcUpdatedSettings.OtmRelSelectedAttributes.Clone();
                OneToManyListView.Columns.Clear();
                manyToOneListView.Columns.Clear();
                ListViewColumnHelper.AddColumnsHeader(OneToManyListView, typeof(OneToManyRelationshipMetadataInfo), ListViewColumnsSettings.RelFirstColumns, lvcSettings.OtmRelSelectedAttributes, new string[] { });
                ListViewColumnHelper.AddColumnsHeader(manyToOneListView, typeof(OneToManyRelationshipMetadataInfo), ListViewColumnsSettings.RelFirstColumns, lvcSettings.OtmRelSelectedAttributes, new string[] { });
                LoadOneToManyRelationships(emd.OneToManyRelationships);
                LoadManyToOneRelationships(emd.ManyToOneRelationships);
            }

            if (lvcSettings.MtmRelSelectedAttributes != lvcUpdatedSettings.MtmRelSelectedAttributes)
            {
                lvcSettings.MtmRelSelectedAttributes = (string[])lvcUpdatedSettings.MtmRelSelectedAttributes.Clone();
                manyToManyListView.Columns.Clear();
                ListViewColumnHelper.AddColumnsHeader(manyToManyListView, typeof(ManyToManyRelationshipMetadataInfo), ListViewColumnsSettings.RelFirstColumns, lvcSettings.MtmRelSelectedAttributes, new string[] { });
                LoadManyToManyRelationships(emd.ManyToManyRelationships);
            }

            if (lvcSettings.PrivSelectedAttributes != lvcUpdatedSettings.PrivSelectedAttributes)
            {
                lvcSettings.PrivSelectedAttributes = (string[])lvcUpdatedSettings.PrivSelectedAttributes.Clone();
                privilegeListView.Columns.Clear();
                ListViewColumnHelper.AddColumnsHeader(privilegeListView, typeof(SecurityPrivilegeInfo), ListViewColumnsSettings.PrivFirstColumns, lvcSettings.PrivSelectedAttributes, new string[] { });
                LoadPrivileges(emd.Privileges);
            }

            if (lvcSettings.KeySelectedAttributes != lvcUpdatedSettings.KeySelectedAttributes)
            {
                lvcSettings.KeySelectedAttributes = (string[])lvcUpdatedSettings.KeySelectedAttributes.Clone();
                keyListView.Columns.Clear();
                ListViewColumnHelper.AddColumnsHeader(keyListView, typeof(KeyMetadataInfo), ListViewColumnsSettings.KeyFirstColumns, lvcSettings.KeySelectedAttributes, new string[] { });
                LoadKeys(emd.Keys);
            }

            lvcSettings = lvcUpdatedSettings;
        }

        public void RefreshContent(EntityMetadata newEmd, EntityCollection components)
        {
            emd = newEmd;
            entityPropertyGrid.SelectedObject = new EntityMetadataInfo(emd);
            LoadAttributes(emd.Attributes);
            LoadOneToManyRelationships(emd.OneToManyRelationships);
            LoadManyToOneRelationships(emd.ManyToOneRelationships);
            LoadManyToManyRelationships(emd.ManyToManyRelationships);
            LoadPrivileges(emd.Privileges);
            LoadKeys(emd.Keys);
            LoadSolutions(components);
        }

        protected virtual void RaiseOnColumnSettingsUpdated(ColumnSettingsUpdatedEventArgs e)
        {
            EventHandler<ColumnSettingsUpdatedEventArgs> handler = OnColumnSettingsUpdated;

            if (handler != null)
            {
                handler(this, e);
            }
        }

        private static bool MatchAttributesByFilter(AttributeMetadata attribute, string filter)
        {
            // Demystified code for readability, knowing it can be made more compact/efficient -Jonas Rapp
            if (string.IsNullOrEmpty(filter))
            {
                return true;
            }
            if (attribute.LogicalName.Contains(filter))
            {
                return true;
            }
            if (attribute.DisplayName?.UserLocalizedLabel != null &&
                attribute.DisplayName.UserLocalizedLabel.Label.ToLower().Contains(filter))
            {
                return true;
            }
            if (attribute.MetadataId.ToString().ToLower().Contains(filter))
            {
                return true;
            }
            return false;
        }

        private void AddSecondarySubItems(Type type, string[] firstColumns, string[] selectedAttributes, object o, ListViewItem item)
        {
            if (selectedAttributes == null)
            {
                foreach (var prop in type.GetProperties().OrderBy(p => p.Name))
                {
                    if (firstColumns.Contains(prop.Name))
                        continue;

                    if (ListViewColumnsSettings.EntityAttributesToIgnore.Contains(prop.Name))
                        continue;

                    object value = null;

                    try
                    {
                        value = prop.GetValue(o, null);
                    }
                    catch
                    {
                        //MessageBox.Show(error.ToString());
                    }

                    var labelInfoValue = value as LabelInfo;
                    var managedPropertyInfoValue = value as BooleanManagedPropertyInfo;
                    var cascadeConfigurationInfoValue = value as CascadeConfigurationInfo;
                    var associatedMenuBehaviorInfoValue = value as AssociatedMenuConfigurationInfo;
                    var requiredLevelInfoValue = value as AttributeRequiredLevelManagedPropertyInfo;

                    if (labelInfoValue != null)
                    {
                        item.SubItems.Add(labelInfoValue.UserLocalizedLabel != null
                            ? labelInfoValue.UserLocalizedLabel.Label
                            : "N/A");
                    }
                    else if (managedPropertyInfoValue != null)
                    {
                        item.SubItems.Add(managedPropertyInfoValue.Value.ToString());
                    }
                    else if (requiredLevelInfoValue != null)
                    {
                        item.SubItems.Add(requiredLevelInfoValue.Value.ToString());
                    }
                    else if (cascadeConfigurationInfoValue != null || associatedMenuBehaviorInfoValue != null)
                    {
                        item.SubItems.Add("(Open row to see details)");
                    }
                    else
                    {
                        var stringArrayValue = value as String[];
                        if (stringArrayValue != null)
                        {
                            item.SubItems.Add(string.Join(",", stringArrayValue));
                            continue;
                        }

                        item.SubItems.Add(value == null ? "" : value.ToString());
                    }
                }
            }
            else
            {
                var properties = type.GetProperties();

                foreach (var attr in selectedAttributes)
                {
                    if (firstColumns.Contains(attr))
                        continue;

                    var prop = properties.First(p => p.Name == attr);

                    try
                    {
                        var value = prop.GetValue(o, null);
                        var labelInfoValue = value as LabelInfo;
                        var managedPropertyInfoValue = value as BooleanManagedPropertyInfo;
                        var cascadeConfigurationInfoValue = value as CascadeConfigurationInfo;
                        var associatedMenuBehaviorInfoValue = value as AssociatedMenuConfigurationInfo;
                        var requiredLevelInfoValue = value as AttributeRequiredLevelManagedPropertyInfo;
                        if (labelInfoValue != null)
                        {
                            item.SubItems.Add(labelInfoValue.UserLocalizedLabel != null
                                ? labelInfoValue.UserLocalizedLabel.Label
                                : "N/A");
                        }
                        else if (managedPropertyInfoValue != null)
                        {
                            item.SubItems.Add(managedPropertyInfoValue.Value.ToString());
                        }
                        else if (requiredLevelInfoValue != null)
                        {
                            item.SubItems.Add(requiredLevelInfoValue.Value.ToString());
                        }
                        else if (cascadeConfigurationInfoValue != null || associatedMenuBehaviorInfoValue != null)
                        {
                            item.SubItems.Add("(Open row to see details)");
                        }
                        else
                        {
                            item.SubItems.Add(value == null ? "" : value.ToString());
                        }
                    }
                    catch
                    {
                    }
                }
            }
        }

        private void attributeListView_DoubleClick(object sender, EventArgs e)
        {
            if (attributeListView.SelectedItems.Count == 0)
                return;

            DisplayAttributeMetadataPanel();
            attributesSplitContainer.Panel2Collapsed = false;
            tsbHideAttributePanel.Visible = true;
            tsbAttributeColumns.Visible = false;
        }

        private void attributeListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (attributeListView.SelectedItems.Count == 0)
                return;

            if (!attributesSplitContainer.Panel2Collapsed)
            {
                DisplayAttributeMetadataPanel();
            }
        }

        private void cmsAttributes_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (attributeListView.SelectedItems.Count == 0)
                return;

            var amd = (AttributeMetadataInfo)attributeListView.SelectedItems[0].Tag;

            if (e.ClickedItem == tsmiAttributesCopyLogicalName)
            {
                Clipboard.SetText(amd.LogicalName);
            }
            else if (e.ClickedItem == tsmiAttributesCopySchemaName)
            {
                Clipboard.SetText(amd.SchemaName);
            }
            else if (e.ClickedItem == copyNameForWebApiToolStripMenuItem)
            {
                if (amd.AttributeType == AttributeTypeCode.Customer || amd.AttributeType == AttributeTypeCode.Lookup || amd.AttributeType == AttributeTypeCode.Owner)
                    Clipboard.SetText($"_{amd.LogicalName}_value");
                else
                    Clipboard.SetText(amd.LogicalName);
            }
        }

        private void cmsNNRelationship_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (manyToManyListView.SelectedItems.Count == 0)
                return;

            var amd = (ManyToManyRelationshipMetadataInfo)manyToManyListView.SelectedItems[0].Tag;

            if (e.ClickedItem == tsmiRelNNCopySchemaName)
            {
                Clipboard.SetText(amd.SchemaName);
            }
            else if (e.ClickedItem == tsmiRelNNCopyEntity1NavigationProperty)
            {
                Clipboard.SetText(amd.Entity1NavigationPropertyName);
            }
            else if (e.ClickedItem == tsmiRelNNCopyEntity2NavigationProperty)
            {
                Clipboard.SetText(amd.Entity2NavigationPropertyName);
            }
        }

        private void cmsOptionSet_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == copyValueToolStripMenuItem)
            {
                Clipboard.SetText(pgOptionSet.SelectedGridItem.Label);
            }
            else if (e.ClickedItem == copyLabelToolStripMenuItem)
            {
                Clipboard.SetText(((OptionMetadataInfo)pgOptionSet.SelectedGridItem.Value).Label.UserLocalizedLabel.Label);
            }
        }

        private void cmsRelationships_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            OneToManyRelationshipMetadataInfo omrmi = null;
            if (OneToManyListView.Focused && OneToManyListView.SelectedItems.Count > 0)
            {
                omrmi = (OneToManyRelationshipMetadataInfo)OneToManyListView.SelectedItems[0].Tag;
            }
            else if (manyToOneListView.Focused && manyToOneListView.SelectedItems.Count > 0)
            {
                omrmi = (OneToManyRelationshipMetadataInfo)manyToOneListView.SelectedItems[0].Tag;
            }

            if (omrmi != null)
            {
                if (e.ClickedItem == tsmiRelationshipCopySchemaName)
                {
                    Clipboard.SetText(omrmi.SchemaName);
                }
                else if (e.ClickedItem == tsmiRelationshipCopyReferencedNavigationProperty)
                {
                    Clipboard.SetText(omrmi.ReferencedEntityNavigationPropertyName);
                }
                else if (e.ClickedItem == tsmiRelationshipCopyReferencingNavigationProperty)
                {
                    Clipboard.SetText(omrmi.ReferencingEntityNavigationPropertyName);
                }
            }
        }

        private void DisplayAttributeMetadataPanel()
        {
            var amd = (AttributeMetadataInfo)attributeListView.SelectedItems[0].Tag;
            attributePropertyGrid.SelectedObject = amd;

            bool autoExpandOptions = false;

            if (amd is PicklistAttributeMetadataInfo pami)
            {
                pgOptionSet.SelectedObject = pami.OptionSet.Options;
                scMetadata.Panel1Collapsed = false;
                autoExpandOptions = true;
            }
            else if (amd is MultiSelectPicklistAttributeMetadataInfo mspami)
            {
                pgOptionSet.SelectedObject = mspami.OptionSet.Options;
                scMetadata.Panel1Collapsed = false;
                autoExpandOptions = true;
            }
            else if (amd is StateAttributeMetadataInfo sami)
            {
                pgOptionSet.SelectedObject = sami.OptionSet.Options;
                scMetadata.Panel1Collapsed = false;
                autoExpandOptions = true;
            }
            else if (amd is StatusAttributeMetadataInfo sami2)
            {
                pgOptionSet.SelectedObject = sami2.OptionSet.Options;
                scMetadata.Panel1Collapsed = false;
                autoExpandOptions = true;
            }
            else
            {
                scMetadata.Panel1Collapsed = true;
            }

            if (autoExpandOptions)
            {
                GridItem root = pgOptionSet.SelectedGridItem;
                //Get the parent
                while (root.Parent != null)
                    root = root.Parent;

                foreach (GridItem g in root.GridItems)
                {
                    if (g.GridItemType == GridItemType.Category)
                    {
                        foreach (GridItem g2 in g.GridItems)
                        {
                            if (g2.GridItemType == GridItemType.Property && g2.Label == "Options")
                            {
                                g2.Expanded = true;
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void FilterAttributeList(object filter = null)
        {
            string filterText = filter?.ToString();
            if (filter == null)
            {
                return;
            }

            var action = new MethodInvoker(delegate
            {
                LoadAttributes(emd.Attributes, filterText.ToLower());
            });

            if (attributeListView.InvokeRequired)
            {
                attributeListView.Invoke(action);
            }
            else
            {
                action();
            }
        }

        private void FilterM2MList(object filter = null)
        {
            string filterText = filter?.ToString();
            if (filter == null)
            {
                return;
            }

            var action = new MethodInvoker(delegate
            {
                LoadManyToManyRelationships(emd.ManyToManyRelationships, filterText.ToLower());
            });

            if (manyToManyListView.InvokeRequired)
            {
                manyToManyListView.Invoke(action);
            }
            else
            {
                action();
            }
        }

        private void FilterMtoList(object filter = null)
        {
            string filterText = filter?.ToString();
            if (filter == null)
            {
                return;
            }

            var action = new MethodInvoker(delegate
            {
                LoadManyToOneRelationships(emd.ManyToOneRelationships, filterText.ToLower());
            });

            if (manyToOneListView.InvokeRequired)
            {
                manyToOneListView.Invoke(action);
            }
            else
            {
                action();
            }
        }

        private void FilterOtmList(object filter = null)
        {
            string filterText = filter?.ToString();
            if (filter == null)
            {
                return;
            }

            var action = new MethodInvoker(delegate
            {
                LoadOneToManyRelationships(emd.OneToManyRelationships, filterText.ToLower());
            });

            if (OneToManyListView.InvokeRequired)
            {
                OneToManyListView.Invoke(action);
            }
            else
            {
                action();
            }
        }

        private void keyListView_DoubleClick(object sender, EventArgs e)
        {
            if (keyListView.SelectedItems.Count == 0)
                return;

            var kmi = (KeyMetadataInfo)keyListView.SelectedItems[0].Tag;
            keyPropertyGrid.SelectedObject = kmi;
            keySplitContainer.Panel2Collapsed = false;
            tsbHideKeyPanel.Visible = true;
            tsbKeyColumns.Visible = false;
        }

        private void keyListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (keyListView.SelectedItems.Count == 0)
                return;

            if (!keySplitContainer.Panel2Collapsed)
            {
                var amd = (KeyMetadataInfo)keyListView.SelectedItems[0].Tag;
                attributePropertyGrid.SelectedObject = amd;
            }
        }

        private void listView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            var list = (ListView)sender;
            list.Sorting = list.Sorting == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
            list.ListViewItemSorter = new ListViewItemComparer(e.Column, list.Sorting);
        }

        private void LoadAttributes(IEnumerable<AttributeMetadata> attributes, string filter = null)
        {
            var items = new List<ListViewItem>();

            foreach (var attribute in attributes.OrderBy(a => a.LogicalName).Where(a => MatchAttributesByFilter(a, filter)
            ))
            {
                var amd = new AttributeMetadataInfo(attribute);
                var item = new ListViewItem(amd.LogicalName);
                item.SubItems.Add(amd.SchemaName);
                item.SubItems.Add(amd.AttributeType.ToString());
                AddSecondarySubItems(typeof(AttributeMetadataInfo), ListViewColumnsSettings.AttributeFirstColumns, lvcSettings.AttributeSelectedAttributes, amd, item);

                switch (attribute.AttributeType.Value)
                {
                    case AttributeTypeCode.Boolean:
                        {
                            item.Tag = new BooleanAttributeMetadataInfo((BooleanAttributeMetadata)attribute);
                        }
                        break;

                    case AttributeTypeCode.BigInt:
                        {
                            item.Tag = new BigIntAttributeMetadataInfo((BigIntAttributeMetadata)attribute);
                        }
                        break;

                    case AttributeTypeCode.Customer:
                    case AttributeTypeCode.Lookup:
                    case AttributeTypeCode.Owner:
                        {
                            item.Tag = new LookupAttributeMetadataInfo((LookupAttributeMetadata)attribute);
                        }
                        break;

                    case AttributeTypeCode.DateTime:
                        {
                            item.Tag = new DateTimeAttributeMetadataInfo((DateTimeAttributeMetadata)attribute);
                        }
                        break;

                    case AttributeTypeCode.Decimal:
                        {
                            item.Tag = new DecimalAttributeMetadataInfo((DecimalAttributeMetadata)attribute);
                        }
                        break;

                    case AttributeTypeCode.Double:
                        {
                            item.Tag = new DoubleAttributeMetadataInfo((DoubleAttributeMetadata)attribute);
                        }
                        break;

                    case AttributeTypeCode.EntityName:
                        {
                            item.Tag = new AttributeMetadataInfo(attribute);
                        }
                        break;

                    case AttributeTypeCode.Integer:
                        {
                            item.Tag = new IntegerAttributeMetadataInfo((IntegerAttributeMetadata)attribute);
                        }
                        break;

                    case AttributeTypeCode.ManagedProperty:
                        {
                            item.Tag =
                                new ManagedPropertyAttributeMetadataInfo((ManagedPropertyAttributeMetadata)attribute);
                        }
                        break;

                    case AttributeTypeCode.Memo:
                        {
                            item.Tag = new MemoAttributeMetadataInfo((MemoAttributeMetadata)attribute);
                        }
                        break;

                    case AttributeTypeCode.Money:
                        {
                            item.Tag = new MoneyAttributeMetadataInfo((MoneyAttributeMetadata)attribute);
                        }
                        break;

                    case AttributeTypeCode.Picklist:
                        {
                            item.Tag = new PicklistAttributeMetadataInfo((PicklistAttributeMetadata)attribute);
                        }
                        break;

                    case AttributeTypeCode.State:
                        {
                            item.Tag = new StateAttributeMetadataInfo((StateAttributeMetadata)attribute);
                        }
                        break;

                    case AttributeTypeCode.Status:
                        {
                            item.Tag = new StatusAttributeMetadataInfo((StatusAttributeMetadata)attribute);
                        }
                        break;

                    case AttributeTypeCode.String:
                        {
                            item.Tag = new StringAttributeMetadataInfo((StringAttributeMetadata)attribute);
                        }
                        break;

                    default:
                        {
                            if (attribute.AttributeTypeName == AttributeTypeDisplayName.ImageType)
                            {
                                item.Tag = new ImageAttributeMetadataInfo((ImageAttributeMetadata)attribute);
                            }
                            else if (attribute.AttributeTypeName == AttributeTypeDisplayName.FileType)
                            {
                                item.Tag = new FileAttributeMetadataInfo((FileAttributeMetadata)attribute);
                            }
                            else if (attribute is MultiSelectPicklistAttributeMetadata mspamd)
                            {
                                item.Tag = new MultiSelectPicklistAttributeMetadataInfo(mspamd);
                            }
                            else
                            {
                                item.Tag = new AttributeMetadataInfo(attribute);
                            }
                        }
                        break;
                }

                items.Add(item);
            }
            attributeListView.Items.Clear();
            attributeListView.Items.AddRange(items.ToArray());

            if (tabControl1.TabPages[1].ToolTipText == "")
            {
                tabControl1.TabPages[1].ToolTipText = tabControl1.TabPages[1].Text; 
            }
            tabControl1.TabPages[1].Text = tabControl1.TabPages[1].ToolTipText + " [" + attributeListView.Items.Count + "]";
        }

        private void LoadKeys(EntityKeyMetadata[] keys)
        {
            if (keys == null)
            {
                return;
            }

            var items = new List<ListViewItem>();

            foreach (var key in keys.OrderBy(a => a.SchemaName))
            {
                var kmi = new KeyMetadataInfo(key);

                var item = new ListViewItem(kmi.SchemaName) { Tag = kmi };
                AddSecondarySubItems(typeof(KeyMetadataInfo), ListViewColumnsSettings.KeyFirstColumns, lvcSettings.KeySelectedAttributes, kmi, item);

                items.Add(item);
            }

            keyListView.Items.Clear();
            keyListView.Items.AddRange(items.ToArray());

            if (tabControl1.TabPages[2].ToolTipText == "")
            {
                tabControl1.TabPages[2].ToolTipText = tabControl1.TabPages[2].Text;
            }
            tabControl1.TabPages[2].Text = tabControl1.TabPages[2].ToolTipText + " [" + keyListView.Items.Count + "]";
        }

        private void LoadManyToManyRelationships(IEnumerable<ManyToManyRelationshipMetadata> rels, string filter = null)
        {
            var items = new List<ListViewItem>();

            foreach (var rel in rels
                .Where(r =>
                filter == null
                || r.SchemaName.ToLower().Contains(filter?.ToLower())
                || r.Entity1LogicalName.ToLower().Contains(filter?.ToLower())
                || r.Entity1IntersectAttribute.ToLower().Contains(filter?.ToLower())
                || r.Entity2LogicalName.ToLower().Contains(filter?.ToLower())
                || r.Entity2IntersectAttribute.ToLower().Contains(filter?.ToLower())
                )
                .OrderBy(a => a.Entity2LogicalName))
            {
                var rmd = new ManyToManyRelationshipMetadataInfo(rel);

                var item = new ListViewItem(rmd.SchemaName) { Tag = rmd };
                AddSecondarySubItems(typeof(ManyToManyRelationshipMetadataInfo), ListViewColumnsSettings.RelFirstColumns, lvcSettings.MtmRelSelectedAttributes, rmd, item);

                items.Add(item);
            }

            manyToManyListView.Items.Clear();
            manyToManyListView.Items.AddRange(items.ToArray());

            if (tabControl1.TabPages[5].ToolTipText == "")
            {
                tabControl1.TabPages[5].ToolTipText = tabControl1.TabPages[5].Text;
            }
            tabControl1.TabPages[5].Text = tabControl1.TabPages[5].ToolTipText + " [" + manyToManyListView.Items.Count + "]";
        }

        private void LoadManyToOneRelationships(IEnumerable<OneToManyRelationshipMetadata> rels, string filter = null)
        {
            var items = new List<ListViewItem>();

            foreach (var rel in rels
                .Where(r =>
                filter == null
                || r.SchemaName.ToLower().Contains(filter?.ToLower())
                || r.ReferencedEntity.ToLower().Contains(filter?.ToLower())
                || r.ReferencedAttribute.ToLower().Contains(filter?.ToLower())
                || r.ReferencingEntity.ToLower().Contains(filter?.ToLower())
                || r.ReferencingAttribute.ToLower().Contains(filter?.ToLower())
                )
                .OrderBy(a => a.ReferencedAttribute))
            {
                var rmd = new OneToManyRelationshipMetadataInfo(rel);

                var item = new ListViewItem(rmd.SchemaName) { Tag = rmd };
                AddSecondarySubItems(typeof(OneToManyRelationshipMetadataInfo), ListViewColumnsSettings.RelFirstColumns, lvcSettings.OtmRelSelectedAttributes, rmd, item);

                items.Add(item);
            }

            manyToOneListView.Items.Clear();
            manyToOneListView.Items.AddRange(items.ToArray());

            if (tabControl1.TabPages[4].ToolTipText == "")
            {
                tabControl1.TabPages[4].ToolTipText = tabControl1.TabPages[4].Text;
            }
            tabControl1.TabPages[4].Text = tabControl1.TabPages[4].ToolTipText + " [" + manyToOneListView.Items.Count + "]";
        }

        private void LoadOneToManyRelationships(IEnumerable<OneToManyRelationshipMetadata> rels, string filter = null)
        {
            var items = new List<ListViewItem>();

            foreach (var rel in rels
                .Where(r =>
                filter == null
                || r.SchemaName.ToLower().Contains(filter?.ToLower())
                || r.ReferencedEntity.ToLower().Contains(filter?.ToLower())
                || r.ReferencedAttribute.ToLower().Contains(filter?.ToLower())
                || r.ReferencingEntity.ToLower().Contains(filter?.ToLower())
                || r.ReferencingAttribute.ToLower().Contains(filter?.ToLower())
                )
                .OrderBy(a => a.ReferencingEntity))
            {
                var rmd = new OneToManyRelationshipMetadataInfo(rel);

                var item = new ListViewItem(rmd.SchemaName) { Tag = rmd };
                AddSecondarySubItems(typeof(OneToManyRelationshipMetadataInfo), ListViewColumnsSettings.RelFirstColumns, lvcSettings.OtmRelSelectedAttributes, rmd, item);

                items.Add(item);
            }

            OneToManyListView.Items.Clear();
            OneToManyListView.Items.AddRange(items.ToArray());

            if (tabControl1.TabPages[3].ToolTipText == "")
            {
                tabControl1.TabPages[3].ToolTipText = tabControl1.TabPages[3].Text;
            }
            tabControl1.TabPages[3].Text = tabControl1.TabPages[3].ToolTipText + " [" + OneToManyListView.Items.Count + "]";
        }

        private void LoadPrivileges(IEnumerable<SecurityPrivilegeMetadata> privileges)
        {
            var items = new List<ListViewItem>();

            foreach (var privilege in privileges.OrderBy(a => a.Name))
            {
                var pmd = new SecurityPrivilegeInfo(privilege);

                var item = new ListViewItem(pmd.Name) { Tag = pmd };
                AddSecondarySubItems(typeof(SecurityPrivilegeInfo), ListViewColumnsSettings.PrivFirstColumns, lvcSettings.PrivSelectedAttributes, pmd, item);

                items.Add(item);
            }

            privilegeListView.Items.Clear();
            privilegeListView.Items.AddRange(items.ToArray());

            if (tabControl1.TabPages[6].ToolTipText == "")
            {
                tabControl1.TabPages[6].ToolTipText = tabControl1.TabPages[6].Text;
            }
            tabControl1.TabPages[6].Text = tabControl1.TabPages[6].ToolTipText + " [" + privilegeListView.Items.Count + "]";
        }

        private void LoadSolutions(EntityCollection components)
        {
            var items = new List<ListViewItem>();

            foreach (var component in components.Entities)
            {
                var item = new ListViewItem(component.GetAttributeValue<AliasedValue>("solution.friendlyname").Value.ToString())
                {
                    SubItems =
                    {
                        new ListViewItem.ListViewSubItem{Text =component.GetAttributeValue<AliasedValue>("solution.uniquename").Value.ToString() },
                        new ListViewItem.ListViewSubItem{Text =component.GetAttributeValue<AliasedValue>("solution.version").Value.ToString() },
                        new ListViewItem.ListViewSubItem{Text = (bool)component.GetAttributeValue<AliasedValue>("solution.ismanaged").Value ? "Managed" : "Unmanaged" },
                        new ListViewItem.ListViewSubItem{Text = emd.SchemaName },
                        new ListViewItem.ListViewSubItem{Text = component.FormattedValues.Contains("rootcomponentbehavior") ? component.FormattedValues["rootcomponentbehavior"] : "" }
                    }
                };

                items.Add(item);
            }

            lvSolutions.Items.Clear();
            lvSolutions.Items.AddRange(items.ToArray());

            if (tabControl1.TabPages[7].ToolTipText == "")
            {
                tabControl1.TabPages[7].ToolTipText = tabControl1.TabPages[7].Text;
            }
            tabControl1.TabPages[7].Text = tabControl1.TabPages[7].ToolTipText + " [" + lvSolutions.Items.Count + "]";
        }

        private void manyToManyListView_DoubleClick(object sender, EventArgs e)
        {
            if (manyToManyListView.SelectedItems.Count == 0)
                return;

            var rmd = (ManyToManyRelationshipMetadataInfo)manyToManyListView.SelectedItems[0].Tag;
            manyToManyPropertyGrid.SelectedObject = rmd;
            manyToManySplitContainer.Panel2Collapsed = false;
            tsbHideManyToManyPanel.Visible = true;
            tsbManyToManyColumns.Visible = false;
        }

        private void manyToManyListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (manyToManyListView.SelectedItems.Count == 0)
                return;

            if (!manyToManySplitContainer.Panel2Collapsed)
            {
                var amd = (ManyToManyRelationshipMetadataInfo)manyToManyListView.SelectedItems[0].Tag;
                manyToManyPropertyGrid.SelectedObject = amd;
            }
        }

        private void manyToOneListView_DoubleClick(object sender, EventArgs e)
        {
            if (manyToOneListView.SelectedItems.Count == 0)
                return;

            var rmd = (OneToManyRelationshipMetadataInfo)manyToOneListView.SelectedItems[0].Tag;
            manyToOnePropertyGrid.SelectedObject = rmd;
            manyToOneSplitContainer.Panel2Collapsed = false;
            tsbHideManyToOnePanel.Visible = true;
            tsbManyToOneColumns.Visible = false;
        }

        private void manyToOneListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (manyToOneListView.SelectedItems.Count == 0)
                return;

            if (!manyToOneSplitContainer.Panel2Collapsed)
            {
                var amd = (OneToManyRelationshipMetadataInfo)manyToOneListView.SelectedItems[0].Tag;
                manyToOnePropertyGrid.SelectedObject = amd;
            }
        }

        private void OneToManyListView_DoubleClick(object sender, EventArgs e)
        {
            if (OneToManyListView.SelectedItems.Count == 0)
                return;

            var rmd = (OneToManyRelationshipMetadataInfo)OneToManyListView.SelectedItems[0].Tag;
            OneToManyPropertyGrid.SelectedObject = rmd;
            oneToManySplitContainer.Panel2Collapsed = false;
            tsbHideOneToManyPanel.Visible = true;
            tsbOneToManyColumns.Visible = false;
        }

        private void OneToManyListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (OneToManyListView.SelectedItems.Count == 0)
                return;

            if (!oneToManySplitContainer.Panel2Collapsed)
            {
                var amd = (OneToManyRelationshipMetadataInfo)OneToManyListView.SelectedItems[0].Tag;
                OneToManyPropertyGrid.SelectedObject = amd;
            }
        }

        private void privilegeListView_DoubleClick(object sender, EventArgs e)
        {
            if (privilegeListView.SelectedItems.Count == 0)
                return;

            var rmd = (SecurityPrivilegeInfo)privilegeListView.SelectedItems[0].Tag;
            privilegePropertyGrid.SelectedObject = rmd;
            privilegeSplitContainer.Panel2Collapsed = false;
            tsbHidePrivilegePanel.Visible = true;
            tsbPrivilegeColumns.Visible = false;
        }

        private void privilegeListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (privilegeListView.SelectedItems.Count == 0)
                return;

            if (!privilegeSplitContainer.Panel2Collapsed)
            {
                var amd = (SecurityPrivilegeInfo)privilegeListView.SelectedItems[0].Tag;
                privilegePropertyGrid.SelectedObject = amd;
            }
        }

        private void TabControl1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            OnSelectedTabChanged?.Invoke(this, new EventArgs());
        }

        private void tsbColumns_Click(object sender, EventArgs e)
        {
            switch (((ToolStripButton)sender).Name)
            {
                case "tsbAttributeColumns":
                    {
                        var dialog = new ColumnSelector(typeof(AttributeMetadataInfo),
                            ListViewColumnsSettings.AttributeFirstColumns,
                            new string[] { },
                            lvcSettings.AttributeSelectedAttributes);

                        if (dialog.ShowDialog(this) == DialogResult.OK)
                        {
                            lvcSettings.AttributeSelectedAttributes = dialog.UpdatedCurrentAttributes;
                            attributeListView.Columns.Clear();
                            attributeListView.Items.Clear();

                            ListViewColumnHelper.AddColumnsHeader(attributeListView,
                                typeof(AttributeMetadataInfo),
                                ListViewColumnsSettings.AttributeFirstColumns,
                                lvcSettings.AttributeSelectedAttributes,
                                new string[] { });

                            LoadAttributes(emd.Attributes);
                        }
                    }
                    break;

                case "tsbOneToManyColumns":
                    {
                        var dialog = new ColumnSelector(typeof(OneToManyRelationshipMetadataInfo),
                            ListViewColumnsSettings.RelFirstColumns,
                            new string[] { },
                            lvcSettings.OtmRelSelectedAttributes);

                        if (dialog.ShowDialog(this) == DialogResult.OK)
                        {
                            lvcSettings.OtmRelSelectedAttributes = dialog.UpdatedCurrentAttributes;
                            OneToManyListView.Columns.Clear();
                            OneToManyListView.Items.Clear();

                            ListViewColumnHelper.AddColumnsHeader(OneToManyListView,
                                typeof(OneToManyRelationshipMetadataInfo),
                                ListViewColumnsSettings.RelFirstColumns,
                                lvcSettings.OtmRelSelectedAttributes,
                                new string[] { });

                            LoadOneToManyRelationships(emd.OneToManyRelationships);
                        }
                    }
                    break;

                case "tsbManyToOneColumns":
                    {
                        var dialog = new ColumnSelector(typeof(OneToManyRelationshipMetadataInfo),
                            ListViewColumnsSettings.RelFirstColumns,
                            new string[] { },
                            lvcSettings.OtmRelSelectedAttributes);

                        if (dialog.ShowDialog(this) == DialogResult.OK)
                        {
                            lvcSettings.OtmRelSelectedAttributes = dialog.UpdatedCurrentAttributes;
                            manyToOneListView.Columns.Clear();
                            manyToOneListView.Items.Clear();

                            ListViewColumnHelper.AddColumnsHeader(manyToOneListView,
                                typeof(OneToManyRelationshipMetadataInfo),
                                ListViewColumnsSettings.RelFirstColumns,
                                lvcSettings.OtmRelSelectedAttributes,
                                new string[] { });

                            LoadManyToOneRelationships(emd.ManyToOneRelationships);
                        }
                    }
                    break;

                case "tsbManyToManyColumns":
                    {
                        var dialog = new ColumnSelector(typeof(ManyToManyRelationshipMetadataInfo),
                            ListViewColumnsSettings.RelFirstColumns,
                            new string[] { },
                            lvcSettings.MtmRelSelectedAttributes);

                        if (dialog.ShowDialog(this) == DialogResult.OK)
                        {
                            lvcSettings.MtmRelSelectedAttributes = dialog.UpdatedCurrentAttributes;
                            manyToManyListView.Columns.Clear();
                            manyToManyListView.Items.Clear();

                            ListViewColumnHelper.AddColumnsHeader(manyToManyListView,
                                typeof(ManyToManyRelationshipMetadataInfo),
                                ListViewColumnsSettings.RelFirstColumns,
                                lvcSettings.MtmRelSelectedAttributes,
                                new string[] { });

                            LoadManyToManyRelationships(emd.ManyToManyRelationships);
                        }
                    }
                    break;

                case "tsbPrivilegeColumns":
                    {
                        var dialog = new ColumnSelector(typeof(SecurityPrivilegeInfo),
                            ListViewColumnsSettings.PrivFirstColumns,
                            new string[] { },
                            lvcSettings.PrivSelectedAttributes);

                        if (dialog.ShowDialog(this) == DialogResult.OK)
                        {
                            lvcSettings.PrivSelectedAttributes = dialog.UpdatedCurrentAttributes;
                            privilegeListView.Columns.Clear();
                            privilegeListView.Items.Clear();

                            ListViewColumnHelper.AddColumnsHeader(privilegeListView,
                                typeof(SecurityPrivilegeInfo),
                                ListViewColumnsSettings.PrivFirstColumns,
                                lvcSettings.PrivSelectedAttributes,
                                new string[] { });

                            LoadPrivileges(emd.Privileges);
                        }
                    }
                    break;

                case "tsbKeyColumns":
                    {
                        var dialog = new ColumnSelector(typeof(KeyMetadataInfo),
                            ListViewColumnsSettings.KeyFirstColumns,
                            new string[] { },
                            lvcSettings.KeySelectedAttributes);

                        if (dialog.ShowDialog(this) == DialogResult.OK)
                        {
                            lvcSettings.KeySelectedAttributes = dialog.UpdatedCurrentAttributes;
                            keyListView.Columns.Clear();
                            keyListView.Items.Clear();

                            ListViewColumnHelper.AddColumnsHeader(keyListView,
                                typeof(KeyMetadataInfo),
                                ListViewColumnsSettings.KeyFirstColumns,
                                lvcSettings.KeySelectedAttributes,
                                new string[] { });

                            LoadKeys(emd.Keys);
                        }
                    }
                    break;

                default:
                    {
                        MessageBox.Show(this, "Unexpected source for hiding panels");
                    }
                    break;
            }

            RaiseOnColumnSettingsUpdated(new ColumnSettingsUpdatedEventArgs { Settings = lvcSettings, Control = this });
        }

        private void tsbExportAttributesExcel_Click(object sender, EventArgs e)
        {
            if (attributeListView.Items.Count == 0) return;

            var sfd = new SaveFileDialog
            {
                Filter = @"Excel file (*.xlsx)|*.xlsx"
            };

            if (sfd.ShowDialog(this) == DialogResult.OK)
            {
                var builder = new Builder();
                builder.BuildFile(sfd.FileName, attributeListView, $"{emd.SchemaName} attributes", this);
            }
        }

        private void tsbExportExcelSolutions_Click(object sender, EventArgs e)
        {
            if (lvSolutions.Items.Count == 0) return;

            var sfd = new SaveFileDialog
            {
                Filter = @"Excel file (*.xlsx)|*.xlsx"
            };

            if (sfd.ShowDialog(this) == DialogResult.OK)
            {
                var builder = new Builder();
                builder.BuildFile(sfd.FileName, lvSolutions, $"{emd.SchemaName} solutions", this);
            }
        }

        private void tsbExportKeysExcel_Click(object sender, EventArgs e)
        {
            if (keyListView.Items.Count == 0) return;

            var sfd = new SaveFileDialog
            {
                Filter = @"Excel file (*.xlsx)|*.xlsx"
            };

            if (sfd.ShowDialog(this) == DialogResult.OK)
            {
                var builder = new Builder();
                builder.BuildFile(sfd.FileName, keyListView, $"{emd.SchemaName} keys", this);
            }
        }

        private void tsbExportMmRelsExcel_Click(object sender, EventArgs e)
        {
            if (manyToManyListView.Items.Count == 0) return;

            var sfd = new SaveFileDialog
            {
                Filter = @"Excel file (*.xlsx)|*.xlsx"
            };

            if (sfd.ShowDialog(this) == DialogResult.OK)
            {
                var builder = new Builder();
                builder.BuildFile(sfd.FileName, manyToManyListView, $"{emd.SchemaName} NN relationships", this);
            }
        }

        private void tsbExportMoRelsExcel_Click(object sender, EventArgs e)
        {
            if (manyToOneListView.Items.Count == 0) return;

            var sfd = new SaveFileDialog
            {
                Filter = @"Excel file (*.xlsx)|*.xlsx"
            };

            if (sfd.ShowDialog(this) == DialogResult.OK)
            {
                var builder = new Builder();
                builder.BuildFile(sfd.FileName, manyToOneListView, $"{emd.SchemaName} N1 relationships", this);
            }
        }

        private void tsbExportOmRelsExcel_Click(object sender, EventArgs e)
        {
            if (OneToManyListView.Items.Count == 0) return;

            var sfd = new SaveFileDialog
            {
                Filter = @"Excel file (*.xlsx)|*.xlsx"
            };

            if (sfd.ShowDialog(this) == DialogResult.OK)
            {
                var builder = new Builder();
                builder.BuildFile(sfd.FileName, OneToManyListView, $"{emd.SchemaName} 1N relationships", this);
            }
        }

        private void tsbExportPrivExcel_Click(object sender, EventArgs e)
        {
            if (privilegeListView.Items.Count == 0) return;

            var sfd = new SaveFileDialog
            {
                Filter = @"Excel file (*.xlsx)|*.xlsx"
            };

            if (sfd.ShowDialog(this) == DialogResult.OK)
            {
                var builder = new Builder();
                builder.BuildFile(sfd.FileName, privilegeListView, $"{emd.SchemaName} privileges", this);
            }
        }

        private void tsbHidePanel_Click(object sender, EventArgs e)
        {
            switch (((ToolStripButton)sender).Name)
            {
                case "tsbHideEntityPanel":
                    {
                        var tabPage = (TabPage)Parent;
                        var tabPagesControl = (TabControl)tabPage.Parent;

                        tabPagesControl.TabPages.Remove(tabPage);
                    }
                    break;

                case "tsbHideAttributePanel":
                    {
                        attributesSplitContainer.Panel1Collapsed = false;
                        attributesSplitContainer.Panel2Collapsed = true;
                        tsbHideAttributePanel.Visible = false;
                        tsbAttributeColumns.Visible = true;
                    }
                    break;

                case "tsbHideOneToManyPanel":
                    {
                        oneToManySplitContainer.Panel1Collapsed = false;
                        oneToManySplitContainer.Panel2Collapsed = true;
                        tsbHideOneToManyPanel.Visible = false;
                        tsbOneToManyColumns.Visible = true;
                    }
                    break;

                case "tsbHideManyToOnePanel":
                    {
                        manyToOneSplitContainer.Panel1Collapsed = false;
                        manyToOneSplitContainer.Panel2Collapsed = true;
                        tsbHideManyToOnePanel.Visible = false;
                        tsbManyToOneColumns.Visible = true;
                    }
                    break;

                case "tsbHideManyToManyPanel":
                    {
                        manyToManySplitContainer.Panel1Collapsed = false;
                        manyToManySplitContainer.Panel2Collapsed = true;
                        tsbHideManyToManyPanel.Visible = false;
                        tsbManyToManyColumns.Visible = true;
                    }
                    break;

                case "tsbHidePrivilegePanel":
                    {
                        privilegeSplitContainer.Panel1Collapsed = false;
                        privilegeSplitContainer.Panel2Collapsed = true;
                        tsbHidePrivilegePanel.Visible = false;
                        tsbPrivilegeColumns.Visible = true;
                    }
                    break;

                case "tsbHideKeyPanel":
                    {
                        keySplitContainer.Panel1Collapsed = false;
                        keySplitContainer.Panel2Collapsed = true;
                        tsbHideKeyPanel.Visible = false;
                        tsbKeyColumns.Visible = true;
                    }
                    break;

                default:
                    {
                        MessageBox.Show(this, "Unexpected source for hiding panels");
                    }
                    break;
            }
        }

        private void tsbOpenInWebApp_Click(object sender, EventArgs e)
        {
            if (attributeListView.SelectedItems.Count != 1)
            {
                return;
            }

            var amd = (AttributeMetadataInfo)attributeListView.SelectedItems[0].Tag;

            Process.Start(
              $"{connectionDetail.WebApplicationUrl}/tools/systemcustomization/attributes/manageAttribute.aspx?appSolutionId=%7bfd140aaf-4df4-11dd-bd17-0019b9312238%7d&attributeId={amd.MetadataId}&entityId={emd.MetadataId.Value}");
        }

        private void tstxtSearch_Enter(object sender, EventArgs e)
        {
            var textBox = (ToolStripTextBox)sender;
            if (textBox.ForeColor == SystemColors.InactiveCaption)
            {
                textBox.TextChanged -= tstxtSearch_TextChanged;
                textBox.ForeColor = Color.Black;
                textBox.Text = string.Empty;
                textBox.TextChanged += tstxtSearch_TextChanged;
            }
        }

        private void tstxtSearch_TextChanged(object sender, EventArgs e)
        {
            if (searchThread != null)
            {
                searchThread.Abort();
            }

            if (sender == tstxtSearchContact)
            {
                searchThread = new Thread(FilterAttributeList);
                searchThread.Start(((ToolStripTextBox)sender).Text);
            }
            else if (sender == tstxtSearchOtm)
            {
                searchThread = new Thread(FilterOtmList);
                searchThread.Start(((ToolStripTextBox)sender).Text);
            }
            else if (sender == tstxtSearchMtO)
            {
                searchThread = new Thread(FilterMtoList);
                searchThread.Start(((ToolStripTextBox)sender).Text);
            }
            else if (sender == tstxtSearchM2M)
            {
                searchThread = new Thread(FilterM2MList);
                searchThread.Start(((ToolStripTextBox)sender).Text);
            }
        }
    }
}