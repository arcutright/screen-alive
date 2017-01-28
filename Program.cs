#region headerArkaneSystems

// ScreenAlive - Program.cs
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
using System.Threading;
using System.Windows.Forms;

namespace CutrightIndustries.ScreenAlive
{
    internal static class Program
    {
        public static bool Enabled = false;
        public static bool ZenJiggling = false;
        public static bool StartMinimized = false;
        public static bool PartialTitleMatching = false;

        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main (string[] args)
        {
            Mutex instance = new Mutex(false, "single instance: CutrightIndustries.ScreenAlive");

            if (instance.WaitOne(0, false))
            {
                // Check for command-line switches.
                foreach (string arg in args)
                {
                    if ((string.Compare (arg.ToUpperInvariant (), "--ENABLED", StringComparison.Ordinal) == 0) ||
                        (string.Compare (arg.ToUpperInvariant (), "-E", StringComparison.Ordinal) == 0))
                        Enabled = true;

                    if ((string.Compare (arg.ToUpperInvariant (), "--ZEN", StringComparison.Ordinal) == 0) ||
                        (string.Compare (arg.ToUpperInvariant (), "-Z", StringComparison.Ordinal) == 0))
                        ZenJiggling = true;

                    if ((string.Compare (arg.ToUpperInvariant (), "--MINIMIZED", StringComparison.Ordinal) == 0) ||
                        (string.Compare (arg.ToUpperInvariant (), "-M", StringComparison.Ordinal) == 0))
                        StartMinimized = true;

                    if ((string.Compare(arg.ToUpperInvariant(), "--PARTIAL_MATCHING", StringComparison.Ordinal) == 0) ||
                        (string.Compare(arg.ToUpperInvariant(), "-P", StringComparison.Ordinal) == 0))
                        PartialTitleMatching = true;
                }

                Application.EnableVisualStyles ();
                Application.SetCompatibleTextRenderingDefault (false);
                Application.Run (new MainForm ());
            }

            instance.Close ();
        }
    }
}
