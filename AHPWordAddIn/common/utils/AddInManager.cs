using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AcronymsHighlightsPlugin.Common.Dao.Interfaces;
using AHPWordAddIn.common.plugin;

namespace AHPWordAddIn.common.utils
{
    /// <summary>
    /// Add in controller.
    /// This singelton provide events to business logic layer logical events.
    /// Any component that want to reflect buisiness logic layer state should register to fitting event.
    /// </summary>
    internal class AddInManager
    {
        private AddInManager() { }
        private static AddInManager internalInstance = new AddInManager();
        internal static AddInManager instance
        {
            get
            {
                if (AddInManager.internalInstance == null)
                {
                    AddInManager.internalInstance = new AddInManager();
                }
                
                return AddInManager.internalInstance;
            }
        }

        internal event EventHandler<WordTranslatedEventArgs> Translated;
        internal event EventHandler<LocalDataSourceAddedEventArgs> LocalDataSourceAdded;

        internal void notifyTranslation(IAcronym acronym)
        {
            if (this.Translated != null)
            {
                this.Translated(this, new WordTranslatedEventArgs() { acronym = acronym });
            }
        }
        

        internal void notifyLocalDataSorceSetup(IDataSource localDataSource)
        {
            if (this.LocalDataSourceAdded != null)
            {
                this.LocalDataSourceAdded(this, new LocalDataSourceAddedEventArgs() { dataSource = localDataSource });
            }
        }

        internal static IDocumentDetails getDocumentDetails()
        {
            WordDocumentProperties documentProperties = new WordDocumentProperties();
            documentProperties.set(new WordDocumentProperty() { name = WordDocumentProperties.DataSourceLibPathPropertyName, value = "D:\\Work Station\\lib" });
            return documentProperties;
        }
    }
}
