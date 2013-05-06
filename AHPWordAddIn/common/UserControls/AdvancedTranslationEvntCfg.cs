using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AHPWordAddIn.common.UserControls
{
    public partial class AdvancedTranslationEvntCfg : UserControl
    {
        private MouseHoverTimerConfiguration mouseHoverTimerConfiguration = new MouseHoverTimerConfiguration();
        private MultipleMatchesConfiguration multipleMatchesConfiguration = new MultipleMatchesConfiguration();

        /// <summary>
        /// Constructor
        /// </summary>
        public AdvancedTranslationEvntCfg()
        {
            InitializeComponent();
            InitGUI();
        }

        /// <summary>
        /// Initializes the GUI components
        /// </summary>
        private void InitGUI()
        {
            pnlMouseHoverTimer.Controls.Add(mouseHoverTimerConfiguration);
            pnlMultipleMatchesCfg.Controls.Add(multipleMatchesConfiguration);
        }

        /// <summary>
        /// Gets components state
        /// </summary>
        /// <param name="settings">Application's Settings Object</param>
        internal void getComponentsState(Properties.Settings settings)
        {
            multipleMatchesConfiguration.getComponentsState(settings);
            mouseHoverTimerConfiguration.getComponentsState(settings);
        }

        /// <summary>
        /// Sets componetns state
        /// </summary>
        /// <param name="settings">Application's Settings Object</param>
        internal void setComponentsState(Properties.Settings settings)
        {
            multipleMatchesConfiguration.setComponentsState(settings);
            mouseHoverTimerConfiguration.setComponentsState(settings);
        }
    }
}