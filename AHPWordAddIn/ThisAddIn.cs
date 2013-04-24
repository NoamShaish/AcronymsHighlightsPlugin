using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Word = Microsoft.Office.Interop.Word;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Word;
using AHPWordAddIn.common.utils;
using AHPWordAddIn.common.commands;
using AcronymsHighlightsPlugin.Common.Dao.Interfaces;
using Microsoft.Office.Core;
using AcronymsHighlightsPlugin.Common.Dao.Base;

namespace AHPWordAddIn
{
    public partial class ThisAddIn
    {
        #region Members
        internal static Word.Application application { get; private set; }

        private Translate               translate                   = null;       // Responsible for the accronym translation and inserting it into the DDSP
        private AddInManager            addInManager                = null;       // Responsible to provide events to business logic layer logical events
        private List<CommandBarButton>  listOfCurrentTranslations   = null;       // Contains all the translations from the last accronym that have been loaded into the Text command bar
        #endregion
        /********************************************************************/
        /// <summary>
        /// Initializes the basic members of the object
        /// </summary>
        private void initializeMembers()
        {
            try
            {
                ThisAddIn.application       = this.Application;
                translate                   = new Translate();
                addInManager                = AddInManager.instance;
                listOfCurrentTranslations   = new List<CommandBarButton>();
            }
            catch(Exception)
            {
            }
        }
        /********************************************************************/
        /// <summary>
        /// Links all the necessary events to the passed application object
        /// </summary>
        /// <param name="application">Application object</param>
        private void linkEventsToApplication(Word.Application application)
        {
            try
            {
                application.WindowBeforeRightClick +=
                    new Word.ApplicationEvents4_WindowBeforeRightClickEventHandler(application_WindowBeforeRightClick);

                addInManager.Translated += 
                    new EventHandler<WordTranslatedEventArgs>(updateTextPropertiesMenu);
            }
            catch (Exception)
            {
            }
        }
        /********************************************************************/
        /// <summary>
        /// This method recieves an object of type WordTranslatedEventArgs and updates the properties menu
        /// according to the accronym and it's translations whice are the members of the WordTranslatedEventArgs class
        /// </summary>
        /// <param name="sender">The object that fired the event which is linked to this method</param>
        /// <param name="e">An object which contains the Accronym and it's translations</param>
        private void updateTextPropertiesMenu(  object                  sender, 
                                                WordTranslatedEventArgs e)
        {
            Office.CommandBar commandBar = null;

            try
            {
                getCommandBarInstanceByName(    application.CommandBars, 
                                                "Text", 
                                            out commandBar);

                CleanCommandBarByList(ref commandBar);

                updateCommandBarByAccronym(     e.acronym, 
                                           ref  commandBar);
            }
            catch(Exception)
            {
            }
        }
        /********************************************************************/
        /// <summary>
        /// Resets the command bar from previouse results
        /// </summary>
        /// <param name="commandBar">CommandBar instance</param>
        private void CleanCommandBarByList(ref CommandBar commandBar)
        {
            try
            {
                commandBar.Reset();
            }
            catch(Exception)
            {
            }
        }
        /********************************************************************/
        /// <summary>
        /// Returns an instance of the selected command bar by name
        /// </summary>
        /// <param name="commandBars">A vector of command bars</param>
        /// <param name="commandBarName">Command bar name</param>
        /// <param name="commandBar">Handle of the selected command bar</param>
        private void getCommandBarInstanceByName(       Office.CommandBars  commandBars, 
                                                        string              commandBarName, 
                                                    out Office.CommandBar   commandBar)
        {
            try
            {
                commandBar = null;
                commandBar = application.CommandBars[commandBarName];
            }
            catch (Exception)
            {
                commandBar = null;
            }
        }
        /********************************************************************/
        /// <summary>
        /// Updates the properties menu by the new accronym
        /// </summary>
        /// <param name="iAcronym">An Accronym and all it's translations</param>
        /// <param name="commandBar">An instance  of a command bar</param>
        private void updateCommandBarByAccronym(        IAcronym            iAcronym,
                                                    ref Office.CommandBar   commandBar)
        {
            CommandBarButton button = null;
            try
            {
                foreach(string translation in iAcronym.Translations)
                {
                    button = commandBar.Controls.Add(Office.MsoControlType.msoControlButton) as Office.CommandBarButton;
                    button.accName  = translation;
                    button.Caption  = translation;
                    button.Tag      = string.Format("tag_{0}", translation);
                    listOfCurrentTranslations.Add(button);
                }
            }
            catch (Exception)
            {
            }
        }
        /********************************************************************/
        #region Events
        /********************************************************************/
        /// <summary>
        /// This event occurs on the startup process of the application
        /// </summary>
        /// <param name="sender">Irrelevant</param>
        /// <param name="e">Irrelevant</param>
        private void ThisAddIn_Startup(object               sender,
                                        System.EventArgs    e)
        {
            try
            {
                initializeMembers();
                linkEventsToApplication(application);
            }
            catch (Exception)
            {
            }
        }
        /********************************************************************/
        private void ThisAddIn_Shutdown(object              sender,
                                        System.EventArgs    e)
        {
            try
            {

            }
            catch(Exception)
            {
            }
        }
        /********************************************************************/
        /// <summary>
        /// This event occurs before the document in the MS Word application clicked with the right button of the mouse
        /// </summary>
        /// <param name="selection">The selected text area of the document</param>
        /// <param name="cancel">Indicates if you want to cancel the right click process</param>
        private void application_WindowBeforeRightClick(    Word.Selection  selection,
                                                        ref bool            cancel)
        {
            try
            {
                translate.execute();
            }
            catch(Exception)
            {

            }
        }
        #endregion
        /********************************************************************/
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