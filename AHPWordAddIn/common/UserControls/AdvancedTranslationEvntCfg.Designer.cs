namespace AHPWordAddIn.common.UserControls
{
    partial class AdvancedTranslationEvntCfg
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.pnlMouseHoverTimer = new System.Windows.Forms.Panel();
            this.pnlMultipleMatchesCfg = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pnlMouseHoverTimer
            // 
            this.pnlMouseHoverTimer.Location = new System.Drawing.Point(182, 3);
            this.pnlMouseHoverTimer.Name = "pnlMouseHoverTimer";
            this.pnlMouseHoverTimer.Size = new System.Drawing.Size(132, 117);
            this.pnlMouseHoverTimer.TabIndex = 0;
            this.pnlMouseHoverTimer.Visible = false;
            // 
            // pnlMultipleMatchesCfg
            // 
            this.pnlMultipleMatchesCfg.Location = new System.Drawing.Point(3, 3);
            this.pnlMultipleMatchesCfg.Name = "pnlMultipleMatchesCfg";
            this.pnlMultipleMatchesCfg.Size = new System.Drawing.Size(170, 117);
            this.pnlMultipleMatchesCfg.TabIndex = 1;
            // 
            // AdvancedTranslationEvntCfg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlMultipleMatchesCfg);
            this.Controls.Add(this.pnlMouseHoverTimer);
            this.Name = "AdvancedTranslationEvntCfg";
            this.Size = new System.Drawing.Size(314, 126);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMouseHoverTimer;
        private System.Windows.Forms.Panel pnlMultipleMatchesCfg;
    }
}
