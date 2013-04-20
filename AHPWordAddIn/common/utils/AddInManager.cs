using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AcronymsHighlightsPlugin.Common.Dao.Interfaces;
using AHPWordAddIn.common.plugin;

namespace AHPWordAddIn.common.utils
{
    internal class AddInManager
    {
        internal static readonly string DataSourceLibPathPropertyName = "dataSourceLibPath";

        private AddInManager() { }
        internal static AddInManager instance { get; private set; }

        internal event EventHandler<WordTranslatedEventArgs> Translated;
        internal event EventHandler<LocalDataSourceAddedEventArgs> LocalDataSourceAdded;

        internal void notifyTranslation(IAcronym acronym)
        {
            this.Translated(this, new WordTranslatedEventArgs() { acronym = acronym });
        }

        internal void notifyLocalDataSorceSetup(IDataSource localDataSource)
        {
            this.LocalDataSourceAdded(this, new LocalDataSourceAddedEventArgs() { dataSource = localDataSource });
        }

        internal static IDocumentDetails getDocumentDetails()
        {
            throw new NotImplementedException();
        }
    }
}
