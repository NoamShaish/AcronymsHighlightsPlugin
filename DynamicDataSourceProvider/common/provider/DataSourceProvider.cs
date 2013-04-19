using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AcronymsHighlightsPlugin.Common.Dao.Interfaces;
using DynamicDataSourceProvider.common.factory;
using DynamicDataSourceProvider.common.factory.creator;

namespace DynamicDataSourceProvider.common.provider
{
    class DataSourceProvider : IDataSourceProvider
    {
        private IFactory factory { get; set; }
        private IDocumentDetails documentDetails { get; set; }

        private DataSourceProvider() { }
                
        public static DataSourceProvider newInstance(IFactory factory, IDocumentDetails documentDetails)
        {
            if (factory == null)
            {
                throw new ArgumentNullException("factory");
            }
            if (factory.creating().Count <= 0)
            {
                throw new ArgumentException("Factory produce nothing", "factory");
            }

            DataSourceProvider provider = new DataSourceProvider();
            provider.factory = factory;
            return provider;
        }

        public ICollection<Type> providing()
        {
            IEnumerable<Type> factoryMenu = this.factory.creating().Where<Type>(
                type => typeof(IDataSource).IsAssignableFrom(type));
            return factoryMenu.ToList<Type>();
        }

        public ICollection<IDataSource> getAll()
        {
            ICollection<IDataSource> allDataSources = new LinkedList<IDataSource>();
            foreach (Type type in this.providing())
            {
                allDataSources.Add(createDataSource(type));
            }

            return allDataSources;
        }

        public IDataSource get(Type dataSourceType)
        {
            if (!typeof(IDataSource).IsAssignableFrom(dataSourceType))
            {
                throw new ArgumentException("Given type is not an IDataSource", "dataSourceType");
            }

            return createDataSource(dataSourceType);
        }

        private IDataSource createDataSource(Type type)
        {
            IDataSource newDataSource = (IDataSource)this.factory.create(type);
            if (this.documentDetails != null)
            {
                newDataSource.documentDetails = this.documentDetails;
            }
            return newDataSource;
        }
    }
}
