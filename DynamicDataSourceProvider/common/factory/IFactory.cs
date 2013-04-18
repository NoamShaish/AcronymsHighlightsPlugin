using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DynamicDataSourceProvider.common.factory.creator;

namespace DynamicDataSourceProvider.common.factory
{
    public interface IFactory
    {
        /// <summary>
        /// Create a new object of type T.
        /// </summary>
        /// <param name="type">The type of wanted object.</typeparam>
        /// <returns>New object of type T.</returns>
        object create(Type type);

        /// <summary>
        /// Try to create new object of type T.
        /// </summary>
        /// <param name="type">The type of wanted object.</typeparam>
        /// <param name="obj">An output parameter to set new object.</param>
        /// <returns>True if mannaged to create wanted object.</returns>
        bool tryCreate(Type type, out object obj);

        /// <summary>
        /// Verify if factory is creating objects of type T.
        /// </summary>
        /// <param name="type">Checked type.</typeparam>
        /// <returns>True if factory is creating objects from type T.</returns>
        bool isCreating(Type type);

        /// <summary>
        /// Returns all types that factory can create.
        /// </summary>
        /// <returns>Collection of all type factory can create.</returns>
        ICollection<Type> creating();

        /// <summary>
        /// register a new creator of type T to factory and replace if one exists.
        /// </summary>
        /// <param name="type">Type created by new creator.</typeparam>
        /// <param name="creator">Type T creator.</param>
        void registerCreator(Type type, ICanCreate creator);

        /// <summary>
        /// register a new creator of type T to factory.
        /// </summary>
        /// <param name="type">Type created by new creator.</typeparam>
        /// <param name="creator">Type T creator.</param>
        /// <param name="replace">True will replace existing creator.</param>
        void registerCreator(Type type, ICanCreate creator, bool replace);
    }
}
