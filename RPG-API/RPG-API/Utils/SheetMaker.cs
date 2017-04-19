using RPG_API.Models;
using RPG_API.Models.Games;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace RPG_API.Utils
{
    public class SheetMaker
    {
        private SheetWriter sWriter = new SheetWriter();
        private SheetFiller sFiller = new SheetFiller();
        private Logger logger = new Logger();
        string mypath = ConfigurationManager.AppSettings["path"];


        public void makeSheet(Character myHero)
        {
            string path = System.Web.HttpContext.Current.Server.MapPath(mypath);
            logger.Log(String.Format("Inside sheetMaker.makeSheet with path {0}",path));
            try
            {
                sWriter.CreateSheet(myHero.game);
                sFiller.fillInfos(myHero, path);
                sFiller.fillBaseAttributes(myHero, path);
                sFiller.fillStats(myHero, path);
                sFiller.fillSpendablePoints(myHero, path);
                sFiller.fillSkills(myHero, path);
            }
            catch(Exception ex)
            {
                logger.Log(String.Format("Error in Sheet Maker : {0}", ex.Message));
                throw ex;
            }
            logger.Log("MakeSheet finished");
        }

    }
}