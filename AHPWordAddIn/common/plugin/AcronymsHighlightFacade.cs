﻿using System;
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
    /// singelton facade to all plugin capabilties.
    /// </summary>
    internal class AcronymsHighlightFacade : IAcronymsHighlightPlugin, DDSP.IDataSourceProvider
    {
        private IAcronymsHighlightPlugin plugin;
        private DDSP.IDataSourceProvider provider;
        public IDataSource localDataSources { get; set; }

        #region Singleton
        private AcronymsHighlightFacade() 
        {
            this.plugin = AcronymsHighlightPlugin.newInstance();
            IDocumentDetails details = AddInManager.getDocumentDetails();
            this.provider = DDSP.DynamicDataSourceProvider.newInstance(details.get(AddInManager.DataSourceLibPathPropertyName).ToString(), details);
        }

        private static AcronymsHighlightFacade internalInstance = new AcronymsHighlightFacade();

        public static AcronymsHighlightFacade instance
        {
            get { return AcronymsHighlightFacade.internalInstance; }
        }
        #endregion

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
            return this.provider.providing();
        }

        public ICollection<IDataSource> getAll()
        {
            return this.provider.getAll();
        }

        public IDataSource get(Type dataSourceType)
        {
            return this.provider.get(dataSourceType);
        }
        #endregion
    }
}