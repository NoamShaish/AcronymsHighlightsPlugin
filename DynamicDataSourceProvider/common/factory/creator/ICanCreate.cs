using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynamicDataSourceProvider.common.factory.creator
{
    public interface ICanCreate
    {
        Type creating();
        object create();
    }
}
