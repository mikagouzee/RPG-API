using RPG_API.Models;
using RPG_API.Models.Caracteristic;
using System;
using System.Configuration;
using System.IO;
using System.Xml;

namespace RPG_API.Utils
{
    public class SheetFiller
    {
        private XmlDocument myDoc;
        private Logger logger = new Logger();

        // Used to save older sheet before changing them, in case there's a trouble
        public void backUpCharacter(Character myCharac, string myPath)
        {
            logger.Log("Inside BackUpCharacter");
            myDoc = new XmlDocument();

            if (CheckIfCharacterAlreadyExists(myCharac.CharacterName.ToLower()))
            {
                logger.Log(String.Format("Found Character with name {0}", myCharac.CharacterName));
                myDoc.Load(myPath + myCharac.CharacterName.ToLower() + ".xml");

                myPath += "backup\\";
                myPath += myCharac.CharacterName.ToLower() + ".xml";

                SaveFile(myPath);
                logger.Log("Exiting backup character");
            }
        }

        // Used to find the good sheet
        public XmlDocument FindSheet(Character myCharac, string myPath)
        {
            logger.Log(String.Format("Inside FindSheet for character {0}", myCharac.CharacterName));
            myDoc = new XmlDocument();

            if (CheckIfCharacterAlreadyExists(myCharac.CharacterName.ToLower()))
                myDoc.Load(myPath + myCharac.CharacterName.ToLower() + ".xml");
            else
                myDoc.Load(myPath + myCharac.GameName.Replace(" ", "_").ToLower() + "_character_sheet.xml");

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

        public void FillInfos(Character myCharac, string myPath)
        {
            logger.Log(String.Format("Inside fill Infos withs args : character {0} , path {1}", myCharac, myPath));
            XmlDocument myDoc = FindSheet(myCharac, myPath);

            // We fill the information section : name, campaign, game etc.
            logger.Log(String.Format("Name Node : {0}", myCharac.CharacterName));
            var nameNode = myDoc.SelectSingleNode("/character_sheet/infos/name");
            nameNode.InnerText = myCharac.CharacterName;

            logger.Log(String.Format("Player Name Node : {0}", myCharac.PlayerName));
            var playerNameNode = myDoc.SelectSingleNode("/character_sheet/infos/player_name");
            playerNameNode.InnerText = myCharac.PlayerName;

            logger.Log(String.Format("Game Node : {0}", myCharac.GameName));
            var gameNode = myDoc.SelectSingleNode("/character_sheet/infos/game");
            gameNode.InnerText = myCharac.GameName.ToString();

            logger.Log(String.Format("Career Node : {0}", myCharac.Metier.name));
            var careerNode = myDoc.SelectSingleNode("/character_sheet/infos/career");
            careerNode.InnerText = myCharac.Metier.name;

            // Now we save the file as an xml.
            string path = myPath + myCharac.CharacterName.ToLower() + ".xml";
            logger.Log("Exiting fill infos");
            SaveFile(path);
        }

        public void FillBaseAttributes(Character myCharac, string myPath)
        {
            logger.Log("Inside fill base attr");
            XmlDocument myDoc = FindSheet(myCharac, myPath);

            foreach (ICaracteristic battr in myCharac.BaseAttr)
            {
                var currentNode = myDoc.SelectSingleNode("/character_sheet/base_attributes/" + battr.Name.Replace(" ", "_").ToLower());
                currentNode.InnerText = battr.Value.ToString();
            }
            string path = myPath + myCharac.CharacterName.ToLower() + ".xml";

            logger.Log("Exiting fill base attr");
            SaveFile(path);
        }

        public void FillStats(Character myCharac, string myPath)
        {
            logger.Log("Inside Fill Stat");
            XmlDocument myDoc = FindSheet(myCharac, myPath);

            foreach (ICaracteristic stat in myCharac.Stats)
            {
                var currentNode = myDoc.SelectSingleNode("/character_sheet/stats/" + stat.Name.Replace(" ", "_").ToLower());
                currentNode.InnerText = stat.Value.ToString();
            }
            string path = myPath + myCharac.CharacterName.ToLower() + ".xml";
            logger.Log("Exiting fill Stat");
            SaveFile(path);
        }

        public void FillSpendablePoints(Character myCharac, string myPath)
        {
            logger.Log("Inside fill Spendable points");
            XmlDocument myDoc = FindSheet(myCharac, myPath);

            foreach (ICaracteristic sPoint in myCharac.SpendPoints)
            {
                var currentNode = myDoc.SelectSingleNode("/character_sheet/spendable_points/" + sPoint.Name.Replace(" ", "_").ToLower());
                currentNode.InnerText = sPoint.Value.ToString();
            }

            string path = myPath + myCharac.CharacterName.ToLower() + ".xml";
            logger.Log("Exiting fill spendable points");
            SaveFile(path);
        }

        public void FillSkills(Character myCharac, string myPath)
        {
            logger.Log("Inside fillSkills");
            XmlDocument myDoc = FindSheet(myCharac, myPath);

            foreach (ICaracteristic skill in myCharac.Skills)
            {
                var currentNode = myDoc.SelectSingleNode("/character_sheet/skills/" + skill.Name.Replace(" ", "_").ToLower());
                currentNode.InnerText = skill.Value.ToString();
            }

            string path = myPath + myCharac.CharacterName.ToLower() + ".xml";
            logger.Log("Exiting fillSkills");
            SaveFile(path);
        }

        // Fill the whole sheet at once.
        public void FillSheet(Character myCharac, string myPath)
        {
            logger.Log("Inside fill Sheet");
            XmlDocument myDoc = FindSheet(myCharac, myPath);

            FillBaseAttributes(myCharac, myPath);
            FillStats(myCharac, myPath);
            FillSkills(myCharac, myPath);
            FillSpendablePoints(myCharac, myPath);
            logger.Log("Exiting fill Sheet");
        }

        //SAVE FILE
        public void SaveFile(string myPath)
        {
            logger.Log("Inside save file");
            myDoc.Save(myPath);
            logger.Log("file saved");
            logger.Log(Environment.NewLine);
        }
    }
}