using RPG_API.Utils;

namespace RPG_API.Models.GameRules
{
    public class GameRule : IGameRule
    {
        private readonly Logger logger = new Logger();

        public virtual void SetStats(Character myCharac)
        {
            logger.Log("Inside base virtual setStats method");
        }

        public virtual void SetSpendablePoints(Character myCharac)
        {
            logger.Log("Inside base virtual setSpendPoints method");
        }

        public virtual void SetSkills(Character myCharac)
        {
            logger.Log("Inside base virtual setSkills method");
        }

        public virtual void SetBaseAttr(Character myCharac)
        {
            logger.Log("Inside base virtual setBattr method");
        }

        public virtual void SetCareerSkills(Character myCharac)
        {
            logger.Log("Inside base virtual setCareerSkills method");
        }

    }
}