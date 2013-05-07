using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DynamicDataSourceProvider.common.factory.creator;

namespace DynamicDataSourceProvider.common.factory
{
    /// <summary>
    /// Factory pattern.
    /// </summary>
    public class Factory : IFactory
    {
        /// <summary>
        /// Creators mapping.
        /// </summary>
        private Dictionary<Type, ICanCreate> creators = new Dictionary<Type, ICanCreate>();

        #region Factory method pattern
        /// <summary>
        /// Prevent from uncontroled creation.
        /// </summary>
        private Factory() { }

        // <summary>
        /// Factory method implementation.
        /// </summary>
        /// <returns>New instance of factory.</returns>
        public static Factory newInstance()
        {
            return new Factory();
        }
        #endregion


        #region IFactory
        public object create(Type type)
        {
            ICanCreate creator = this.creators[type];
            return creator == null ? null : creator.create();
        }

        public bool tryCreate(Type type, out object obj)
        {
            bool result = false;
            obj = GetDefault(type);
            if (this.creators.ContainsKey(type))
            {
                try
                {
                    obj = this.create(type);
                    result = true;
                }
                catch (Exception)
                {
                    obj = GetDefault(type);
                    result = false;
                }
            }

            return result;
        }

        public bool isCreating(Type type)
        {
            return this.creators.ContainsKey(type);
        }

        public ICollection<Type> creating()
        {
            return this.creators.Keys;
        }

        public void registerCreator(Type type, creator.ICanCreate creator)
        {
            this.creators[type] = creator;
        }

        public void registerCreator(Type type, creator.ICanCreate creator, bool replace)
        {
            if (!this.isCreating(type) || replace)
            {
                this.creators[type] = creator;
            }
        }
        #endregion

        /// <summary>
        /// Utility method to get the default value.
        /// If type is of class return null, if type of value return default value.
        /// </summary>
        /// <param name="type">Type to get default for.</param>
        /// <returns>Default value of type.</returns>
        private static object GetDefault(Type type)
        {
            if (type.IsValueType)
            {
                return Activator.CreateInstance(type);
            }
            return null;
        }
    }
}
