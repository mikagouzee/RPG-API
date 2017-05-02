using RPG_API.Models.Caracteristic;
using RPG_API.Models.Careers;
using RPG_API.Models.GameRules;
using RPG_API.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RPG_API.Models.Games
{
    // A base class is better than an interface for many of our implementations, so let's add this
    public class Game: IGame
    {
        private Logger logger;

        public string name { get; set; }

        public List<BaseAttributes> BaseAttributes { get; set; }
        public List<Stats> Stats { get; set; }
        public List<Skills> Skills { get; set; }
        public List<spendpoints> SpendPoints { get; set; }
        public List<Profession> professions { get; set; }

        public GameRule rules { get; set; }

        //DEFAULT EMPTY CONSTRUCTOR
        public Game()
        {
            logger = new Logger();
            logger.Log("Inside empty game constructor");
        }

        public Game(string name)
        {
            logger = new Logger();
            logger.Log(String.Format("Inside game constructor with args {0}", name));
            string game_name = name.Replace(" ", "");
            Type CAType = Type.GetType("RPG_API.Models.Games." + game_name);

            Game my_game = Activator.CreateInstance(CAType) as Game;
            logger.Log(String.Format("We created game : {0}", my_game.name));
            this.name = my_game.name;
            this.BaseAttributes = my_game.BaseAttributes;
            this.Stats = my_game.Stats;
            this.Skills = my_game.Skills;
            this.SpendPoints = my_game.SpendPoints;
            this.professions = my_game.professions;
            this.rules = my_game.rules;
        }

    }
}