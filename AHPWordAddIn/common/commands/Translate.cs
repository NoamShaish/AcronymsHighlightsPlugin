using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Word = Microsoft.Office.Interop.Word;
using AHPWordAddIn.common.plugin;

namespace AHPWordAddIn.common.commands
{
    internal class Translate : ICommand
    {
        void execute()
        {
            Word.Selection selection = ThisAddIn.application.Selection;
            if (selection != null && !String.IsNullOrEmpty(selection.Text))
            {
                AcronymsHighlightBLO.instance.translate(selection.Text);
            }
        }
    }
}
