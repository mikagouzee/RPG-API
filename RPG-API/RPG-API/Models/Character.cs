using RPG_API.Models.Caracteristic;
using RPG_API.Models.Careers;
using RPG_API.Models.GameRules;
using RPG_API.Models.Games;
using RPG_API.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace RPG_API.Models
{
    //what's the difference between metier and career name?
    public class Character
    {
        private Logger logger = new Logger();

        // Infos
        public string CharacterName { get; set; }
        public string PlayerName { get; set; }
        public string GameName { get; set; }
        public Profession Metier { get; set; }
        public string CareerName { get; set; }

        // Caracteristics
        public List<BaseAttributes> BaseAttr { get; set; }
        public List<Skills> Skills { get; set; }
        public List<Stats> Stats { get; set; }
        public List<Spendpoints> SpendPoints { get; set; }

        private int SetValue(string nodeContent)
        {
            Int32 retVal = 0;
            if (!String.IsNullOrEmpty(nodeContent))
            {
                //IF we have something else, this should avoid errors!
                var res = 0;
                bool result = Int32.TryParse(nodeContent, out res);
                if (result)
                {
                    retVal = Convert.ToInt32(nodeContent);
                }
            }
            else
                retVal = 0;
            return retVal;
        }

        // Empty constructor, creates an empty character named "new character" for player "toby determined".
        public Character()
        {
            logger.Log("Inside default character constructor");
            var characterName = "New Character";
            var playerName = "Toby Determined";
            new Character(characterName, playerName);
        }

        public Character(Game game)
        {
            logger.Log(String.Format("Inside Character constructor with parameter game : {0} ", game.Name));

            var characterName = "New Character";
            var playerName = "Toby Determined";

            new Character(game, characterName, playerName);
        }

        public Character(string charName, string playerName)
        {
            logger.Log(String.Format("Inside Character constructor with args characterName {0} and playerName {1}", charName, playerName));
            var game = new Fallout();
            new Character(game, charName, playerName);
        }

        // This constructor takes a game in parameter.
        // This will allow us to use the same framework for multiple games.
        public Character(Game myGame, string mycharacterName, string myplayerName)
        {
            if (myGame == null)
            {
                logger.Log("No Game found in Character creation. An error might happen.");
                throw new ArgumentNullException(nameof(Game));
            }

            logger.Log(String.Format("Inside ultimate character constructor : game {0}, characterName {1} and playerName {2}", myGame, mycharacterName, myplayerName));
            CharacterName = mycharacterName;
            PlayerName = myplayerName;
            GameName = myGame.Name;

            BaseAttr = myGame.BaseAttributes;
            Skills = myGame.Skills;
            Stats = myGame.Stats;
            SpendPoints = myGame.SpendPoints;
            Metier = (Profession)myGame.professions.Where(p => p.name == "mendiant").FirstOrDefault();
            CareerName = Metier == null ? "mendiant" : Metier.name;

            IGameRule rules = myGame.rules;
            try
            {
                rules.SetBaseAttr(this);
                rules.SetStats(this);
                rules.SetSpendablePoints(this);
                rules.SetSkills(this);
                rules.SetCareerSkills(this);
            }
            catch (Exception ex)
            {
                logger.Log(String.Format("Error in Character Creation : {0} ", ex.Message));
            }
        }

        // This uses a character sheet in xml format.
        public Character(string characterSheet)
        {
            logger.Log("Inside Character constructor with a character sheet");
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(characterSheet);

            this.CharacterName = xmlDoc.SelectSingleNode("/character_sheet/infos/name").InnerText;
            this.PlayerName = xmlDoc.SelectSingleNode("/character_sheet/infos/player_name").InnerText;
            logger.Log(String.Format("Character name : {0}", this.CharacterName));
            logger.Log(String.Format("player name : {0}", this.PlayerName));

            // INFOS
            // We will have the same difficulty for Game and for Profession : create an instance from the name.
            string gameName = xmlDoc.SelectSingleNode("/character_sheet/infos/game").InnerText;
            Game game = Game.GetaGame(gameName);

            // as the professions are created inside the game, we can't use reflexion.
            string metierName = xmlDoc.SelectSingleNode("/character_sheet/infos/career").InnerText;
            this.Metier = (Profession)game.professions.Where(p => p.name == metierName).FirstOrDefault();
            CareerName = Metier == null ? "Trouffion" : Metier.name;

            // CARACTERISTICS
            this.BaseAttr = game.BaseAttributes;
            this.Skills = game.Skills;
            this.Stats = game.Stats;
            this.SpendPoints = game.SpendPoints;

            try
            {
                foreach (ICaracteristic battr in this.BaseAttr)
                {
                    var nodeContent = (xmlDoc.SelectSingleNode("/character_sheet/base_attributes/" + battr.Name.Replace(" ", "_").ToLower()).InnerText);
                    battr.Value = SetValue(nodeContent);
                }

                foreach (ICaracteristic skill in this.Skills)
                {
                    string skillName = skill.Name.Replace(" ", "_");
                    var nodeContent = xmlDoc.SelectSingleNode("/character_sheet/skills/" + skillName.ToLower()).InnerText;
                    skill.Value = SetValue(nodeContent);
                }

                foreach (ICaracteristic stat in this.Stats)
                {
                    string statName = stat.Name.Replace(" ", "_");

                    var nodeContent = xmlDoc.SelectSingleNode("/character_sheet/stats/" + statName.ToLower()).InnerText;

                    stat.Value = SetValue(nodeContent);
                }

                foreach (ICaracteristic sPoint in this.SpendPoints)
                {
                    string sPointName = sPoint.Name.Replace(" ", "_");

                    var nodeContent = xmlDoc.SelectSingleNode("/character_sheet/spendable_points/" + sPointName.ToLower()).InnerText;

                    sPoint.Value = SetValue(nodeContent);
                }
            }
            catch (Exception ex)
            {
                logger.Log(String.Format("Error in Character constructor : {0}", ex.Message));
                throw ex;
            }
        }

        public void SetCaracteristic(List<ICaracteristic> caracteristics)
        {

            Game currentGame = Game.GetaGame(GameName);

            foreach (var carac in caracteristics)
            {
                var heroBaseAttr = BaseAttr.FirstOrDefault(x => x.Name == carac.Name);
                if (heroBaseAttr != null)
                {
                    heroBaseAttr.Value = carac.Value > heroBaseAttr.Max ?
                        carac.Value :
                        heroBaseAttr.Value;
                    continue;
                }

                var heroSkill = Skills.FirstOrDefault(x => x.Name == carac.Name);
                if(heroSkill!= null)
                {
                    heroSkill.Value = carac.Value > heroSkill.Max ?
                        carac.Value :
                        heroSkill.Value;
                    continue;
                }

                var heroStats = Stats.FirstOrDefault(x => x.Name == carac.Name);
                if (heroStats != null)
                {
                    heroStats.Value = carac.Value > heroStats.Max ?
                        carac.Value :
                        heroStats.Value;
                    continue;
                }

                var heroSpendPoint = SpendPoints.FirstOrDefault(x => x.Name == carac.Name);
                if (heroSpendPoint != null)
                {
                    heroSpendPoint.Value = carac.Value > heroSpendPoint.Max ?
                        carac.Value :
                        heroSpendPoint.Value;
                    continue;
                }
            }

        }
        

    }
}