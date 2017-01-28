namespace CutrightIndustries.ScreenAlive
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.jiggleTimer = new System.Windows.Forms.Timer(this.components);
            this.cbEnabled = new System.Windows.Forms.CheckBox();
            this.cmdAbout = new System.Windows.Forms.Button();
            this.cbZenJiggle = new System.Windows.Forms.CheckBox();
            this.cmdToTray = new System.Windows.Forms.Button();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyIconContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.bContextMenuClose = new System.Windows.Forms.ToolStripMenuItem();
            this.bConextMenuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.tbWindowTitles = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbPartialTitleMatching = new System.Windows.Forms.CheckBox();
            this.bTitlesUpdated = new System.Windows.Forms.Button();
            this.notifyIconContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // jiggleTimer
            // 
            this.jiggleTimer.Interval = 50000;
            this.jiggleTimer.Tick += new System.EventHandler(this.jiggleTimer_Tick);
            // 
            // cbEnabled
            // 
            this.cbEnabled.AutoSize = true;
            this.cbEnabled.Checked = true;
            this.cbEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbEnabled.Location = new System.Drawing.Point(315, 210);
            this.cbEnabled.Name = "cbEnabled";
            this.cbEnabled.Size = new System.Drawing.Size(119, 17);
            this.cbEnabled.TabIndex = 0;
            this.cbEnabled.Text = "Enable ScreenAlive";
            this.cbEnabled.UseVisualStyleBackColor = true;
            this.cbEnabled.CheckedChanged += new System.EventHandler(this.cbEnabled_CheckedChanged);
            // 
            // cmdAbout
            // 
            this.cmdAbout.Location = new System.Drawing.Point(402, 36);
            this.cmdAbout.Name = "cmdAbout";
            this.cmdAbout.Size = new System.Drawing.Size(38, 23);
            this.cmdAbout.TabIndex = 1;
            this.cmdAbout.Text = "?";
            this.cmdAbout.UseVisualStyleBackColor = true;
            this.cmdAbout.Click += new System.EventHandler(this.cmdAbout_Click);
            // 
            // cbZenJiggle
            // 
            this.cbZenJiggle.AutoSize = true;
            this.cbZenJiggle.Checked = true;
            this.cbZenJiggle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbZenJiggle.Location = new System.Drawing.Point(329, 233);
            this.cbZenJiggle.Name = "cbZenJiggle";
            this.cbZenJiggle.Size = new System.Drawing.Size(72, 17);
            this.cbZenJiggle.TabIndex = 2;
            this.cbZenJiggle.Text = "Zen jiggle";
            this.cbZenJiggle.UseVisualStyleBackColor = true;
            this.cbZenJiggle.CheckedChanged += new System.EventHandler(this.cbZenJiggle_CheckedChanged);
            // 
            // cmdToTray
            // 
            this.cmdToTray.Image = ((System.Drawing.Image)(resources.GetObject("cmdToTray.Image")));
            this.cmdToTray.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdToTray.Location = new System.Drawing.Point(329, 7);
            this.cmdToTray.Name = "cmdToTray";
            this.cmdToTray.Size = new System.Drawing.Size(111, 23);
            this.cmdToTray.TabIndex = 3;
            this.cmdToTray.Text = "Minimize to tray";
            this.cmdToTray.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdToTray.UseVisualStyleBackColor = true;
            this.cmdToTray.Click += new System.EventHandler(this.cmdToTray_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.notifyIconContextMenu;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "ScreenAlive";
            this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
            // 
            // notifyIconContextMenu
            // 
            this.notifyIconContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bContextMenuClose,
            this.bConextMenuOpen});
            this.notifyIconContextMenu.Name = "notifyIconContextMenu";
            this.notifyIconContextMenu.Size = new System.Drawing.Size(168, 70);
            // 
            // bContextMenuClose
            // 
            this.bContextMenuClose.Name = "bContextMenuClose";
            this.bContextMenuClose.Size = new System.Drawing.Size(167, 22);
            this.bContextMenuClose.Text = "Exit ScreenAlive";
            this.bContextMenuClose.Click += new System.EventHandler(this.bContextMenuClose_Click);
            // 
            // bConextMenuOpen
            // 
            this.bConextMenuOpen.Name = "bConextMenuOpen";
            this.bConextMenuOpen.Size = new System.Drawing.Size(167, 22);
            this.bConextMenuOpen.Text = "Open ScreenAlive";
            this.bConextMenuOpen.Click += new System.EventHandler(this.bConextMenuOpen_Click);
            // 
            // tbWindowTitles
            // 
            this.tbWindowTitles.AcceptsReturn = true;
            this.tbWindowTitles.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbWindowTitles.Location = new System.Drawing.Point(12, 9);
            this.tbWindowTitles.Multiline = true;
            this.tbWindowTitles.Name = "tbWindowTitles";
            this.tbWindowTitles.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbWindowTitles.Size = new System.Drawing.Size(297, 214);
            this.tbWindowTitles.TabIndex = 4;
            this.tbWindowTitles.WordWrap = false;
            this.tbWindowTitles.TextChanged += new System.EventHandler(this.tbWindowTitles_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.CausesValidation = false;
            this.label1.Location = new System.Drawing.Point(315, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 92);
            this.label1.TabIndex = 5;
            this.label1.Text = "Add the window names \r\nfor the programs\r\nyou want to activate \r\nScreenAlive here," +
    " then\r\nhit \"Update titles\" when\r\nyou\'re done\r\n<--------\r\n";
            this.label1.UseCompatibleTextRendering = true;
            // 
            // cbPartialTitleMatching
            // 
            this.cbPartialTitleMatching.AutoSize = true;
            this.cbPartialTitleMatching.Location = new System.Drawing.Point(315, 159);
            this.cbPartialTitleMatching.Name = "cbPartialTitleMatching";
            this.cbPartialTitleMatching.Size = new System.Drawing.Size(120, 17);
            this.cbPartialTitleMatching.TabIndex = 6;
            this.cbPartialTitleMatching.Text = "Partial title matching";
            this.cbPartialTitleMatching.UseVisualStyleBackColor = true;
            this.cbPartialTitleMatching.CheckedChanged += new System.EventHandler(this.cbPartialTitleMatching_CheckedChanged);
            // 
            // bTitlesUpdated
            // 
            this.bTitlesUpdated.Location = new System.Drawing.Point(12, 229);
            this.bTitlesUpdated.Name = "bTitlesUpdated";
            this.bTitlesUpdated.Size = new System.Drawing.Size(79, 23);
            this.bTitlesUpdated.TabIndex = 7;
            this.bTitlesUpdated.Text = "Update Titles";
            this.bTitlesUpdated.UseVisualStyleBackColor = true;
            this.bTitlesUpdated.Click += new System.EventHandler(this.bTitlesUpdated_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 256);
            this.Controls.Add(this.bTitlesUpdated);
            this.Controls.Add(this.cbPartialTitleMatching);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbWindowTitles);
            this.Controls.Add(this.cmdToTray);
            this.Controls.Add(this.cbZenJiggle);
            this.Controls.Add(this.cmdAbout);
            this.Controls.Add(this.cbEnabled);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(16, 39);
            this.Name = "MainForm";
            this.Text = "ScreenAlive";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.notifyIconContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer jiggleTimer;
        private System.Windows.Forms.CheckBox cbEnabled;
        private System.Windows.Forms.Button cmdAbout;
        private System.Windows.Forms.CheckBox cbZenJiggle;
        private System.Windows.Forms.Button cmdToTray;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.TextBox tbWindowTitles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbPartialTitleMatching;
        private System.Windows.Forms.Button bTitlesUpdated;
        private System.Windows.Forms.ContextMenuStrip notifyIconContextMenu;
        private System.Windows.Forms.ToolStripMenuItem bContextMenuClose;
        private System.Windows.Forms.ToolStripMenuItem bConextMenuOpen;
    }
}

