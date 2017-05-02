using Newtonsoft.Json;
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
        public IHttpActionResult Post(Object aCharac)
        {
            logger.Log("Inside characterDto.controller post method.");
            if(aCharac == null)
            {
                logger.Log("Character Not found");
                return NotFound();
            }

            string jsonString = aCharac.ToString();
            Character_DTO myCharac = JsonConvert.DeserializeObject<Character_DTO>(jsonString);

            logger.Log(String.Format("Character deserialized from the json string received : {0}", jsonString));
            logger.Log(String.Format("Character {0} for player {1} with career {2}", myCharac.characterName, myCharac.playerName, myCharac.metier.name));

            repo.CreateWithDTO(myCharac);
            Character created_character = repo.Get(myCharac.characterName);

            logger.Log("Exiting characterDto.Controller");
            return Ok(created_character);
        }
    }
}
