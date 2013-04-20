using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Word = Microsoft.Office.Interop.Word;
using AcronymsHighlightsPlugin.Common.Dao.Interfaces;
using AHPWordAddIn.common.plugin;
using AHPWordAddIn.common.utils;

namespace AHPWordAddIn.common.commands
{
    internal class AddLocalDataSource : ICommand
    {
        public void execute()
        {
            Word.Selection selection = ThisAddIn.application.Selection;
            IDataSource localDataSource = convertToDataSource(selection);
            AddInManager.instance.setLocalDataSource(localDataSource);
        }

        private IDataSource convertToDataSource(Word.Selection selection)
        {
            throw new NotImplementedException();
        }
    }
}
