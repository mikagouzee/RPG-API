using RPG_API.Models.Caracteristic;
using RPG_API.Models.Careers;
using RPG_API.Utils;
using System.Collections.Generic;

namespace RPG_API.Models.DTO.Character_DTO
{
    public class Character_DTO
    {
        private Logger logger = new Logger();

        public string CharacterName { get; set; }
        public string PlayerName { get; set; }
        public string GameName { get; set; }
        public List<BaseAttributes> BaseAttr { get; set; }
        public string Metier { get; set; }

        public Character_DTO()
        {
            logger.Log("Inside Character Dto Empty Builder");
            BaseAttr = new List<BaseAttributes>();
        }
    }
}