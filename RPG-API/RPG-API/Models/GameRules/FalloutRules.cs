using RPG_API.Models.Caracteristic;
using RPG_API.Models.Games;
using RPG_API.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RPG_API.Models.GameRules
{
    public class FalloutRules : GameRule
    {
        private Logger logger = new Logger();

        //EMPTY CONSTRUCTOR
        public FalloutRules()
        {

        }

        public override void setStats(Character myCharac)
        {
            //if (!(myCharac.game is Fallout))
            //{
            //    return;
            //}
            logger.Log("Inside FalloutRules.SetStat.");

            int str = myCharac.baseAttr.Where(b => b.name == "strength").FirstOrDefault().value;
            int endu = myCharac.baseAttr.Where(b => b.name == "endurance").FirstOrDefault().value;

            myCharac.stats.Where(s => s.name == "karma").FirstOrDefault().value = 0;

            int AP = 0;
            int agi = (myCharac.baseAttr.Where(b => b.name == "agility").FirstOrDefault().value != null ? myCharac.baseAttr.Where(b => b.name == "agility").FirstOrDefault().value : 0);
            logger.Log(String.Format("Setting AP on base of agi {0}", agi));
            switch (agi)
            {
                case 1:
                    AP = 5;
                    break;
                case 2:
                case 3:
                    AP = 6;
                    break;
                case 4:
                case 5:
                    AP = 7;
                    break;
                case 6:
                case 7:
                    AP = 8;
                    break;
                case 8:
                case 9:
                    AP = 9;
                    break;
                case 10:
                    AP = 10;
                    break;

                default:
                    AP = 1;
                    break;
            }
            logger.Log(String.Format("AP : {0}", AP));

            myCharac.stats.Where(s => s.name == "action points").FirstOrDefault().value = AP;

            myCharac.stats.Where(s => s.name == "armor class").FirstOrDefault().value = agi;
            logger.Log("Armor Class set up");

            myCharac.stats.Where(s => s.name == "carry weight").FirstOrDefault().value = 25 + (25 * str);
            logger.Log("Carry Weight set up");

            int MD = 5 + (str - 10);
            myCharac.stats.Where(s => s.name == "melee damage").FirstOrDefault().value = (MD > 0 ? MD : 1);
            logger.Log("Melee Damage set up");

            int per = myCharac.baseAttr.Where(b => b.name == "perception").FirstOrDefault().value;
            myCharac.stats.Where(s => s.name == "sequence").FirstOrDefault().value = 2 * per;
            logger.Log("Sequence set up");

            int HR = 0;
            logger.Log(String.Format("Setting HR on base of endu {0}", endu));
            switch (endu)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                    HR = 1;
                    break;
                case 6:
                case 7:
                case 8:
                    HR = 2;
                    break;
                case 9:
                case 10:
                    HR = 3;
                    break;

                default:
                    HR = 4;
                    break;
            }
            logger.Log(String.Format("HR : {0}", HR));
            myCharac.stats.Where(s => s.name == "healing rate").FirstOrDefault().value = HR;


            logger.Log("Exiting setStats");
        }

        public override void setSpendablePoints(Character myCharac)
        {
            //healthpoints, woundlimit, skillpoints
            logger.Log("Inside FalloutRules.setSpendablePoints");

            int str = myCharac.baseAttr.Where(b => b.name == "strength").FirstOrDefault().value;
            int endu = myCharac.baseAttr.Where(b => b.name == "endurance").FirstOrDefault().value;

            myCharac.spendPoints.Where(s => s.name == "health points").FirstOrDefault().value = 15 + str + (2 * endu);

            myCharac.spendPoints.Where(s => s.name == "wound limit").FirstOrDefault().value = 0;

            myCharac.spendPoints.Where(s => s.name == "skill points").FirstOrDefault().value = 0;

            logger.Log("Exiting setSpendablePoints");
        }

        // Is this needed? we might use "mean value"... 
        public override void setSkills(Character myCharac)
        {
            //if (!(myCharac.game is Fallout))
            //{
            //    return;
            //}

            logger.Log("Inside FalloutRules.setSkills");

            int str = myCharac.baseAttr.Where(b => b.name == "strength").FirstOrDefault().value;
            int per = myCharac.baseAttr.Where(b => b.name == "perception").FirstOrDefault().value;
            int end = myCharac.baseAttr.Where(b => b.name == "endurance").FirstOrDefault().value;
            int cha = myCharac.baseAttr.Where(b => b.name == "charism").FirstOrDefault().value;
            int inte = myCharac.baseAttr.Where(b => b.name == "intelligence").FirstOrDefault().value;
            int agi = myCharac.baseAttr.Where(b => b.name == "agility").FirstOrDefault().value;
            int lck = myCharac.baseAttr.Where(b => b.name == "luck").FirstOrDefault().value;

            myCharac.skills.Where(s => s.name == "small guns").FirstOrDefault().          value = 5 + agi * 4;
            myCharac.skills.Where(s => s.name == "big guns").FirstOrDefault().            value = 0 + (agi * 2);
            myCharac.skills.Where(s => s.name == "energy weapons").FirstOrDefault().      value = 0 + (agi * 2);
            myCharac.skills.Where(s => s.name == "unarmed").FirstOrDefault().             value = 30 + 2 * (agi + str);
            myCharac.skills.Where(s => s.name == "melee weapons").FirstOrDefault().       value = 20 + 2 * (agi + str);
            myCharac.skills.Where(s => s.name == "throwing").FirstOrDefault().            value = 0 + 4 * agi;
            myCharac.skills.Where(s => s.name == "first aid").FirstOrDefault().           value = 0 + 2 * (per + end);
            myCharac.skills.Where(s => s.name == "doctor").FirstOrDefault().              value = 5 + (per + inte);
            myCharac.skills.Where(s => s.name == "sneak").FirstOrDefault().               value = 5 + (3 * agi);
            myCharac.skills.Where(s => s.name == "lockpick").FirstOrDefault().            value = 10 + (per + agi);
            myCharac.skills.Where(s => s.name == "steal").FirstOrDefault().               value = 0 + (3 * agi);
            myCharac.skills.Where(s => s.name == "traps").FirstOrDefault().               value = 10 + (per + agi);
            myCharac.skills.Where(s => s.name == "science").FirstOrDefault().             value = 0 + 4 * inte;
            myCharac.skills.Where(s => s.name == "repair").FirstOrDefault().              value = 0 + 3 * inte;
            myCharac.skills.Where(s => s.name == "pilot").FirstOrDefault().               value = 0 + 2 * (agi + per);
            myCharac.skills.Where(s => s.name == "speech").FirstOrDefault().              value = 0 + 5 * cha;
            myCharac.skills.Where(s => s.name == "barter").FirstOrDefault().              value = 0 + 4 * cha;
            myCharac.skills.Where(s => s.name == "gambling").FirstOrDefault().            value = 0 + 5 * lck;
            myCharac.skills.Where(s => s.name == "outdoorsman").FirstOrDefault().         value = 0 + 2 * (end + inte);
            myCharac.skills.Where(s => s.name == "radiation resistance").FirstOrDefault().value = 0;
            myCharac.skills.Where(s => s.name == "poison resistance").FirstOrDefault().   value = 0;
            myCharac.skills.Where(s => s.name == "damage resistance").FirstOrDefault().   value = 0;
            myCharac.skills.Where(s => s.name == "electric resistance").FirstOrDefault(). value = 0;

            logger.Log("Exiting setSkills");

        }

        //TO DO : REWORK THIS
        public override void setBaseAttr(Character myCharac)
        {
            logger.Log("Inside FalloutRules.setBaseAttr");
            Random r = new Random();

            int max = myCharac.spendPoints.Where(s => s.name == "creation points").FirstOrDefault().value;

            for (int i = 0; i < max; i++)
            {
                int j= r.Next(1, myCharac.baseAttr.Count);

                if (myCharac.baseAttr[j].value < myCharac.baseAttr[j].max)
                {
                    logger.Log(String.Format("Accessing baseAttr {0} with current value {1}. Remaining {2} points to use.", myCharac.baseAttr[j].name, myCharac.baseAttr[j].value, max - i));
                    myCharac.baseAttr[j].value += 1;
                }
            }
            logger.Log("Exiting setBaseAttr");
        }

    }
}