using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcronymsHighlightsPlugin.Common.Dao.Interfaces
{
    public interface IDataSource
    {
        String Name { get; }
        IDocumentDetails documentDetails { set; }
        IAcronym transaulate(IAcronym acronymToTransulate);
        bool hasTransulationFor(IAcronym acronym);
    }
}
