using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynamicDataSourceProvider.common.factory.creator
{
    /// <summary>
    /// Interface for creator class.
    /// Creator classes are classes that can create instances of other classes.
    /// </summary>
    public interface ICanCreate
    {
        /// <summary>
        /// Indicate wich class this creator can create.
        /// </summary>
        /// <returns>Type of class creator can create.</returns>
        Type creating();

        /// <summary>
        /// Create an instance of class of type returns from creating().
        /// </summary>
        /// <see cref="creating"/>
        /// <returns>New instance of class creator knows to create.</returns>
        object create();
    }
}
