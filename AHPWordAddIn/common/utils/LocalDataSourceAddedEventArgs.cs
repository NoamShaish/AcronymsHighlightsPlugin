using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AcronymsHighlightsPlugin.Common.Dao.Interfaces;

namespace AHPWordAddIn.common.utils
{
    /// <summary>
    /// Arguments for add local data source event.
    /// </summary>
    internal class LocalDataSourceAddedEventArgs : EventArgs
    {
        internal IDataSource dataSource { get; set; }
    }
}
