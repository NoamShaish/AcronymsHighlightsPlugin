using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AHPWordAddIn.common.UserControls;

namespace AHPWordAddIn.common.GUIForms
{
    public partial class ExternalDataSourceConfiguration : Form
    {
        /* Singletone Convention */
        internal static ExternalDataSourceConfiguration instance;
        
        internal ExternalDataSourceMgr externalDataSourceMgr = new ExternalDataSourceMgr();

        /// <summary>
        /// Singletone implemintation
        /// </summary>
        /// <returns>Classe's instance</returns>
        internal static ExternalDataSourceConfiguration getExternalDataSourceConfiguration()
        {
            if (instance == null)
            {
                instance = new ExternalDataSourceConfiguration();
            }

            return instance;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        private ExternalDataSourceConfiguration()
        {
            InitializeComponent();
            initGUI();
        }

        /// <summary>
        /// Initializes GUI components
        /// </summary>
        private void initGUI()
        {
            ControlBox = false;
            pnlExDsMgr.Controls.Add(externalDataSourceMgr);
        }

        /// <summary>
        /// Closes current window
        /// </summary>
        /// <param name="sender">Irrelevant</param>
        /// <param name="e">Irrelevant</param>
        private void btnClose_Click_1(  object      sender, 
                                        EventArgs   e)
        {
            Hide();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="settings"></param>
        internal void setComponentsState(Properties.Settings settings)
        {
            externalDataSourceMgr.setComponentsState(settings);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="settings"></param>
        internal void getComponentsState(Properties.Settings settings)
        {
            externalDataSourceMgr.getComponentsState(settings);
        }
    }
}