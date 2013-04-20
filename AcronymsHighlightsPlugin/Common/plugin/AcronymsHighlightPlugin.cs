using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AcronymsHighlightsPlugin.Common.Dao.Interfaces;

namespace AcronymsHighlightsPlugin.Common.plugin
{
    public class AcronymsHighlightPlugin : IAcronymsHighlightPlugin
    {
        private AcronymsHighlightPlugin() { }

        public static AcronymsHighlightPlugin newInstance()
        {
            return new AcronymsHighlightPlugin();
        }

        private ICollection<IDataSource> registeredDataSources;

        public IAcronym translate(IAcronym acronym)
        {
            foreach (IDataSource dataSource in this.registeredDataSources)
            {
                acronym = dataSource.transaulate(acronym);
            }

            return acronym;
        }

        public void registerDataSources(ICollection<Dao.Interfaces.IDataSource> dataSources)
        {
            this.registeredDataSources = dataSources;
        }
    }
}
