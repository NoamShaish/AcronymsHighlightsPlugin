using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynamicDataSourceProvider.common.factory.creator
{
    public static class CreatorFactory
    {
        private sealed class CreatorImpl<T> : ICanCreateT<T> {
            internal Func<T> internalCreateFunc;
            internal Type internalType;

            public T create()
            {
                return internalCreateFunc();
            }

            object ICanCreate.create()
            {
                return this.internalCreateFunc();
            }

            public Type creating()
            {
                return this.internalType;
            }
        }

        public static ICanCreate create<T>(Func<T> createFunc, Type type)
        {
            return new CreatorImpl<T>() { internalCreateFunc = createFunc, internalType = type };
        }
    }
}
