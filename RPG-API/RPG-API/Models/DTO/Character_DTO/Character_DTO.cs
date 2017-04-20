﻿using RPG_API.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RPG_API.Models.DTO.Character_DTO
{
    public class Character_DTO
    {
        Logger logger = new Logger();

        public string characterName { get; set; }
        public string playerName { get; set; }

        public string gameName { get; set; }

        public Character_DTO()
        {
            logger.Log("Inside Character Dto Empty Builder");
        }
    }
}