using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AcronymsHighlightsPlugin.Common.Dao.Interfaces;

namespace AcronymsHighlightsPlugin.Common.plugin
{
    public interface IAcronymsHighlightPlugin
    {
        string[] translate(string acronym);
        void addDataSource(IDataSource dataSource);
        ICollection<IDataSource> getAviableDataSources();
        void registerDataSources(ICollection<IDataSource> dataSources);
        IDocumentDetails documentDetais { get; set; }
    }
}
