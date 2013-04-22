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
    /// Any component want to reflect buisiness logic layer state should register to fitting event.
    /// </summary>
    internal class AddInManager
    {
        private AddInManager() { }
        private static AddInManager internalInstance = new AddInManager();
        internal static AddInManager instance { get { return AddInManager.internalInstance; } }

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
