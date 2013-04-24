using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AcronymsHighlightsPlugin.Common.Dao.Interfaces;

namespace AHPWordAddIn.common.plugin
{
    internal class WordDocumentProperties : IDocumentDetails
    {
        #region Members
        internal static readonly string DataSourceLibPathPropertyName = "dataSourceLibPath";
        #endregion

        #region Methods
        /********************************************************************/
        /// <summary>
        /// 
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public IDocumentProperty get(String propertyName)
        {
            throw new NotImplementedException();
        }
        /********************************************************************/
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ICollection<IDocumentProperty> getAll()
        {
            throw new NotImplementedException();
        }
        /********************************************************************/
        /// <summary>
        /// 
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public IDocumentProperty set(IDocumentProperty property)
        {
            throw new NotImplementedException();
        }
        /********************************************************************/
        #endregion
    }
}
