using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AcronymsHighlightsPlugin.Common.Dao.Interfaces;
using DynamicDataSourceProvider.common.factory;
using DynamicDataSourceProvider.common.factory.creator;

namespace DynamicDataSourceProvider.common.provider
{
    /// <summary>
    /// A basic data source provider.
    /// </summary>
    public class DataSourceProvider : IDataSourceProvider
    {
        /// <summary>
        /// Data source factory to be used.
        /// </summary>
        private IFactory factory { get; set; }

        /// <summary>
        /// Details of current document.
        /// </summary>
        private IDocumentDetails documentDetails { get; set; }

        #region Factory method pattern
        /// <summary>
        /// Prevent from uncontroled creation.
        /// </summary>
        private DataSourceProvider() { }
                
        /// <summary>
        /// Factory method.
        /// </summary>
        /// <param name="factory">Data source factory to be used.</param>
        /// <param name="documentDetails">Current document details.</param>
        /// <returns></returns>
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
            provider.documentDetails = documentDetails;
            return provider;
        }
        #endregion

        #region IDataSourceProvider
        public ICollection<Type> providing()
        {
            //Get only IDataSource implementations.
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
        #endregion

        /// <summary>
        /// Create a data source using the factory.
        /// </summary>
        /// <param name="type">Wanted data source.</param>
        /// <returns>Wanted data source if aviable.</returns>
        private IDataSource createDataSource(Type type)
        {
            IDataSource newDataSource = (IDataSource)this.factory.create(type);
            if (this.documentDetails != null)
            {
                newDataSource.DocumentDetails = this.documentDetails;
            }
            return newDataSource;
        }
    }
}
