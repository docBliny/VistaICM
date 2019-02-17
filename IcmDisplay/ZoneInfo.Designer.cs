namespace IcmDisplay
{
    partial class ZoneInfo
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
            this.lblZoneName = new System.Windows.Forms.Label();
            this.zoneFault = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // lblZoneName
            // 
            this.lblZoneName.AutoEllipsis = true;
            this.lblZoneName.AutoSize = true;
            this.lblZoneName.Location = new System.Drawing.Point(23, 0);
            this.lblZoneName.Margin = new System.Windows.Forms.Padding(0);
            this.lblZoneName.Name = "lblZoneName";
            this.lblZoneName.Size = new System.Drawing.Size(0, 13);
            this.lblZoneName.TabIndex = 1;
            this.lblZoneName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // zoneFault
            // 
            this.zoneFault.BackColor = System.Drawing.Color.Silver;
            this.zoneFault.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.zoneFault.Location = new System.Drawing.Point(0, 0);
            this.zoneFault.Name = "zoneFault";
            this.zoneFault.Size = new System.Drawing.Size(16, 16);
            this.zoneFault.TabIndex = 0;
            // 
            // ZoneInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblZoneName);
            this.Controls.Add(this.zoneFault);
            this.Name = "ZoneInfo";
            this.Size = new System.Drawing.Size(150, 16);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblZoneName;
        private System.Windows.Forms.Panel zoneFault;
    }
}
