using System;
using System.IO;
using System.Web;

namespace RPG_API.Utils
{
    public class Logger
    {
        private string logFile = HttpContext.Current.Server.MapPath("~/App_Data/Logs/log.txt");

        public void Log(string description)
        {
            using (StreamWriter file = new StreamWriter(@logFile, true))
            {
                file.WriteLine(DateTime.Now.ToString() + " : " + description);
            }
        }
    }
}