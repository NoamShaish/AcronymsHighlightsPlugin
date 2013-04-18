using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DynamicDataSourceProvider.common.factory.creator;

namespace DynamicDataSourceProvider.common.factory
{
    public class Factory : IFactory
    {
        private Dictionary<Type, ICanCreate> creators = new Dictionary<Type, ICanCreate>();

        private Factory() { }

        public static Factory newInstance()
        {
            return new Factory();
        }

        public object create(Type type)
        {
            ICanCreate creator = this.creators[type];
            return creator.create();
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
                catch (Exception e)
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

        public static object GetDefault(Type type)
        {
            if (type.IsValueType)
            {
                return Activator.CreateInstance(type);
            }
            return null;
        }
    }
}
