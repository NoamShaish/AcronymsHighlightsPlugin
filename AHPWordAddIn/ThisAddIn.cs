using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Microsoft.Office.Interop.Word;
using Microsoft.Office.Tools.Word;
using AHPWordAddIn.common.utils;
using AHPWordAddIn.common.commands;
using AcronymsHighlightsPlugin.Common.Dao.Interfaces;
using Microsoft.Office.Core;
using AcronymsHighlightsPlugin.Common.Dao.Base;
using AHPWordAddIn.common.GUIConnectors;
using System.Configuration;
using AHPWordAddIn.common.plugin;

namespace AHPWordAddIn
{
    public partial class ThisAddIn
    {
        #region Members
        
        internal static readonly ICollection<IGUIConnector> GUIConnectors = new LinkedList<IGUIConnector>();
 
        private AHPWordAddIn.Properties.Settings settings = new Properties.Settings();

        #endregion

        #region Methods
        
        
        /// <summary>
        /// Links all the necessary events to the passed application object
        /// </summary>
        /// <param name="application">Application object</param>
        private void initializeConnectors()
        {
            ThisAddIn.GUIConnectors.Add(new RightClickMenuConnector());
        }

        /// <summary>
        /// Imports setings into add-in's ribbon
        /// </summary>
        private void setRibbonComponentsState()
        {
            Globals.Ribbons.AccronymHighlightsRibbon.setComponentsState(settings);
        }

        /// <summary>
        /// Updates the "Settings" object with current "Ribbon's" components state
        /// </summary>
        private void getRibbonComponentsState()
        {
            Globals.Ribbons.AccronymHighlightsRibbon.getComponentsState(settings);
        }

        void saveDocumentDetails(Microsoft.Office.Interop.Word.Document Doc, ref bool Cancel)
        {
            AddInManager.instance.saveDocumentDetails();
        }

        #endregion

        #region Events
        /// <summary>
        /// This event occurs on the startup process of the application
        /// </summary>
        /// <param name="sender">Irrelevant</param>
        /// <param name="e">Irrelevant</param>
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            initializeConnectors();
            setRibbonComponentsState();
            //Globals.ThisAddIn.Application.DocumentBeforeClose += new ApplicationEvents4_DocumentBeforeCloseEventHandler(saveDocumentDetails);
        }

        /// <summary>
        /// This event occures before applicaion is shutting down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ThisAddIn_Shutdown(object sender, System.EventArgs e) 
        {
            getRibbonComponentsState();
            settings.Save();
        }
        #endregion
        
        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}