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
    public partial class AdvancedTranslationConfiguration : Form
    {
        /* Singletone Convention */
        private static AdvancedTranslationConfiguration instance = null;

        AdvancedTranslationEvntCfg advancedTranslationEvntCfg = new AdvancedTranslationEvntCfg();

        /* Singletone implemintation */
        internal static AdvancedTranslationConfiguration getAdvancedTranslationConfiguration()
        {
            if (instance == null)
            {
                instance = new AdvancedTranslationConfiguration();
            }

            return instance;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        private AdvancedTranslationConfiguration()
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
            pnlMain.Controls.Add(advancedTranslationEvntCfg);
        }

        /// <summary>
        /// Closes current window
        /// </summary>
        /// <param name="sender">Irrelevant</param>
        /// <param name="e">Irrelevant</param>
        private void btnClose_Click(object      sender, 
                                    EventArgs   e)
        {
            Hide();
        }

        /// <summary>
        /// Gets components' state
        /// </summary>
        /// <param name="settings">Application's Settings Object</param>
        internal void getComponentsState(Properties.Settings settings)
        {
            advancedTranslationEvntCfg.getComponentsState(settings);
        }

        /// <summary>
        /// Sets components' state
        /// </summary>
        /// <param name="settings">Application's Settings Object</param>
        internal void setComponentsState(Properties.Settings settings)
        {
            advancedTranslationEvntCfg.setComponentsState(settings);
        }

        internal int getNumberOfTranslations()
        {
            return advancedTranslationEvntCfg.getNumberOfTranslations();
        }
    }
}
