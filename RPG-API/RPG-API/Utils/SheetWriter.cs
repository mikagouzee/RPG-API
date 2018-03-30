using RPG_API.Models.Caracteristic;
using RPG_API.Models.Games;
using System;
using System.Web;
using System.Xml;

namespace RPG_API.Utils
{
    public class SheetWriter
    {
        //string fold = ConfigurationManager.AppSettings["folder"];
        private string fold = HttpContext.Current.Server.MapPath("~/App_Data/Characters/");

        private static XmlWriter myWriter;
        private Logger logger = new Logger();

        public void CreateSheet(IGame myGame)
        {
            logger.Log("Inside SheetWriter.CreateSheet.");
            logger.Log(String.Format("game : {0}", myGame));

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            logger.Log(String.Format("The sheet will be written at : {0}", @fold + myGame.Name.ToLower().Replace(" ", "_") + "_character_sheet.xml"));

            myWriter = XmlWriter.Create(@fold + myGame.Name.ToLower().Replace(" ", "_") + "_character_sheet.xml", settings);
            myWriter.WriteStartDocument();

            myWriter.WriteStartElement("character_sheet");

            //Information section : meta about the character and game

            #region info

            myWriter.WriteStartElement("infos");
            myWriter.WriteStartElement("name");
            myWriter.WriteEndElement();
            myWriter.WriteStartElement("player_name");
            myWriter.WriteEndElement();
            myWriter.WriteStartElement("career");
            myWriter.WriteEndElement();
            myWriter.WriteStartElement("campaign");
            myWriter.WriteEndElement();
            myWriter.WriteStartElement("game");
            myWriter.WriteEndElement();
            myWriter.WriteEndElement();

            #endregion info

            //base attributes section
            myWriter.WriteStartElement("base_attributes");
            foreach (ICaracteristic battr in myGame.BaseAttributes)
            {
                myWriter.WriteStartElement(battr.Name.Replace(" ", "_").ToLower());
                myWriter.WriteEndElement();
            }
            myWriter.WriteEndElement();

            //Stats
            myWriter.WriteStartElement("stats");
            foreach (ICaracteristic stat in myGame.Stats)
            {
                myWriter.WriteStartElement(stat.Name.Replace(" ", "_").ToLower());
                myWriter.WriteEndElement();
            }
            myWriter.WriteEndElement();

            //spendable points
            myWriter.WriteStartElement("spendable_points");
            foreach (ICaracteristic sPoint in myGame.SpendPoints)
            {
                myWriter.WriteStartElement(sPoint.Name.Replace(" ", "_").ToLower());
                myWriter.WriteEndElement();
            }
            myWriter.WriteEndElement();

            //Skills
            myWriter.WriteStartElement("skills");
            foreach (ICaracteristic skill in myGame.Skills)
            {
                myWriter.WriteStartElement(skill.Name.Replace(" ", "_").ToLower());
                myWriter.WriteEndElement();
            }
            myWriter.WriteEndElement();

            //END CHARACTER SHEET
            myWriter.WriteEndElement();

            myWriter.WriteEndDocument();
            logger.Log("Ending document.");
            myWriter.Close();
        }

       
    }
}