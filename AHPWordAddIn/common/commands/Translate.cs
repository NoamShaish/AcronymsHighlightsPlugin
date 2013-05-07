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
    /// Command to be called when acronym translation is needed.
    /// </summary>
    internal class Translate : ICommand
    {
        #region ICommand
        public void execute()
        {
            Word.Selection selection = Globals.ThisAddIn.Application.Selection;
            if (selection != null && selection.Text != null)
            {
                string text = selection.Text.Trim().TrimEnd(Environment.NewLine.ToCharArray());
                if (!String.IsNullOrEmpty(text))
                {
                    IAcronym acronym = AcronymsHighlightFacade.instance.translate(Acronym.newInstance(text));
                    AddInManager.instance.notifyTranslation(acronym);
                }
            }
        }
        #endregion
    }
}
