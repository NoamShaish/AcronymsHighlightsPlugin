﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using AHPWordAddIn.common.GUIForms;
using AHPWordAddIn.common.commands;
using AcronymsHighlightsPlugin.Common.Dao.Interfaces;

namespace AHPWordAddIn
{
    public partial class AccronymHighlightsRibbon
    {
        #region Members
        private AHPWordAddIn.Properties.Settings settings = new Properties.Settings();
        #endregion

        #region API
        /// <summary>
        /// Sets components state according to "Settings" object values
        /// </summary>
        /// <param name="settings">Application's Settings object</param>
        internal void setComponentsState(AHPWordAddIn.Properties.Settings settings)
        {
            setTranslationSettings(settings);
            setExternalDataSourcesSettings(settings);
        }

        /// <summary>
        /// Gets components state according to "Settings" object values
        /// </summary>
        /// <param name="settings">Application's Settings object</param>
        internal void getComponentsState(Properties.Settings settings)
        {
            getTranslationSettings(settings);
            getExternalDataSourcesSettings(settings);
        }

        internal int getNumOfTranslations()
        {
            return AdvancedTranslationConfiguration.getAdvancedTranslationConfiguration().getNumberOfTranslations();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Sets external data sources settings according to the "Settings" object parameters
        /// </summary>
        /// <param name="settings">Application's Settings object</param>
        private void setExternalDataSourcesSettings(Properties.Settings settings)
        {
            chkBxExternalDataSources.Checked = settings.EnableExternalDS;
            ExternalDataSourceConfiguration.getExternalDataSourceConfiguration().setComponentsState(settings);
        }

        /// <summary>
        /// Sets translation settings according to the "Settings" object parameters
        /// </summary>
        /// <param name="settings">Application's Settings object</param>
        private void setTranslationSettings(Properties.Settings settings)
        {
            chkBxTranslateOnRightClick.Checked = settings.TranslateOnRightClick;
            chkBxMultipleMatches.Checked = settings.EnableMultipleTranslation;
            chkBxTranslateOnMouseHover.Checked = settings.TranslateOnMaouseHover;
            drpDwnNumberOfTranslations.SelectedItemIndex = settings.NumOfMultipleTranslations - 1;
            //AdvancedTranslationConfiguration.getAdvancedTranslationConfiguration().setComponentsState(settings);

        }

        /// <summary>
        /// Gets External Data Sources Settings
        /// </summary>
        /// <param name="settings">Application's Settings object</param>
        private void getExternalDataSourcesSettings(Properties.Settings settings)
        {
            settings.EnableExternalDS = chkBxExternalDataSources.Checked;
            ExternalDataSourceConfiguration.getExternalDataSourceConfiguration().getComponentsState(settings);
        }

        /// <summary>
        /// Gets translation settings
        /// </summary>
        /// <param name="settings">Application's Settings object</param>
        private void getTranslationSettings(Properties.Settings settings)
        {
            settings.TranslateOnRightClick      = chkBxTranslateOnRightClick.Checked;
            settings.EnableMultipleTranslation  = chkBxMultipleMatches.Checked;
            settings.TranslateOnMaouseHover     = chkBxTranslateOnMouseHover.Checked;

            settings.NumOfMultipleTranslations = Int32.Parse(drpDwnNumberOfTranslations.SelectedItem.ToString()[0].ToString());
        }

        #endregion

        #region Events
        /// <summary>
        /// This event occcres when this "Ribbon" is loading
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AccronymHighlightsRibbon_Load( object              sender, 
                                                    RibbonUIEventArgs   e)
        {

        }

        /// <summary>
        /// This event occures when you click on the expand group (grpConfiguration) button in the "Ribbon" component
        /// </summary>
        /// <param name="sender">Irrelevant</param>
        /// <param name="e">Irrelevant</param>
        private void grpConfiguration_DialogLauncherClick(  object                  sender, 
                                                            RibbonControlEventArgs  e)
        {
            AdvancedTranslationConfiguration.getAdvancedTranslationConfiguration().Show();
        }

        private void buttonSetLocalDataSource_Click(object sender, RibbonControlEventArgs e)
        {
            new AddLocalDataSource().execute();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iAcronym"></param>
        internal void setAcronymAndTranslations(IAcronym iAcronym)
        {
            lblAcronym.Label = string.Format("Acronym: {0}", iAcronym.Text);
            drpDwnTranslations.Items.Clear();

            foreach (string translation in iAcronym.Translations)
            {
                RibbonDropDownItem item = this.Factory.CreateRibbonDropDownItem();
                item.Label = translation;
                drpDwnTranslations.Items.Add(item);
            }
        }

        /// <summary>
        /// This event occures when you click on the expand group (grpDataSrc) button in the "Ribbon" component
        /// </summary>
        /// <param name="sender">Irrelevant</param>
        /// <param name="e">Irrelevant</param>
        private void btnSetEternalDS_Click( object                  sender, 
                                            RibbonControlEventArgs  e)
        {
            ExternalDataSourceConfiguration.getExternalDataSourceConfiguration().Show();
        }
        #endregion
    }
}