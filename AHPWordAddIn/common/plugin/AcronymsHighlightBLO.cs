using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AcronymsHighlightsPlugin.Common.plugin;

namespace AHPWordAddIn.common.plugin
{
    internal class AcronymsHighlightBLO : IAcronymsHighlightPlugin
    {
        private IAcronymsHighlightPlugin plugin;
        private AcronymsHighlightBLO() 
        {
            this.plugin = AcronymsHighlightPlugin.newInstance();
        }
        private static AcronymsHighlightBLO internalInstance = new AcronymsHighlightBLO();

        public static AcronymsHighlightBLO instance
        {
            get { return AcronymsHighlightBLO.internalInstance; }
        }

        public string[] translate(string acronym)
        {
            return this.plugin.translate(acronym);
        }

        public void addDataSource(AcronymsHighlightsPlugin.Common.Dao.Interfaces.IDataSource dataSource)
        {
            this.addDataSource(dataSource);
        }

        public ICollection<AcronymsHighlightsPlugin.Common.Dao.Interfaces.IDataSource> getAviableDataSources()
        {
            return this.plugin.getAviableDataSources();
        }

        public void registerDataSources(ICollection<AcronymsHighlightsPlugin.Common.Dao.Interfaces.IDataSource> dataSources)
        {
            this.plugin.registerDataSources(dataSources);
        }

        public AcronymsHighlightsPlugin.Common.Dao.Interfaces.IDocumentDetails documentDetais
        {
            get
            {
                return this.plugin.documentDetais;
            }
            set
            {
                this.plugin.documentDetais = value;
            }
        }
    }
}
