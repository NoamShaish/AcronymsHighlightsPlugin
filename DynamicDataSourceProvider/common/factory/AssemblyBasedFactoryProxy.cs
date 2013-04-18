using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DynamicDataSourceProvider.common.factory.creator;
using System.Reflection;

namespace DynamicDataSourceProvider.common.factory
{
    public class AssemblyBasedFactoryProxy : IFactory
    {
        private IFactory factory;

        private AssemblyBasedFactoryProxy(IFactory factory)
        {
            this.factory = factory;
        }

        public static AssemblyBasedFactoryProxy newInstance(IFactory factory, AssemblyCreatorGenerator[] generators)
        {
            if (factory == null)
            {
                throw new NullReferenceException("Parameter 'factory' is Null");
            }

            if (generators == null)
            {
                throw new NullReferenceException("Parameter 'generator' is Null");
            }
            foreach (AssemblyCreatorGenerator generator in generators)
            {
                foreach (ICanCreateT<object> creator in generator.getCreators())
                {
                    factory.registerCreator(creator.creating(), creator);
                }
            }

            return new AssemblyBasedFactoryProxy(factory);
        }

        public object create(Type type)
        {
            return this.factory.create(type);
        }

        public bool tryCreate(Type type, out object obj)
        {
            return this.factory.tryCreate(type, out obj);
        }

        public bool isCreating(Type type)
        {
            return this.factory.isCreating(type);
        }

        public ICollection<Type> creating()
        {
            return this.factory.creating();
        }

        public void registerCreator(Type type, ICanCreate creator)
        {
            this.factory.registerCreator(type, creator);
        }

        public void registerCreator(Type type, ICanCreate creator, bool replace)
        {
            registerCreator(type, creator, replace);
        }
    }
}
