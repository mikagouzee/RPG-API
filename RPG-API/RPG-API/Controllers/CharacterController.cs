using Newtonsoft.Json;
using RPG_API.Models;
using RPG_API.Models.Games;
using RPG_API.Repository;
using RPG_API.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using System.Web.Http.Results;

namespace RPG_API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CharacterController : ApiController
    {
        private readonly CharacterRepository repo = new CharacterRepository();
        private Logger logger = new Logger();

        // GET: api/Character
        [Route("api/getAll")]
        public JsonResult<List<Character>> GetAll()
        {
            logger.Log("Inside Characte Controller.GetAll");
            List<Character> myCharacs = repo.Get().ToList();

            return Json(myCharacs);
        }

        // GET: api/Character/azazel
        [Route("api/get/{name}")]
        public Character Get(string name)
        {
            logger.Log("Inside characterController.get");
            Character searchedCharac = repo.Get(name);
            logger.Log("Returning searched character to front.");
            return searchedCharac;
        }

        // POST: api/Character
        /// <summary>
        /// Creates a default character for game Fallout.
        /// </summary>
        /// <param name="charac">The character posted</param>
        /// <returns></returns>
        [ResponseType(typeof(Character))]
        //[Route("api/create")]
        public IHttpActionResult Post(Character charac)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            logger.Log("Inside CharacterController.Post");

            repo.Create(new Fallout(), charac.CharacterName, charac.PlayerName);
            Character created_character = repo.Get(charac.CharacterName);

            return Ok(created_character);
        }

        // PUT: api/Character/5
        //Todo : extract this in a service
        [ResponseType(typeof(void))]
        [Route("api/update")]
        public IHttpActionResult Put(Character newVersion)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var currentVersion = repo.Get(newVersion.CharacterName);
            if (currentVersion == null)
                return NotFound();

            repo.Update(currentVersion, newVersion);

            return NotFound();
        }

        // DELETE: api/Character/5
        // TODO
        public void Delete(int id)
        {
        }
    }
}