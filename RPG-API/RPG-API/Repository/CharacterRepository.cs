using RPG_API.Models;
using RPG_API.Models.DTO.Character_DTO;
using RPG_API.Models.Games;
using RPG_API.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;

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
                        logger.Log(String.Format("Character Found! Expected {1}, found {0}. Returning character.", searched_character.characterName, name));
                        return searched_character;
                    }
                }
                logger.Log("Nothing found...");
                return searched_character;
            }
            catch(Exception ex)
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

            Game game = monPerso.game;
            newVersion.game = game;
            
            try
            {
                // Save existing version in "backup" sub-folder
                sFiller.backUpCharacter(monPerso, path);

                // Record the new values
                sFiller.fillInfos(newVersion, path);
                sFiller.fillBaseAttributes(newVersion, path);
                sFiller.fillStats(newVersion, path);
                sFiller.fillSpendablePoints(newVersion, path);
                sFiller.fillSkills(newVersion, path);
            }
            catch(Exception ex)
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

            // Save existing version in "backup" sub-folder
            sFiller.backUpCharacter(monPerso, path);

            // Record the new values
            sFiller.fillSkills(newVersion, path);
            sFiller.fillSpendablePoints(newVersion, path);
        }

        //CREATE
        //TODO : ADD 'MACHINE' RIGHTS ONLY
        public void Create(string characterName, string playerName)
        {
            logger.Log("Inside character repository.Create.");
            // This might be reworked
            //string mypath = ConfigurationManager.AppSettings["path"];
            //string path = System.Web.HttpContext.Current.Server.MapPath(mypath);

            // Use a basic constructor.
            Character myCharacter = new Character(characterName, playerName);

            SheetMaker sMaker = new SheetMaker();
            sMaker.makeSheet(myCharacter);

            #region before test of sheetmaker
            //// Creates a character_sheet for Cthulhu Game. 
            //// It's the default for dev purposes.
            //SheetWriter sWriter = new SheetWriter();

            //// We know the game will be Cthulhu, so we pass a hardcoded path
            //sWriter.CreateSheet(myCharacter.game, "cthulhu_character_sheet");

            //// Filler will be used to record values of character in sheet.
            //SheetFiller sFiller = new SheetFiller();
            //sFiller.fillInfos(myCharacter, path);
            //sFiller.fillBaseAttributes(myCharacter, path);
            //sFiller.fillStats(myCharacter, path);
            //sFiller.fillSpendablePoints(myCharacter, path);
            //sFiller.fillSkills(myCharacter, path);
            #endregion
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
                sMaker.makeSheet(myHero);
            }
            catch(Exception ex)
            {
                logger.Log(String.Format("Error in repo.Create character : {0}", ex.Message));
                throw ex;
            }
        }

        public void CreateWithDTO(Character_DTO myHeroDTO)
        {
            logger.Log("Inside character repository createWithDto");
            logger.Log(String.Format("Character : {0}", myHeroDTO.characterName));

            try
            {
                string game_name = myHeroDTO.gameName.Replace(" ", "");
                Game my_game = new Game(game_name);
                logger.Log(String.Format("We will create the character with game {0}", my_game.name));


                //We create a character based on the game
                Character myHero = new Character(my_game);
                myHero.characterName = myHeroDTO.characterName;
                myHero.playerName = myHeroDTO.playerName;
                myHero.baseAttr = myHeroDTO.baseAttr;

                myHero.game.rules.setStats(myHero);
                myHero.game.rules.setSpendablePoints(myHero);
                myHero.game.rules.setSkills(myHero);

                SheetMaker sMaker = new SheetMaker();
                sMaker.makeSheet(myHero);

            }
            catch(Exception ex)
            {
                logger.Log(String.Format("Error in character repository create with DTO : {0}", ex.Message));
                throw ex;
            }

        }

        public void Create(Character_DTO hero_DTO)
        {
            string game_name = hero_DTO.gameName.Replace(" ", "");
            Game my_game = new Game(game_name);

            try
            {
                Character created_character = new Character(my_game);

                if (hero_DTO.characterName != null)
                    created_character.characterName = hero_DTO.characterName;

                if (hero_DTO.playerName != null)
                    created_character.playerName = hero_DTO.playerName;

                if (hero_DTO.baseAttr != null && hero_DTO.baseAttr.Count == created_character.baseAttr.Count)
                    created_character.baseAttr = hero_DTO.baseAttr;

                SheetMaker sMaker = new SheetMaker();
                sMaker.makeSheet(created_character);
            }
            catch(Exception ex)
            {
                logger.Log(String.Format("Error in repo.Create Character with DTO : {0}", ex.Message));
                throw ex;
            }
        }

    }

}