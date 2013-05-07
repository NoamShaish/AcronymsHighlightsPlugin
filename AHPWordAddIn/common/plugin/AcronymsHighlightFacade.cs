using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AcronymsHighlightsPlugin.Common.plugin;
using AcronymsHighlightsPlugin.Common.Dao.Interfaces;
using DDSP = DynamicDataSourceProvider.common.provider;
using AHPWordAddIn.common.utils;

namespace AHPWordAddIn.common.plugin
{
    /// <summary>
    /// Singelton facade to all plugin capabilties.
    /// </summary>
    internal class AcronymsHighlightFacade : IAcronymsHighlightPlugin, DDSP.IDataSourceProvider
    {
        private IAcronymsHighlightPlugin plugin;
        private DDSP.IDataSourceProvider provider;
        public IDataSource localDataSources { get; set; }

        #region Singleton
        /// <summary>
        /// Constructor initializing add in AHP and DDSP.
        /// </summary>
        private AcronymsHighlightFacade() 
        {
            this.plugin = AcronymsHighlightPlugin.newInstance();
            IDocumentDetails details = AddInManager.instance.getDocumentDetails();
            IDocumentProperty pathToDataSource = details.get(WordDocumentProperties.DataSourceLibPathPropertyName);

            if (pathToDataSource != null && !string.IsNullOrWhiteSpace(pathToDataSource.value.ToString()))
            {
                this.provider = DDSP.DynamicDataSourceProvider.newInstance(pathToDataSource.value.ToString(), details);
            }
            
            AddInManager.instance.DocumentDetailsUpdated += new EventHandler<UpdateDocumentDetailsEventArgs>(refreshDDSP);
        }

        /// <summary>
        /// The singleton instance.
        /// </summary>
        private static AcronymsHighlightFacade internalInstance = new AcronymsHighlightFacade();

        /// <summary>
        /// Entry point.
        /// </summary>
        public static AcronymsHighlightFacade instance
        {
            get {
                if (AcronymsHighlightFacade.internalInstance == null)
                {
                    AcronymsHighlightFacade.internalInstance = new AcronymsHighlightFacade();
                }

                return AcronymsHighlightFacade.internalInstance; 
            }
        }
        #endregion

        private void refreshDDSP(object sender, UpdateDocumentDetailsEventArgs args)
        {
            foreach (IDocumentProperty property in args.updatedDetails)
            {
                if (property.name.Equals(WordDocumentProperties.DataSourceLibPathPropertyName)){
                    if (!string.IsNullOrWhiteSpace(property.value.ToString()))
                    {
                        this.provider = DDSP.DynamicDataSourceProvider.newInstance(property.value.ToString(), AddInManager.instance.getDocumentDetails());
                    }

                    break;
                }
            }
        }

        #region IAcronymsHighlightPlugin
        public IAcronym translate(IAcronym acronym)
        {
            if (this.localDataSources != null)
            {
                acronym = this.localDataSources.transaulate(acronym);
            }

            return this.plugin.translate(acronym);
        }

        public void registerDataSources(ICollection<AcronymsHighlightsPlugin.Common.Dao.Interfaces.IDataSource> dataSources)
        {
            this.plugin.registerDataSources(dataSources);
        }
        #endregion

        #region IDataSourceProvider
        public ICollection<Type> providing()
        {   
            return this.provider == null ? new Type[0] : this.provider.providing();
        }

        public ICollection<IDataSource> getAll()
        {
            return this.provider == null ? new IDataSource[0] : this.provider.getAll();
        }

        public IDataSource get(Type dataSourceType)
        {
            return this.provider == null ? null : this.provider.get(dataSourceType);
        }
        #endregion
    }
}
