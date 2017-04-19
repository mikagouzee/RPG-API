using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

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