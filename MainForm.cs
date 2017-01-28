#region header

// ScreenAlive - MainForm.cs
// 
// Aaron Cutright
// Copyright Cutright Industries 2017.
// 
// Forked from 
// https://mousejiggler.codeplex.com
// Alistair J. R. Young
// Arkane Systems
// Copyright Arkane Systems 2012-2013.

#endregion

using System;
using System.Windows.Forms;
using Microsoft.Win32;

namespace CutrightIndustries.ScreenAlive
{

    public partial class MainForm : Form
    {
        internal class REGISTRY
        {
            public const string location = @"Software\Cutright Industries\ScreenAlive";
            public const string enabled = "ScreenAliveEnabled";
            public const string zen = "ZenJiggleEnabled";
            public const string partialMatching = "PartialTitleMatchingEnabled";
            public const string windowTitles = "WindowTitles";
            public const string titleSeparator = @"<||;||;||>";
        }
        private const int MOUSEMOVE = 8;
        protected bool zig = true;

        public MainForm()
        {
            InitializeComponent();
        }

        private void jiggleTimer_Tick(object sender, EventArgs e)
        {
            // jiggle mouse cursor
            if (cbZenJiggle.Checked)
                Jiggler.Jiggle(0, 0);
            else
            {
                if (zig)
                    Jiggler.Jiggle(4, 4);
                else
                    Jiggler.Jiggle(-4, -4);
            }
            zig = !zig;
        }

        private void cbEnabled_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.CreateSubKey(REGISTRY.location,
                                                                    RegistryKeyPermissionCheck.ReadWriteSubTree);
                if (cbEnabled.Checked)
                    key.SetValue(REGISTRY.enabled, 1);
                else
                    key.SetValue(REGISTRY.enabled, 0);
            }
            catch { }

        }

        private void cmdAbout_Click(object sender, EventArgs e)
        {
            using (var a = new AboutBox())
                a.ShowDialog();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                // check registry key for settings
                RegistryKey key = Registry.CurrentUser.CreateSubKey(REGISTRY.location,
                                                                     RegistryKeyPermissionCheck.ReadWriteSubTree);
                var enabled = (int)key.GetValue(REGISTRY.enabled, 0);
                var zen = (int)key.GetValue(REGISTRY.zen, 0);
                var partialMatching = (int)key.GetValue(REGISTRY.partialMatching, 0);
                var titles = (string)key.GetValue(REGISTRY.windowTitles, "");
                if (enabled == 0)
                    cbEnabled.Checked = false;
                else
                    cbEnabled.Checked = true;
                if (zen == 0)
                    cbZenJiggle.Checked = false;
                else
                    cbZenJiggle.Checked = true;
                if (partialMatching == 0)
                    cbPartialTitleMatching.Checked = false;
                else
                    cbPartialTitleMatching.Checked = true;
                if (titles != "")
                {
                    //decode window titles from registry
                    string formattedTitles = "";
                    string[] titleArray = titles.Split(new[] { REGISTRY.titleSeparator }, StringSplitOptions.None);
                    for (int i = 0; i < titleArray.Length; i++)
                    {
                        if (i < titleArray.Length - 1)
                            formattedTitles += titleArray[i] + "\n";
                        else
                            formattedTitles += titleArray[i];
                    }
                    //store in textbox
                    tbWindowTitles.Text = formattedTitles;
                }
                jiggleTimer.Enabled = false; //don't automatically start jiggling
                bTitlesUpdated_Click(null, null); //see if stored titles are matching, start jiggletimer if so
            }
            catch { }

            if (Program.ZenJiggling)
                cbZenJiggle.Checked = true;
            if (Program.Enabled)
                cbEnabled.Checked = true;
            if (Program.PartialTitleMatching)
                cbPartialTitleMatching.Checked = true;
            if (Program.StartMinimized)
                cmdToTray_Click(this, null);
        }

        private void cbZenJiggle_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.CreateSubKey(REGISTRY.location,
                                                                    RegistryKeyPermissionCheck.ReadWriteSubTree);
                if (cbZenJiggle.Checked)
                    key.SetValue(REGISTRY.zen, 1);
                else
                    key.SetValue(REGISTRY.zen, 0);
            }
            catch { }
        }

        private void cmdToTray_Click(object sender, EventArgs e)
        {
            // minimize to tray
            Visible = false;
            // remove from taskbar
            ShowInTaskbar = false;
            // show tray icon
            notifyIcon.Visible = true;
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            // restore the window
            Visible = true;
            // replace in taskbar
            ShowInTaskbar = true;
            // hide tray icon
            notifyIcon.Visible = false;
        }

        private void cbPartialTitleMatching_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.CreateSubKey(REGISTRY.location,
                                                                    RegistryKeyPermissionCheck.ReadWriteSubTree);
                if (cbPartialTitleMatching.Checked)
                    key.SetValue(REGISTRY.partialMatching, 1);
                else
                    key.SetValue(REGISTRY.partialMatching, 0);
            }
            catch { }
        }

        private void tbWindowTitles_TextChanged(object sender, EventArgs e)
        {
            //do nothing
        }

        private void bTitlesUpdated_Click(object sender, EventArgs e)
        {
            string[] lines = tbWindowTitles.Text.Split('\n');
            if (cbEnabled.Checked)
            {
                //encode window titles array
                string encodedLines = "";
                for (int i = 0; i < lines.Length; i++)
                {
                    if (i < lines.Length - 1)
                        encodedLines += lines[i] + REGISTRY.titleSeparator;
                    else
                        encodedLines += lines[i];
                }

                //store window titles in registry
                RegistryKey key = Registry.CurrentUser.CreateSubKey(REGISTRY.location,
                                                                    RegistryKeyPermissionCheck.ReadWriteSubTree);
                key.SetValue(REGISTRY.windowTitles, encodedLines, RegistryValueKind.String);

                //check if there are any window title matches, if so, enable the jiggle timer
                jiggleTimer.Enabled = WindowDetection.IsAnyWindowOpen(lines, cbPartialTitleMatching.Checked);
            }
        }

        private void bContextMenuClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bConextMenuOpen_Click(object sender, EventArgs e)
        {
            // restore the window
            Visible = true;
            // replace in taskbar
            ShowInTaskbar = true;
            // hide tray icon
            notifyIcon.Visible = false;
        }
    }
}
