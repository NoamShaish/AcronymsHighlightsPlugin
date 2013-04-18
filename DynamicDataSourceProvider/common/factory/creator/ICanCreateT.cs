using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynamicDataSourceProvider.common.factory.creator
{
    public interface ICanCreateT<out T> : ICanCreate
    {
        T create();
    }
}
