using System;
using System.IO;
using System.Web;

namespace RPG_API.Utils
{
    public class Logger
    {
        private string logFile = HttpContext.Current.Server.MapPath("~/App_Data/Logs/log.txt");

        void Setup()
        {
            if (!File.Exists(logFile))
            {
                File.Create(logFile);
            }
            else
            {
                DateTime dt = File.GetLastWriteTime(logFile);
                if (dt.Day != DateTime.Now.Day)
                    logFile.Replace(".txt", "-" + DateTime.Now.Day + ".txt");
            }
        }

        public void Log(string description)
        {
            Setup();
            using (StreamWriter file = new StreamWriter(@logFile, true))
            {
                file.WriteLine(DateTime.Now.ToString() + " : " + description);
            }
            File.SetLastWriteTime(logFile, DateTime.Now);
        }
    }
}