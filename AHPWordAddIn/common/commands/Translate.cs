using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Word = Microsoft.Office.Interop.Word;
using AHPWordAddIn.common.plugin;
using AHPWordAddIn.common.utils;

namespace AHPWordAddIn.common.commands
{
    internal class Translate : ICommand
    {
        void execute()
        {
            Word.Selection selection = ThisAddIn.application.Selection;
            if (selection != null && !String.IsNullOrEmpty(selection.Text))
            {
                string[] translations = AcronymsHighlightBLO.instance.translate(selection.Text);
                AddInManager.instance.setSelectionTranslation(selection.Text, translations);
            }
        }
    }
}
