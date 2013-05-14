using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Linq.Expressions;

namespace DynamicDataSourceProvider.common.factory.creator
{
    /// <summary>
    /// A creators generator who based on given assembly.
    /// This implementation basic predication rules are:
    ///     1. Must be a class.
    ///     2. Must be public.
    ///     3. Must not be an interface.
    ///     4. Must have an empty constructor.
    /// 
    /// If more predicates are require use registerPredicate.
    /// </summary>
    public class AssemblyCreatorGenerator
    {
        #region Factory method pattern
        /// <summary>
        /// Prevent from uncontroled creation.
        /// </summary>
        private AssemblyCreatorGenerator() { }

        /// <summary>
        /// Factory method implementation.
        /// </summary>
        /// <param name="assembly">Assembly to generate creators for.</param>
        /// <returns>New instance of AssemblyCreatorGenerator.</returns>
        public static AssemblyCreatorGenerator newInstance(Assembly assembly)
        {
            AssemblyCreatorGenerator generator = new AssemblyCreatorGenerator();
            generator.assembly = assembly;
            return generator;
        }
        #endregion

        /// <summary>
        /// Predicates to be verify for classes in assembly.
        /// </summary>
        private ICollection<Predicate<Type>> predicates = new LinkedList<Predicate<Type>>();

        /// <summary>
        /// Assembly creators will be genrated for.
        /// </summary>
        public  Assembly assembly { get; private set; }

        /// <summary>
        /// Get creators for all class in assembly.
        /// </summary>
        /// <returns>Collection of creators.</returns>
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
        
        /// <summary>
        /// generate a creator for given type.
        /// </summary>
        /// <param name="creatorType"></param>
        /// <returns></returns>
        private ICanCreate generateCreator(Type creatorType)
        {
            Func<object> act = () => this.assembly.CreateInstance(creatorType.FullName);
            var method = typeof(CreatorFactory).GetMethod("create", BindingFlags.Public | BindingFlags.Static)
                .MakeGenericMethod(new[] { typeof(object) });
            return (ICanCreate) method.Invoke(null, new object[] { act, creatorType });
        }

        /// <summary>
        /// Get types from assembly that stand in all predicates.
        /// </summary>
        /// <returns>An array of type to generate creator for.</returns>
        private Type[] getTypesFromAssembly()
        {
            Type[] allTypes = this.assembly.GetTypes();
            Type[] types = Array.FindAll<Type>(allTypes, 
                type => type.IsClass && 
                    type.IsPublic && 
                    !type.IsInterface &&
                    type.GetConstructor(Type.EmptyTypes)!=null &&
                    this.verifyAdditionalPredicates(type));
            return types;
        }

        /// <summary>
        /// Verify custom predicates.
        /// </summary>
        /// <param name="type">Type to be verified.</param>
        /// <returns>True if type is verified.</returns>
        private bool verifyAdditionalPredicates(Type type)
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
	
        /// <summary>
        /// Add predicate to be verified.
        /// </summary>
        /// <param name="predicate"></param>
        public void registerPredicate(Predicate<Type> predicate)
        {
            this.predicates.Add(predicate);
        }

        /// <summary>
        /// Remove a predicate to be verified.
        /// </summary>
        /// <param name="predicate"></param>
        public void unregisterPredicate(Predicate<Type> predicate)
        {
            this.predicates.Remove(predicate);
        }
    }
}
