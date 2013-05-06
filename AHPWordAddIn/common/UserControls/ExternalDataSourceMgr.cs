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
    public partial class ExternalDataSourceMgr : UserControl
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public ExternalDataSourceMgr()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Updating the checklistbox of external datasource (enables/ disables)
        /// accoriding to the application settings.
        /// </summary>
        /// <param name="settings"></param>
        internal void setComponentsState(Properties.Settings settings)
        {
            
            for(int index = 0; index < chkLstBxURLAddresses.Items.Count; index++)
            {
                foreach(object item in settings.ExternalDS)
                {
                    if (item == null)
                    {
                        continue;
                    }
                    if (chkLstBxURLAddresses.Items[index].ToString().Equals(item.ToString()) == true)
                    {
                        chkLstBxURLAddresses.SetItemChecked(index, true);
                    }
                    else
                    {
                        chkLstBxURLAddresses.SetItemChecked(index, false);
                    }
                }
            }
        }

        /// <summary>
        /// Gets components state
        /// </summary>
        /// <param name="settings">Application's Settings Object</param>
        internal void getComponentsState(Properties.Settings settings)
        {
            int index = 0;
            settings.ExternalDS.Clear();
            foreach(object item in chkLstBxURLAddresses.CheckedItems)
            {
                if (item == null)
                {
                    continue;
                }

                settings.ExternalDS.Insert(index, item.ToString());
                index++;
            }

        }
    }
}