using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AcronymsHighlightsPlugin.Common.Dao.Interfaces;
using Microsoft.Office.Core;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;
using System.Xml;

namespace AHPWordAddIn.common.plugin
{
    [DataContract]
    internal class WordDocumentProperties : IDocumentDetails
    {
        #region Properties Names
        internal static readonly string DataSourceLibPathPropertyName = "dataSourceLibPath";
        internal static readonly string AHPDetailsProprtyName = "AHPDetails";
        #endregion

        [DataMember]
        private Dictionary<string, IDocumentProperty> properties = new Dictionary<string, IDocumentProperty>();

        public static WordDocumentProperties load()
        {
            WordDocumentProperties result = null;
            DocumentProperties properties = Globals.ThisAddIn.Application.ActiveDocument.CustomDocumentProperties;
            foreach (DocumentProperty property in properties)
            {
                if (property.Name.Equals(WordDocumentProperties.AHPDetailsProprtyName))
                {
                    result = WordDocumentProperties.deserialize(property.Value);
                }
            }

            if (result == null)
            {
                result = new WordDocumentProperties();
                result.setBuiltInDocumentDetails();
            }

            return result;
        }

        public WordDocumentProperties() { }

        private void setBuiltInDocumentDetails()
        {
            DocumentProperties properties = Globals.ThisAddIn.Application.ActiveDocument.BuiltInDocumentProperties;
            foreach (DocumentProperty property in properties)
            {
                try
                {
                    IDocumentProperty AHPProperty = new WordDocumentProperty() { name = property.Name, value = property.Value };
                    this.set(AHPProperty);
                }
                catch (System.Runtime.InteropServices.COMException)
                {
                }
            }
        }

        #region IDocumentDetails
        
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

        public void save()
        {
            DocumentProperties properties = Globals.ThisAddIn.Application.ActiveDocument.CustomDocumentProperties;
            clearProperties(properties);
            properties.Add(
                WordDocumentProperties.AHPDetailsProprtyName,
                false,
                Microsoft.Office.Core.MsoDocProperties.msoPropertyTypeString,
                this.serialize()
            );
        }

        private void clearProperties(DocumentProperties properties)
        {
            foreach (DocumentProperty property in properties)
            {
                if (property.Name.Equals(WordDocumentProperties.AHPDetailsProprtyName))
                {
                    properties[WordDocumentProperties.AHPDetailsProprtyName].Delete();
                }
            }
        }

        private string serialize()
        {
            var serializer = new DataContractSerializer(typeof(WordDocumentProperties));
            string xmlString;
            using (var sw = new StringWriter())
            {
                using (var writer = new XmlTextWriter(sw))
                {
                    writer.Formatting = Formatting.Indented; // indent the Xml so it's human readable
                    serializer.WriteObject(writer, this);
                    writer.Flush();
                    xmlString = sw.ToString();
                }
            }

            return xmlString;
        }

        private static WordDocumentProperties deserialize(string str)
        {
            DataContractSerializer dcs = new DataContractSerializer(typeof(WordDocumentProperties));
            byte[] byteArray = Encoding.ASCII.GetBytes(str);
            MemoryStream stream = new MemoryStream(byteArray); 
            XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(stream, new XmlDictionaryReaderQuotas());

            return (WordDocumentProperties)dcs.ReadObject(reader);
        }
    }
}
