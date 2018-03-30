using Newtonsoft.Json;
using RPG_API.Models;
using RPG_API.Models.DTO.Character_DTO;
using RPG_API.Repository;
using RPG_API.Utils;
using System;
using System.Web.Http;
using System.Web.Http.Cors;

namespace RPG_API.Controllers
{
    [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
    public class Character_DTOController : ApiController
    {
        private readonly CharacterRepository repo = new CharacterRepository();
        private Logger logger = new Logger();

        [Route("api/create")]
        public IHttpActionResult Post(Character_DTO aCharac)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            repo.CreateWithDTO(aCharac);
            Character created_character = repo.Get(aCharac.CharacterName);

            logger.Log("Exiting characterDto.Controller");
            return Ok(created_character);
        }
    }
}