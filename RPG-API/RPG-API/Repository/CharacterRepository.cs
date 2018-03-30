using RPG_API.Models;
using RPG_API.Models.Careers;
using RPG_API.Models.DTO.Character_DTO;
using RPG_API.Models.Games;
using RPG_API.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace RPG_API.Repository
{
    public class CharacterRepository
    {
        private Logger logger = new Logger();

        //GET ALL
        public IEnumerable<Character> Get()
        {
            logger.Log("Inside Repo Character Get All method");
            List<Character> myCharacs = new List<Character>();

            // This might be reworked.
            // We get the character sheets in app_data and create characters from that.
            string mypath = ConfigurationManager.AppSettings["path"];
            string path = System.Web.HttpContext.Current.Server.MapPath(mypath);
            var myFiles = Directory.GetFiles(@path);

            try
            {
                foreach (var file in myFiles)
                {
                    // The empty character sheet are saved in the same folder, so we filter them out:
                    if (file.ToLower() != path.ToLower() + "call_of_cthulhu_character_sheet.xml" &&
                        file.ToLower() != path.ToLower() + "fallout_character_sheet.xml")
                    {
                        logger.Log(String.Format("Treating file : {0}", file));
                        Character charac = new Character(file);
                        myCharacs.Add(charac);
                    }
                }
                return myCharacs;
            }
            catch (Exception ex)
            {
                logger.Log(String.Format("Error in Get All method from Character Repo : {0}", ex.Message));
                throw ex;
            }
        }

        //GET ONE
        public Character Get(string name)
        {
            logger.Log("Inside character repository.Get.");
            // This might be reworked
            string mypath = ConfigurationManager.AppSettings["path"];
            string path = System.Web.HttpContext.Current.Server.MapPath(mypath);
            var myFiles = Directory.GetFiles(@path);

            Character searched_character = new Character();
            try
            {
                foreach (var file in myFiles)
                {
                    logger.Log("CharacterRepository.get : file " + file.ToLower());

                    if (file == path + name.ToLower() + ".xml")
                    {
                        searched_character = new Character(file);
                        logger.Log(String.Format("Character Found! Expected {1}, found {0}. Returning character.", searched_character.CharacterName, name));
                        return searched_character;
                    }
                }
                logger.Log("Nothing found...");
                return searched_character;
            }
            catch (Exception ex)
            {
                logger.Log("CharacterRepository.get : " + ex.Message);
                throw ex;
            }
        }

        //UPDATE
        // TODO : ADD ADMIN RIGHTS ONLY
        public void Update(Character monPerso, Character newVersion)
        {
            logger.Log("Inside character repository.Update.");
            SheetFiller sFiller = new SheetFiller();
            // This might be reworked
            string mypath = ConfigurationManager.AppSettings["path"];
            string path = System.Web.HttpContext.Current.Server.MapPath(mypath);

            // Save existing version in "backup" sub-folder
            sFiller.backUpCharacter(monPerso, path);

            try
            {
                UpdateSkills(monPerso, newVersion);
                UpdateStats(monPerso, newVersion);
                UpdateBaseAttr(monPerso, newVersion);
                UpdateSpendPoints(monPerso, newVersion);

            }
            catch (Exception ex)
            {
                logger.Log(String.Format("Error in Repo.update character : {0}", ex.Message));
                throw ex;
            }
        }

        //UPDATE SKILLS ONLY
        public void UpdateSkills(Character monPerso, Character newVersion)
        {
            logger.Log("Inside character repository.UpdateSkills.");
            SheetFiller sFiller = new SheetFiller();

            // This might be reworked
            string mypath = ConfigurationManager.AppSettings["path"];
            string path = System.Web.HttpContext.Current.Server.MapPath(mypath);

            bool sanCheck = true;
            
            foreach (var skill in newVersion.Skills)
            {
                sanCheck = skill.Validate();
            }
            if (!sanCheck)
                return;

            // Record the new values
            sFiller.FillSkills(newVersion, path);
            sFiller.FillSpendablePoints(newVersion, path);
            
        }

        public void UpdateStats(Character monPerso, Character newVersion)
        {
            logger.Log("Inside character repository.UpdateSkills.");
            SheetFiller sFiller = new SheetFiller();

            // This might be reworked
            string mypath = ConfigurationManager.AppSettings["path"];
            string path = System.Web.HttpContext.Current.Server.MapPath(mypath);

            bool sanCheck = true;

            foreach (var stat in newVersion.Stats)
            {
                sanCheck = stat.Validate();
            }
            if (!sanCheck)
                return;

            // Record the new values
            sFiller.FillStats(newVersion, path);
        }

        public void UpdateBaseAttr(Character monPerso, Character newVersion)
        {
            logger.Log("Inside character repository.UpdateSkills.");
            SheetFiller sFiller = new SheetFiller();

            // This might be reworked
            string mypath = ConfigurationManager.AppSettings["path"];
            string path = System.Web.HttpContext.Current.Server.MapPath(mypath);

            bool sanCheck = true;

            foreach (var battr in newVersion.BaseAttr)
            {
                sanCheck = battr.Validate();
            }
            if (!sanCheck)
                return;

            // Record the new values
            sFiller.FillBaseAttributes(newVersion, path);
        }

        public void UpdateSpendPoints(Character monPerso, Character newVersion)
        {
            logger.Log("Inside character repository.UpdateSkills.");
            SheetFiller sFiller = new SheetFiller();

            // This might be reworked
            string mypath = ConfigurationManager.AppSettings["path"];
            string path = System.Web.HttpContext.Current.Server.MapPath(mypath);

            bool sanCheck = true;

            foreach (var sPoint in newVersion.SpendPoints)
            {
                sanCheck = sPoint.Validate();
            }
            if (!sanCheck)
                return;

            // Record the new values
            sFiller.FillSpendablePoints(newVersion, path);
        }

        // This is the "ultimate" creator.
        public void Create(Game myGame, string mycharacterName, string myplayerName)
        {
            logger.Log("Inside character repository.Create ultimate.");
            logger.Log(String.Format("Game : {0}, characterName: {1}, playerName : {2}", myGame, mycharacterName, myplayerName));

            try
            {
                // This will load the caracteristic of the game in the character and set every value
                Character myHero = new Character(myGame, mycharacterName, myplayerName);

                // This will create a generic character sheet using the name of the game and its caracteristic lists.
                SheetMaker sMaker = new SheetMaker();
                sMaker.makeSheet(myHero, myGame);
            }
            catch (Exception ex)
            {
                logger.Log(String.Format("Error in repo.Create character : {0}", ex.Message));
                throw ex;
            }
        }

        public void CreateWithDTO(Character_DTO myHeroDTO)
        {
            logger.Log("Inside character repository createWithDto");
            logger.Log(String.Format("Character : {0}", myHeroDTO.CharacterName));

            try
            {
                string game_name = myHeroDTO.GameName.Replace(" ", "");

                if (string.IsNullOrEmpty(game_name)) game_name = "Fallout";

                Game my_game = Game.GetaGame(game_name);
                Character myHero = new Character(my_game, myHeroDTO.CharacterName, myHeroDTO.PlayerName);

                myHero.CharacterName = string.IsNullOrEmpty(myHeroDTO.CharacterName) ? "Toby Determined" : myHeroDTO.CharacterName ;
                myHero.PlayerName = string.IsNullOrEmpty(myHeroDTO.PlayerName) ? "Meujeu" : myHeroDTO.PlayerName;
                if (!string.IsNullOrEmpty(myHeroDTO.Metier))
                {
                    myHero.Metier = (Profession)my_game.professions.Find(p => p.name == myHeroDTO.Metier);
                }
                else
                {
                    myHero.Metier = (Profession)my_game.professions.Find(p => p.name == "mendiant");
                }

                myHero.CareerName = myHero.Metier.name;

                //to do : change to allow creation of a character with chosen base attr
                myHero.BaseAttr = my_game.BaseAttributes;

                my_game.rules.SetStats(myHero);
                my_game.rules.SetSpendablePoints(myHero);
                my_game.rules.SetSkills(myHero);
                my_game.rules.SetCareerSkills(myHero);

                SheetMaker sMaker = new SheetMaker();
                sMaker.makeSheet(myHero, my_game);
            }
            catch (Exception ex)
            {
                logger.Log(String.Format("Error in character repository create with DTO : {0}", ex.Message));
                throw ex;
            }
        }

    }
}