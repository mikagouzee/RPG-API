using Newtonsoft.Json;
using RPG_API.Models;
using RPG_API.Repository;
using RPG_API.Utils;
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
        Logger logger = new Logger();

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
        [ResponseType(typeof(Character))]
        //[Route("api/create")]
        public IHttpActionResult Post(Character charac)
        {
            logger.Log("Inside CharacterController.Post");
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
        [Route("api/update")]
        public IHttpActionResult Put(Object newVersion)
        {
            logger.Log("Inside CharacterController.Update");
            if (newVersion == null)
                return NotFound();

            string jsonString = newVersion.ToString();
            Character mynewVersion;
            try
            {
                mynewVersion = JsonConvert.DeserializeObject<Character>(jsonString);
                logger.Log(String.Format("Character value received : {0}", jsonString));
            }
            catch(Exception ex)
            {
                logger.Log(String.Format("Error in the json received : {0} . /n Json was : {1}", ex.Message, jsonString));
                throw ex;
            }

            
            Character toUpdate_character = repo.Get(mynewVersion.characterName);

            if (mynewVersion.baseAttr.Count > 0)
            {
                toUpdate_character.baseAttr = mynewVersion.baseAttr;
                logger.Log(String.Format("Added base attr to our character : {0}", mynewVersion.baseAttr));
            }

            if (mynewVersion.stats.Count > 0)
            {
                toUpdate_character.stats = mynewVersion.stats;
                logger.Log(String.Format("Added stats to our character : {0}", mynewVersion.stats));
            }

            if (mynewVersion.skills.Count > 0)
            {
                toUpdate_character.skills = mynewVersion.skills;
                logger.Log(String.Format("Added skills to our character : {0}", mynewVersion.skills));
            }

            if (mynewVersion.spendPoints.Count > 0)
            {
                toUpdate_character.spendPoints = mynewVersion.spendPoints;
                logger.Log(String.Format("Added spendPoints to our character : {0}", mynewVersion.spendPoints));
            }


            repo.Update(toUpdate_character, mynewVersion);
            toUpdate_character = repo.Get(mynewVersion.characterName);
            logger.Log("Character updated, exiting controller");
            return Ok(toUpdate_character);
        }

        // DELETE: api/Character/5
        // TODO
        public void Delete(int id)
        {
        }
    }
}
