using RPG_API.Models;
using RPG_API.Models.DTO.Character_DTO;
using RPG_API.Models.Games;
using RPG_API.Repository;
using RPG_API.Utils;
using System;
using System.Web.Http;
using System.Web.Http.Cors;

namespace RPG_API.Controllers
{
    [EnableCors(origins:"http://localhost:3000", headers:"*",methods:"*")]
    public class Character_DTOController : ApiController
    {
        private readonly CharacterRepository repo = new CharacterRepository();
        private Logger logger = new Logger();

        [Route("api/create")]
        public IHttpActionResult Post(Character_DTO myCharac)
        {
            logger.Log("Inside characterDto.controller");
            if(myCharac == null)
            {
                logger.Log("Character Not found");
                return NotFound();
            }

            string game_name = myCharac.gameName.Replace(" ", "");

            // Use reflexion to create a game from it's name. 
            Type CAType = Type.GetType("RPG_API.Models.Games." + game_name);
            IGame my_game = Activator.CreateInstance(CAType) as IGame;

            repo.Create(my_game, myCharac.characterName, myCharac.playerName);
            Character created_character = repo.Get(myCharac.characterName);
            //created_character.baseAttr = myCharac.baseAttr;
            //created_character.game.rules.setStats(created_character);
            //created_character.game.rules.setSpendablePoints(created_character);
            //created_character.game.rules.setSkills(created_character);


            logger.Log("Exiting characterDto.Controller");
            return Ok(created_character);
        }
    }
}
