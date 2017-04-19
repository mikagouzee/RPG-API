 using RPG_API.Models;
using RPG_API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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

        // GET: api/Character
        [Route("api/getAll")]
        public JsonResult<List<Character>> GetAll()
        {
            List<Character> myCharacs = repo.Get().ToList();

            return Json(myCharacs);
        }

        // GET: api/Character/azazel
        [Route("api/get/{name}")]
        public Character Get(string name)
        {
            Character searchedCharac = repo.Get(name);
            
            return searchedCharac;
        }

        // POST: api/Character
        [ResponseType(typeof(Character))]
        //[Route("api/create")]
        public IHttpActionResult Post(Character charac)
        {
            if (charac == null)
            {
                return NotFound();
            }
 

            repo.Create(charac.characterName, charac.playerName);
            Character created_character = repo.Get(charac.characterName);

            return Ok(created_character);

        }

        // PUT: api/Character/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(Character newVersion)
        {
            if (newVersion == null)
                return NotFound();

            Character toUpdate_character = repo.Get(newVersion.characterName);
            repo.Update(toUpdate_character, newVersion);
            toUpdate_character = repo.Get(newVersion.characterName);

            return Ok(toUpdate_character);
        }

        // DELETE: api/Character/5
        // TODO
        public void Delete(int id)
        {
        }
    }
}
