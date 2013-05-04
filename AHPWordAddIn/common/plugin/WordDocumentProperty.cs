using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AcronymsHighlightsPlugin.Common.Dao.Interfaces;

namespace AHPWordAddIn.common.plugin
{
    internal class WordDocumentProperty : IDocumentProperty
    {
        public string name { get; set; }

        public object value { get; set; }
    }
}
