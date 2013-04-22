using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AcronymsHighlightsPlugin.Common.Dao.Interfaces;

namespace AcronymsHighlightsPlugin.Common.plugin
{
    /// <summary>
    /// Basic acronym highligh plugin implementation.
    /// </summary>
    public class AcronymsHighlightPlugin : IAcronymsHighlightPlugin
    {
        /// <summary>
        /// Corrent registered data sources.
        /// </summary>
        private ICollection<IDataSource> registeredDataSources;

        #region Factory method pattern
        /// <summary>
        /// Prevent from uncontroled creation.
        /// </summary>
        private AcronymsHighlightPlugin() { }

        /// <summary>
        /// Factory method.
        /// </summary>
        /// <returns>New instance of AcronymsHighlightPlugin.</returns>
        public static AcronymsHighlightPlugin newInstance()
        {
            return new AcronymsHighlightPlugin();
        }
        #endregion

        #region IAcronymsHighlightPlugin
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
        #endregion
    }
}
