using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Word = Microsoft.Office.Interop.Word;
using AcronymsHighlightsPlugin.Common.Dao.Interfaces;
using AHPWordAddIn.common.plugin;
using AHPWordAddIn.common.utils;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;

namespace AHPWordAddIn.common.commands
{
    /// <summary>
    /// Command to be called when local data source is setup.
    /// </summary>
    internal class AddLocalDataSource : ICommand
    {
        #region ICommand
        public void execute()
        {
            Word.Selection selection = Globals.ThisAddIn.Application.Selection;
            try
            {
                Table table = getTable(selection);
                if (AcronymsHighlightFacade.instance.localDataSources == null)
                {
                    IDataSource localDataSource = WordTableDataSource.newInstance(selection.Tables[1]);
                    AcronymsHighlightFacade.instance.localDataSources = localDataSource;
                }
                else
                {
                    ((WordTableDataSource)AcronymsHighlightFacade.instance.localDataSources).extand(table);
                }

                AddInManager.instance.notifyLocalDataSorceSetup(AcronymsHighlightFacade.instance.localDataSources);
                MessageBox.Show("Local data source was successfully setup.");
            }
            catch (ArgumentException e)
            {
                MessageBox.Show(e.Message);
            }
        }
        #endregion

        private Table getTable(Selection selection)
        {
            if (selection != null && selection.Tables != null && selection.Tables[1] != null)
            {
                return selection.Tables[1];
            }

            throw new ArgumentException("No table selected");
        }
    }
}
