using RPG_API.Models;
using RPG_API.Models.Games;
using System;
using System.Configuration;

namespace RPG_API.Utils
{
    public class SheetMaker
    {
        private SheetWriter sWriter = new SheetWriter();
        private SheetFiller sFiller = new SheetFiller();
        private Logger logger = new Logger();
        private string mypath = ConfigurationManager.AppSettings["path"];

        public void makeSheet(Character myHero, Game game)
        {
            string path = System.Web.HttpContext.Current.Server.MapPath(mypath);
            logger.Log(String.Format("Inside sheetMaker.makeSheet with path {0}", path));
            try
            {
                sWriter.CreateSheet(game);
                sFiller.FillInfos(myHero, path);
                sFiller.FillBaseAttributes(myHero, path);
                sFiller.FillStats(myHero, path);
                sFiller.FillSpendablePoints(myHero, path);
                sFiller.FillSkills(myHero, path);
            }
            catch (Exception ex)
            {
                logger.Log(String.Format("Error in Sheet Maker : {0}", ex.Message));
                throw ex;
            }
            logger.Log("MakeSheet finished");
        }
    }
}