using RPG_API.Models.Games;
using RPG_API.Repository;
using RPG_API.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;

namespace RPG_API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class GamesController : ApiController
    {
        private readonly GameRepository repo = new GameRepository();
        private Logger logger = new Logger();

        [Route("api/games/getAll")]
        public JsonResult<List<IGame>> GetAll()
        {
            logger.Log("Inside Game Controller Get All.");
            List<IGame> myGames = repo.Get().ToList();

            logger.Log("Exiting Controller");
            return Json(myGames);
        }

        [Route("api/games/get/{name}")]
        public IGame Get(string name)
        {
            logger.Log(String.Format("Inside Game Controller Get with parameter name : {0}", name));
            IGame searched_game = repo.Get(name);
            logger.Log("Exiting Game Controller");
            return searched_game;
        }
    }
}