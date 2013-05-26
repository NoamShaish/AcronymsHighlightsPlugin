using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AHPWordAddIn.common.commands;
using Microsoft.Office.Interop.Word;
using Microsoft.Office.Core;
using Microsoft.Office.Tools.Word;
using AHPWordAddIn.common.utils;
using AcronymsHighlightsPlugin.Common.Dao.Interfaces;


namespace AHPWordAddIn.common.GUIConnectors
{
    internal class RightClickMenuConnector : IGUIConnector
    {
        #region Members

        bool isMutipleTranslationEnabled    = false;
        bool isExternalDataSourcesEnabled   = false;
        bool translateOnRightClick          = false;
        bool translateOnMaouseHover         = false;

        uint numOfTranslations = 0;

        private AHPWordAddIn.Properties.Settings settings = new Properties.Settings();
        #endregion

        public RightClickMenuConnector()
        {
            Globals.ThisAddIn.Application.WindowBeforeRightClick += new ApplicationEvents4_WindowBeforeRightClickEventHandler(translateSelection);
            AddInManager.instance.Translated += new EventHandler<WordTranslatedEventArgs>(updateTextPropertiesMenu);

            initConfiguration();
        }

        /// <summary>
        /// Initializes configuration according to the Settings object
        /// </summary>
        private void initConfiguration()
        {
            isMutipleTranslationEnabled  = settings.EnableMultipleTranslation;
            isExternalDataSourcesEnabled = settings.EnableExternalDS;
            translateOnRightClick        = settings.TranslateOnRightClick;
            translateOnMaouseHover       = settings.TranslateOnMaouseHover;

            numOfTranslations = (uint)settings.NumOfMultipleTranslations;
        }

        /// <summary>
        /// This event occurs before the document in the MS Word application clicked with the right button of the mouse
        /// </summary>
        /// <param name="selection">The selected text area of the document</param>
        /// <param name="cancel">Indicates if you want to cancel the right click process</param>
        private void translateSelection(    Selection   selection, 
                                        ref bool        cancel)
        {
            //if (translateOnRightClick == true)
            //{
                new Translate().execute();
            //}
        }

        /// <summary>
        /// This method recieves an object of type WordTranslatedEventArgs and updates the properties menu
        /// according to the accronym and it's translations whice are the members of the WordTranslatedEventArgs class
        /// </summary>
        /// <param name="sender">The object that fired the event which is linked to this method</param>
        /// <param name="e">An object which contains the Accronym and it's translations</param>
        private void updateTextPropertiesMenu(object sender, WordTranslatedEventArgs e)
        {
            CommandBar commandBar = null;
            getCommandBarInstanceByName(Globals.ThisAddIn.Application.CommandBars, "Text", out commandBar);
            CleanCommandBar(ref commandBar);
            updateCommandBarByAccronym(e.acronym, ref commandBar);
            Globals.Ribbons.AccronymHighlightsRibbon.setAcronymAndTranslations(e.acronym);
        }

        /// <summary>
        /// Resets the command bar from previouse results
        /// </summary>
        /// <param name="commandBar">CommandBar instance</param>
        private void CleanCommandBar(ref CommandBar commandBar)
        {
            commandBar.Reset();
        }

        /// <summary>
        /// Returns an instance of the selected command bar by name
        /// </summary>
        /// <param name="commandBars">A vector of command bars</param>
        /// <param name="commandBarName">Command bar name</param>
        /// <param name="commandBar">Handle of the selected command bar</param>
        private void getCommandBarInstanceByName(CommandBars commandBars, string commandBarName, out CommandBar commandBar)
        {
            try
            {
                commandBar = null;
                commandBar = Globals.ThisAddIn.Application.CommandBars[commandBarName];
            }
            catch (Exception)
            {
                commandBar = null;
            }
        }

        /// <summary>
        /// Updates the properties menu by the new accronym
        /// </summary>
        /// <param name="iAcronym">An Accronym and all it's translations</param>
        /// <param name="commandBar">An instance  of a command bar</param>
        private void updateCommandBarByAccronym(IAcronym iAcronym, ref CommandBar commandBar)
        {
            CommandBarButton button = null;
            uint counter = 0;
            foreach (string translation in iAcronym.Translations)
            {
                button = commandBar.Controls.Add(MsoControlType.msoControlButton) as CommandBarButton;
                button.accName = translation;
                button.Caption = translation;
                button.Tag = string.Format("tag_{0}", translation);
                counter++;
                if (counter                     >= numOfTranslations ||
                    isMutipleTranslationEnabled == false)
                {
                    break;
                }
            }
        }
    }
}
