using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AHPWordAddIn.common.utils
{
    internal class WordTranslatedEventArgs : EventArgs
    {
        public string word { get; set; }
        public string[] translations { get; set; }
    }
}
