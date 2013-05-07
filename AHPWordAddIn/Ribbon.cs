using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using Office = Microsoft.Office.Core;
using Word = Microsoft.Office.Interop.Word;
using AHPWordAddIn.common.utils;
using AcronymsHighlightsPlugin.Common.Dao.Interfaces;

// TODO:  Follow these steps to enable the Ribbon (XML) item:

// 1: Copy the following code block into the ThisAddin, ThisWorkbook, or ThisDocument class.

//  protected override Microsoft.Office.Core.IRibbonExtensibility CreateRibbonExtensibilityObject()
//  {
//      return new Ribbon();
//  }

// 2. Create callback methods in the "Ribbon Callbacks" region of this class to handle user
//    actions, such as clicking a button. Note: if you have exported this Ribbon from the Ribbon designer,
//    move your code from the event handlers to the callback methods and modify the code to work with the
//    Ribbon extensibility (RibbonX) programming model.

// 3. Assign attributes to the control tags in the Ribbon XML file to identify the appropriate callback methods in your code.  

// For more information, see the Ribbon XML documentation in the Visual Studio Tools for Office Help.


namespace AHPWordAddIn
{
    [ComVisible(true)]
    public class Ribbon : Office.IRibbonExtensibility
    {
        private Office.IRibbonUI ribbon;
        public IAcronym CurrentAcronym { get; private set; }

        public Ribbon()
        {
            AddInManager.instance.Translated += new EventHandler<WordTranslatedEventArgs>(updateCurrentAcronym);
        }

        #region IRibbonExtensibility Members

        public string GetCustomUI(string ribbonID)
        {
            return GetResourceText("AHPWordAddIn.Ribbon.xml");
        }

        #endregion

        #region Ribbon Callbacks
        //Create callback methods here. For more information about adding callback methods, select the Ribbon XML item in Solution Explorer and then press F1

        public void Ribbon_Load(Office.IRibbonUI ribbonUI)
        {
            this.ribbon = ribbonUI;
        }

        public void buttonAddLocalDataSource_Click(Office.IRibbonControl control)
        {
            new AHPWordAddIn.common.commands.AddLocalDataSource().execute();
        }

        #endregion

        #region Helpers

        private static string GetResourceText(string resourceName)
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            string[] resourceNames = asm.GetManifestResourceNames();
            for (int i = 0; i < resourceNames.Length; ++i)
            {
                if (string.Compare(resourceName, resourceNames[i], StringComparison.OrdinalIgnoreCase) == 0)
                {
                    using (StreamReader resourceReader = new StreamReader(asm.GetManifestResourceStream(resourceNames[i])))
                    {
                        if (resourceReader != null)
                        {
                            return resourceReader.ReadToEnd();
                        }
                    }
                }
            }
            return null;
        }

        #endregion

        private void updateCurrentAcronym(object sender, WordTranslatedEventArgs e)
        {
            if (e.acronym == null || string.IsNullOrEmpty(e.acronym.Text) || e.acronym.Translations == null || e.acronym.Translations.Count < 1)
            {
                this.CurrentAcronym = null;
            }
            else
            {
                this.CurrentAcronym = e.acronym;
            }
        }

        


        public string GetContent(Office.IRibbonControl control)
        {
            string result = "";
            if (this.CurrentAcronym != null && this.CurrentAcronym.Translations != null & this.CurrentAcronym.Translations.Count > 0)
            {
                StringBuilder translationsXml = new StringBuilder(@"<menu xmlns=""http:=//schemas.microsoft.com/office/2009/07/customui"">");
                int translationCount = 0;
                foreach (string translation in this.CurrentAcronym.Translations)
                {
                    ++translationCount;
                    translationsXml.Append(buildXml(translation, translationCount));
                }
                translationsXml.Append(@"</menu>");
                result = translationsXml.ToString();
            }

            return result;
        }

        private string buildXml(string translation, int translationCount)
        {
            return string.Format("<button id=\"{0}\" label=\"{1}\" onAction=\"\"/>", "translation_" + translationCount, translation); 
        }
    }
}
