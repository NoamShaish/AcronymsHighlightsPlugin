using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AcronymsHighlightsPlugin.Common.Dao.Interfaces;

namespace AHPWordAddIn.common.utils
{
    internal class UpdateDocumentDetailsEventArgs : EventArgs
    {
        internal IEnumerable<IDocumentProperty> updatedDetails { get; set; }
    }
}
