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
            this.btnFetch = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtBxDDSPPath = new System.Windows.Forms.TextBox();
            this.lblWorkingFolder = new System.Windows.Forms.Label();
            this.lblURL = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.pnlExDataSource.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkLstBxURLAddresses
            // 
            this.chkLstBxURLAddresses.FormattingEnabled = true;
            this.chkLstBxURLAddresses.Location = new System.Drawing.Point(6, 63);
            this.chkLstBxURLAddresses.Name = "chkLstBxURLAddresses";
            this.chkLstBxURLAddresses.Size = new System.Drawing.Size(331, 214);
            this.chkLstBxURLAddresses.TabIndex = 7;
            // 
            // pnlExDataSource
            // 
            this.pnlExDataSource.BackColor = System.Drawing.Color.White;
            this.pnlExDataSource.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlExDataSource.Controls.Add(this.btnFetch);
            this.pnlExDataSource.Controls.Add(this.btnBrowse);
            this.pnlExDataSource.Controls.Add(this.txtBxDDSPPath);
            this.pnlExDataSource.Controls.Add(this.lblWorkingFolder);
            this.pnlExDataSource.Controls.Add(this.lblURL);
            this.pnlExDataSource.Controls.Add(this.chkLstBxURLAddresses);
            this.pnlExDataSource.Location = new System.Drawing.Point(3, 3);
            this.pnlExDataSource.Name = "pnlExDataSource";
            this.pnlExDataSource.Size = new System.Drawing.Size(423, 287);
            this.pnlExDataSource.TabIndex = 12;
            // 
            // btnFetch
            // 
            this.btnFetch.Location = new System.Drawing.Point(262, 35);
            this.btnFetch.Name = "btnFetch";
            this.btnFetch.Size = new System.Drawing.Size(75, 23);
            this.btnFetch.TabIndex = 13;
            this.btnFetch.Text = "Fetch";
            this.btnFetch.UseVisualStyleBackColor = true;
            this.btnFetch.Click += new System.EventHandler(this.btnFetch_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(343, 35);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 12;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtBxDDSPPath
            // 
            this.txtBxDDSPPath.Location = new System.Drawing.Point(91, 9);
            this.txtBxDDSPPath.Name = "txtBxDDSPPath";
            this.txtBxDDSPPath.Size = new System.Drawing.Size(327, 20);
            this.txtBxDDSPPath.TabIndex = 11;
            // 
            // lblWorkingFolder
            // 
            this.lblWorkingFolder.AutoSize = true;
            this.lblWorkingFolder.Location = new System.Drawing.Point(3, 12);
            this.lblWorkingFolder.Name = "lblWorkingFolder";
            this.lblWorkingFolder.Size = new System.Drawing.Size(82, 13);
            this.lblWorkingFolder.TabIndex = 10;
            this.lblWorkingFolder.Text = "Working Folder:";
            // 
            // lblURL
            // 
            this.lblURL.AutoSize = true;
            this.lblURL.Location = new System.Drawing.Point(3, 40);
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
        private System.Windows.Forms.Label lblWorkingFolder;
        private System.Windows.Forms.TextBox txtBxDDSPPath;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnFetch;
        private System.Windows.Forms.Button btnBrowse;

    }
}
