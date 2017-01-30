using System;
using System.IO;

namespace CutrightIndustries.ScreenAlive
{
    class Logger
    {
        public const string LOGFILE_PATH = "screenalive-log.txt";
        public static bool DEBUG_MODE = true;
        
        public static void Debug(params string[] str)
        {
            if (DEBUG_MODE)
            {
                string time = DateTime.Now.ToString("MM/dd/yyyy h:mm:ss tt");
                string content = "[" + time + "] ";
                for (int i = 0; i < str.Length; i++)
                    content += str[i];
                File.AppendAllText(LOGFILE_PATH, content + "\n");
            }
        }

        public static void DebugWithoutTimestamp(params string[] str)
        {
            if (DEBUG_MODE)
            {
                string content = " ";
                for (int i = 0; i < str.Length; i++)
                    content += str[i];
                File.AppendAllText(LOGFILE_PATH, content + "\n");
            }
        }
    }
}
