using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcronymsHighlightsPlugin.Common.Dao.Interfaces
{
    /// <summary>
    /// Information regarding a document.
    /// </summary>
    public interface IDocumentDetails
    {
        /// <summary>
        /// Get a document specific property.
        /// </summary>
        /// <param name="propertyName">Name of wanted property.</param>
        /// <returns></returns>
        IDocumentProperty get(String propertyName);

        /// <summary>
        /// Set a value to a document property.
        /// </summary>
        /// <param name="property">Property to be set.</param>
        /// <returns>The property that been replaced or null if new property added.</returns>
        IDocumentProperty set(IDocumentProperty property);

        /// <summary>
        /// Return all documents properties.
        /// </summary>
        /// <returns>Collection of properties.</returns>
        ICollection<IDocumentProperty> getAll();
    }
}
