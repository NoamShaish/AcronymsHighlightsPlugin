using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using AHPWordAddIn.common.GUIForms;

namespace AHPWordAddIn
{
    public partial class AccronymHighlightsRibbon
    {
        #region API
        /// <summary>
        /// 
        /// </summary>
        public void getRibbonComponentsState()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        internal void setComponentsState(AHPWordAddIn.Properties.Settings settings)
        {
            setTranslationSettings(settings);
            setExternalDataSourcesSettings(settings);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="settings"></param>
        private void setExternalDataSourcesSettings(Properties.Settings settings)
        {
            chkBxExternalDataSources.Checked = settings.EnableExternalDS;
            ExternalDataSourceConfiguration.getExternalDataSourceConfiguration().setComponentsState(settings);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="settings"></param>
        private void setTranslationSettings(Properties.Settings settings)
        {
            chkBxTranslateOnRightClick.Checked = settings.TranslateOnRightClick;
            chkBxMultipleMatches.Checked       = settings.EnableMultipleTranslation;
            chkBxTranslateOnMouseHover.Checked = settings.TranslateOnMaouseHover;

            AdvancedTranslationConfiguration.getAdvancedTranslationConfiguration().setComponentsState(settings);

        }

        #endregion
        private void AccronymHighlightsRibbon_Load(object sender, RibbonUIEventArgs e)
        {
        }

        private void grpConfiguration_DialogLauncherClick(object sender, RibbonControlEventArgs e)
        {
            AdvancedTranslationConfiguration.getAdvancedTranslationConfiguration().Show();
        }

        private void grpDataSrc_DialogLauncherClick(object sender, RibbonControlEventArgs e)
        {
            ExternalDataSourceConfiguration.getExternalDataSourceConfiguration().Show();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="settings"></param>
        internal void getComponentsState(Properties.Settings settings)
        {
            getTranslationSettings(settings);
            getExternalDataSourcesSettings(settings);
        }

        private void getExternalDataSourcesSettings(Properties.Settings settings)
        {
            settings.EnableExternalDS = chkBxExternalDataSources.Checked;
            ExternalDataSourceConfiguration.getExternalDataSourceConfiguration().getComponentsState(settings);
        }

        private void getTranslationSettings(Properties.Settings settings)
        {
            settings.TranslateOnRightClick      = chkBxTranslateOnRightClick.Checked;
            settings.EnableMultipleTranslation  = chkBxMultipleMatches.Checked;
            settings.TranslateOnMaouseHover     = chkBxTranslateOnMouseHover.Checked;

            AdvancedTranslationConfiguration.getAdvancedTranslationConfiguration().getComponentsState(settings);
        }
    }
}
