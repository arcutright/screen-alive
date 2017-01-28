#region header

// ScreenAlive - WindowDetection.cs
// 
// Aaron Cutright
// Copyright Cutright Industries 2017.

#endregion

using System.Diagnostics;

namespace CutrightIndustries.ScreenAlive
{
    class WindowDetection
    {
        public static bool IsAnyWindowOpen(string[] windowTitles, bool partialMatchingEnabled)
        {
            string title = "";
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
                        if (title == null || title == "")
                            continue;
                        if (partialMatchingEnabled && title.Contains(windowTitles[i]))
                            return true;
                        else if (title.Equals(windowTitles[i]))
                            return true;
                    }
                }
            }
            catch { }
            return false;
        }
    }
}
