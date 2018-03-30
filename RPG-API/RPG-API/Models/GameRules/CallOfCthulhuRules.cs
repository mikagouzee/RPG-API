﻿using RPG_API.Models.Caracteristic;
using RPG_API.Utils;
using System;
using System.Linq;

namespace RPG_API.Models.GameRules
{
    public class CallOfCthulhuRules : GameRule
    {
        private Logger logger = new Logger();

        //EMPTY CONSTRUCTOR
        public CallOfCthulhuRules()
        {
        }

        public override void SetStats(Character myCharac)
        {
            #region before

            //Stats prestance = new Stats("prestance", 90, mon_perso.baseAttr.Where(b => b.name == "appearance").FirstOrDefault().value * 5);
            //Stats endurance = new Stats("endurance", 90, mon_perso.baseAttr.Where(b => b.name == "constitution").FirstOrDefault().value * 5);
            //Stats agility = new Stats("agility", 90, mon_perso.baseAttr.Where(b => b.name == "dexterity").FirstOrDefault().value * 5);
            //Stats brawlpower = new Stats("brawl power", 90, mon_perso.baseAttr.Where(b => b.name == "strength").FirstOrDefault().value * 5);
            //Stats height = new Stats("height", 90, mon_perso.baseAttr.Where(b => b.name == "size").FirstOrDefault().value * 5);
            //Stats knowledge = new Stats("knowledge", 120, mon_perso.baseAttr.Where(b => b.name == "education").FirstOrDefault().value * 5);
            //Stats idea = new Stats("idea", 90, mon_perso.baseAttr.Where(b => b.name == "intelligence").FirstOrDefault().value * 5);
            //Stats willpower = new Stats("will power", 90, mon_perso.baseAttr.Where(b => b.name == "power").FirstOrDefault().value * 5);
            //Stats sanity = new Stats("sanity", 90, mon_perso.baseAttr.Where(b => b.name == "power").FirstOrDefault().value * 5);

            //if (!(myCharac.game is CallOfCthulhu))
            //{
            //    return;
            //}

            #endregion before

            logger.Log("Inside CoCrules setStats");

            try
            {
                myCharac.Stats.Where(s => s.Name == "prestance").FirstOrDefault().Value = myCharac.BaseAttr.Where(b => b.Name == "appearance").FirstOrDefault().Value * 5;
                myCharac.Stats.Where(s => s.Name == "endurance").FirstOrDefault().Value = myCharac.BaseAttr.Where(b => b.Name == "constitution").FirstOrDefault().Value * 5;
                myCharac.Stats.Where(s => s.Name == "agility").FirstOrDefault().Value = myCharac.BaseAttr.Where(b => b.Name == "dexterity").FirstOrDefault().Value * 5;
                myCharac.Stats.Where(s => s.Name == "brawl power").FirstOrDefault().Value = myCharac.BaseAttr.Where(b => b.Name == "strength").FirstOrDefault().Value * 5;
                myCharac.Stats.Where(s => s.Name == "height").FirstOrDefault().Value = myCharac.BaseAttr.Where(b => b.Name == "size").FirstOrDefault().Value * 5;
                myCharac.Stats.Where(s => s.Name == "knowledge").FirstOrDefault().Value = myCharac.BaseAttr.Where(b => b.Name == "education").FirstOrDefault().Value * 5;
                myCharac.Stats.Where(s => s.Name == "idea").FirstOrDefault().Value = myCharac.BaseAttr.Where(b => b.Name == "intelligence").FirstOrDefault().Value * 5;
                myCharac.Stats.Where(s => s.Name == "will power").FirstOrDefault().Value = myCharac.BaseAttr.Where(b => b.Name == "power").FirstOrDefault().Value * 5;
                myCharac.Stats.Where(s => s.Name == "sanity").FirstOrDefault().Value = myCharac.BaseAttr.Where(b => b.Name == "power").FirstOrDefault().Value * 5;
            }
            catch (Exception ex)
            {
                logger.Log(String.Format("Error in cocRules.setStats : {0}", ex.Message));
                throw ex;
            }
        }

        public override void SetSpendablePoints(Character myCharac)
        {
            #region before

            //spendpoints healthPoints = new spendpoints("health points", 18, (
            //    (mon_perso.baseAttr.Where(b => b.name == "constitution").FirstOrDefault().value
            //    )
            //    +
            //    (mon_perso.baseAttr.Where(b => b.name == "size").FirstOrDefault().value)
            //    ) / 2
            //    );
            //spendpoints woundLimit = new spendpoints("wound limit", 9);
            //spendpoints magicPoints = new spendpoints("magic points", 18);
            //spendpoints occupationSkillPoints = new spendpoints("Occupation skill points", 480);
            //spendpoints personalInterestSkillPoints = new spendpoints("Personal interest skill points", 180);

            //if (!(myCharac.game is CallOfCthulhu))
            //{
            //    return;
            //}

            #endregion before

            logger.Log("Inside CocRules setSpendablePoints");
            try
            {
                myCharac.SpendPoints.Where(s => s.Name == "health points").FirstOrDefault().Value =
                    (myCharac.BaseAttr.Where(b => b.Name == "constitution").FirstOrDefault().Value +
                    myCharac.BaseAttr.Where(b => b.Name == "size").FirstOrDefault().Value)
                    / 2;

                myCharac.SpendPoints.Where(s => s.Name == "wound limit").FirstOrDefault().Value = myCharac.SpendPoints.Where(s => s.Name == "health points").FirstOrDefault().Value / 2;
                myCharac.SpendPoints.Where(s => s.Name == "magic points").FirstOrDefault().Value = myCharac.BaseAttr.Where(b => b.Name == "power").FirstOrDefault().Value;
                myCharac.SpendPoints.Where(s => s.Name == "Occupation skill points").FirstOrDefault().Value = myCharac.BaseAttr.Where(b => b.Name == "education").FirstOrDefault().Value * 20;
                myCharac.SpendPoints.Where(s => s.Name == "Personal interest skill points").FirstOrDefault().Value = myCharac.BaseAttr.Where(b => b.Name == "intelligence").FirstOrDefault().Value * 10;
            }
            catch (Exception ex)
            {
                logger.Log(String.Format("Error in cocRules.setSpendablePoints : {0}", ex.Message));
                throw ex;
            }
        }

        public override void SetBaseAttr(Character myCharac)
        {
            logger.Log("Inside CoCRules.setBaseAttr");

            Random r = new Random();
            try
            {
                foreach (BaseAttributes batr in myCharac.BaseAttr)
                {
                    batr.Value = r.Next(3, batr.Max + 1);

                    if (batr.Name == "size" || batr.Name == "intelligence" || batr.Name == "education")
                        batr.Value += 6;
                }
            }
            catch (Exception ex)
            {
                logger.Log(String.Format("Error in setBaseAttr : {0}", ex.Message));
                throw ex;
            }
        }

        public override void SetSkills(Character myCharac)
        {
            //basic skills value are set in the game's definition

            //to do : log "skill set"
            logger.Log("Inside CoCRules.setSkills : nothing to do");
            
        }

        public override void SetCareerSkills(Character myCharac)
        {
            logger.Log("Inside CoCRules.setCareerSkills : nothing to do");
        }
    }
}