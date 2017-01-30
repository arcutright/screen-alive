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
        protected bool titleMatch;

        public MainForm()
        {
            InitializeComponent();
        }

        private void jiggleTimer_Tick(object sender, EventArgs ev)
        {
            Logger.Debug("jiggle tick,  zen:"+cbZenJiggle.Checked, "  partial:"+cbPartialTitleMatching.Checked);
            if (cbEnabled.Checked)
            {
                //check if there are any window title matches, if so, enable the jiggle timer
                string[] lines = tbWindowTitles.Text.Split('\n');
                if (WindowDetection.IsAnyWindowOpen(lines, cbPartialTitleMatching.Checked))
                {
                    Logger.Debug("jiggling cursor (zen:", cbZenJiggle.Checked.ToString(), ")");
                    //jiggle mouse cursor
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
            }
        }

        private void cbEnabled_CheckedChanged(object sender, EventArgs ev)
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
            catch (Exception ex)
            {
                Logger.Debug("Error writing to registry cbEnabled: " + ex.GetBaseException());
            }

        }

        private void cmdAbout_Click(object sender, EventArgs ev)
        {
            using (var a = new AboutBox())
                a.ShowDialog();
        }

        private void MainForm_Load(object sender, EventArgs ev)
        {
            try
            {
                Logger.Debug("initializing...");
                //check registry key for settings
                RegistryKey key = Registry.CurrentUser.CreateSubKey(REGISTRY.location,
                                                                     RegistryKeyPermissionCheck.ReadWriteSubTree);
                var enabled = (int)key.GetValue(REGISTRY.enabled, 0);
                var zen = (int)key.GetValue(REGISTRY.zen, 0);
                var partialMatching = (int)key.GetValue(REGISTRY.partialMatching, 0);
                var titles = (string)key.GetValue(REGISTRY.windowTitles, "");
                Logger.DebugWithoutTimestamp("\tloaded all registry values");
                Logger.DebugWithoutTimestamp("\tenabled: " + enabled);
                Logger.DebugWithoutTimestamp("\tzen: " + zen);
                Logger.DebugWithoutTimestamp("\tpartial matching: " + partialMatching);
                Logger.DebugWithoutTimestamp("\ttitles: " + titles);
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
                    string[] titleArray = titles.Split(new[] { REGISTRY.titleSeparator }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < titleArray.Length; i++)
                    {
                        if (i < titleArray.Length - 1)
                            formattedTitles += titleArray[i].Trim() + "\r\n";
                        else
                            formattedTitles += titleArray[i].Trim();
                    }
                    //store in textbox
                    tbWindowTitles.Text = formattedTitles;
                }
                jiggleTimer.Enabled = true; //automatically start jiggle timer
                jiggleTimer_Tick(null, null); //initialize timer (unnecessary, but guarantees no screen timeout)
            }
            catch (Exception ex)
            {
                Logger.Debug("Error during initalization: " + ex.GetBaseException());
            }

            if (Program.ZenJiggling)
                cbZenJiggle.Checked = true;
            if (Program.Enabled)
                cbEnabled.Checked = true;
            if (Program.PartialTitleMatching)
                cbPartialTitleMatching.Checked = true;
            if (Program.StartMinimized)
                cmdToTray_Click(this, null);
        }

        private void cbZenJiggle_CheckedChanged(object sender, EventArgs ev)
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
            catch (Exception ex)
            {
                Logger.Debug("Error writing to registry cbZenJiggle: " + ex.GetBaseException());
            }
        }

        private void cmdToTray_Click(object sender, EventArgs ev)
        {
            //hide the window
            Visible = false;
            //show tray icon
            notifyIcon.Visible = true;
            //remove taskbar icon
            ShowInTaskbar = false;
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs ev)
        {
            //restore the window
            Visible = true;
            //hide tray icon
            notifyIcon.Visible = false;
            //place icon to taskbar
            ShowInTaskbar = true;
        }

        private void cbPartialTitleMatching_CheckedChanged(object sender, EventArgs ev)
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
            catch (Exception ex)
            {
                Logger.Debug("Error writing to registry cbPatialMatching: " + ex.GetBaseException());
            }
        }

        private void tbWindowTitles_TextChanged(object sender, EventArgs ev)
        {
            //do nothing
        }

        private void bTitlesUpdated_Click(object sender, EventArgs ev)
        {
            try
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
                    //update
                    jiggleTimer_Tick(null, null);
                }
            }
            catch (Exception ex)
            {
                Logger.Debug("Error writing to registry bTitlesUpdated: " + ex.GetBaseException());
            }
        }

        private void bContextMenuClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bConextMenuOpen_Click(object sender, EventArgs e)
        {
            //restore the window
            Visible = true;
            //hide tray icon
            notifyIcon.Visible = false;
            //place icon in taskbar
            ShowInTaskbar = true;
        }
    }
}
