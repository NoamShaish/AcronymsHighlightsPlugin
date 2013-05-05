using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace AHPWordAddIn.common.UserControls
{
    public partial class MouseHoverTimerConfiguration : UserControl
    {
        /// <summary>
        /// 
        /// </summary>
        public MouseHoverTimerConfiguration()
        {
            InitializeComponent();
            InitComponents();
        }

        /// <summary>
        /// 
        /// </summary>
        private void InitComponents()
        {
            cmBxMsHvrTimer.SelectedIndex = 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="settings"></param>
        internal void getComponentsState(Properties.Settings settings)
        {
            settings.MouseHoverTimerWait = Int32.Parse(cmBxMsHvrTimer.SelectedItem.ToString()[0].ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="settings"></param>
        internal void setComponentsState(Properties.Settings settings)
        {
            string wait = settings.MouseHoverTimerWait.ToString();

            for (int index = 0; index < cmBxMsHvrTimer.Items.Count; index++)
            {
                if (Regex.IsMatch(cmBxMsHvrTimer.Items[index].ToString(),
                    wait) == true)
                {
                    cmBxMsHvrTimer.SelectedIndex = index;
                    break;
                }
            }
        }
    }
}
