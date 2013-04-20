using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AcronymsHighlightsPlugin.Common.Dao.Interfaces;

namespace DynamicDataSourceProvider.common.provider
{
    /// <summary>
    /// Interface all data source providers should implement.
    /// </summary>
    public interface IDataSourceProvider
    {
        /// <summary>
        /// List all aviable data sources in the provider.
        /// </summary>
        /// <returns>Collection of data sources types.</returns>
        ICollection<Type> providing();

        /// <summary>
        /// Get all aviable data sources in provider.
        /// </summary>
        /// <returns>Collection of IDataSources.</returns>
        ICollection<IDataSource> getAll();

        /// <summary>
        /// Get a specific data source.
        /// </summary>
        /// <param name="dataSourceType">Type of wanted data source.</param>
        /// <returns>Wanted data source if aviable.</returns>
        IDataSource get(Type dataSourceType);
    }
}
