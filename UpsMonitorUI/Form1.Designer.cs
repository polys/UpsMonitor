namespace UpsMonitorUI
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ShowHideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PortStatusPicBox = new System.Windows.Forms.PictureBox();
            this.BatteryStatusPicBox = new System.Windows.Forms.PictureBox();
            this.AcStatusPicBox = new System.Windows.Forms.PictureBox();
            this.PortStatusLabel = new System.Windows.Forms.Label();
            this.BatteryStatusLabel = new System.Windows.Forms.Label();
            this.AcStatuslabel = new System.Windows.Forms.Label();
            this.HideLinkLabel = new System.Windows.Forms.LinkLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PortStatusPicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BatteryStatusPicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AcStatusPicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "UPS Monitor";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.BalloonTipClicked += new System.EventHandler(this.notifyIcon1_BalloonTipClicked);
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowHideToolStripMenuItem,
            this.toolStripSeparator2,
            this.ExitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 76);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // ShowHideToolStripMenuItem
            // 
            this.ShowHideToolStripMenuItem.Name = "ShowHideToolStripMenuItem";
            this.ShowHideToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.ShowHideToolStripMenuItem.Text = "Show";
            this.ShowHideToolStripMenuItem.Click += new System.EventHandler(this.ShowHideToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.ExitToolStripMenuItem.Text = "Exit";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // PortStatusPicBox
            // 
            this.PortStatusPicBox.BackColor = System.Drawing.Color.Transparent;
            this.PortStatusPicBox.Image = global::UpsMonitorUI.Properties.Resources.Green24;
            this.PortStatusPicBox.Location = new System.Drawing.Point(28, 31);
            this.PortStatusPicBox.Margin = new System.Windows.Forms.Padding(3, 3, 6, 15);
            this.PortStatusPicBox.Name = "PortStatusPicBox";
            this.PortStatusPicBox.Size = new System.Drawing.Size(25, 25);
            this.PortStatusPicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.PortStatusPicBox.TabIndex = 4;
            this.PortStatusPicBox.TabStop = false;
            // 
            // BatteryStatusPicBox
            // 
            this.BatteryStatusPicBox.BackColor = System.Drawing.Color.Transparent;
            this.BatteryStatusPicBox.Image = global::UpsMonitorUI.Properties.Resources.Green24;
            this.BatteryStatusPicBox.Location = new System.Drawing.Point(28, 117);
            this.BatteryStatusPicBox.Margin = new System.Windows.Forms.Padding(3, 3, 6, 15);
            this.BatteryStatusPicBox.Name = "BatteryStatusPicBox";
            this.BatteryStatusPicBox.Size = new System.Drawing.Size(25, 25);
            this.BatteryStatusPicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.BatteryStatusPicBox.TabIndex = 5;
            this.BatteryStatusPicBox.TabStop = false;
            // 
            // AcStatusPicBox
            // 
            this.AcStatusPicBox.BackColor = System.Drawing.Color.Transparent;
            this.AcStatusPicBox.Image = global::UpsMonitorUI.Properties.Resources.Green24;
            this.AcStatusPicBox.Location = new System.Drawing.Point(28, 74);
            this.AcStatusPicBox.Margin = new System.Windows.Forms.Padding(3, 3, 6, 15);
            this.AcStatusPicBox.Name = "AcStatusPicBox";
            this.AcStatusPicBox.Size = new System.Drawing.Size(25, 25);
            this.AcStatusPicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.AcStatusPicBox.TabIndex = 6;
            this.AcStatusPicBox.TabStop = false;
            // 
            // PortStatusLabel
            // 
            this.PortStatusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PortStatusLabel.BackColor = System.Drawing.Color.Transparent;
            this.PortStatusLabel.Location = new System.Drawing.Point(62, 31);
            this.PortStatusLabel.Name = "PortStatusLabel";
            this.PortStatusLabel.Size = new System.Drawing.Size(214, 25);
            this.PortStatusLabel.TabIndex = 7;
            this.PortStatusLabel.Text = "Connected";
            this.PortStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BatteryStatusLabel
            // 
            this.BatteryStatusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BatteryStatusLabel.BackColor = System.Drawing.Color.Transparent;
            this.BatteryStatusLabel.Location = new System.Drawing.Point(62, 117);
            this.BatteryStatusLabel.Name = "BatteryStatusLabel";
            this.BatteryStatusLabel.Size = new System.Drawing.Size(214, 25);
            this.BatteryStatusLabel.TabIndex = 8;
            this.BatteryStatusLabel.Text = "Low Battery";
            this.BatteryStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AcStatuslabel
            // 
            this.AcStatuslabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AcStatuslabel.BackColor = System.Drawing.Color.Transparent;
            this.AcStatuslabel.Location = new System.Drawing.Point(62, 74);
            this.AcStatuslabel.Name = "AcStatuslabel";
            this.AcStatuslabel.Size = new System.Drawing.Size(214, 25);
            this.AcStatuslabel.TabIndex = 9;
            this.AcStatuslabel.Text = "label3";
            this.AcStatuslabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // HideLinkLabel
            // 
            this.HideLinkLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.HideLinkLabel.AutoSize = true;
            this.HideLinkLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.HideLinkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.HideLinkLabel.Location = new System.Drawing.Point(241, 144);
            this.HideLinkLabel.Name = "HideLinkLabel";
            this.HideLinkLabel.Size = new System.Drawing.Size(35, 17);
            this.HideLinkLabel.TabIndex = 10;
            this.HideLinkLabel.TabStop = true;
            this.HideLinkLabel.Text = "Hide";
            this.HideLinkLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.HideLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.HideLinkLabel_LinkClicked);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(294, 176);
            this.ControlBox = false;
            this.Controls.Add(this.HideLinkLabel);
            this.Controls.Add(this.AcStatuslabel);
            this.Controls.Add(this.BatteryStatusLabel);
            this.Controls.Add(this.AcStatusPicBox);
            this.Controls.Add(this.PortStatusLabel);
            this.Controls.Add(this.BatteryStatusPicBox);
            this.Controls.Add(this.PortStatusPicBox);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Opacity = 0.8D;
            this.Padding = new System.Windows.Forms.Padding(15);
            this.ShowInTaskbar = false;
            this.Text = "UPS Monitor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PortStatusPicBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BatteryStatusPicBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AcStatusPicBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ShowHideToolStripMenuItem;
        private System.Windows.Forms.PictureBox PortStatusPicBox;
        private System.Windows.Forms.PictureBox BatteryStatusPicBox;
        private System.Windows.Forms.PictureBox AcStatusPicBox;
        private System.Windows.Forms.Label PortStatusLabel;
        private System.Windows.Forms.Label BatteryStatusLabel;
        private System.Windows.Forms.Label AcStatuslabel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.LinkLabel HideLinkLabel;
        private System.Windows.Forms.Timer timer1;
    }
}

