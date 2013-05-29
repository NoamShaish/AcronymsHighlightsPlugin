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
        /// Constructor
        /// </summary>
        public MultipleMatchesConfiguration()
        {
            InitializeComponent();
            InitComponents();
        }

        /// <summary>
        /// Initilizes components
        /// </summary>
        private void InitComponents()
        {
            cmBxNumResults.SelectedIndex = 0;
        }

        /// <summary>
        /// Gets components state
        /// </summary>
        /// <param name="settings">Application's Settings Object</param>
        internal void getComponentsState(Properties.Settings settings)
        {
            settings.NumOfMultipleTranslations = Int32.Parse(cmBxNumResults.SelectedItem.ToString()[0].ToString());
        }

        /// <summary>
        /// Sets components state
        /// </summary>
        /// <param name="settings">Application's Settings Object</param>
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

        /// <summary>
        /// Returns the allowed amount of translations
        /// </summary>
        /// <returns>The allowed amount of translations</returns>
        internal int getNumberOfTranslations()
        {
            return Int32.Parse(cmBxNumResults.SelectedItem.ToString()[0].ToString());
        }
    }
}