using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AcronymsHighlightsPlugin.Common.Dao.Interfaces;

namespace DynamicDataSourceProvider.common.provider
{
    public interface IDataSourceProvider
    {
        ICollection<Type> providing();
        ICollection<IDataSource> getAll();
        IDataSource get(Type dataSourceType);
    }
}
