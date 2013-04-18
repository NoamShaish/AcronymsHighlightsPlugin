using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Linq.Expressions;

namespace DynamicDataSourceProvider.common.factory.creator
{
    public class AssemblyCreatorGenerator
    {
        private AssemblyCreatorGenerator() { }
        private ICollection<Predicate<Type>> predicates = new LinkedList<Predicate<Type>>();
        public  Assembly assembly { get; private set; }

        public static AssemblyCreatorGenerator newInstance(Assembly assembly)
        {
            AssemblyCreatorGenerator generator = new AssemblyCreatorGenerator();
            generator.assembly = assembly;
            return generator;
        }

        public ICollection<ICanCreate> getCreators()
        {
            ICollection<ICanCreate> creators = new LinkedList<ICanCreate>();
            Type[] typesToGenerateCreatorFor = this.getTypesFromAssembly();
            foreach (Type type in typesToGenerateCreatorFor)
            {
                creators.Add(generateCreator(type));
            }

            return creators;
        }
        
        private ICanCreate generateCreator(Type creatorType)
        {
            //() => this.assembly.CreateInstance(creatorType.FullName));
            Func<object> act = () => this.assembly.CreateInstance(creatorType.FullName);

            var method = typeof(CreatorFactory).GetMethod("create", BindingFlags.Public | BindingFlags.Static)
                .MakeGenericMethod(new[] { typeof(object) });
            return (ICanCreate) method.Invoke(null, new object[] { act, creatorType });
        }



        private Type[] getTypesFromAssembly()
        {
            Type[] allTypes = this.assembly.GetTypes();
            Type[] types = Array.FindAll<Type>(allTypes, 
                type => type.IsClass && 
                    type.IsPublic && 
                    !type.IsInterface &&
                    type.GetConstructor(Type.EmptyTypes)!=null &&
                    this.veridyAdditionalPredicates(type));
            return types;
        }

        private bool veridyAdditionalPredicates(Type type)
        {
            bool result = true;
            foreach (Predicate<Type> predicate in this.predicates)
            {
                result &= predicate.Invoke(type);
                if (!result)
                {
                    break;
                }
            }
            return result;
        }
	

        public void registerPredicate(Predicate<Type> predicate)
        {
            this.predicates.Add(predicate);
        }

        public void unregisterPredicate(Predicate<Type> predicate)
        {
            this.predicates.Remove(predicate);
        }
    }
}
