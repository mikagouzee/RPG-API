using RPG_API.Models.Caracteristic;
using RPG_API.Models.Careers;
using RPG_API.Models.GameRules;
using RPG_API.Utils;
using System;
using System.Collections.Generic;

namespace RPG_API.Models.Games
{
    // A base class is better than an interface for many of our implementations, so let's add this
    public class Game : IGame
    {
        private Logger logger;

        public string Name { get; set; }

        public List<BaseAttributes> BaseAttributes { get; set; }
        public List<Stats> Stats { get; set; }
        public List<Skills> Skills { get; set; }
        public List<Spendpoints> SpendPoints { get; set; }
        public List<Profession> professions { get; set; }

        public GameRule rules { get; set; }

        //DEFAULT EMPTY CONSTRUCTOR
        public Game()
        {
            logger = new Logger();
            logger.Log("Inside empty game constructor");
        }

        public virtual void Setup() { }

        public static Game GetaGame(string name)
        {
            string game_name = name.Replace(" ", "");
            Type CAType = Type.GetType("RPG_API.Models.Games." + game_name);

            Game my_game = Activator.CreateInstance(CAType) as Game;
            
            return my_game;
        }
    }
}