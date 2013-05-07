using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AcronymsHighlightsPlugin.Common.Dao.Interfaces;

namespace AHPWordAddIn.common.plugin
{
    internal class WordDocumentProperties : IDocumentDetails
    {
        #region Properties Names
        internal static readonly string DataSourceLibPathPropertyName = "dataSourceLibPath";
        #endregion

        private Dictionary<string, IDocumentProperty> properties = new Dictionary<string, IDocumentProperty>();
        #region Methods
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public IDocumentProperty get(String propertyName)
        {
            IDocumentProperty property = null;
            if (this.properties.Keys.Contains<string>(propertyName))
            {
                property = this.properties[propertyName];
            }

            return property;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ICollection<IDocumentProperty> getAll()
        {
            return this.properties.Values;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public IDocumentProperty set(IDocumentProperty property)
        {
            IDocumentProperty oldProperty = property;
            if (this.properties.Keys.Contains<string>(property.name))
            {
                oldProperty = this.properties[property.name];
                this.properties.Remove(property.name);
            }

            this.properties.Add(property.name, property);

            return oldProperty;
        }
        
        #endregion
    }
}
