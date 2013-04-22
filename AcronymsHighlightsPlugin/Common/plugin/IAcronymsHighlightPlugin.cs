using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AcronymsHighlightsPlugin.Common.Dao.Interfaces;

namespace AcronymsHighlightsPlugin.Common.plugin
{
    /// <summary>
    /// Acronyms highlight plugin API
    /// </summary>
    public interface IAcronymsHighlightPlugin
    {
        /// <summary>
        /// Translate a given acronym by registered data sources.
        /// </summary>
        /// <param name="acronym">Acronym to be translated.</param>
        /// <returns>Translated Acronym.</returns>
        IAcronym translate(IAcronym acronym);

        /// <summary>
        /// register a data source to be used for translation
        /// </summary>
        /// <param name="dataSources">Collection of data sources to be used.</param>
        void registerDataSources(ICollection<IDataSource> dataSources);
    }
}
