using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcronymsHighlightsPlugin.Common.plugin
{
    public class AcronymsHighlightPlugin : IAcronymsHighlightPlugin
    {
        private AcronymsHighlightPlugin() { }
        public static AcronymsHighlightPlugin newInstance()
        {
            return new AcronymsHighlightPlugin();
        }

        public string[] translate(string acronym)
        {
            throw new NotImplementedException();
        }

        public void addDataSource(Dao.Interfaces.IDataSource dataSource)
        {
            throw new NotImplementedException();
        }

        public ICollection<Dao.Interfaces.IDataSource> getAviableDataSources()
        {
            throw new NotImplementedException();
        }

        public void registerDataSources(ICollection<Dao.Interfaces.IDataSource> dataSources)
        {
            throw new NotImplementedException();
        }

        public Dao.Interfaces.IDocumentDetails documentDetais
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
