namespace Uyanik
{
    partial class MouseJigglerForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.CheckBox checkBoxJiggling;
        private System.Windows.Forms.CheckBox checkBoxZen;
        private System.Windows.Forms.CheckBox checkBoxMinimize;
        private System.Windows.Forms.TrackBar trackBarInterval;
        private System.Windows.Forms.Label labelInterval;
        private System.Windows.Forms.Button buttonSettings;
        private System.Windows.Forms.Button buttonMenu;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.ContextMenuStrip trayMenu;
        private System.Windows.Forms.ToolStripMenuItem menuShow;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
        private System.Windows.Forms.CheckBox checkBoxStartup;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.checkBoxJiggling = new System.Windows.Forms.CheckBox();
            this.checkBoxZen = new System.Windows.Forms.CheckBox();
            this.checkBoxMinimize = new System.Windows.Forms.CheckBox();
            this.trackBarInterval = new System.Windows.Forms.TrackBar();
            this.labelInterval = new System.Windows.Forms.Label();
            this.buttonSettings = new System.Windows.Forms.Button();
            this.buttonMenu = new System.Windows.Forms.Button();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.trayMenu = new System.Windows.Forms.ContextMenuStrip();
            this.menuShow = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.checkBoxStartup = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarInterval)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBoxJiggling
            // 
            this.checkBoxJiggling.AutoSize = true;
            this.checkBoxJiggling.Checked = true;
            this.checkBoxJiggling.Location = new System.Drawing.Point(20, 20);
            this.checkBoxJiggling.Name = "checkBoxJiggling";
            this.checkBoxJiggling.Size = new System.Drawing.Size(80, 19);
            this.checkBoxJiggling.TabIndex = 0;
            this.checkBoxJiggling.Text = "Jiggling?";
            this.checkBoxJiggling.CheckedChanged += new System.EventHandler(this.checkBoxJiggling_CheckedChanged);
            // 
            // buttonSettings
            // 
            this.buttonSettings.Location = new System.Drawing.Point(110, 16);
            this.buttonSettings.Size = new System.Drawing.Size(80, 25);
            this.buttonSettings.Text = "Settings...";
            // 
            // buttonMenu
            // 
            this.buttonMenu.Location = new System.Drawing.Point(200, 16);
            this.buttonMenu.Size = new System.Drawing.Size(30, 25);
            this.buttonMenu.Text = "▼";
            // 
            // checkBoxZen
            // 
            this.checkBoxZen.AutoSize = true;
            this.checkBoxZen.Location = new System.Drawing.Point(20, 50);
            this.checkBoxZen.Name = "checkBoxZen";
            this.checkBoxZen.Size = new System.Drawing.Size(80, 19);
            this.checkBoxZen.TabIndex = 1;
            this.checkBoxZen.Text = "Zen jiggle?";
            this.checkBoxZen.CheckedChanged += new System.EventHandler(this.checkBoxZen_CheckedChanged);
            // 
            // checkBoxMinimize
            // 
            this.checkBoxMinimize.AutoSize = true;
            this.checkBoxMinimize.Location = new System.Drawing.Point(20, 75);
            this.checkBoxMinimize.Name = "checkBoxMinimize";
            this.checkBoxMinimize.Size = new System.Drawing.Size(130, 19);
            this.checkBoxMinimize.TabIndex = 2;
            this.checkBoxMinimize.Text = "Minimize on start?";
            this.checkBoxMinimize.CheckedChanged += new System.EventHandler(this.checkBoxMinimize_CheckedChanged);
            // 
            // trackBarInterval
            // 
            this.trackBarInterval.Location = new System.Drawing.Point(20, 10);
            this.trackBarInterval.Minimum = 1;
            this.trackBarInterval.Maximum = 60;
            this.trackBarInterval.Value = 10;
            this.trackBarInterval.TickFrequency = 1;
            this.trackBarInterval.Size = new System.Drawing.Size(200, 45);
            this.trackBarInterval.Scroll += new System.EventHandler(this.trackBarInterval_Scroll);
            // 
            // labelInterval
            // 
            this.labelInterval.AutoSize = true;
            this.labelInterval.Location = new System.Drawing.Point(230, 20);
            this.labelInterval.Size = new System.Drawing.Size(30, 15);
            this.labelInterval.Text = "10 s";
            // 
            // panelBottom
            // 
            this.panelBottom.Location = new System.Drawing.Point(0, 90);
            this.panelBottom.Size = new System.Drawing.Size(300, 70);
            this.panelBottom.Controls.Add(this.trackBarInterval);
            this.panelBottom.Controls.Add(this.labelInterval);
            this.panelBottom.Visible = false;
            // 
            // trayMenu
            //
            this.trayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.menuShow,
                this.menuExit});
            // menuShow
            //
            this.menuShow.Text = "Göster";
            // menuExit
            //
            this.menuExit.Text = "Çıkış";
            // checkBoxStartup
            //
            this.checkBoxStartup.AutoSize = true;
            this.checkBoxStartup.Location = new System.Drawing.Point(20, 0);
            this.checkBoxStartup.Name = "checkBoxStartup";
            this.checkBoxStartup.Size = new System.Drawing.Size(130, 19);
            this.checkBoxStartup.TabIndex = 10;
            this.checkBoxStartup.Text = "Windows ile başlat";
            // 
            // MouseJigglerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 100);
            this.Controls.Add(this.checkBoxJiggling);
            this.Controls.Add(this.buttonSettings);
            this.Controls.Add(this.buttonMenu);
            this.Controls.Add(this.checkBoxZen);
            this.Controls.Add(this.checkBoxMinimize);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.checkBoxStartup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = true;
            this.Name = "MouseJigglerForm";
            this.Text = "Mouse Jiggler";
            this.Load += new System.EventHandler(this.MouseJigglerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarInterval)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
} 