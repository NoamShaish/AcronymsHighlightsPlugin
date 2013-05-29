namespace AHPWordAddIn
{
    partial class AccronymHighlightsRibbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public AccronymHighlightsRibbon()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem ribbonDropDownItemImpl1 = this.Factory.CreateRibbonDropDownItem();
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem ribbonDropDownItemImpl2 = this.Factory.CreateRibbonDropDownItem();
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem ribbonDropDownItemImpl3 = this.Factory.CreateRibbonDropDownItem();
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem ribbonDropDownItemImpl4 = this.Factory.CreateRibbonDropDownItem();
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem ribbonDropDownItemImpl5 = this.Factory.CreateRibbonDropDownItem();
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem ribbonDropDownItemImpl6 = this.Factory.CreateRibbonDropDownItem();
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem ribbonDropDownItemImpl7 = this.Factory.CreateRibbonDropDownItem();
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem ribbonDropDownItemImpl8 = this.Factory.CreateRibbonDropDownItem();
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem ribbonDropDownItemImpl9 = this.Factory.CreateRibbonDropDownItem();
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem ribbonDropDownItemImpl10 = this.Factory.CreateRibbonDropDownItem();
            this.tabAcronymHighlights = this.Factory.CreateRibbonTab();
            this.grpConfiguration = this.Factory.CreateRibbonGroup();
            this.chkBxTranslateOnRightClick = this.Factory.CreateRibbonCheckBox();
            this.chkBxTranslateOnMouseHover = this.Factory.CreateRibbonCheckBox();
            this.chkBxMultipleMatches = this.Factory.CreateRibbonCheckBox();
            this.drpDwnNumberOfTranslations = this.Factory.CreateRibbonDropDown();
            this.grpDataSrc = this.Factory.CreateRibbonGroup();
            this.chkBxExternalDataSources = this.Factory.CreateRibbonCheckBox();
            this.btnSetEternalDS = this.Factory.CreateRibbonButton();
            this.buttonSetLocalDataSource = this.Factory.CreateRibbonButton();
            this.grpTranslationSection = this.Factory.CreateRibbonGroup();
            this.lblAcronym = this.Factory.CreateRibbonLabel();
            this.drpDwnTranslations = this.Factory.CreateRibbonDropDown();
            this.tabAcronymHighlights.SuspendLayout();
            this.grpConfiguration.SuspendLayout();
            this.grpDataSrc.SuspendLayout();
            this.grpTranslationSection.SuspendLayout();
            // 
            // tabAcronymHighlights
            // 
            this.tabAcronymHighlights.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tabAcronymHighlights.Groups.Add(this.grpConfiguration);
            this.tabAcronymHighlights.Groups.Add(this.grpDataSrc);
            this.tabAcronymHighlights.Groups.Add(this.grpTranslationSection);
            this.tabAcronymHighlights.Label = "Acronym Highlights";
            this.tabAcronymHighlights.Name = "tabAcronymHighlights";
            // 
            // grpConfiguration
            // 
            this.grpConfiguration.Items.Add(this.chkBxTranslateOnRightClick);
            this.grpConfiguration.Items.Add(this.chkBxTranslateOnMouseHover);
            this.grpConfiguration.Items.Add(this.chkBxMultipleMatches);
            this.grpConfiguration.Items.Add(this.drpDwnNumberOfTranslations);
            this.grpConfiguration.Label = "Translation Configuration";
            this.grpConfiguration.Name = "grpConfiguration";
            this.grpConfiguration.DialogLauncherClick += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.grpConfiguration_DialogLauncherClick);
            // 
            // chkBxTranslateOnRightClick
            // 
            this.chkBxTranslateOnRightClick.Label = "On Right Click";
            this.chkBxTranslateOnRightClick.Name = "chkBxTranslateOnRightClick";
            // 
            // chkBxTranslateOnMouseHover
            // 
            this.chkBxTranslateOnMouseHover.Label = "On Mouse Hover";
            this.chkBxTranslateOnMouseHover.Name = "chkBxTranslateOnMouseHover";
            this.chkBxTranslateOnMouseHover.Visible = false;
            // 
            // chkBxMultipleMatches
            // 
            this.chkBxMultipleMatches.Label = "Multiple Matches";
            this.chkBxMultipleMatches.Name = "chkBxMultipleMatches";
            // 
            // drpDwnNumberOfTranslations
            // 
            ribbonDropDownItemImpl1.Label = "1";
            ribbonDropDownItemImpl2.Label = "2";
            ribbonDropDownItemImpl3.Label = "2";
            ribbonDropDownItemImpl4.Label = "3";
            ribbonDropDownItemImpl5.Label = "4";
            ribbonDropDownItemImpl6.Label = "5";
            ribbonDropDownItemImpl7.Label = "6";
            ribbonDropDownItemImpl8.Label = "7";
            ribbonDropDownItemImpl9.Label = "8";
            ribbonDropDownItemImpl10.Label = "9";
            this.drpDwnNumberOfTranslations.Items.Add(ribbonDropDownItemImpl1);
            this.drpDwnNumberOfTranslations.Items.Add(ribbonDropDownItemImpl2);
            this.drpDwnNumberOfTranslations.Items.Add(ribbonDropDownItemImpl3);
            this.drpDwnNumberOfTranslations.Items.Add(ribbonDropDownItemImpl4);
            this.drpDwnNumberOfTranslations.Items.Add(ribbonDropDownItemImpl5);
            this.drpDwnNumberOfTranslations.Items.Add(ribbonDropDownItemImpl6);
            this.drpDwnNumberOfTranslations.Items.Add(ribbonDropDownItemImpl7);
            this.drpDwnNumberOfTranslations.Items.Add(ribbonDropDownItemImpl8);
            this.drpDwnNumberOfTranslations.Items.Add(ribbonDropDownItemImpl9);
            this.drpDwnNumberOfTranslations.Items.Add(ribbonDropDownItemImpl10);
            this.drpDwnNumberOfTranslations.Label = "Number of Matches:";
            this.drpDwnNumberOfTranslations.Name = "drpDwnNumberOfTranslations";
            // 
            // grpDataSrc
            // 
            this.grpDataSrc.Items.Add(this.chkBxExternalDataSources);
            this.grpDataSrc.Items.Add(this.btnSetEternalDS);
            this.grpDataSrc.Items.Add(this.buttonSetLocalDataSource);
            this.grpDataSrc.Label = "Data Source";
            this.grpDataSrc.Name = "grpDataSrc";
            // 
            // chkBxExternalDataSources
            // 
            this.chkBxExternalDataSources.Label = "External Data Sources";
            this.chkBxExternalDataSources.Name = "chkBxExternalDataSources";
            // 
            // btnSetEternalDS
            // 
            this.btnSetEternalDS.Label = "Set External Data Sources";
            this.btnSetEternalDS.Name = "btnSetEternalDS";
            this.btnSetEternalDS.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnSetEternalDS_Click);
            // 
            // buttonSetLocalDataSource
            // 
            this.buttonSetLocalDataSource.Label = "Set Local Data Source";
            this.buttonSetLocalDataSource.Name = "buttonSetLocalDataSource";
            this.buttonSetLocalDataSource.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.buttonSetLocalDataSource_Click);
            // 
            // grpTranslationSection
            // 
            this.grpTranslationSection.Items.Add(this.lblAcronym);
            this.grpTranslationSection.Items.Add(this.drpDwnTranslations);
            this.grpTranslationSection.Label = "Translation Section";
            this.grpTranslationSection.Name = "grpTranslationSection";
            // 
            // lblAcronym
            // 
            this.lblAcronym.Label = "Acronym:";
            this.lblAcronym.Name = "lblAcronym";
            // 
            // drpDwnTranslations
            // 
            this.drpDwnTranslations.Label = "Tranalstions:";
            this.drpDwnTranslations.Name = "drpDwnTranslations";
            // 
            // AccronymHighlightsRibbon
            // 
            this.Name = "AccronymHighlightsRibbon";
            this.RibbonType = "Microsoft.Word.Document";
            this.Tabs.Add(this.tabAcronymHighlights);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.AccronymHighlightsRibbon_Load);
            this.tabAcronymHighlights.ResumeLayout(false);
            this.tabAcronymHighlights.PerformLayout();
            this.grpConfiguration.ResumeLayout(false);
            this.grpConfiguration.PerformLayout();
            this.grpDataSrc.ResumeLayout(false);
            this.grpDataSrc.PerformLayout();
            this.grpTranslationSection.ResumeLayout(false);
            this.grpTranslationSection.PerformLayout();

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonGroup grpConfiguration;
        internal Microsoft.Office.Tools.Ribbon.RibbonTab tabAcronymHighlights;
        internal Microsoft.Office.Tools.Ribbon.RibbonCheckBox chkBxTranslateOnRightClick;
        internal Microsoft.Office.Tools.Ribbon.RibbonCheckBox chkBxTranslateOnMouseHover;
        internal Microsoft.Office.Tools.Ribbon.RibbonCheckBox chkBxMultipleMatches;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup grpDataSrc;
        internal Microsoft.Office.Tools.Ribbon.RibbonCheckBox chkBxExternalDataSources;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton buttonSetLocalDataSource;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup grpTranslationSection;
        internal Microsoft.Office.Tools.Ribbon.RibbonLabel lblAcronym;
        internal Microsoft.Office.Tools.Ribbon.RibbonDropDown drpDwnTranslations;
        internal Microsoft.Office.Tools.Ribbon.RibbonDropDown drpDwnNumberOfTranslations;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnSetEternalDS;
    }

    partial class ThisRibbonCollection
    {
        internal AccronymHighlightsRibbon AccronymHighlightsRibbon
        {
            get { return this.GetRibbon<AccronymHighlightsRibbon>(); }
        }
    }
}
