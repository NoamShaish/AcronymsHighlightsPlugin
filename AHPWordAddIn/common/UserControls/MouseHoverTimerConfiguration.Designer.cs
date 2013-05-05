namespace AHPWordAddIn.common.UserControls
{
    partial class MouseHoverTimerConfiguration
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
            this.cmBxMsHvrTimer = new System.Windows.Forms.ComboBox();
            this.lblOnMouseHoverTimer = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmBxMsHvrTimer);
            this.panel1.Controls.Add(this.lblOnMouseHoverTimer);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(137, 47);
            this.panel1.TabIndex = 1;
            // 
            // cmBxMsHvrTimer
            // 
            this.cmBxMsHvrTimer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmBxMsHvrTimer.FormattingEnabled = true;
            this.cmBxMsHvrTimer.Items.AddRange(new object[] {
            "1 sec",
            "2 sec",
            "3 sec",
            "4 sec"});
            this.cmBxMsHvrTimer.Location = new System.Drawing.Point(6, 19);
            this.cmBxMsHvrTimer.Name = "cmBxMsHvrTimer";
            this.cmBxMsHvrTimer.Size = new System.Drawing.Size(121, 21);
            this.cmBxMsHvrTimer.TabIndex = 1;
            // 
            // lblOnMouseHoverTimer
            // 
            this.lblOnMouseHoverTimer.AutoSize = true;
            this.lblOnMouseHoverTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblOnMouseHoverTimer.Location = new System.Drawing.Point(3, 3);
            this.lblOnMouseHoverTimer.Name = "lblOnMouseHoverTimer";
            this.lblOnMouseHoverTimer.Size = new System.Drawing.Size(103, 13);
            this.lblOnMouseHoverTimer.TabIndex = 0;
            this.lblOnMouseHoverTimer.Text = "Mouse Hover Timer:";
            // 
            // MouseHoverTimerConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "MouseHoverTimerConfiguration";
            this.Size = new System.Drawing.Size(137, 47);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblOnMouseHoverTimer;
        private System.Windows.Forms.ComboBox cmBxMsHvrTimer;
    }
}
