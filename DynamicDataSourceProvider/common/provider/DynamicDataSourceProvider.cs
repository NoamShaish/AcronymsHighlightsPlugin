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
    public class DynamicDataSourceProvider : IDataSourceProvider
    {
        private DynamicDataSourceProvider(IDataSourceProvider provider) 
        {
            this.provider = provider;
        }

        private IDataSourceProvider provider { get; set; }
        
        public static DynamicDataSourceProvider newInstance(string pathToDataSourceLib, IDocumentDetails documentDetails)
        {
            if (String.IsNullOrEmpty(pathToDataSourceLib.Trim()))
            {
                throw new ArgumentException("No path is provided for data sources", "pathToDataSourceLib");
            }
            Assembly[] assemblies = getAssemblies(pathToDataSourceLib);
            AssemblyCreatorGenerator[] generators = getGenerators(assemblies);
            AssemblyBasedFactoryProxy factory = AssemblyBasedFactoryProxy.newInstance(Factory.newInstance(), generators);
            return new DynamicDataSourceProvider(DataSourceProvider.newInstance(factory, documentDetails);
        }

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
    }
}
