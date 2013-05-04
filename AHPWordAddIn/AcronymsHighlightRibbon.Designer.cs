namespace AHPWordAddIn
{
    partial class AcronymsHighlightRibbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public AcronymsHighlightRibbon()
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
            this.tabMain = this.Factory.CreateRibbonTab();
            this.groupCommands = this.Factory.CreateRibbonGroup();
            this.buttonAddLocalDataSource = this.Factory.CreateRibbonButton();
            this.tabMain.SuspendLayout();
            this.groupCommands.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tabMain.Groups.Add(this.groupCommands);
            this.tabMain.Label = "Acronyms Highlight";
            this.tabMain.Name = "tabMain";
            // 
            // groupCommands
            // 
            this.groupCommands.Items.Add(this.buttonAddLocalDataSource);
            this.groupCommands.Label = "Commands";
            this.groupCommands.Name = "groupCommands";
            // 
            // buttonAddLocalDataSource
            // 
            this.buttonAddLocalDataSource.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.buttonAddLocalDataSource.Label = "Set Data Source";
            this.buttonAddLocalDataSource.Name = "buttonAddLocalDataSource";
            this.buttonAddLocalDataSource.ShowImage = true;
            this.buttonAddLocalDataSource.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.buttonAddLocalDataSource_Click);
            // 
            // AcronymsHighlightRibbon
            // 
            this.Name = "AcronymsHighlightRibbon";
            this.RibbonType = "Microsoft.Word.Document";
            this.Tabs.Add(this.tabMain);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.AcronymsHighlightRibbon_Load);
            this.tabMain.ResumeLayout(false);
            this.tabMain.PerformLayout();
            this.groupCommands.ResumeLayout(false);
            this.groupCommands.PerformLayout();

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tabMain;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup groupCommands;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton buttonAddLocalDataSource;
    }

    partial class ThisRibbonCollection
    {
        internal AcronymsHighlightRibbon AcronymsHighlightRibbon
        {
            get { return this.GetRibbon<AcronymsHighlightRibbon>(); }
        }
    }
}
