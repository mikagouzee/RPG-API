using RPG_API.Models;
using RPG_API.Models.Caracteristic;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;

namespace RPG_API.Utils
{
    public class SheetFiller
    {
        XmlDocument myDoc;
        Logger logger = new Logger();

        // Used to save older sheet before changing them, in case there's a trouble
        public void backUpCharacter(Character myCharac, string myPath)
        {
            logger.Log("Inside BackUpCharacter");
            myDoc = new XmlDocument();

            if (CheckIfCharacterAlreadyExists(myCharac.characterName.ToLower()))
            {
                logger.Log(String.Format("Found Character with name {0}", myCharac.characterName));
                myDoc.Load(myPath + myCharac.characterName.ToLower() + ".xml");

                myPath += "backup\\";
                myPath += myCharac.characterName.ToLower() + ".xml";

                saveFile(myPath);
            }
        }

        // Used to find the good sheet
        public XmlDocument FindSheet(Character myCharac, string myPath)
        {
            logger.Log(String.Format("Inside FindSheet for character {0}", myCharac.characterName));
            myDoc = new XmlDocument();

            if (CheckIfCharacterAlreadyExists(myCharac.characterName.ToLower()))
                myDoc.Load(myPath + myCharac.characterName.ToLower() + ".xml");
            else
                myDoc.Load(myPath + myCharac.game.name.Replace(" ", "_").ToLower() + "_character_sheet.xml");

            logger.Log("Exiting findsheet");
            return myDoc;
        }

        // Used to check that the sheet exists
        public bool CheckIfCharacterAlreadyExists(string characterName)
        {
            logger.Log("Inside Check If Charac Exists");
            string directory = ConfigurationManager.AppSettings["path"];
            directory = System.Web.HttpContext.Current.Server.MapPath(directory);
            string mask = "*.xml";
            string nameModified = directory.ToString() + characterName + ".xml";

            foreach (string file in Directory.GetFiles(directory, mask))
            {
                logger.Log(String.Format("Treating file : {0}", file));

                if (file == nameModified)
                {
                    logger.Log("Character Found!");
                    return true;
                }
            }
            logger.Log("Exiting Check If Charac Exists");
            return false;
        }

        public void fillInfos(Character myCharac, string myPath)
        {
            logger.Log(String.Format("Inside fill Infos withs args : character {0} , path {1}", myCharac, myPath)); 
            XmlDocument myDoc = FindSheet(myCharac, myPath);

            // We fill the information section : name, campaign, game etc.
            var nameNode = myDoc.SelectSingleNode("/character_sheet/infos/name");
            nameNode.InnerText = myCharac.characterName;

            var playerNameNode = myDoc.SelectSingleNode("/character_sheet/infos/player_name");
            playerNameNode.InnerText = myCharac.playerName;

            var gameNode = myDoc.SelectSingleNode("/character_sheet/infos/game");
            gameNode.InnerText = myCharac.game.name.ToString();

            var careerNode = myDoc.SelectSingleNode("/character_sheet/infos/career");
            //careerNode.InnerText = myCharac.metier.name;
            careerNode.InnerText = myCharac.careerName;

            // Now we save the file as an xml.
            string path = myPath + myCharac.characterName.ToLower() + ".xml";
            logger.Log("Exiting fill infos");
            saveFile(path);
        }
     
        public void fillBaseAttributes(Character myCharac, string myPath)
        {
            logger.Log("Inside fill base attr");
            XmlDocument myDoc = FindSheet(myCharac, myPath);

            foreach (ICaracteristic battr in myCharac.baseAttr)
            {
                var currentNode = myDoc.SelectSingleNode("/character_sheet/base_attributes/" + battr.name.Replace(" ", "_").ToLower());
                currentNode.InnerText = battr.value.ToString();
            }
            string path = myPath + myCharac.characterName.ToLower() + ".xml";

            logger.Log("Exiting fill base attr");
            saveFile(path);
        }

        public void fillStats(Character myCharac, string myPath)
        {
            logger.Log("Inside Fill Stat");
            XmlDocument myDoc = FindSheet(myCharac, myPath);

            foreach (ICaracteristic stat in myCharac.stats)
            {
                var currentNode = myDoc.SelectSingleNode("/character_sheet/stats/" + stat.name.Replace(" ", "_").ToLower());
                currentNode.InnerText = stat.value.ToString();
            }
            string path = myPath + myCharac.characterName.ToLower() + ".xml";
            logger.Log("Exiting fill Stat");
            saveFile(path);
        }

        public void fillSpendablePoints(Character myCharac, string myPath)
        {
            logger.Log("Inside fill Spendable points");
            XmlDocument myDoc = FindSheet(myCharac, myPath);

            foreach (ICaracteristic sPoint in myCharac.spendPoints)
            {
                var currentNode = myDoc.SelectSingleNode("/character_sheet/spendable_points/" + sPoint.name.Replace(" ", "_").ToLower());
                currentNode.InnerText = sPoint.value.ToString();
            }

            string path = myPath + myCharac.characterName.ToLower() + ".xml";
            logger.Log("Exiting fill spendable points");
            saveFile(path);
        }

        public void fillSkills(Character myCharac, string myPath)
        {
            logger.Log("Inside fillSkills");
            XmlDocument myDoc = FindSheet(myCharac, myPath);

            foreach (ICaracteristic skill in myCharac.skills)
            {
                var currentNode = myDoc.SelectSingleNode("/character_sheet/skills/" + skill.name.Replace(" ", "_").ToLower());
                currentNode.InnerText = skill.value.ToString();
            }

            string path = myPath + myCharac.characterName.ToLower() + ".xml";
            logger.Log("Exiting fillSkills");
            saveFile(path);
        }




        // Fill the whole sheet at once.
        public void fillSheet(Character myCharac, string myPath)
        {
            logger.Log("Inside fill Sheet");
            XmlDocument myDoc = FindSheet(myCharac, myPath);

            fillBaseAttributes(myCharac, myPath);
            fillStats(myCharac, myPath);
            fillSkills(myCharac, myPath);
            fillSpendablePoints(myCharac, myPath);
            logger.Log("Exiting fill Sheet");
        }


        //SAVE FILE
        public void saveFile(string myPath)
        {
            logger.Log("Inside save file");
            myDoc.Save(myPath);
            logger.Log("file saved");
        }
    }
}