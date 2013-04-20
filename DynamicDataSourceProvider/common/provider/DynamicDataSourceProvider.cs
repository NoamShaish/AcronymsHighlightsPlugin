using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DynamicDataSourceProvider.common.factory.creator;
using System.Reflection;
using DynamicDataSourceProvider.common.factory;
using AcronymsHighlightsPlugin.Common.Dao.Interfaces;
using System.IO;

namespace DynamicDataSourceProvider.common.provider
{
    /// <summary>
    /// DynamicDataSourceProvider provide data sources from external dll's.
    /// </summary>
    public class DynamicDataSourceProvider : IDataSourceProvider
    {
        #region Factory method pattern
        /// <summary>
        /// Prevent from uncontroled creation.
        /// </summary>
        private DynamicDataSourceProvider(IDataSourceProvider provider) 
        {
            this.provider = provider;
        }
        
        /// <summary>
        /// Creates new instance of DynamicDataSourceProvider.
        /// </summary>
        /// <param name="pathToDataSourceLib">Path to librery where data sources will be loaded from.</param>
        /// <param name="documentDetails">Current document details.</param>
        /// <returns></returns>
        public static DynamicDataSourceProvider newInstance(string pathToDataSourceLib, IDocumentDetails documentDetails)
        {
            if (String.IsNullOrEmpty(pathToDataSourceLib.Trim()))
            {
                throw new ArgumentException("No path is provided for data sources", "pathToDataSourceLib");
            }
            Assembly[] assemblies = getAssemblies(pathToDataSourceLib);
            AssemblyCreatorGenerator[] generators = getGenerators(assemblies);
            AssemblyBasedFactoryProxy factory = AssemblyBasedFactoryProxy.newInstance(Factory.newInstance(), generators);
            return new DynamicDataSourceProvider(DataSourceProvider.newInstance(factory, documentDetails));
        }
        #endregion

        /// <summary>
        /// Wraped DataSourceProvider
        /// </summary>
        private IDataSourceProvider provider { get; set; }

        /// <summary>
        /// Retrive AssemblyCreatorGenerators for assemblies.
        /// </summary>
        /// <param name="assemblies">Array of assemblies to create generators for.</param>
        /// <returns>Creator generators for given assemblies.</returns>
        private static AssemblyCreatorGenerator[] getGenerators(Assembly[] assemblies)
        {
            AssemblyCreatorGenerator[] generators = new AssemblyCreatorGenerator[assemblies.Length];
            for (int i = 0; i < assemblies.Length; ++i)
            {
                generators[i] = AssemblyCreatorGenerator.newInstance(assemblies[i]);
                generators[i].registerPredicate(type => typeof(IDataSource).IsAssignableFrom(type));
            }

            return generators;
        }

        /// <summary>
        /// Retirve all assemblies in given path.
        /// </summary>
        /// <param name="pathToDataSourceLib">Path of librery where assemblies to be searched.</param>
        /// <returns>Assemblies from path given.</returns>
        private static Assembly[] getAssemblies(string pathToDataSourceLib)
        {
            if (!Directory.Exists(pathToDataSourceLib))
            {
                throw new DirectoryNotFoundException(pathToDataSourceLib + " not found");
            }

            string[] files = Directory.GetFiles(pathToDataSourceLib, "*.dll");
            Assembly[] assemblies = new Assembly[files.Length];
            for (int i = 0; i < files.Length; ++i)
            {
                assemblies[i] = Assembly.LoadFile(files[i]);
            }

            return assemblies;
        }

        #region IDataSourceProvider
        public ICollection<Type> providing()
        {
            return this.provider.providing();
        }

        public ICollection<IDataSource> getAll()
        {
            return this.provider.getAll();
        }

        public IDataSource get(Type dataSourceType)
        {
            return this.provider.get(dataSourceType);
        }
        #endregion
    }
}
