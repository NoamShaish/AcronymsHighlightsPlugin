using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcronymsHighlightsPlugin.Common.Dao.Interfaces
{
    public interface IDocumentProperty
    {
        String name { get; set; }
        Object value { get; set; }
    }
}
