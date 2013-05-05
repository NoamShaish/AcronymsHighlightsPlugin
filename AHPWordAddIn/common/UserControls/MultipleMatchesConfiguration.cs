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
    public partial class MultipleMatchesConfiguration : UserControl
    {
        /// <summary>
        /// 
        /// </summary>
        public MultipleMatchesConfiguration()
        {
            InitializeComponent();
            InitComponents();
        }

        /// <summary>
        /// 
        /// </summary>
        private void InitComponents()
        {
            cmBxNumResults.SelectedIndex = 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="settings"></param>
        internal void getComponentsState(Properties.Settings settings)
        {
            settings.NumOfMultipleTranslations = Int32.Parse(cmBxNumResults.SelectedItem.ToString()[0].ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="settings"></param>
        internal void setComponentsState(Properties.Settings settings)
        {
            string numOfTrans = settings.NumOfMultipleTranslations.ToString();

            for (int index = 0; index < cmBxNumResults.Items.Count; index++)
            {
                if (Regex.IsMatch(cmBxNumResults.Items[index].ToString(),
                    numOfTrans) == true)
                {
                    cmBxNumResults.SelectedIndex = index;
                    break;
                }
            }
        }
    }
}
