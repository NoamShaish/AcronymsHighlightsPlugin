using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynamicDataSourceProvider.common.factory.creator
{
    /// <summary>
    /// This class is factory class of ICreator classes.
    /// The idea is to create on the fly generic creators by giving a creaton delegate.
    /// </summary>
    public static class CreatorFactory
    {
        /// <summary>
        /// This is an internal implementation of interface ICanCreateT that will be return by the factory.
        /// </summary>
        /// <typeparam name="T">Type of class the creator will create.</typeparam>
        private sealed class CreatorImpl<T> : ICanCreateT<T> {
            /// <summary>
            /// Creation delegate.
            /// </summary>
            internal Func<T> internalCreateFunc;

            /// <summary>
            /// Created type.
            /// </summary>
            internal Type internalType;

            #region ICanCreateT<T>
            public T create()
            {
                return internalCreateFunc();
            }
            #endregion

            #region ICanCreate
            object ICanCreate.create()
            {
                return this.internalCreateFunc();
            }

            public Type creating()
            {
                return this.internalType;
            }
            #endregion
        }

        /// <summary>
        /// Factory method to create creators.
        /// </summary>
        /// <typeparam name="T">Type of objects the new creator will create.</typeparam>
        /// <param name="createFunc">Creation function that the creator will use.</param>
        /// <param name="type">Type of objects the new creator will declare he create.</param>
        /// <returns></returns>
        public static ICanCreate create<T>(Func<T> createFunc, Type type)
        {
            return new CreatorImpl<T>() { internalCreateFunc = createFunc, internalType = type };
        }
    }
}
