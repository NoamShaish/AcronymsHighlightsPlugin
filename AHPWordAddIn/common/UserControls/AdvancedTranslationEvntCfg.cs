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
        /// 
        /// </summary>
        public AdvancedTranslationEvntCfg()
        {
            InitializeComponent();
            InitGUI();
        }

        /// <summary>
        /// 
        /// </summary>
        private void InitGUI()
        {
            pnlMouseHoverTimer.Controls.Add(mouseHoverTimerConfiguration);
            pnlMultipleMatchesCfg.Controls.Add(multipleMatchesConfiguration);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="settings"></param>
        internal void getComponentsState(Properties.Settings settings)
        {
            multipleMatchesConfiguration.getComponentsState(settings);
            mouseHoverTimerConfiguration.getComponentsState(settings);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="settings"></param>
        internal void setComponentsState(Properties.Settings settings)
        {
            multipleMatchesConfiguration.setComponentsState(settings);
            mouseHoverTimerConfiguration.setComponentsState(settings);
        }
    }
}
