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
            Microsoft.Office.Tools.Ribbon.RibbonDialogLauncher ribbonDialogLauncherImpl1 = this.Factory.CreateRibbonDialogLauncher();
            Microsoft.Office.Tools.Ribbon.RibbonDialogLauncher ribbonDialogLauncherImpl2 = this.Factory.CreateRibbonDialogLauncher();
            this.tabAcronymHighlights = this.Factory.CreateRibbonTab();
            this.grpConfiguration = this.Factory.CreateRibbonGroup();
            this.chkBxTranslateOnRightClick = this.Factory.CreateRibbonCheckBox();
            this.chkBxMultipleMatches = this.Factory.CreateRibbonCheckBox();
            this.chkBxTranslateOnMouseHover = this.Factory.CreateRibbonCheckBox();
            this.grpDataSrc = this.Factory.CreateRibbonGroup();
            this.chkBxExternalDataSources = this.Factory.CreateRibbonCheckBox();
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
            this.grpConfiguration.DialogLauncher = ribbonDialogLauncherImpl1;
            this.grpConfiguration.Items.Add(this.chkBxTranslateOnRightClick);
            this.grpConfiguration.Items.Add(this.chkBxMultipleMatches);
            this.grpConfiguration.Items.Add(this.chkBxTranslateOnMouseHover);
            this.grpConfiguration.Label = "Translation Configuration";
            this.grpConfiguration.Name = "grpConfiguration";
            this.grpConfiguration.DialogLauncherClick += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.grpConfiguration_DialogLauncherClick);
            // 
            // chkBxTranslateOnRightClick
            // 
            this.chkBxTranslateOnRightClick.Label = "On Right Click";
            this.chkBxTranslateOnRightClick.Name = "chkBxTranslateOnRightClick";
            
            // 
            // chkBxMultipleMatches
            // 
            this.chkBxMultipleMatches.Label = "Multiple Matches";
            this.chkBxMultipleMatches.Name = "chkBxMultipleMatches";
            // 
            // chkBxTranslateOnMouseHover
            // 
            this.chkBxTranslateOnMouseHover.Label = "On Mouse Hover";
            this.chkBxTranslateOnMouseHover.Name = "chkBxTranslateOnMouseHover";
            this.chkBxTranslateOnMouseHover.Visible = false;
            // 
            // grpDataSrc
            // 
            this.grpDataSrc.DialogLauncher = ribbonDialogLauncherImpl2;
            this.grpDataSrc.Items.Add(this.chkBxExternalDataSources);
            this.grpDataSrc.Items.Add(this.buttonSetLocalDataSource);
            this.grpDataSrc.Label = "Data Source";
            this.grpDataSrc.Name = "grpDataSrc";
            this.grpDataSrc.DialogLauncherClick += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.grpDataSrc_DialogLauncherClick);
            // 
            // chkBxExternalDataSources
            // 
            this.chkBxExternalDataSources.Label = "External Data Sources";
            this.chkBxExternalDataSources.Name = "chkBxExternalDataSources";
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
    }

    partial class ThisRibbonCollection
    {
        internal AccronymHighlightsRibbon AccronymHighlightsRibbon
        {
            get { return this.GetRibbon<AccronymHighlightsRibbon>(); }
        }
    }
}
