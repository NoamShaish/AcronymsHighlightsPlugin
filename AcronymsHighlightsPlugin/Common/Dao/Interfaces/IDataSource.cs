using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcronymsHighlightsPlugin.Common.Dao.Interfaces
{
    /// <summary>
    /// Contract any data source must accept.
    /// </summary>
    public interface IDataSource
    {
        /// <summary>
        /// Name of data source. 
        /// Should be informative.
        /// </summary>
        String Name { get; }

        /// <summary>
        /// Ability to add information regarding spcific document.
        /// </summary>
        IDocumentDetails documentDetails { set; }

        /// <summary>
        /// Translate an acronym.
        /// </summary>
        /// <param name="acronym">Acronym to be translated.</param>
        /// <returns>A translated acronym.</returns>
        IAcronym transaulate(IAcronym acronym);

        /// <summary>
        /// Information if data source can translate a given acronym.
        /// </summary>
        /// <param name="acronym">Acronym to be checked.</param>
        /// <returns>True if data source contain a translation for given acronym.</returns>
        bool hasTransulationFor(IAcronym acronym);
    }
}
