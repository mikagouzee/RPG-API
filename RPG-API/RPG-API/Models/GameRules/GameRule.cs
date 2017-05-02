using RPG_API.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RPG_API.Models.GameRules
{
    public class GameRule:IGameRule
    {
        private readonly Logger logger = new Logger();

        public virtual void setStats(Character myCharac) { logger.Log("Inside base virtual setStats method"); }

        public virtual void setSpendablePoints(Character myCharac) { logger.Log("Inside base virtual setSpendPoints method"); }

        public virtual void setSkills(Character myCharac) { logger.Log("Inside base virtual setSkills method"); }

        public virtual void setBaseAttr(Character myCharac) { logger.Log("Inside base virtual setBattr method"); }

    }
}