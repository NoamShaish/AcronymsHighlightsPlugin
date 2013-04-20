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
        private AddInManager() { }
        internal static AddInManager instance { get; }

        internal event EventHandler<WordTranslatedEventArgs> Translated;
        internal event EventHandler<LocalDataSourceAddedEventArgs> LocalDataSourceAdded;

        internal void setSelectionTranslation(string word, string[] translations)
        {
            this.Translated(this, new WordTranslatedEventArgs() { word = word, translations = translations });
        }

        internal void setLocalDataSource(IDataSource localDataSource)
        {
            AcronymsHighlightBLO.instance.addDataSource(localDataSource);
            this.LocalDataSourceAdded(this, new LocalDataSourceAddedEventArgs() { dataSource = localDataSource });
        }
    }
}
