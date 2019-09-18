using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadData.Tools
{
    public static class ncLog
    {
        private static Home myHome;
        private static object unlocked = new object();
        private static string logFile = Path.Combine(Directory.GetCurrentDirectory(), "LoadData.log");


        public static void SetMyHome(Home nmyHome)
        {
            myHome = nmyHome;
        }


        private static void LogMessageToFile(string msg, bool ToFile = true)
        {
            try
            {
                lock (unlocked)
                {
                    System.IO.StreamWriter sw = System.IO.File.AppendText(logFile);

                    try
                    {
                        string logLine = System.String.Format("[{0}] {1}", System.DateTime.Now, msg);

                        if (ToFile)
                        {
                            sw.WriteLine(logLine);
                        }
                        myHome.MyInvokeLog(logLine);
                        Debug.WriteLine(logLine);
                    }
                    finally
                    {
                        sw.Flush();
                        sw.Close();
                    }
                }
            }
            catch (Exception exp)
            {
                System.IO.StreamWriter sw = System.IO.File.AppendText(logFile);
                string logLine = System.String.Format("[{0:T}] {1}", System.DateTime.Now, exp.Message);
                Debug.WriteLine(logLine);
                sw.WriteLine(logLine);
                sw.Close();
            }
        }

        internal static void Exception(string msj)
        {
            LogMessageToFile("Exception - " + msj, true);
        }

        internal static void Error(string msj)
        {
            LogMessageToFile("ERROR - " + msj, true);
        }

        internal static void Warning(string msj)
        {
            LogMessageToFile("Warning - " + msj, true);
        }

        internal static void Message(string msj)
        {
            LogMessageToFile("Message - " + msj, true);
        }
    }
}
