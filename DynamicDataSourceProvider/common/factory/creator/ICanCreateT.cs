using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynamicDataSourceProvider.common.factory.creator
{
    /// <summary>
    /// This is generalization of interface ICanCreate
    /// </summary>
    /// <typeparam name="T">Type of class that creator knows to create.</typeparam>
    public interface ICanCreateT<out T> : ICanCreate
    {
        /// <summary>
        /// Create an instance of T.
        /// </summary>
        /// <returns>New T instance.</returns>
        new T create();
    }
}
