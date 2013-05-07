using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Word = Microsoft.Office.Interop.Word;
using AcronymsHighlightsPlugin.Common.Dao.Interfaces;
using AHPWordAddIn.common.plugin;
using AHPWordAddIn.common.utils;
using System.Windows.Forms;

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
                IDataSource localDataSource = convertToDataSource(selection);
                AcronymsHighlightFacade.instance.localDataSources = localDataSource;
                AddInManager.instance.notifyLocalDataSorceSetup(localDataSource);
            }
            catch (ArgumentException e)
            {
                MessageBox.Show(e.Message);
            }
        }
        #endregion

        private IDataSource convertToDataSource(Word.Selection selection)
        {
            try
            {
                if (selection != null && selection.Tables != null && selection.Tables[1] != null)
                {
                    return WordTableDataSource.newInstance(selection.Tables[1]);
                }
            }
            catch (Exception e)
            {
                string a = e.Message;
            }

            throw new ArgumentException("No table selected");
        }
    }
}
