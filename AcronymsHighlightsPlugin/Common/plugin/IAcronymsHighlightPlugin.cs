using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AcronymsHighlightsPlugin.Common.Dao.Interfaces;

namespace AcronymsHighlightsPlugin.Common.plugin
{
    public interface IAcronymsHighlightPlugin
    {
        IAcronym translate(IAcronym acronym);
        void registerDataSources(ICollection<IDataSource> dataSources);
    }
}
