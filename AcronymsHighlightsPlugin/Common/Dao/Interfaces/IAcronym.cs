using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace AcronymsHighlightsPlugin.Common.Dao.Interfaces
{
    /// <summary>
    /// Contract any acronym must accept.
    /// </summary>
    public interface IAcronym
    {
        /// <summary>
        /// Actual acronym text.
        /// </summary>
        String Text { get; }

        /// <summary>
        /// Acronym translations.
        /// </summary>
        ICollection<String> Transulations { get; }

        /// <summary>
        /// Information if acronym is translated.
        /// isTrunslated() = true => Transulations.length = 0.
        /// </summary>
        /// <returns>True if no translations exists for acronym.</returns>
        Boolean isTrunslated();

        /// <summary>
        /// Clear all existing translations for acronym.
        /// After call Transulations.length = 0.
        /// </summary>
        void clearTransulations();
    }
}
