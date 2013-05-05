namespace AHPWordAddIn.common.UserControls
{
    partial class MultipleMatchesConfiguration
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmBxNumResults = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmBxNumResults);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(179, 48);
            this.panel1.TabIndex = 0;
            // 
            // cmBxNumResults
            // 
            this.cmBxNumResults.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmBxNumResults.FormattingEnabled = true;
            this.cmBxNumResults.Items.AddRange(new object[] {
            "1 Results",
            "2 Results",
            "3 Results",
            "4 Results",
            "5 Results",
            "6 Results",
            "7 Results",
            "8 Results",
            "9 Results",
            "10 Results"});
            this.cmBxNumResults.Location = new System.Drawing.Point(6, 22);
            this.cmBxNumResults.Name = "cmBxNumResults";
            this.cmBxNumResults.Size = new System.Drawing.Size(121, 21);
            this.cmBxNumResults.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Maximum Number of Results:";
            // 
            // MultipleMatchesConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "MultipleMatchesConfiguration";
            this.Size = new System.Drawing.Size(179, 48);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.ComboBox cmBxNumResults;
    }
}
