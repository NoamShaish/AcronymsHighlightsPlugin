﻿using System;
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

namespace AHPWordAddIn
{
    public partial class ThisAddIn
    {
        #region Members
        internal static Application application { get; private set; }
        internal static readonly ICollection<IGUIConnector> GUIConnectors = new LinkedList<IGUIConnector>();
        
        private         AHPWordAddIn.Properties.Settings settings = new Properties.Settings();

        #endregion
        
        /// <summary>
        /// Initializes the basic members of the object
        /// </summary>
        private void initializeMembers()
        {
            ThisAddIn.application = this.Application;
        }
        
        /// <summary>
        /// Links all the necessary events to the passed application object
        /// </summary>
        /// <param name="application">Application object</param>
        private void initializeConnectors()
        {
            ThisAddIn.GUIConnectors.Add(new RightClickMenuConnector());
        }
        
        #region Events
        /// <summary>
        /// This event occurs on the startup process of the application
        /// </summary>
        /// <param name="sender">Irrelevant</param>
        /// <param name="e">Irrelevant</param>
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            initializeMembers();
            initializeConnectors();
            setRibbonComponentsState();
        }

        /// <summary>
        /// Imports setings into add-in's ribbon
        /// </summary>
        private void setRibbonComponentsState()
        {
            Globals.Ribbons.AccronymHighlightsRibbon.setComponentsState(settings);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ThisAddIn_Shutdown(object sender, System.EventArgs e) 
        {
            getRibbonComponentsState();
            settings.Save();
        }

        /// <summary>
        /// 
        /// </summary>
        private void getRibbonComponentsState()
        {
            Globals.Ribbons.AccronymHighlightsRibbon.getComponentsState(settings);
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