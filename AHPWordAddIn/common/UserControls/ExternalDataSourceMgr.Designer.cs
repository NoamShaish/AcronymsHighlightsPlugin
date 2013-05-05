namespace AHPWordAddIn.common.UserControls
{
    partial class ExternalDataSourceMgr
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
            this.chkLstBxURLAddresses = new System.Windows.Forms.CheckedListBox();
            this.pnlExDataSource = new System.Windows.Forms.Panel();
            this.lblURL = new System.Windows.Forms.Label();
            this.pnlExDataSource.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkLstBxURLAddresses
            // 
            this.chkLstBxURLAddresses.FormattingEnabled = true;
            this.chkLstBxURLAddresses.Location = new System.Drawing.Point(6, 33);
            this.chkLstBxURLAddresses.Name = "chkLstBxURLAddresses";
            this.chkLstBxURLAddresses.Size = new System.Drawing.Size(252, 244);
            this.chkLstBxURLAddresses.TabIndex = 7;
            // 
            // pnlExDataSource
            // 
            this.pnlExDataSource.BackColor = System.Drawing.Color.White;
            this.pnlExDataSource.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlExDataSource.Controls.Add(this.lblURL);
            this.pnlExDataSource.Controls.Add(this.chkLstBxURLAddresses);
            this.pnlExDataSource.Location = new System.Drawing.Point(3, 3);
            this.pnlExDataSource.Name = "pnlExDataSource";
            this.pnlExDataSource.Size = new System.Drawing.Size(423, 287);
            this.pnlExDataSource.TabIndex = 12;
            // 
            // lblURL
            // 
            this.lblURL.AutoSize = true;
            this.lblURL.Location = new System.Drawing.Point(4, 14);
            this.lblURL.Name = "lblURL";
            this.lblURL.Size = new System.Drawing.Size(116, 13);
            this.lblURL.TabIndex = 9;
            this.lblURL.Text = "External Data Sources:";
            // 
            // ExternalDataSourceMgr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.Controls.Add(this.pnlExDataSource);
            this.Name = "ExternalDataSourceMgr";
            this.Size = new System.Drawing.Size(429, 293);
            this.pnlExDataSource.ResumeLayout(false);
            this.pnlExDataSource.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox chkLstBxURLAddresses;
        private System.Windows.Forms.Panel pnlExDataSource;
        private System.Windows.Forms.Label lblURL;

    }
}
