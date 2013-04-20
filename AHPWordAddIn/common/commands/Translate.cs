using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Word = Microsoft.Office.Interop.Word;
using AHPWordAddIn.common.plugin;
using AHPWordAddIn.common.utils;
using AcronymsHighlightsPlugin.Common.Dao.Interfaces;
using AcronymsHighlightsPlugin.Common.Dao.Base;

namespace AHPWordAddIn.common.commands
{
    /// <summary>
    /// Translate command, to be called when acronym translation is needed.
    /// </summary>
    internal class Translate : ICommand
    {
        #region ICommand
        public void execute()
        {
            Word.Selection selection = ThisAddIn.application.Selection;
            if (selection != null && !String.IsNullOrEmpty(selection.Text))
            {
                IAcronym acronym = AcronymsHighlightFacade.instance.translate(Acronym.newInstance(selection.Text));
                AddInManager.instance.notifyTranslation(acronym);
            }
        }
        #endregion
    }
}
