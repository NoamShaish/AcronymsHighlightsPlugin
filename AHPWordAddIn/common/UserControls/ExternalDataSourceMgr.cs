using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using AcronymsHighlightsPlugin.Common.Dao.Interfaces;
using AHPWordAddIn.common.plugin;
using AHPWordAddIn.common.commands;
using AHPWordAddIn.common.utils;

namespace AHPWordAddIn.common.UserControls
{
    public partial class ExternalDataSourceMgr : UserControl
    {   
        /// <summary>
        /// Constructor
        /// </summary>
        public ExternalDataSourceMgr()
        {
            InitializeComponent();
            linkEvents();
        }

        /// <summary>
        /// Link object's events 
        /// </summary>
        private void linkEvents()
        {
            AddInManager.instance.DocumentDetailsUpdated += new EventHandler<UpdateDocumentDetailsEventArgs>(DocumentDetailsUpdated);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DocumentDetailsUpdated(object                          sender, 
                                            UpdateDocumentDetailsEventArgs  e)
        {
            //List<IDataSource>list = AcronymsHighlightFacade.instance.getAll() as List<IDataSource>;
            List<IDataSource> list = null;
            if (list == null)
            {
                return;
            }

            cleanDataSources();
            fillDataSources(list);
        }

        /// <summary>
        /// Fills the data sources checklist box by the given List
        /// </summary>
        /// <param name="list">List of data sources</param>
        private void fillDataSources(List<IDataSource> list)
        {
            foreach (IDataSource item in list)
            {
                if (item == null)
                {
                    continue;
                }

                chkLstBxURLAddresses.Items.Add(item.Name);
            }
        }

        /// <summary>
        /// Clears  the data sources check list box
        /// </summary>
        private void cleanDataSources()
        {
            chkLstBxURLAddresses.Items.Clear();
        }

        /// <summary>
        /// Updating the checklistbox of external datasource (enables/ disables)
        /// accoriding to the application settings.
        /// </summary>
        /// <param name="settings"></param>
        internal void setComponentsState(Properties.Settings settings)
        {
            txtBxDDSPPath.Text = settings.ExternalDSPath;
            /* Remove Comment */
            //updateExternalDSCheckBoxListByPath();
        }

        /// <summary>
        /// Gets components state
        /// </summary>
        /// <param name="settings">Application's Settings Object</param>
        internal void getComponentsState(Properties.Settings settings)
        {
            settings.ExternalDSPath = txtBxDDSPPath.Text;
        }

        /// <summary>
        /// This event assits the user with finding his data sources DLLs
        /// </summary>
        /// <param name="sender">Irrelevant</param>
        /// <param name="e">Irrelevant</param>
        private void btnBrowse_Click(   object      sender, 
                                        EventArgs   e)
        {
            string folderPath = "";
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.SelectedPath = "C:\\";
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                folderPath = folderBrowserDialog.SelectedPath;
            }
            txtBxDDSPPath.Text = folderPath;
        }

        /// <summary>
        /// Thise event updates the data sources working directory
        /// </summary>
        /// <param name="sender">Irrelevant</param>
        /// <param name="e">Irrelevant</param>
        private void btnFetch_Click(object      sender, 
                                    EventArgs   e)
        {
            /* Remove Comment */
            //updateExternalDSCheckBoxListByPath();
        }

        /// <summary>
        /// Updates Checklistbox with the data sources that located in 
        /// the wirtten path in the "Working Directory" path
        /// </summary>
        private void updateExternalDSCheckBoxListByPath()
        {
            String valueInTextBox = txtBxDDSPPath.Text;
            ICollection<IDocumentProperty> props = new LinkedList<IDocumentProperty>();
            props.Add(new WordDocumentProperty()
            {
                name = WordDocumentProperties.DataSourceLibPathPropertyName,
                value = valueInTextBox
            });
            new UpdateDocumentDetails(props).execute();
        }
    }
}