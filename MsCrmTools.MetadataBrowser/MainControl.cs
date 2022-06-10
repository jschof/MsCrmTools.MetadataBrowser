﻿using McTools.Xrm.Connection;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Metadata.Query;
using Microsoft.Xrm.Sdk.Query;
using MsCrmTools.MetadataBrowser.AppCode;
using MsCrmTools.MetadataBrowser.AppCode.Excel;
using MsCrmTools.MetadataBrowser.AppCode.LabelMd;
using MsCrmTools.MetadataBrowser.AppCode.OptionMd;
using MsCrmTools.MetadataBrowser.AppCode.OptionSetMd;
using MsCrmTools.MetadataBrowser.Forms;
using MsCrmTools.MetadataBrowser.Helpers;
using MsCrmTools.MetadataBrowser.UserControls;
using OfficeOpenXml; // For Excel workbook
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO; // For Excel workbook FileInfo
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;

namespace MsCrmTools.MetadataBrowser
{
    public partial class MainControl : PluginControlBase, IGitHubPlugin, IHelpPlugin
    {
        private List<EntityMetadata> currentAllMetadata;
        private List<OptionSetMetadata> currentAllOptionSet;
        private bool initialized;
        private bool initialLoading = true;
        private ListViewColumnsSettings lvcSettings;
        private Thread searchThread;

        public MainControl()
        {
            InitializeComponent();
            lvcSettings = ListViewColumnsSettings.LoadSettings();
            scOptionSet.Panel2Collapsed = true;

            if (initialLoading)
            {
                // Loads listview header column for entities
                ListViewColumnHelper.AddColumnsHeader(entityListView, typeof(EntityMetadataInfo),
                    ListViewColumnsSettings.EntityFirstColumns, lvcSettings.EntitySelectedAttributes,
                    ListViewColumnsSettings.EntityAttributesToIgnore);

                ListViewColumnHelper.AddColumnsHeader(lvChoices, typeof(OptionSetMetadataInfo),
                   ListViewColumnsSettings.OptionSetFirstColumns, lvcSettings.OptionSetSelectedAttributes,
                   ListViewColumnsSettings.OptionSetAttributesToIgnore);

                initialLoading = false;
            }

            this.Enter += MainControl_Enter;
        }

        public string HelpUrl => "https://github.com/MscrmTools/MsCrmTools.MetadataBrowser/wiki";

        public string RepositoryName => "MsCrmTools.MetadataBrowser";

        public string UserName => "MscrmTools";

        public void LoadEntities(bool fromSolution = false)
        {
            List<Entity> solutions = new List<Entity>();

            if (fromSolution)
            {
                var dialog = new SolutionPicker(Service);
                if (dialog.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                solutions.AddRange(dialog.SelectedSolutions);
            }

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading Entities...",
                Work = (bw, e) =>
                {
                    // Search for all entities metadata

                    currentAllMetadata = GetEntities(solutions);
                    // return listview items
                    var items = BuildEntityItems(currentAllMetadata.ToList());

                    bw.ReportProgress(0, "Loading Choices...");
                    currentAllOptionSet = GetOptionSets(solutions);

                    items.AddRange(BuildOptionSetItems(currentAllOptionSet));

                    e.Result = items;
                },
                ProgressChanged = e =>
                {
                    SetWorkingMessage(e.UserState.ToString());
                },
                PostWorkCallBack = e =>
                {
                    entityListView.Items.Clear();
                    // Add listview items to listview
                    entityListView.Items.AddRange(((List<ListViewItem>)e.Result).Where(i => i.Tag is EntityMetadata).ToArray());

                    if (mainTabControl.TabPages[0].ToolTipText == "")
                    {
                        mainTabControl.TabPages[0].ToolTipText = mainTabControl.TabPages[0].Text;
                    }
                    mainTabControl.TabPages[0].Text = mainTabControl.TabPages[0].ToolTipText + " [" + entityListView.Items.Count + "]";

                    lvChoices.Items.Clear();
                    lvChoices.Items.AddRange(((List<ListViewItem>)e.Result).Where(i => i.Tag is OptionSetMetadata).ToArray());

                    if (mainTabControl.TabPages[1].ToolTipText == "")
                    {
                        mainTabControl.TabPages[1].ToolTipText = mainTabControl.TabPages[1].Text;
                    }
                    mainTabControl.TabPages[1].Text = mainTabControl.TabPages[1].ToolTipText + " [" + lvChoices.Items.Count + "]";
                }
            });
        }

        private static bool MatchItemsByFilter(ListViewItem item, string filterText)
        {
            // Demystified code for readability, knowing it can be made more compact/efficient -Jonas Rapp
            if (item.Tag is EntityMetadata entity)
            {
                if (entity.LogicalName.ToLower().Contains(filterText))
                {
                    return true;
                }
                if (entity.DisplayName?.UserLocalizedLabel != null &&
                    entity.DisplayName.UserLocalizedLabel.Label.ToLower().Contains(filterText))
                {
                    return true;
                }
                if (entity.MetadataId.ToString().ToLower().Contains(filterText))
                {
                    return true;
                }
            }
            else if (item.Tag is OptionSetMetadata omd)
            {
                if (omd.Name.ToLower().Contains(filterText))
                {
                    return true;
                }
                if (omd.DisplayName?.UserLocalizedLabel != null &&
                    omd.DisplayName.UserLocalizedLabel.Label.ToLower().Contains(filterText))
                {
                    return true;
                }
                if (omd.MetadataId.ToString().ToLower().Contains(filterText))
                {
                    return true;
                }
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
                    catch (Exception error)
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
                    else if (value is Color)
                    {
                        var color = (Color)value;
                        item.SubItems.Add(color.Name);
                    }
                    else
                    {
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
                        if (labelInfoValue != null)
                        {
                            item.SubItems.Add(labelInfoValue.UserLocalizedLabel != null
                                ? labelInfoValue.UserLocalizedLabel.Label
                                : "N/A");
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

        private List<ListViewItem> BuildEntityItems(IEnumerable<EntityMetadata> emds)
        {
            if (emds == null) return new List<ListViewItem>();

            var items = new List<ListViewItem>();

            // Stores each property in a listviewitem
            foreach (var metadata in emds.OrderBy(m => m.LogicalName))
            {
                var emd = new EntityMetadataInfo(metadata);

                var item = new ListViewItem(emd.LogicalName) { Tag = metadata };
                item.SubItems.Add(emd.SchemaName);
                item.SubItems.Add(emd.ObjectTypeCode.ToString(CultureInfo.InvariantCulture));
                AddSecondarySubItems(typeof(EntityMetadataInfo), ListViewColumnsSettings.EntityFirstColumns, lvcSettings.EntitySelectedAttributes, emd, item);

                items.Add(item);
            }

            return items;
        }

        private List<ListViewItem> BuildOptionSetItems(IEnumerable<OptionSetMetadata> omds)
        {
            if (omds == null) return new List<ListViewItem>();

            var items = new List<ListViewItem>();

            // Stores each property in a listviewitem
            foreach (var metadata in omds.OrderBy(m => m.Name))
            {
                var omd = new OptionSetMetadataInfo(metadata);

                var item = new ListViewItem(omd.Name) { Tag = metadata };
                AddSecondarySubItems(typeof(OptionSetMetadataInfo), ListViewColumnsSettings.OptionSetFirstColumns, lvcSettings.OptionSetSelectedAttributes, omd, item);

                items.Add(item);
            }

            return items;
        }

        private void cmsEntity_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (entityListView.SelectedItems.Count == 0) return;

            var emd = (EntityMetadata)entityListView.SelectedItems[0].Tag;

            if (e.ClickedItem == tsmiEntityCopyLogicalName)
            {
                Clipboard.SetText(emd.LogicalName);
            }
            else if (e.ClickedItem == tsmiEntityCopyLogicalCollectionName)
            {
                Clipboard.SetText(emd.LogicalCollectionName);
            }
            else if (e.ClickedItem == tsmiEntityCopySchemaName)
            {
                Clipboard.SetText(emd.SchemaName);
            }
        }

        private void cmsPicklist_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == copyValueToolStripMenuItem)
            {
                Clipboard.SetText(pgOptionSetValues.SelectedGridItem.Label);
            }
            else if (e.ClickedItem == copyDisplayNameToolStripMenuItem)
            {
                Clipboard.SetText(((OptionMetadataInfo)pgOptionSetValues.SelectedGridItem.Value).Label.UserLocalizedLabel.Label);
            }
        }

        private void entityListView_DoubleClick(object sender, EventArgs e)
        {
            if (sender == entityListView)
            {
                ExecuteMethod(LoadEntity);
            }
            else if (sender == lvChoices)
            {
                var item = lvChoices.SelectedItems.Cast<ListViewItem>().FirstOrDefault();
                if (item == null) return;

                pgOptionSet.SelectedObject = new OptionSetMetadataInfo((OptionSetMetadata)item.Tag);
                pgOptionSetValues.SelectedObject = new OptionSetMetadataInfo((OptionSetMetadata)item.Tag).Options;
                scOptionSet.Panel2Collapsed = false;
            }
        }

        private void entityListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            tsbOpenInWebApp.Enabled = mainTabControl.SelectedIndex == 0 && entityListView.SelectedItems.Count > 0 || mainTabControl.SelectedIndex == 1 && lvChoices.SelectedItems.Count > 0;
        }

        private void epc_OnColumnSettingsUpdated(object sender, ColumnSettingsUpdatedEventArgs e)
        {
            lvcSettings = (ListViewColumnsSettings)e.Settings.Clone();
            lvcSettings.SaveSettings();

            foreach (TabPage page in mainTabControl.TabPages)
            {
                if (page.TabIndex == 0 || page.TabIndex == 1) continue;
                var ctrl = ((EntityPropertiesControl)page.Controls[0]);
                if (ctrl.Name != e.Control.Name)
                {
                    ctrl.RefreshColumns(lvcSettings);
                }
            }
        }

        private void FilterItemsList(object filter = null)
        {
            if (mainTabControl.SelectedIndex == 0 && currentAllMetadata == null
                || mainTabControl.SelectedIndex == 1 && currentAllOptionSet == null)
            {
                return;
            }

            string filterText = filter?.ToString()?.ToLower();
            if (filter == null)
            {
                return;
            }

            Invoke(new Action(() =>
            {
                if (mainTabControl.SelectedIndex == 0)
                {
                    entityListView.Items.Clear();
                    entityListView.Items.AddRange(
                        BuildEntityItems(currentAllMetadata.ToList())
                        .Where(item => MatchItemsByFilter(item, filterText))
                        .ToArray());
                }
                else if (mainTabControl.SelectedIndex == 1)
                {
                    lvChoices.Items.Clear();
                    lvChoices.Items.AddRange(
                        BuildOptionSetItems(currentAllOptionSet.ToList())
                        .Where(item => MatchItemsByFilter(item, filterText))
                        .ToArray());
                }
            }));
        }

        private List<EntityMetadata> GetEntities(List<Entity> solutions)
        {
            if (solutions.Count > 0)
            {
                var components = Service.RetrieveMultiple(new QueryExpression("solutioncomponent")
                {
                    ColumnSet = new ColumnSet("objectid"),
                    NoLock = true,
                    Criteria = new FilterExpression
                    {
                        Conditions =
                        {
                            new ConditionExpression("solutionid", ConditionOperator.In,
                                solutions.Select(s => s.Id).ToArray()),
                            new ConditionExpression("componenttype", ConditionOperator.Equal, 1)
                        }
                    }
                }).Entities;

                var list = components.Select(component => component.GetAttributeValue<Guid>("objectid"))
                    .ToList();

                if (list.Count > 0)
                {
                    EntityQueryExpression entityQueryExpression = new EntityQueryExpression
                    {
                        Criteria = new MetadataFilterExpression(LogicalOperator.Or),
                        Properties = new MetadataPropertiesExpression
                        {
                            AllProperties = true
                        },
                        AttributeQuery = new AttributeQueryExpression
                        {
                            Criteria = new MetadataFilterExpression(LogicalOperator.Or)
                            {
                                Conditions =
                                {
                                    new MetadataConditionExpression("LogicalName", MetadataConditionOperator.Equals, "filterout"),
                                }
                            }
                        },
                        KeyQuery = new EntityKeyQueryExpression
                        {
                            Criteria = new MetadataFilterExpression(LogicalOperator.Or)
                            {
                                Conditions =
                                {
                                    new MetadataConditionExpression("LogicalName", MetadataConditionOperator.Equals, "filterout"),
                                }
                            }
                        },
                        RelationshipQuery = new RelationshipQueryExpression
                        {
                            Criteria = new MetadataFilterExpression(LogicalOperator.Or)
                            {
                                Conditions =
                                {
                                    new MetadataConditionExpression("SchemaName", MetadataConditionOperator.Equals, "filterout"),
                                }
                            }
                        }
                    };

                    list.ForEach(id =>
                    {
                        entityQueryExpression.Criteria.Conditions.Add(new MetadataConditionExpression("MetadataId", MetadataConditionOperator.Equals, id));
                    });

                    RetrieveMetadataChangesRequest retrieveMetadataChangesRequest = new RetrieveMetadataChangesRequest
                    {
                        Query = entityQueryExpression,
                        ClientVersionStamp = null
                    };

                    var response = (RetrieveMetadataChangesResponse)Service.Execute(retrieveMetadataChangesRequest);

                    return response.EntityMetadata.ToList();
                }

                return new List<EntityMetadata>();
            }

            EntityQueryExpression entityQueryExpression2 = new EntityQueryExpression
            {
                Properties = new MetadataPropertiesExpression
                {
                    AllProperties = true
                },
                AttributeQuery = new AttributeQueryExpression
                {
                    Criteria = new MetadataFilterExpression(LogicalOperator.Or)
                    {
                        Conditions =
                            {
                                new MetadataConditionExpression("LogicalName", MetadataConditionOperator.Equals, "filterout"),
                            }
                    }
                },
                KeyQuery = new EntityKeyQueryExpression
                {
                    Criteria = new MetadataFilterExpression(LogicalOperator.Or)
                    {
                        Conditions =
                        {
                            new MetadataConditionExpression("LogicalName", MetadataConditionOperator.Equals, "filterout"),
                        }
                    }
                },
                RelationshipQuery = new RelationshipQueryExpression
                {
                    Criteria = new MetadataFilterExpression(LogicalOperator.Or)
                    {
                        Conditions =
                        {
                            new MetadataConditionExpression("SchemaName", MetadataConditionOperator.Equals, "filterout"),
                        }
                    }
                }
            };

            RetrieveMetadataChangesRequest retrieveMetadataChangesRequest2 = new RetrieveMetadataChangesRequest
            {
                Query = entityQueryExpression2,
                ClientVersionStamp = null
            };

            var response2 = (RetrieveMetadataChangesResponse)Service.Execute(retrieveMetadataChangesRequest2);

            return response2.EntityMetadata.ToList();
        }

        private List<OptionSetMetadata> GetOptionSets(List<Entity> solutions)
        {
            var request = new RetrieveAllOptionSetsRequest();
            var response = (RetrieveAllOptionSetsResponse)Service.Execute(request);

            if (solutions.Count > 0)
            {
                var components = Service.RetrieveMultiple(new QueryExpression("solutioncomponent")
                {
                    ColumnSet = new ColumnSet("objectid"),
                    NoLock = true,
                    Criteria = new FilterExpression
                    {
                        Conditions =
                        {
                            new ConditionExpression("solutionid", ConditionOperator.In,
                                solutions.Select(s => s.Id).ToArray()),
                            new ConditionExpression("componenttype", ConditionOperator.Equal, 9)
                        }
                    }
                }).Entities;

                var list = components.Select(component => component.GetAttributeValue<Guid>("objectid"))
                    .ToList();

                if (list.Count > 0)
                {
                    return response.OptionSetMetadata.Where(o => list.Contains(o.MetadataId.Value)).OfType<OptionSetMetadata>().ToList();
                }

                return new List<OptionSetMetadata>();
            }

            return response.OptionSetMetadata.OfType<OptionSetMetadata>().ToList();
        }

        private void listView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            var list = (ListView)sender;
            list.Sorting = list.Sorting == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
            list.ListViewItemSorter = new ListViewItemComparer(e.Column, list.Sorting);
        }

        private void LoadEntity()
        {
            if (entityListView.SelectedItems.Count == 0)
                return;

            int intIdx = 0;
            int intCount = entityListView.SelectedItems.Count;

            while (intIdx < intCount)
            {
                var emd = new EntityMetadataInfo((EntityMetadata)entityListView.SelectedItems[intIdx].Tag);

                WorkAsync(new WorkAsyncInfo
                {
                    Message = "Loading Entity...",
                    AsyncArgument = emd,
                    Work = (bw, e) =>
                    {
                        var request = new RetrieveEntityRequest
                        {
                            EntityFilters = EntityFilters.All,
                            LogicalName = ((EntityMetadataInfo)e.Argument).LogicalName
                        };
                        var response = (RetrieveEntityResponse)Service.Execute(request);

                        ColumnSet cols = new ColumnSet("rootcomponentbehavior");
                        if (ConnectionDetail.OrganizationMajorVersion < 8)
                        {
                            cols = new ColumnSet();
                        }

                        var solutionComponents = Service.RetrieveMultiple(new QueryExpression("solutioncomponent")
                        {
                            NoLock = true,
                            ColumnSet = cols,
                            Criteria = new FilterExpression
                            {
                                Conditions =
                                {
                                new ConditionExpression("objectid", ConditionOperator.Equal, emd.MetadataId)
                                }
                            },
                            LinkEntities =
                            {
                            new LinkEntity
                            {
                                LinkFromEntityName =    "solutioncomponent",
                                LinkFromAttributeName = "solutionid",
                                LinkToAttributeName ="solutionid",
                                LinkToEntityName = "solution",
                                Columns = new ColumnSet("friendlyname","uniquename","version", "ismanaged"),
                                EntityAlias = "solution",
                                LinkCriteria = new FilterExpression
                                {
                                    Conditions =
                                    {
                                        new ConditionExpression("isvisible", ConditionOperator.Equal, true)
                                    }
                                }
                            }
                            }
                        });

                        var tuple = new Tuple<EntityMetadata, EntityCollection>(response.EntityMetadata, solutionComponents);

                        e.Result = tuple;
                    },
                    PostWorkCallBack = e =>
                    {
                        var tuple = (Tuple<EntityMetadata, EntityCollection>)e.Result;

                        TabPage tab;
                        if (mainTabControl.TabPages.ContainsKey(emd.SchemaName))
                        {
                            tab = mainTabControl.TabPages[emd.SchemaName];
                            ((EntityPropertiesControl)tab.Controls[0]).RefreshContent(tuple.Item1, tuple.Item2);
                        }
                        else
                        {
                            mainTabControl.TabPages.Add(emd.SchemaName, emd.SchemaName);
                            tab = mainTabControl.TabPages[emd.SchemaName];

                            var epc = new EntityPropertiesControl(tuple.Item1, tuple.Item2, lvcSettings, ConnectionDetail)
                            {
                                Dock = DockStyle.Fill,
                                Name = tuple.Item1.SchemaName
                            };
                            epc.OnSelectedTabChanged += (s, evt2) => { mainTabControl_SelectedIndexChanged(mainTabControl, new EventArgs()); };
                            epc.OnColumnSettingsUpdated += epc_OnColumnSettingsUpdated;
                            tab.Controls.Add(epc);
                            mainTabControl.SelectTab(tab);
                        }
                    }
                });

                intIdx++;
            }
        }

        private void MainControl_Enter(object sender, EventArgs e)
        {
            if (sender is MainControl control)
            {
                if (control.Service != null && !initialized)
                {
                    ExecuteMethod(LoadEntities, false);
                    initialized = true;
                }
            }
        }

        private void mainTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            tstxtFilter.Enabled = mainTabControl.SelectedIndex == 0 || mainTabControl.SelectedIndex == 1 || mainTabControl.SelectedTab.Controls[0] is EntityPropertiesControl epc && epc.SelectedTabIndex != 1;
            tsbOpenInWebApp.Enabled = mainTabControl.SelectedIndex == 0 || mainTabControl.SelectedIndex == 1 || mainTabControl.SelectedTab.Controls[0] is EntityPropertiesControl epc2 && epc2.SelectedTabIndex == 0;
            toolStripSeparator5.Visible = mainTabControl.SelectedIndex == 0 || mainTabControl.SelectedIndex == 1;
            tsbDeselectAllTables.Visible = mainTabControl.SelectedIndex == 0;
            tsbSelectAllTables.Visible = mainTabControl.SelectedIndex == 0;
            tsbSelectInverseTables.Visible = mainTabControl.SelectedIndex == 0;
            tsbViewTables.Visible = mainTabControl.SelectedIndex == 0;
            tsbExportExcel.Visible = mainTabControl.SelectedIndex == 0 || mainTabControl.SelectedIndex == 1;
            exportSelectedTablesToolStripMenuItem.Visible = mainTabControl.SelectedIndex == 0;
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            CloseTool();
        }

        private void tsbColumns_Click(object sender, EventArgs e)
        {
            switch (((ToolStripButton)sender).Name)
            {
                case "tsbEntityColumns":
                    {
                        var dialog = new ColumnSelector(typeof(EntityMetadataInfo),
                            ListViewColumnsSettings.EntityFirstColumns,
                            ListViewColumnsSettings.EntityAttributesToIgnore,
                            lvcSettings.EntitySelectedAttributes);

                        if (dialog.ShowDialog(this) == DialogResult.OK)
                        {
                            lvcSettings.EntitySelectedAttributes = dialog.UpdatedCurrentAttributes;
                            entityListView.Columns.Clear();
                            entityListView.Items.Clear();

                            ListViewColumnHelper.AddColumnsHeader(entityListView,
                                typeof(EntityMetadataInfo),
                                ListViewColumnsSettings.EntityFirstColumns,
                                lvcSettings.EntitySelectedAttributes,
                                ListViewColumnsSettings.EntityAttributesToIgnore);

                            entityListView.Items.AddRange(BuildEntityItems(currentAllMetadata).ToArray());
                        }
                    }
                    break;

                default:
                    {
                        MessageBox.Show(this, "Unexpected source for hiding panels");
                    }
                    break;
            }

            try
            {
                lvcSettings.SaveSettings();
                foreach (TabPage page in mainTabControl.TabPages)
                {
                    if (page.TabIndex == 0) continue;

                    ((EntityPropertiesControl)page.Controls[0]).RefreshColumns(lvcSettings);
                }
            }
            catch (UnauthorizedAccessException error)
            {
                MessageBox.Show(this, "An error occured while trying to save your settings: " + error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbExportExcel_Click(object sender, EventArgs e)
        {
            if (mainTabControl.SelectedIndex == 0)
            {
                if (entityListView.Items.Count == 0) return;

                var sfd = new SaveFileDialog
                {
                    Filter = @"Excel file (*.xlsx)|*.xlsx"
                };

                if (sfd.ShowDialog(this) == DialogResult.OK)
                {
                    var builder = new Builder();
                    builder.BuildFile(sfd.FileName, entityListView, "Tables", this);
                }
            }
            else
            {
                if (lvChoices.Items.Count == 0) return;

                var sfd = new SaveFileDialog
                {
                    Filter = @"Excel file (*.xlsx)|*.xlsx"
                };

                if (sfd.ShowDialog(this) == DialogResult.OK)
                {
                    var builder = new Builder();
                    builder.BuildFile(sfd.FileName, lvChoices, "Choices", this);
                }
            }
        }

        private void tsbLoadEntities_Click(object sender, EventArgs e)
        {
            ExecuteMethod(LoadEntities, false);
        }

        private void tsbOpenInWebApp_Click(object sender, EventArgs e)
        {
            if (mainTabControl.SelectedIndex == 0)
            {
                if (entityListView.SelectedItems.Count != 1)
                {
                    return;
                }

                var emd = (EntityMetadata)entityListView.SelectedItems[0].Tag;
                ConnectionDetail.OpenUrlWithBrowserProfile(new Uri($"{ConnectionDetail.WebApplicationUrl}/tools/systemcustomization/Entities/manageEntity.aspx?appSolutionId=%7bfd140aaf-4df4-11dd-bd17-0019b9312238%7d&entityId=%7b{emd.MetadataId.Value}%7d"));
            }
            else
            {
                if (lvChoices.SelectedItems.Count != 1)
                {
                    return;
                }

                var omd = (OptionSetMetadata)lvChoices.SelectedItems[0].Tag;
                ConnectionDetail.OpenUrlWithBrowserProfile(new Uri($"{ConnectionDetail.WebApplicationUrl}/tools/systemcustomization/optionset/optionset.aspx?appSolutionId=%7bfd140aaf-4df4-11dd-bd17-0019b9312238%7d&id=%7b{omd.MetadataId.Value}%7d"));
            }
        }

        private void tsmiLoadEntitiesFromSolution_Click(object sender, EventArgs e)
        {
            ExecuteMethod(LoadEntities, true);
        }

        private void tssbLoadEntities_ButtonClick(object sender, EventArgs e)
        {
            ExecuteMethod(LoadEntities, false);
        }

        private void tstxtFilter_Enter(object sender, EventArgs e)
        {
            if (tstxtFilter.ForeColor == SystemColors.InactiveCaption)
            {
                tstxtFilter.TextChanged -= tstxtFilter_TextChanged;
                tstxtFilter.ForeColor = Color.Black;
                tstxtFilter.Text = string.Empty;
                tstxtFilter.TextChanged += tstxtFilter_TextChanged;
            }

            mainTabControl.SelectedIndex = 0;
        }

        private void tstxtFilter_TextChanged(object sender, EventArgs e)
        {
            if (searchThread != null)
            {
                searchThread.Abort();
            }

            searchThread = new Thread(FilterItemsList);
            searchThread.Start(tstxtFilter.Text);
        }

        private void tsbDeselectAllTables_Click(object sender, EventArgs e)
        {
            entityListView.SelectedItems.Clear();
        }

        private void tsbSelectAllTables_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in entityListView.Items)
            {
                item.Selected = true;
            }
        }

        private void tsbSelectInverseTables_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in entityListView.Items)
            {
                if (item.Selected)
                {
                    item.Selected = false;
                }
                else
                {
                    item.Selected = true;
                }
            }
        }

        private void tsbViewTables_Click(object sender, EventArgs e)
        {
            ExecuteMethod(LoadEntity);
        }

        private void exportSelectedTablesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (entityListView.SelectedItems.Count == 0) return;

            if (mainTabControl.TabPages.Count > 2)
            {
                if (DialogResult.No == MessageBox.Show($"Existing opened tabs will be closed!\n\nAre you sure you want to continue?", "Confirm Operation", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) )
                {
                    return;
                }
            }

            var sfd = new SaveFileDialog
            {
                Filter = @"Excel file (*.xlsx)|*.xlsx"
            };

            if (sfd.ShowDialog(this) != DialogResult.OK) return;

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelPackage innerWorkBook = new ExcelPackage(new FileInfo(sfd.FileName));

            var builder = new Builder();

            builder.BuildFile(innerWorkBook, entityListView, "Tables");
            builder.BuildFile(innerWorkBook, lvChoices, "Choices");

            foreach (TabPage pgMain in mainTabControl.TabPages)
            {
                if ((pgMain.TabIndex == 0) || (pgMain.TabIndex == 1))
                {
                    continue;
                }
                else
                {
                    mainTabControl.TabPages.Remove(pgMain);
                }
            }

            int[] SelectedItems = new int[entityListView.SelectedItems.Count];
            int i = 0;

            foreach (ListViewItem item in entityListView.SelectedItems)
            {
                // lvwSelectedItems.Add((ListViewItem)item.Clone());
                SelectedItems[i] = item.Index;
                i++;
            }

            entityListView.SelectedItems.Clear();

            for (int j = 0; j < SelectedItems.Length; j++)
            {
                entityListView.Items[SelectedItems[j]].Selected = true;
                ExecuteMethod(LoadEntity);
                
                while (mainTabControl.TabPages.Count <= 2)
                { 
                    Application.DoEvents();
                }
               
                builder.BuildFile(innerWorkBook, ((EntityPropertiesControl)mainTabControl.TabPages[2].Controls[0]).attributeListView, "Columns");
                builder.BuildFile(innerWorkBook, ((EntityPropertiesControl)mainTabControl.TabPages[2].Controls[0]).keyListView, "Keys");
                builder.BuildFile(innerWorkBook, ((EntityPropertiesControl)mainTabControl.TabPages[2].Controls[0]).OneToManyListView, "OneToManyRelationships");
                builder.BuildFile(innerWorkBook, ((EntityPropertiesControl)mainTabControl.TabPages[2].Controls[0]).manyToManyListView, "ManyToManyRelationships");
//                builder.BuildFile(sfd.FileName, ((EntityPropertiesControl)mainTabControl.TabPages[2].Controls[0]).privilegeListView, "Privileges");
                builder.BuildFile(innerWorkBook, ((EntityPropertiesControl)mainTabControl.TabPages[2].Controls[0]).lvSolutions, "Solutions");

                entityListView.Items[SelectedItems[j]].Selected = false;
                mainTabControl.TabPages.RemoveAt(2);
            }

            innerWorkBook.SaveAs(new FileInfo(sfd.FileName));

            if (DialogResult.Yes == MessageBox.Show(this,
                    $"File saved to {sfd.FileName}!\n\nWould you like to open it now? (Requires Microsoft Excel)",
                    "Success", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
            {
                Process.Start("Excel.exe", $"\"{sfd.FileName}\"");
            }

        }

        private void exportOpenedTabsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog
            {
                Filter = @"Excel file (*.xlsx)|*.xlsx"
            };

            if (sfd.ShowDialog(this) != DialogResult.OK) return;

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelPackage innerWorkBook = new ExcelPackage(new FileInfo(sfd.FileName));

            var builder = new Builder();

            builder.BuildFile(innerWorkBook, entityListView, "Tables");
            builder.BuildFile(innerWorkBook, lvChoices, "Choices");

            foreach (TabPage pgMain in mainTabControl.TabPages)
            {
                if ((pgMain.TabIndex == 0) || (pgMain.TabIndex == 1))
                {
                    continue;
                }
                else
                {
                    builder.BuildFile(innerWorkBook, ((EntityPropertiesControl)pgMain.Controls[0]).attributeListView, "Columns");
                    builder.BuildFile(innerWorkBook, ((EntityPropertiesControl)pgMain.Controls[0]).keyListView, "Keys");
                    builder.BuildFile(innerWorkBook, ((EntityPropertiesControl)pgMain.Controls[0]).OneToManyListView, "OneToManyRelationships");
                    builder.BuildFile(innerWorkBook, ((EntityPropertiesControl)pgMain.Controls[0]).manyToManyListView, "ManyToManyRelationships");
                    //                builder.BuildFile(sfd.FileName, ((EntityPropertiesControl)pgMain.Controls[0]).privilegeListView, "Privileges");
                    builder.BuildFile(innerWorkBook, ((EntityPropertiesControl)pgMain.Controls[0]).lvSolutions, "Solutions");
                }
            }

            innerWorkBook.SaveAs(new FileInfo(sfd.FileName));

            if (DialogResult.Yes == MessageBox.Show(this,
                    $"File saved to {sfd.FileName}!\n\nWould you like to open it now? (Requires Microsoft Excel)",
                    "Success", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
            {
                Process.Start("Excel.exe", $"\"{sfd.FileName}\"");
            }
        }

        private void tsbExportExcel_ButtonClick(object sender, EventArgs e)
        {
            if (mainTabControl.SelectedIndex == 0)
            {
                if (entityListView.Items.Count == 0) return;

                var sfd = new SaveFileDialog
                {
                    Filter = @"Excel file (*.xlsx)|*.xlsx"
                };

                if (sfd.ShowDialog(this) == DialogResult.OK)
                {
                    var builder = new Builder();
                    builder.BuildFile(sfd.FileName, entityListView, "Tables", this);
                }
            }
            else
            {
                if (lvChoices.Items.Count == 0) return;

                var sfd = new SaveFileDialog
                {
                    Filter = @"Excel file (*.xlsx)|*.xlsx"
                };

                if (sfd.ShowDialog(this) == DialogResult.OK)
                {
                    var builder = new Builder();
                    builder.BuildFile(sfd.FileName, lvChoices, "Choices", this);
                }
            }
        }

        private void tbsCloseTabs_Click(object sender, EventArgs e)
        {
            if (mainTabControl.TabPages.Count <= 2)
            {
                MessageBox.Show($"There are no opened tabs to close!", "Unable To Perofrm Operation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (DialogResult.No == MessageBox.Show($"All tabs (except Tables & Choices) will be closed!\n\nAre you sure you want to continue?", "Confirm Operation",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                return;
            }

            foreach (TabPage pgMain in mainTabControl.TabPages)
            {
                if ((pgMain.TabIndex == 0) || (pgMain.TabIndex == 1))
                {
                    continue;
                }
                else
                {
                    mainTabControl.TabPages.Remove(pgMain);
                }
            }
        }
    }
}