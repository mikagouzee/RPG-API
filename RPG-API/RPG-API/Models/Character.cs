using RPG_API.Models.Caracteristic;
using RPG_API.Models.Careers;
using RPG_API.Models.GameRules;
using RPG_API.Models.Games;
using RPG_API.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace RPG_API.Models
{
    public class Character
    {
        Logger logger = new Logger();

        // Infos
        public string characterName { get; set; }
        public string playerName { get; set; }
        public IGame game { get; set; }
        public Profession metier { get; set; }
        public string careerName { get; set; }

        // Caracteristics
        public List<BaseAttributes> baseAttr { get; set; }
        public List<Skills> skills { get; set; }
        public List<Stats> stats { get; set; }
        public List<spendpoints> spendPoints { get; set; }
        
        private int setValue(string nodeContent)
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
            characterName = "New Character";
            playerName = "Toby Determined";
        }
        
        public Character(IGame game)
        {
            logger.Log(String.Format("Inside Character constructor with parameter game : {0} ", game));
            var mon_perso = this;

            mon_perso.characterName = "New Character";
            mon_perso.playerName = "Toby Determined";
            #region helper
            //base attributes
            #region base attributes
            //BaseAttributes appearance = new BaseAttributes("appearance", 18);
            //BaseAttributes constitution = new BaseAttributes("constitution", 18);
            //BaseAttributes strength = new BaseAttributes("strength", 18);
            //BaseAttributes dexterity = new BaseAttributes("dexterity", 18);
            //BaseAttributes power = new BaseAttributes("power", 18);
            //BaseAttributes size = new BaseAttributes("size", 18);
            //BaseAttributes intelligence = new BaseAttributes("intelligence", 18);
            //BaseAttributes education = new BaseAttributes("education", 24);

            //mon_perso.baseAttr.Add(appearance);
            //mon_perso.baseAttr.Add(constitution);
            //mon_perso.baseAttr.Add(strength);
            //mon_perso.baseAttr.Add(dexterity);
            //mon_perso.baseAttr.Add(power);
            //mon_perso.baseAttr.Add(size);
            //mon_perso.baseAttr.Add(intelligence);
            //mon_perso.baseAttr.Add(education);
            #endregion
            //STATS
            #region stats
            //Stats prestance = new Stats("prestance", 90, mon_perso.baseAttr.Where(b => b.name == "appearance").FirstOrDefault().value * 5);
            //Stats endurance = new Stats("endurance", 90, mon_perso.baseAttr.Where(b => b.name == "constitution").FirstOrDefault().value * 5);
            //Stats agility = new Stats("agility", 90, mon_perso.baseAttr.Where(b => b.name == "dexterity").FirstOrDefault().value * 5);
            //Stats brawlpower = new Stats("brawl power", 90, mon_perso.baseAttr.Where(b => b.name == "strength").FirstOrDefault().value * 5);
            //Stats height = new Stats("height", 90, mon_perso.baseAttr.Where(b => b.name == "size").FirstOrDefault().value * 5);
            //Stats knowledge = new Stats("knowledge", 120, mon_perso.baseAttr.Where(b => b.name == "education").FirstOrDefault().value * 5);
            //Stats idea = new Stats("idea", 90, mon_perso.baseAttr.Where(b => b.name == "intelligence").FirstOrDefault().value * 5);
            //Stats willpower = new Stats("will power", 90, mon_perso.baseAttr.Where(b => b.name == "power").FirstOrDefault().value * 5);
            //Stats sanity = new Stats("sanity", 90, mon_perso.baseAttr.Where(b => b.name == "power").FirstOrDefault().value * 5);

            //mon_perso.stats.Add(prestance);
            //mon_perso.stats.Add(endurance);
            //mon_perso.stats.Add(agility);
            //mon_perso.stats.Add(brawlpower);
            //mon_perso.stats.Add(height);
            //mon_perso.stats.Add(knowledge);
            //mon_perso.stats.Add(idea);
            //mon_perso.stats.Add(willpower);
            //mon_perso.stats.Add(sanity);
            #endregion
            //spendable points
            #region spendPoints
            //spendpoints healthPoints = new spendpoints("health points", 18, (
            //    (mon_perso.baseAttr.Where(b => b.name == "constitution").FirstOrDefault().value
            //    )
            //    +
            //    (mon_perso.baseAttr.Where(b => b.name == "size").FirstOrDefault().value)
            //    ) / 2
            //    );
            //spendpoints woundLimit = new spendpoints("wound limit", 9);
            //spendpoints magicPoints = new spendpoints("magic points", 18);
            //spendpoints occupationSkillPoints = new spendpoints("Occupation skill points", 480);
            //spendpoints personalInterestSkillPoints = new spendpoints("Personal interest skill points", 180);

            //mon_perso.spendPoints.Add(healthPoints);
            //mon_perso.spendPoints.Add(woundLimit);
            //mon_perso.spendPoints.Add(magicPoints);
            //mon_perso.spendPoints.Add(occupationSkillPoints);
            //mon_perso.spendPoints.Add(personalInterestSkillPoints);

            //woundLimit.value = mon_perso.spendPoints.Where(s => s.name == "health points").FirstOrDefault().value / 2;
            //magicPoints.value = mon_perso.baseAttr.Where(b => b.name == "power").FirstOrDefault().value;
            //occupationSkillPoints.value = mon_perso.baseAttr.Where(b => b.name == "education").FirstOrDefault().value * 20;
            //personalInterestSkillPoints.value = mon_perso.baseAttr.Where(b => b.name == "intelligence").FirstOrDefault().value * 10;

            #endregion
            //skills
            #region skills
            //Skills art = new Skills("art", 100, 5);
            //Skills artisanat = new Skills("artisanat", 100, 5);
            //Skills baratin = new Skills("baratin", 100, 5);
            //Skills bibliothèque = new Skills("bibliotheque", 100, (mon_perso.baseAttr.Where(b => b.name == "education").FirstOrDefault().value) * 2);
            //Skills comptabilite = new Skills("comptabilite", 100, 10);
            //Skills concocterPotion = new Skills("concocter potion", 100, 1);
            //Skills conduireAttelage = new Skills("conduire attelage", 100, 20);
            //Skills coupDePied = new Skills("coup de pied", 100, 25);
            //Skills coupDePoing = new Skills("coup de poing", 100, 50);
            //Skills coupDeTete = new Skills("coup de tete", 100, 10);
            //Skills discretion = new Skills("discretion", 100, 10);
            //Skills dissimulation = new Skills("dissimulation", 100, 15);
            //Skills ecouter = new Skills("ecouter", 100, 25);
            //Skills ecrireUneLangue = new Skills("ecrire une langue", 100, 1);
            //Skills esquiver = new Skills("esquiver", 100, (mon_perso.baseAttr.Where(b => b.name == "dexterity").FirstOrDefault().value * 2));
            //Skills grimper = new Skills("grimper", 100, 40);
            //Skills lancer = new Skills("lancer", 100, 25);
            //Skills langueEtrangere = new Skills("langue etrangere", 100, 1);
            //Skills langueNatale = new Skills("langue natale", 100, (mon_perso.baseAttr.Where(b => b.name == "education").FirstOrDefault().value * 2));
            //Skills lutte = new Skills("lutte", 100, 25);
            //Skills marchandage = new Skills("marchandage", 100, 5);
            //Skills mondeNaturel = new Skills("monde naturel", 100, 10);
            //Skills monterACheval = new Skills("monter a cheval", 100, 5);
            //Skills mytheDeCthulhu = new Skills("mythe de Cthulhu", 100, 0);
            //Skills nager = new Skills("nager", 100, 25);
            //Skills navigation = new Skills("navigation", 100, 10);
            //Skills occultisme = new Skills("occultisme", 100, 5);
            //Skills persuasion = new Skills("persuasion", 100, 15);
            //Skills piloterBateau = new Skills("piloter bateau", 100, 1);
            //Skills premiersSoins = new Skills("premiers soins", 100, 30);
            //Skills reparerConcevoir = new Skills("reparer concevoir", 100, 20);
            //Skills royaumeNatal = new Skills("royaume natal", 100, 20);
            //Skills royaumesEtrangers = new Skills("royaumes etrangers", 100, 1);
            //Skills sagacite = new Skills("sagacite", 100, 5);
            //Skills sauter = new Skills("sauter", 100, 25);
            //Skills science = new Skills("science", 100, 1);
            //Skills se_cacher = new Skills("se cacher", 100, 10);
            //Skills statut = new Skills("statut", 100, 15);
            //Skills suivrePiste = new Skills("suivre une piste", 100, 10);
            //Skills trouverObjetCache = new Skills("trouver objet cache", 100, 25);

            //mon_perso.skills.Add(art);
            //mon_perso.skills.Add(artisanat);
            //mon_perso.skills.Add(baratin);
            //mon_perso.skills.Add(bibliothèque);
            //mon_perso.skills.Add(comptabilite);
            //mon_perso.skills.Add(concocterPotion);
            //mon_perso.skills.Add(conduireAttelage);
            //mon_perso.skills.Add(coupDePied);
            //mon_perso.skills.Add(coupDePoing);
            //mon_perso.skills.Add(coupDeTete);
            //mon_perso.skills.Add(discretion);
            //mon_perso.skills.Add(dissimulation);
            //mon_perso.skills.Add(ecouter);
            //mon_perso.skills.Add(ecrireUneLangue);
            //mon_perso.skills.Add(esquiver);
            //mon_perso.skills.Add(grimper);
            //mon_perso.skills.Add(lancer);
            //mon_perso.skills.Add(langueEtrangere);
            //mon_perso.skills.Add(langueNatale);
            //mon_perso.skills.Add(lutte);
            //mon_perso.skills.Add(marchandage);
            //mon_perso.skills.Add(mondeNaturel);
            //mon_perso.skills.Add(monterACheval);
            //mon_perso.skills.Add(mytheDeCthulhu);
            //mon_perso.skills.Add(nager);
            //mon_perso.skills.Add(navigation);
            //mon_perso.skills.Add(occultisme);
            //mon_perso.skills.Add(persuasion);
            //mon_perso.skills.Add(piloterBateau);
            //mon_perso.skills.Add(premiersSoins);
            //mon_perso.skills.Add(reparerConcevoir);
            //mon_perso.skills.Add(royaumeNatal);
            //mon_perso.skills.Add(royaumesEtrangers);
            //mon_perso.skills.Add(sagacite);
            //mon_perso.skills.Add(sauter);
            //mon_perso.skills.Add(science);
            //mon_perso.skills.Add(se_cacher);
            //mon_perso.skills.Add(statut);
            //mon_perso.skills.Add(suivrePiste);
            //mon_perso.skills.Add(trouverObjetCache);
            #endregion
            #endregion
            mon_perso.game = game;

            mon_perso.baseAttr = mon_perso.game.BaseAttributes;
            mon_perso.skills = mon_perso.game.Skills;
            mon_perso.stats = mon_perso.game.Stats;
            mon_perso.spendPoints = mon_perso.game.SpendPoints;

            this.metier = (Profession)this.game.professions.Where(p => p.name == "mendiant").FirstOrDefault();
            this.careerName = this.metier == null ? "Trouffion" : this.metier.name;
            logger.Log(String.Format("Metier : {0}", metier));
            logger.Log(String.Format("Career : {0}", careerName));

            IGameRule rules = mon_perso.game.rules;
            try
            {
                rules.setStats(mon_perso);
                rules.setSpendablePoints(mon_perso);
                rules.setBaseAttr(mon_perso);
                rules.setSkills(mon_perso);
            }
            catch(Exception ex)
            {
                logger.Log(String.Format("Error in Character Creation : {0}", ex.Message));
                throw ex;
            }
        }

        public Character(string charName, string playerName)
        {
            logger.Log(String.Format("Inside Character constructor with args characterName {0} and playerName {1}",charName, playerName));
            this.characterName = charName;
            this.playerName = playerName;

            this.game        = new CallOfCthulhu();
            this.baseAttr    = this.game.BaseAttributes;
            this.stats       = this.game.Stats;
            this.spendPoints = this.game.SpendPoints;
            this.skills      = this.game.Skills;
            this.metier      = (Profession)this.game.professions.Where(p => p.name == "mendiant").FirstOrDefault();
            this.careerName  = this.metier == null? "Trouffion" : this.metier.name;


            //TODO : Change this if game is chosen instead of hardcoded
            // This will set the stats of the perso, according to the value of his base attributes, as defined in COC Rules
            var mon_perso = this;
            IGameRule rules = this.game.rules;
            try
            {
                rules.setStats(mon_perso);
                rules.setSpendablePoints(mon_perso);
                rules.setBaseAttr(mon_perso);
            }
            catch(Exception ex)
            {
                logger.Log(String.Format("Error in Character Creation : {0}", ex.Message));
                throw ex;
            }
        }

        // This constructor takes a game in parameter.
        // This will allow us to use the same framework for multiple games.
        public Character(IGame myGame, string mycharacterName, string myplayerName) 
        {
            logger.Log(String.Format("Inside ultimate character constructor : game {0}, characterName {1} and playerName {2}", myGame, mycharacterName, myplayerName));
            this.characterName = mycharacterName;
            this.playerName = myplayerName;

            if (myGame == null)
                logger.Log("No Game found in Character creation. An error might happen.");

            this.game        = myGame;
            this.baseAttr    = myGame.BaseAttributes;
            this.skills      = myGame.Skills;
            this.stats       = myGame.Stats;
            this.spendPoints = myGame.SpendPoints;
            this.metier      = (Profession)this.game.professions.Where(p => p.name == "mendiant").FirstOrDefault();
            this.careerName  = this.metier == null? "Trouffion" : this.metier.name;

            // This might be reworked
            //foreach (BaseAttributes battr in this.baseAttr)
            //{
            //    battr.RollValue();
            //}
            // this should do the trick :
            IGameRule rules = myGame.rules;
            try
            {
                rules.setBaseAttr(this);
                rules.setStats(this);
                rules.setSpendablePoints(this);
                rules.setSkills(this);
            }
            catch(Exception ex)
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

            this.characterName = xmlDoc.SelectSingleNode("/character_sheet/infos/name").InnerText;
            this.playerName = xmlDoc.SelectSingleNode("/character_sheet/infos/player_name").InnerText;
            logger.Log(String.Format("Character name : {0}", this.characterName));
            logger.Log(String.Format("player name : {0}", this.playerName));

            // INFOS
            // We will have the same difficulty for Game and for Profession : create an instance from the name.
            string gameName = xmlDoc.SelectSingleNode("/character_sheet/infos/game").InnerText;
            Type CAType = Type.GetType("RPG_API.Models.Games." + gameName.Replace(" ", ""));
            this.game = Activator.CreateInstance(CAType) as IGame;
            
            // as the professions are created inside the game, we can't use reflexion.
            string metierName = xmlDoc.SelectSingleNode("/character_sheet/infos/career").InnerText;
            this.metier = (Profession)this.game.professions.Where(p => p.name == metierName).FirstOrDefault();
            careerName = metier == null ? "Trouffion" : metier.name;

            // CARACTERISTICS
            this.baseAttr = this.game.BaseAttributes;
            this.skills = this.game.Skills;
            this.stats = this.game.Stats;
            this.spendPoints = this.game.SpendPoints;

            try
            {
                foreach (ICaracteristic battr in this.baseAttr)
                {
                    var nodeContent = (xmlDoc.SelectSingleNode("/character_sheet/base_attributes/" + battr.name.Replace(" ", "_").ToLower()).InnerText);
                    battr.value = setValue(nodeContent);
                    logger.Log(String.Format("Base Attr {0} with value {1}", battr.name, battr.value));
                }

                foreach (ICaracteristic skill in this.skills)
                {
                    string skillName = skill.name.Replace(" ", "_");
                    var nodeContent = xmlDoc.SelectSingleNode("/character_sheet/skills/" + skillName.ToLower()).InnerText;
                    skill.value = setValue(nodeContent);
                    logger.Log(String.Format("Skill {0} with value {1}", skill.name, skill.value));
                }

                foreach (ICaracteristic stat in this.stats)
                {
                    string statName = stat.name.Replace(" ", "_");

                    var nodeContent = xmlDoc.SelectSingleNode("/character_sheet/stats/" + statName.ToLower()).InnerText;

                    stat.value = setValue(nodeContent);
                    //stat.value = Convert.ToInt32(xmlDoc.SelectSingleNode("/character_sheet/stats/" + statName.ToLower()).InnerText);
                    logger.Log(String.Format("Stat {0} with value {1}", stat.name, stat.value));
                }

                foreach (ICaracteristic sPoint in this.spendPoints)
                {
                    //string sPointName = sPoint.name.Replace(" ", "_");
                    //sPoint.value = Convert.ToInt32(xmlDoc.SelectSingleNode("/character_sheet/spendable_points/" + sPointName.ToLower()).InnerText);
                    string sPointName = sPoint.name.Replace(" ", "_");

                    var nodeContent = xmlDoc.SelectSingleNode("/character_sheet/spendable_points/" + sPointName.ToLower()).InnerText;

                    sPoint.value = setValue(nodeContent);

                    logger.Log(String.Format("spendpoint {0} with value {1}", sPoint.name, sPoint.value));
                }
            }
            catch(Exception ex)
            {
                logger.Log(String.Format("Error in Character constructor : {0}", ex.Message));
                throw ex;
            }
        }

    }
}