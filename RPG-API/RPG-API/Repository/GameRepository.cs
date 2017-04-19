using RPG_API.Models.Games;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;

namespace RPG_API.Repository
{
    public class GameRepository
    {
        public IEnumerable<IGame> Get()
         {
            List<IGame> myGames = new List<IGame>();
            // This might be reworked.
            // We get the Game sheets in app_data and create games from that.
            string mypath = ConfigurationManager.AppSettings["game_path"];
            string path = System.Web.HttpContext.Current.Server.MapPath(mypath);
            var myFiles = Directory.GetFiles(@path);

            foreach (var file in myFiles)
            {
               if (file == path + "Games.xml")
                {
                    var xmlDoc = new XmlDocument();
                    xmlDoc.Load(file);

                    var rootNode = xmlDoc.SelectSingleNode("/games");

                    for (int i = 0; i < rootNode.ChildNodes.Count; i++)
                    {
                        string gameName = rootNode.ChildNodes[i].InnerText;
                        gameName = gameName.Replace(" ", "");

                        Type CAType = Type.GetType("RPG_API.Models.Games." + gameName);
                        IGame Game = Activator.CreateInstance(CAType) as IGame;
                        myGames.Add(Game);
                    }
                }
            }
            return myGames;
        }


        public IGame Get(string name)
        {
            string mypath = ConfigurationManager.AppSettings["game_path"];
            string path = System.Web.HttpContext.Current.Server.MapPath(mypath);
            var myFiles = Directory.GetFiles(@path);


            string gameName = name.Replace(" ", "");

            Type CAType = Type.GetType("RPG_API.Models.Games." + gameName);
            IGame Game = Activator.CreateInstance(CAType) as IGame;

            return Game;
        }


    }
}