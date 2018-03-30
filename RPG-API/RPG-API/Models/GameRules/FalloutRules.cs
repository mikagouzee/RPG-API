using RPG_API.Utils;
using System;
using System.Linq;

namespace RPG_API.Models.GameRules
{
    public class FalloutRules : GameRule
    {
        private Logger logger = new Logger();

        //EMPTY CONSTRUCTOR
        public FalloutRules()
        {
        }

        public override void SetStats(Character myCharac)
        {
            logger.Log("Inside FalloutRules.SetStat.");

            myCharac.Stats.FirstOrDefault(s => s.Name == "karma").Value = 0;
            int AP = 0;

            int str = myCharac.BaseAttr.FirstOrDefault(b => b.Name == "strength").Value;
            int endu = myCharac.BaseAttr.FirstOrDefault(b => b.Name == "endurance").Value;
            int agi = (myCharac.BaseAttr.FirstOrDefault(b => b.Name == "agility").Value != 0 ?
                myCharac.BaseAttr.FirstOrDefault(b => b.Name == "agility").Value :
                0);
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
            int MD = 5 + (str - 10);
            int per = myCharac.BaseAttr.FirstOrDefault(b => b.Name == "perception").Value;
            int HR = 0;
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
            myCharac.Stats.FirstOrDefault(s => s.Name == "action points").Value = AP;
            myCharac.Stats.FirstOrDefault(s => s.Name == "armor class").Value = agi;
            myCharac.Stats.FirstOrDefault(s => s.Name == "carry weight").Value = 25 + (25 * str);
            myCharac.Stats.FirstOrDefault(s => s.Name == "melee damage").Value = (MD > 0 ? MD : 1);
            myCharac.Stats.FirstOrDefault(s => s.Name == "sequence").Value = 2 * per;
            myCharac.Stats.FirstOrDefault(s => s.Name == "healing rate").Value = HR;
        }

        public override void SetSpendablePoints(Character myCharac)
        {
            //healthpoints, woundlimit, skillpoints
            logger.Log("Inside FalloutRules.setSpendablePoints");

            int str = myCharac.BaseAttr.FirstOrDefault(b => b.Name == "strength").Value;
            int endu = myCharac.BaseAttr.FirstOrDefault(b => b.Name == "endurance").Value;

            myCharac.SpendPoints.FirstOrDefault(s => s.Name == "health points").Value = 15 + str + (2 * endu);

            myCharac.SpendPoints.FirstOrDefault(s => s.Name == "wound limit").Value = 0;

            myCharac.SpendPoints.FirstOrDefault(s => s.Name == "skill points").Value = 0;

            logger.Log("Exiting setSpendablePoints");
        }

        // Is this needed? we might use "mean value"...
        public override void SetSkills(Character myCharac)
        {
            logger.Log("Inside FalloutRules.setSkills");

            int str = myCharac.BaseAttr.FirstOrDefault(b => b.Name == "strength").Value;
            int per = myCharac.BaseAttr.FirstOrDefault(b => b.Name == "perception").Value;
            int end = myCharac.BaseAttr.FirstOrDefault(b => b.Name == "endurance").Value;
            int cha = myCharac.BaseAttr.FirstOrDefault(b => b.Name == "charism").Value;
            int inte = myCharac.BaseAttr.FirstOrDefault(b => b.Name == "intelligence").Value;
            int agi = myCharac.BaseAttr.FirstOrDefault(b => b.Name == "agility").Value;
            int lck = myCharac.BaseAttr.FirstOrDefault(b => b.Name == "luck").Value;

            myCharac.Skills.FirstOrDefault(s => s.Name == "small guns").Value = 5 + agi * 4;
            myCharac.Skills.FirstOrDefault(s => s.Name == "big guns").Value = 0 + (agi * 2);
            myCharac.Skills.FirstOrDefault(s => s.Name == "energy weapons").Value = 0 + (agi * 2);
            myCharac.Skills.FirstOrDefault(s => s.Name == "unarmed").Value = 30 + 2 * (agi + str);
            myCharac.Skills.FirstOrDefault(s => s.Name == "melee weapons").Value = 20 + 2 * (agi + str);
            myCharac.Skills.FirstOrDefault(s => s.Name == "throwing").Value = 0 + 4 * agi;
            myCharac.Skills.FirstOrDefault(s => s.Name == "first aid").Value = 0 + 2 * (per + end);
            myCharac.Skills.FirstOrDefault(s => s.Name == "doctor").Value = 5 + (per + inte);
            myCharac.Skills.FirstOrDefault(s => s.Name == "sneak").Value = 5 + (3 * agi);
            myCharac.Skills.FirstOrDefault(s => s.Name == "lockpick").Value = 10 + (per + agi);
            myCharac.Skills.FirstOrDefault(s => s.Name == "steal").Value = 0 + (3 * agi);
            myCharac.Skills.FirstOrDefault(s => s.Name == "traps").Value = 10 + (per + agi);
            myCharac.Skills.FirstOrDefault(s => s.Name == "science").Value = 0 + 4 * inte;
            myCharac.Skills.FirstOrDefault(s => s.Name == "repair").Value = 0 + 3 * inte;
            myCharac.Skills.FirstOrDefault(s => s.Name == "pilot").Value = 0 + 2 * (agi + per);
            myCharac.Skills.FirstOrDefault(s => s.Name == "speech").Value = 0 + 5 * cha;
            myCharac.Skills.FirstOrDefault(s => s.Name == "barter").Value = 0 + 4 * cha;
            myCharac.Skills.FirstOrDefault(s => s.Name == "gambling").Value = 0 + 5 * lck;
            myCharac.Skills.FirstOrDefault(s => s.Name == "outdoorsman").Value = 0 + 2 * (end + inte);
            myCharac.Skills.FirstOrDefault(s => s.Name == "radiation resistance").Value = 0;
            myCharac.Skills.FirstOrDefault(s => s.Name == "poison resistance").Value = 0;
            myCharac.Skills.FirstOrDefault(s => s.Name == "damage resistance").Value = 0;
            myCharac.Skills.FirstOrDefault(s => s.Name == "electric resistance").Value = 0;

            logger.Log("Exiting setSkills");
        }

        public override void SetBaseAttr(Character myCharac)
        {
            logger.Log("Inside FalloutRules.setBaseAttr");
            Random r = new Random();

            int max = myCharac.SpendPoints.FirstOrDefault(s => s.Name == "creation points").Value;

            //set minimal value of 1
            foreach (var attr in myCharac.BaseAttr)
            {
                attr.Value = 1;
                max -= 1;
            }

            for (int i = 0; i < max; i++)
            {
                int j = r.Next(1, myCharac.BaseAttr.Count);

                if (myCharac.BaseAttr[j-1].Value < myCharac.BaseAttr[j-1].Max)
                {
                    myCharac.BaseAttr[j-1].Value += 1;
                }
            }
            logger.Log("Exiting setBaseAttr");
        }

        public override void SetCareerSkills(Character myCharac)
        {
            if (!myCharac.Metier.jobSkills.Any())
                return;

            foreach (var jobSkill in myCharac.Metier.jobSkills)
            {
                myCharac.Skills.Find(x => x.Name == jobSkill.Name).Value += 20;
            }

        }

    }
}