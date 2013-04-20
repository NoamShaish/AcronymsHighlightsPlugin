using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DynamicDataSourceProvider.common.factory.creator;
using System.Reflection;

namespace DynamicDataSourceProvider.common.factory
{
    /// <summary>
    /// A Proxy pattern for the IFactory interface.
    /// This proxy is filling the wraped factory with creators from an assembly.
    /// The proxy uses an AssemblyCreatorGenerator provider at creation.
    /// </summary>
    public class AssemblyBasedFactoryProxy : IFactory
    {
        /// <summary>
        /// The wraped factory.
        /// </summary>
        private IFactory factory;

        #region Factory method pattern
        /// <summary>
        /// Prevent from uncontroled creation.
        /// </summary>
        private AssemblyBasedFactoryProxy(IFactory factory)
        {
            this.factory = factory;
        }

        /// <summary>
        /// factory method.
        /// </summary>
        /// <param name="factory">The factory to wrap with the proxy.</param>
        /// <param name="generators">Assembly creator generators to be used.</param>
        /// <returns></returns>
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
        #endregion

        #region IFactory
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
        #endregion
    }
}
