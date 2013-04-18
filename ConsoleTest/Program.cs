using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using DynamicDataSourceProvider.common.factory.creator;
using DynamicDataSourceProvider.common.factory;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            bool filter = true;
            String path = "D:\\Work Station\\lib\\TestAssembly.dll";
            Assembly ass = Assembly.LoadFile(path);
            Type inter = null;
            Console.Out.WriteLine("Assembly classes:");
            foreach (Type type in ass.GetTypes())
            {
                Console.Out.WriteLine(type.FullName);
                if (type.IsInterface)
                {
                    inter = type;
                }
            }

            AssemblyCreatorGenerator generator = AssemblyCreatorGenerator.newInstance(ass);

            Console.Out.WriteLine("Generator classes:");
            if (inter != null && filter)
            {
                Console.Out.WriteLine("filltering class not inplementing" + inter.FullName);
                generator.registerPredicate(type => inter.IsAssignableFrom(type));
            }
            foreach (ICanCreateT<object> creator in generator.getCreators())
            {
                //Console.Out.WriteLine(creator.GetType().FullName);
                //Console.Out.WriteLine(creator.creating().FullName);
                Console.Out.WriteLine(creator.create().GetType().FullName);
            }

            Factory fac = Factory.newInstance();
            AssemblyBasedFactoryProxy asFac = AssemblyBasedFactoryProxy.newInstance(fac, new[] { generator });

            Console.Out.WriteLine("Factory classes:");
            foreach (Type type in asFac.creating())
            {
                Console.Out.WriteLine(asFac.create(type).GetType().FullName);
            }

            Console.In.ReadLine();
        }
    }
}
