namespace IcmDisplay
{
    partial class frmConsole
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsole));
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.pnlControls = new System.Windows.Forms.Panel();
            this.lblReady = new System.Windows.Forms.Label();
            this.ReadyLight = new System.Windows.Forms.Panel();
            this.lblArmed = new System.Windows.Forms.Label();
            this.ArmedLight = new System.Windows.Forms.Panel();
            this.lblDisplay = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.tblZones = new System.Windows.Forms.TableLayoutPanel();
            this.chkVerbose = new System.Windows.Forms.CheckBox();
            this.zoneInfo1 = new IcmDisplay.ZoneInfo();
            this.zoneInfo2 = new IcmDisplay.ZoneInfo();
            this.zoneInfo3 = new IcmDisplay.ZoneInfo();
            this.zoneInfo4 = new IcmDisplay.ZoneInfo();
            this.zoneInfo5 = new IcmDisplay.ZoneInfo();
            this.zoneInfo6 = new IcmDisplay.ZoneInfo();
            this.zoneInfo7 = new IcmDisplay.ZoneInfo();
            this.zoneInfo8 = new IcmDisplay.ZoneInfo();
            this.zoneInfo9 = new IcmDisplay.ZoneInfo();
            this.zoneInfo10 = new IcmDisplay.ZoneInfo();
            this.zoneInfo11 = new IcmDisplay.ZoneInfo();
            this.zoneInfo12 = new IcmDisplay.ZoneInfo();
            this.zoneInfo13 = new IcmDisplay.ZoneInfo();
            this.zoneInfo14 = new IcmDisplay.ZoneInfo();
            this.zoneInfo15 = new IcmDisplay.ZoneInfo();
            this.zoneInfo16 = new IcmDisplay.ZoneInfo();
            this.pnlControls.SuspendLayout();
            this.tblZones.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtbLog
            // 
            this.rtbLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbLog.DetectUrls = false;
            this.rtbLog.Location = new System.Drawing.Point(12, 248);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.ReadOnly = true;
            this.rtbLog.Size = new System.Drawing.Size(520, 149);
            this.rtbLog.TabIndex = 0;
            this.rtbLog.Text = "";
            // 
            // pnlControls
            // 
            this.pnlControls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlControls.Controls.Add(this.lblReady);
            this.pnlControls.Controls.Add(this.ReadyLight);
            this.pnlControls.Controls.Add(this.lblArmed);
            this.pnlControls.Controls.Add(this.ArmedLight);
            this.pnlControls.Controls.Add(this.lblDisplay);
            this.pnlControls.Controls.Add(this.btnClear);
            this.pnlControls.Controls.Add(this.tblZones);
            this.pnlControls.Controls.Add(this.chkVerbose);
            this.pnlControls.Location = new System.Drawing.Point(0, 0);
            this.pnlControls.Name = "pnlControls";
            this.pnlControls.Size = new System.Drawing.Size(544, 227);
            this.pnlControls.TabIndex = 1;
            // 
            // lblReady
            // 
            this.lblReady.AutoSize = true;
            this.lblReady.Location = new System.Drawing.Point(101, 73);
            this.lblReady.Name = "lblReady";
            this.lblReady.Size = new System.Drawing.Size(38, 13);
            this.lblReady.TabIndex = 7;
            this.lblReady.Text = "Ready";
            // 
            // ReadyLight
            // 
            this.ReadyLight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ReadyLight.Location = new System.Drawing.Point(81, 76);
            this.ReadyLight.Name = "ReadyLight";
            this.ReadyLight.Size = new System.Drawing.Size(16, 8);
            this.ReadyLight.TabIndex = 6;
            // 
            // lblArmed
            // 
            this.lblArmed.AutoSize = true;
            this.lblArmed.Location = new System.Drawing.Point(36, 73);
            this.lblArmed.Name = "lblArmed";
            this.lblArmed.Size = new System.Drawing.Size(37, 13);
            this.lblArmed.TabIndex = 5;
            this.lblArmed.Text = "Armed";
            // 
            // ArmedLight
            // 
            this.ArmedLight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ArmedLight.Location = new System.Drawing.Point(16, 76);
            this.ArmedLight.Name = "ArmedLight";
            this.ArmedLight.Size = new System.Drawing.Size(16, 8);
            this.ArmedLight.TabIndex = 4;
            // 
            // lblDisplay
            // 
            this.lblDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDisplay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblDisplay.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDisplay.Font = new System.Drawing.Font("Courier New", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisplay.Location = new System.Drawing.Point(12, 13);
            this.lblDisplay.Name = "lblDisplay";
            this.lblDisplay.Size = new System.Drawing.Size(520, 56);
            this.lblDisplay.TabIndex = 3;
            this.lblDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Location = new System.Drawing.Point(457, 201);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // tblZones
            // 
            this.tblZones.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tblZones.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Outset;
            this.tblZones.ColumnCount = 4;
            this.tblZones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblZones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblZones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblZones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblZones.Controls.Add(this.zoneInfo1, 0, 0);
            this.tblZones.Controls.Add(this.zoneInfo2, 1, 0);
            this.tblZones.Controls.Add(this.zoneInfo3, 2, 0);
            this.tblZones.Controls.Add(this.zoneInfo4, 3, 0);
            this.tblZones.Controls.Add(this.zoneInfo5, 0, 1);
            this.tblZones.Controls.Add(this.zoneInfo6, 1, 1);
            this.tblZones.Controls.Add(this.zoneInfo7, 2, 1);
            this.tblZones.Controls.Add(this.zoneInfo8, 3, 1);
            this.tblZones.Controls.Add(this.zoneInfo9, 0, 2);
            this.tblZones.Controls.Add(this.zoneInfo10, 1, 2);
            this.tblZones.Controls.Add(this.zoneInfo11, 2, 2);
            this.tblZones.Controls.Add(this.zoneInfo12, 3, 2);
            this.tblZones.Controls.Add(this.zoneInfo13, 0, 3);
            this.tblZones.Controls.Add(this.zoneInfo14, 1, 3);
            this.tblZones.Controls.Add(this.zoneInfo15, 2, 3);
            this.tblZones.Controls.Add(this.zoneInfo16, 3, 3);
            this.tblZones.Location = new System.Drawing.Point(13, 95);
            this.tblZones.Name = "tblZones";
            this.tblZones.RowCount = 4;
            this.tblZones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblZones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblZones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblZones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblZones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblZones.Size = new System.Drawing.Size(519, 98);
            this.tblZones.TabIndex = 1;
            // 
            // chkVerbose
            // 
            this.chkVerbose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkVerbose.AutoSize = true;
            this.chkVerbose.Location = new System.Drawing.Point(12, 207);
            this.chkVerbose.Name = "chkVerbose";
            this.chkVerbose.Size = new System.Drawing.Size(151, 17);
            this.chkVerbose.TabIndex = 0;
            this.chkVerbose.Text = "Display verbose messages";
            this.chkVerbose.UseVisualStyleBackColor = true;
            this.chkVerbose.CheckedChanged += new System.EventHandler(this.chkVerbose_CheckedChanged);
            // 
            // zoneInfo1
            // 
            this.zoneInfo1.IsFaulted = false;
            this.zoneInfo1.Location = new System.Drawing.Point(5, 5);
            this.zoneInfo1.Name = "zoneInfo1";
            this.zoneInfo1.Size = new System.Drawing.Size(121, 16);
            this.zoneInfo1.TabIndex = 0;
            this.zoneInfo1.ZoneID = 0;
            this.zoneInfo1.ZoneName = "";
            // 
            // zoneInfo2
            // 
            this.zoneInfo2.IsFaulted = false;
            this.zoneInfo2.Location = new System.Drawing.Point(134, 5);
            this.zoneInfo2.Name = "zoneInfo2";
            this.zoneInfo2.Size = new System.Drawing.Size(121, 16);
            this.zoneInfo2.TabIndex = 1;
            this.zoneInfo2.ZoneID = 0;
            this.zoneInfo2.ZoneName = "";
            // 
            // zoneInfo3
            // 
            this.zoneInfo3.IsFaulted = false;
            this.zoneInfo3.Location = new System.Drawing.Point(263, 5);
            this.zoneInfo3.Name = "zoneInfo3";
            this.zoneInfo3.Size = new System.Drawing.Size(121, 16);
            this.zoneInfo3.TabIndex = 2;
            this.zoneInfo3.ZoneID = 0;
            this.zoneInfo3.ZoneName = "";
            // 
            // zoneInfo4
            // 
            this.zoneInfo4.IsFaulted = false;
            this.zoneInfo4.Location = new System.Drawing.Point(392, 5);
            this.zoneInfo4.Name = "zoneInfo4";
            this.zoneInfo4.Size = new System.Drawing.Size(122, 16);
            this.zoneInfo4.TabIndex = 3;
            this.zoneInfo4.ZoneID = 0;
            this.zoneInfo4.ZoneName = "";
            // 
            // zoneInfo5
            // 
            this.zoneInfo5.IsFaulted = false;
            this.zoneInfo5.Location = new System.Drawing.Point(5, 29);
            this.zoneInfo5.Name = "zoneInfo5";
            this.zoneInfo5.Size = new System.Drawing.Size(121, 16);
            this.zoneInfo5.TabIndex = 4;
            this.zoneInfo5.ZoneID = 0;
            this.zoneInfo5.ZoneName = "";
            // 
            // zoneInfo6
            // 
            this.zoneInfo6.IsFaulted = false;
            this.zoneInfo6.Location = new System.Drawing.Point(134, 29);
            this.zoneInfo6.Name = "zoneInfo6";
            this.zoneInfo6.Size = new System.Drawing.Size(121, 16);
            this.zoneInfo6.TabIndex = 5;
            this.zoneInfo6.ZoneID = 0;
            this.zoneInfo6.ZoneName = "";
            // 
            // zoneInfo7
            // 
            this.zoneInfo7.IsFaulted = false;
            this.zoneInfo7.Location = new System.Drawing.Point(263, 29);
            this.zoneInfo7.Name = "zoneInfo7";
            this.zoneInfo7.Size = new System.Drawing.Size(121, 16);
            this.zoneInfo7.TabIndex = 6;
            this.zoneInfo7.ZoneID = 0;
            this.zoneInfo7.ZoneName = "";
            // 
            // zoneInfo8
            // 
            this.zoneInfo8.IsFaulted = false;
            this.zoneInfo8.Location = new System.Drawing.Point(392, 29);
            this.zoneInfo8.Name = "zoneInfo8";
            this.zoneInfo8.Size = new System.Drawing.Size(122, 16);
            this.zoneInfo8.TabIndex = 7;
            this.zoneInfo8.ZoneID = 0;
            this.zoneInfo8.ZoneName = "";
            // 
            // zoneInfo9
            // 
            this.zoneInfo9.IsFaulted = false;
            this.zoneInfo9.Location = new System.Drawing.Point(5, 53);
            this.zoneInfo9.Name = "zoneInfo9";
            this.zoneInfo9.Size = new System.Drawing.Size(121, 16);
            this.zoneInfo9.TabIndex = 8;
            this.zoneInfo9.ZoneID = 0;
            this.zoneInfo9.ZoneName = "";
            // 
            // zoneInfo10
            // 
            this.zoneInfo10.IsFaulted = false;
            this.zoneInfo10.Location = new System.Drawing.Point(134, 53);
            this.zoneInfo10.Name = "zoneInfo10";
            this.zoneInfo10.Size = new System.Drawing.Size(121, 16);
            this.zoneInfo10.TabIndex = 9;
            this.zoneInfo10.ZoneID = 0;
            this.zoneInfo10.ZoneName = "";
            // 
            // zoneInfo11
            // 
            this.zoneInfo11.IsFaulted = false;
            this.zoneInfo11.Location = new System.Drawing.Point(263, 53);
            this.zoneInfo11.Name = "zoneInfo11";
            this.zoneInfo11.Size = new System.Drawing.Size(121, 16);
            this.zoneInfo11.TabIndex = 10;
            this.zoneInfo11.ZoneID = 0;
            this.zoneInfo11.ZoneName = "";
            // 
            // zoneInfo12
            // 
            this.zoneInfo12.IsFaulted = false;
            this.zoneInfo12.Location = new System.Drawing.Point(392, 53);
            this.zoneInfo12.Name = "zoneInfo12";
            this.zoneInfo12.Size = new System.Drawing.Size(122, 16);
            this.zoneInfo12.TabIndex = 11;
            this.zoneInfo12.ZoneID = 0;
            this.zoneInfo12.ZoneName = "";
            // 
            // zoneInfo13
            // 
            this.zoneInfo13.IsFaulted = false;
            this.zoneInfo13.Location = new System.Drawing.Point(5, 77);
            this.zoneInfo13.Name = "zoneInfo13";
            this.zoneInfo13.Size = new System.Drawing.Size(121, 16);
            this.zoneInfo13.TabIndex = 12;
            this.zoneInfo13.ZoneID = 0;
            this.zoneInfo13.ZoneName = "";
            // 
            // zoneInfo14
            // 
            this.zoneInfo14.IsFaulted = false;
            this.zoneInfo14.Location = new System.Drawing.Point(134, 77);
            this.zoneInfo14.Name = "zoneInfo14";
            this.zoneInfo14.Size = new System.Drawing.Size(121, 16);
            this.zoneInfo14.TabIndex = 13;
            this.zoneInfo14.ZoneID = 0;
            this.zoneInfo14.ZoneName = "";
            // 
            // zoneInfo15
            // 
            this.zoneInfo15.IsFaulted = false;
            this.zoneInfo15.Location = new System.Drawing.Point(263, 77);
            this.zoneInfo15.Name = "zoneInfo15";
            this.zoneInfo15.Size = new System.Drawing.Size(121, 16);
            this.zoneInfo15.TabIndex = 14;
            this.zoneInfo15.ZoneID = 0;
            this.zoneInfo15.ZoneName = "";
            // 
            // zoneInfo16
            // 
            this.zoneInfo16.IsFaulted = false;
            this.zoneInfo16.Location = new System.Drawing.Point(392, 77);
            this.zoneInfo16.Name = "zoneInfo16";
            this.zoneInfo16.Size = new System.Drawing.Size(122, 16);
            this.zoneInfo16.TabIndex = 15;
            this.zoneInfo16.ZoneID = 0;
            this.zoneInfo16.ZoneName = "";
            // 
            // frmConsole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 409);
            this.Controls.Add(this.pnlControls);
            this.Controls.Add(this.rtbLog);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(560, 267);
            this.Name = "frmConsole";
            this.Text = "Vista ICM Viewer";
            this.Load += new System.EventHandler(this.Console_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Console_FormClosing);
            this.pnlControls.ResumeLayout(false);
            this.pnlControls.PerformLayout();
            this.tblZones.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.Panel pnlControls;
        private System.Windows.Forms.CheckBox chkVerbose;
        private System.Windows.Forms.TableLayoutPanel tblZones;
        private ZoneInfo zoneInfo1;
        private System.Windows.Forms.Button btnClear;
        private ZoneInfo zoneInfo2;
        private ZoneInfo zoneInfo3;
        private ZoneInfo zoneInfo4;
        private ZoneInfo zoneInfo5;
        private ZoneInfo zoneInfo6;
        private ZoneInfo zoneInfo7;
        private ZoneInfo zoneInfo8;
        private ZoneInfo zoneInfo9;
        private ZoneInfo zoneInfo10;
        private ZoneInfo zoneInfo11;
        private ZoneInfo zoneInfo12;
        private ZoneInfo zoneInfo13;
        private ZoneInfo zoneInfo14;
        private ZoneInfo zoneInfo15;
        private ZoneInfo zoneInfo16;
        private System.Windows.Forms.Label lblDisplay;
        private System.Windows.Forms.Label lblReady;
        private System.Windows.Forms.Panel ReadyLight;
        private System.Windows.Forms.Label lblArmed;
        private System.Windows.Forms.Panel ArmedLight;
    }
}

