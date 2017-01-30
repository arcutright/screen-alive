#region header

// ScreenAlive - WindowDetection.cs
// 
// Aaron Cutright
// Copyright Cutright Industries 2017.

#endregion

using System;
using System.Diagnostics;

namespace CutrightIndustries.ScreenAlive
{
    class WindowDetection
    {
        public static bool IsAnyWindowOpen(string[] windowTitles, bool partialMatchingEnabled)
        {
            string title = "", pname = "";
            try
            {
                for(int i = 0; i < windowTitles.Length; i++)
                {
                    windowTitles[i] = windowTitles[i].Trim();
                    if (windowTitles[i] == null || windowTitles[i] == "")
                        continue;
                    Process[] processes = Process.GetProcesses();
                    for(int p=0; p < processes.Length; p++)
                    {
                        title = processes[p].MainWindowTitle.Trim();
                        pname = processes[p].ProcessName.Trim();
                        Logger.DebugWithoutTimestamp("\tComparing \'", title, "\' to \'", windowTitles[i], "\'", ".. pname: \'", processes[p].ProcessName, "\'");
                        if ((title == null || title == "") && (pname == null || pname == ""))
                            continue;
                        if (partialMatchingEnabled && (title.Contains(windowTitles[i]) || pname.Contains(windowTitles[i])))
                            return true;
                        else if (title.Equals(windowTitles[i]) || pname.Equals(windowTitles[i]))
                            return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Debug("Error checking for open windows: " + ex.GetBaseException());
            }
            return false;
        }
    }
}
