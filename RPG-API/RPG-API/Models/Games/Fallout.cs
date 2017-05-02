using RPG_API.Models.Caracteristic;
using RPG_API.Models.Careers;
using RPG_API.Models.GameRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RPG_API.Models.Games
{
    public class Fallout : Game
    {
 
        public Fallout()
        {
            this.name = "Fallout";
            this.BaseAttributes = new List<BaseAttributes>();
            this.Stats = new List<Stats>();
            this.Skills = new List<Skills>();
            this.SpendPoints = new List<spendpoints>();

            this.professions = new List<Profession>();
            this.rules = new FalloutRules();

            //GAME BASE ATTRIBUTES
            #region baseAttributes
            BaseAttributes strength = new BaseAttributes("strength", 10);
            BaseAttributes perception = new BaseAttributes("perception", 10);
            BaseAttributes endurance = new BaseAttributes("endurance", 10);
            BaseAttributes charism = new BaseAttributes("charism", 10);
            BaseAttributes intelligence = new BaseAttributes("intelligence", 10);
            BaseAttributes agility = new BaseAttributes("agility", 10);
            BaseAttributes luck = new BaseAttributes("luck", 10);

            this.BaseAttributes.Add(strength);
            this.BaseAttributes.Add(perception);
            this.BaseAttributes.Add(endurance);
            this.BaseAttributes.Add(charism);
            this.BaseAttributes.Add(intelligence);
            this.BaseAttributes.Add(agility);
            this.BaseAttributes.Add(luck);
            #endregion

            //GAME STATS
            #region game stats
            Stats actionPoints = new Stats("action points", 100);
            Stats karma = new Stats("karma", 100);
            Stats armorClass = new Stats("armor class", 100);
            Stats carryWeight = new Stats("carry weight", 500);
            Stats meleeDamage = new Stats("melee damage", 100);
            Stats sequence = new Stats("sequence", 100);
            Stats healingRate = new Stats("healing rate", 4);

            this.Stats.Add(actionPoints);
            this.Stats.Add(karma);
            this.Stats.Add(armorClass);
            this.Stats.Add(carryWeight);
            this.Stats.Add(meleeDamage);
            this.Stats.Add(sequence);
            this.Stats.Add(healingRate);
            #endregion 

            //Game Spendable points
            #region spendable points
            spendpoints healthPoints = new spendpoints("health points", 100);
            spendpoints woundLimit = new spendpoints("wound limit", 100);
            spendpoints skillPoints = new spendpoints("skill points", 100);
            spendpoints creationPoints = new spendpoints("creation points", 5, 5);

            this.SpendPoints.Add(healthPoints);
            this.SpendPoints.Add(woundLimit);
            this.SpendPoints.Add(skillPoints);
            this.SpendPoints.Add(creationPoints);
            #endregion

            //GAME SKILLS
            #region game skills
            Skills smallGuns       = new Skills("small guns", 100, 25);
            Skills bigGuns         = new Skills("big guns", 100, 10);
            Skills energyWeapons   = new Skills("energy weapons", 100, 10);
            Skills unarmed         = new Skills("unarmed", 100, 50);
            Skills meleeWeapon     = new Skills("melee weapons", 100, 40);
            Skills throwing        = new Skills("throwing", 100, 20);
            Skills firstAid        = new Skills("first aid", 100, 20);
            Skills doctor          = new Skills("doctor", 100, 15);
            Skills sneak           = new Skills("sneak", 100, 20);
            Skills lockpick        = new Skills("lockpick", 100, 20);
            Skills steal           = new Skills("steal", 100, 15);
            Skills traps           = new Skills("traps", 100, 20);
            Skills science         = new Skills("science", 100, 20);
            Skills repair          = new Skills("repair", 100, 15);
            Skills pilot           = new Skills("pilot", 100, 20);
            Skills speech          = new Skills("speech", 100, 35);
            Skills barter          = new Skills("barter", 100, 20);
            Skills gambling        = new Skills("gambling", 100, 25);
            Skills outdoorsman     = new Skills("outdoorsman", 100, 20);
            Skills radiationResist = new Skills("radiation resistance", 100, 0);
            Skills poisonResist    = new Skills("poison resistance", 100, 0);
            Skills damageResist    = new Skills("damage resistance", 100, 0);
            Skills electricResist  = new Skills("electric resistance", 100, 0);

            this.Skills.Add(smallGuns);
            this.Skills.Add(bigGuns);
            this.Skills.Add(energyWeapons);
            this.Skills.Add(unarmed);
            this.Skills.Add(meleeWeapon);
            this.Skills.Add(throwing);
            this.Skills.Add(firstAid);
            this.Skills.Add(doctor);
            this.Skills.Add(sneak);
            this.Skills.Add(lockpick);
            this.Skills.Add(steal);
            this.Skills.Add(traps);
            this.Skills.Add(science);
            this.Skills.Add(repair);
            this.Skills.Add(pilot);
            this.Skills.Add(speech);
            this.Skills.Add(barter);
            this.Skills.Add(gambling);
            this.Skills.Add(outdoorsman);
            this.Skills.Add(radiationResist);
            this.Skills.Add(poisonResist);
            this.Skills.Add(damageResist);
            this.Skills.Add(electricResist);
            #endregion

            //GAME CAREERS
            #region game careers
            Profession fighter = new Profession("fighter");
            fighter.jobSkills.Add(smallGuns);
            fighter.jobSkills.Add(bigGuns);
            fighter.jobSkills.Add(firstAid);
            this.professions.Add(fighter);

            Profession wanderer = new Profession("wanderer");
            wanderer.jobSkills.Add(outdoorsman);
            wanderer.jobSkills.Add(firstAid);
            wanderer.jobSkills.Add(repair);
            this.professions.Add(wanderer);

            Profession merchant = new Profession("merchant");
            merchant.jobSkills.Add(barter);
            merchant.jobSkills.Add(gambling);
            merchant.jobSkills.Add(speech);
            this.professions.Add(merchant);

            Profession mendiant = new Profession("mendiant");
            mendiant.jobSkills.Add(sneak);
            mendiant.jobSkills.Add(barter);
            mendiant.jobSkills.Add(steal);
            this.professions.Add(mendiant);


            #endregion
        }
    }
}