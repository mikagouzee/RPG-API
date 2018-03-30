using RPG_API.Models.Caracteristic;
using RPG_API.Models.Careers;
using RPG_API.Models.GameRules;
using System.Collections.Generic;

namespace RPG_API.Models.Games
{
    public class CallOfCthulhu : Game
    {
        public CallOfCthulhu()
        {
            this.Name = "Call Of Cthulhu";
            this.BaseAttributes = new List<BaseAttributes>();
            this.Stats = new List<Stats>();
            this.Skills = new List<Skills>();
            this.SpendPoints = new List<Spendpoints>();

            this.professions = new List<Profession>();

            this.rules = new CallOfCthulhuRules();

            //GAME BASE ATTRIBUTES

            #region baseAttributes

            BaseAttributes appearance = new BaseAttributes("appearance", 18);
            BaseAttributes constitution = new BaseAttributes("constitution", 18);
            BaseAttributes strength = new BaseAttributes("strength", 18);
            BaseAttributes dexterity = new BaseAttributes("dexterity", 18);
            BaseAttributes power = new BaseAttributes("power", 18);
            BaseAttributes size = new BaseAttributes("size", 18);
            BaseAttributes intelligence = new BaseAttributes("intelligence", 18);
            BaseAttributes education = new BaseAttributes("education", 24);

            this.BaseAttributes.Add(appearance);
            this.BaseAttributes.Add(constitution);
            this.BaseAttributes.Add(strength);
            this.BaseAttributes.Add(dexterity);
            this.BaseAttributes.Add(power);
            this.BaseAttributes.Add(size);
            this.BaseAttributes.Add(intelligence);
            this.BaseAttributes.Add(education);

            #endregion baseAttributes

            //GAME STATS

            #region game stats

            Stats prestance = new Stats("prestance", 90);
            Stats endurance = new Stats("endurance", 90);
            Stats agility = new Stats("agility", 90);
            Stats brawlpower = new Stats("brawl power", 90);
            Stats height = new Stats("height", 90);
            Stats knowledge = new Stats("knowledge", 120);
            Stats idea = new Stats("idea", 90);
            Stats willpower = new Stats("will power", 90);
            Stats sanity = new Stats("sanity", 90);

            this.Stats.Add(prestance);
            this.Stats.Add(endurance);
            this.Stats.Add(agility);
            this.Stats.Add(brawlpower);
            this.Stats.Add(height);
            this.Stats.Add(knowledge);
            this.Stats.Add(idea);
            this.Stats.Add(willpower);
            this.Stats.Add(sanity);

            #endregion game stats

            //Game Spendable points

            #region spendable points

            Spendpoints healthPoints = new Spendpoints("health points", 18);
            Spendpoints woundLimit = new Spendpoints("wound limit", 9);
            Spendpoints magicPoints = new Spendpoints("magic points", 18);
            Spendpoints occupationSkillPoints = new Spendpoints("Occupation skill points", 480);
            Spendpoints personalInterestSkillPoints = new Spendpoints("Personal interest skill points", 180);

            this.SpendPoints.Add(healthPoints);
            this.SpendPoints.Add(woundLimit);
            this.SpendPoints.Add(magicPoints);
            this.SpendPoints.Add(occupationSkillPoints);
            this.SpendPoints.Add(personalInterestSkillPoints);

            #endregion spendable points

            //GAME SKILLS

            #region gameSkills

            Skills art = new Skills("art", 100, 5);
            Skills artisanat = new Skills("artisanat", 100, 5);
            Skills baratin = new Skills("baratin", 100, 5);
            Skills bibliotheque = new Skills("bibliotheque", 100, 5);
            Skills comptabilite = new Skills("comptabilite", 100, 10);
            Skills concocterPotion = new Skills("concocter potion", 100, 1);
            Skills conduireAttelage = new Skills("conduire attelage", 100, 20);
            Skills coupDePied = new Skills("coup de pied", 100, 25);
            Skills coupDePoing = new Skills("coup de poing", 100, 50);
            Skills coupDeTete = new Skills("coup de tete", 100, 10);
            Skills discretion = new Skills("discretion", 100, 10);
            Skills dissimulation = new Skills("dissimulation", 100, 15);
            Skills ecouter = new Skills("ecouter", 100, 25);
            Skills ecrireUneLangue = new Skills("ecrire une langue", 100, 1);
            Skills esquiver = new Skills("esquiver", 100, 5);
            Skills grimper = new Skills("grimper", 100, 40);
            Skills lancer = new Skills("lancer", 100, 25);
            Skills langueEtrangere = new Skills("langue etrangere", 100, 1);
            Skills langueNatale = new Skills("langue natale", 100, 5);
            Skills lutte = new Skills("lutte", 100, 25);
            Skills marchandage = new Skills("marchandage", 100, 5);
            Skills mondeNaturel = new Skills("monde naturel", 100, 10);
            Skills monterACheval = new Skills("monter a cheval", 100, 5);
            Skills mytheDeCthulhu = new Skills("mythe de Cthulhu", 100, 0);
            Skills nager = new Skills("nager", 100, 25);
            Skills navigation = new Skills("navigation", 100, 10);
            Skills occultisme = new Skills("occultisme", 100, 5);
            Skills persuasion = new Skills("persuasion", 100, 15);
            Skills piloterBateau = new Skills("piloter bateau", 100, 1);
            Skills premiersSoins = new Skills("premiers soins", 100, 30);
            Skills reparerConcevoir = new Skills("reparer concevoir", 100, 20);
            Skills royaumeNatal = new Skills("royaume natal", 100, 20);
            Skills royaumesEtrangers = new Skills("royaumes etrangers", 100, 1);
            Skills sagacite = new Skills("sagacite", 100, 5);
            Skills sauter = new Skills("sauter", 100, 25);
            Skills science = new Skills("science", 100, 1);
            Skills se_cacher = new Skills("se cacher", 100, 10);
            Skills statut = new Skills("statut", 100, 15);
            Skills suivrePiste = new Skills("suivre une piste", 100, 10);
            Skills trouverObjetCache = new Skills("trouver objet cache", 100, 25);

            this.Skills.Add(art);
            this.Skills.Add(artisanat);
            this.Skills.Add(baratin);
            this.Skills.Add(bibliotheque);
            this.Skills.Add(comptabilite);
            this.Skills.Add(concocterPotion);
            this.Skills.Add(conduireAttelage);
            this.Skills.Add(coupDePied);
            this.Skills.Add(coupDePoing);
            this.Skills.Add(coupDeTete);
            this.Skills.Add(discretion);
            this.Skills.Add(dissimulation);
            this.Skills.Add(ecouter);
            this.Skills.Add(ecrireUneLangue);
            this.Skills.Add(esquiver);
            this.Skills.Add(grimper);
            this.Skills.Add(lancer);
            this.Skills.Add(langueEtrangere);
            this.Skills.Add(langueNatale);
            this.Skills.Add(lutte);
            this.Skills.Add(marchandage);
            this.Skills.Add(mondeNaturel);
            this.Skills.Add(monterACheval);
            this.Skills.Add(mytheDeCthulhu);
            this.Skills.Add(nager);
            this.Skills.Add(navigation);
            this.Skills.Add(occultisme);
            this.Skills.Add(persuasion);
            this.Skills.Add(piloterBateau);
            this.Skills.Add(premiersSoins);
            this.Skills.Add(reparerConcevoir);
            this.Skills.Add(royaumeNatal);
            this.Skills.Add(royaumesEtrangers);
            this.Skills.Add(sagacite);
            this.Skills.Add(sauter);
            this.Skills.Add(science);
            this.Skills.Add(se_cacher);
            this.Skills.Add(statut);
            this.Skills.Add(suivrePiste);
            this.Skills.Add(trouverObjetCache);

            #endregion gameSkills

            //GAME CAREERS

            #region game careers

            Profession artisan = new Profession("artisan");
            artisan.jobSkills.Add(baratin);
            artisan.jobSkills.Add(marchandage);
            artisan.jobSkills.Add(mondeNaturel);
            artisan.jobSkills.Add(royaumeNatal);
            artisan.jobSkills.Add(sagacite);
            artisan.jobSkills.Add(statut);
            this.professions.Add(artisan);

            Profession clerc = new Profession("clerc");
            clerc.jobSkills.Add(bibliotheque);
            clerc.jobSkills.Add(langueEtrangere);
            clerc.jobSkills.Add(persuasion);
            clerc.jobSkills.Add(royaumeNatal);
            clerc.jobSkills.Add(statut);
            clerc.jobSkills.Add(ecrireUneLangue);
            this.professions.Add(clerc);

            Profession ermite = new Profession("ermite");
            ermite.jobSkills.Add(mondeNaturel);
            ermite.jobSkills.Add(occultisme);
            ermite.jobSkills.Add(persuasion);
            ermite.jobSkills.Add(sagacite);
            ermite.jobSkills.Add(sagacite);
            ermite.jobSkills.Add(se_cacher);
            ermite.jobSkills.Add(trouverObjetCache);
            ermite.jobSkills.Add(ecouter);
            this.professions.Add(ermite);

            Profession erudit = new Profession("erudit");
            erudit.jobSkills.Add(bibliotheque);
            erudit.jobSkills.Add(ecrireUneLangue);
            erudit.jobSkills.Add(persuasion);
            erudit.jobSkills.Add(royaumeNatal);
            erudit.jobSkills.Add(science);
            erudit.jobSkills.Add(statut);
            this.professions.Add(erudit);

            Profession fermier = new Profession("fermier");
            fermier.jobSkills.Add(artisanat);
            fermier.jobSkills.Add(conduireAttelage);
            fermier.jobSkills.Add(ecouter);
            fermier.jobSkills.Add(marchandage);
            fermier.jobSkills.Add(mondeNaturel);
            fermier.jobSkills.Add(suivrePiste);
            this.professions.Add(fermier);

            Profession forestier = new Profession("forestier");
            forestier.jobSkills.Add(artisanat);
            forestier.jobSkills.Add(lancer);
            forestier.jobSkills.Add(mondeNaturel);
            forestier.jobSkills.Add(nager);
            forestier.jobSkills.Add(discretion);
            forestier.jobSkills.Add(navigation);
            forestier.jobSkills.Add(piloterBateau);
            forestier.jobSkills.Add(suivrePiste);
            forestier.jobSkills.Add(trouverObjetCache);
            forestier.jobSkills.Add(ecouter);
            this.professions.Add(forestier);

            Profession garde = new Profession("garde");
            garde.jobSkills.Add(coupDePoing);
            garde.jobSkills.Add(coupDePied);
            garde.jobSkills.Add(coupDeTete);
            garde.jobSkills.Add(lutte);
            garde.jobSkills.Add(discretion);
            garde.jobSkills.Add(lancer);
            garde.jobSkills.Add(royaumeNatal);
            garde.jobSkills.Add(statut);
            garde.jobSkills.Add(trouverObjetCache);
            garde.jobSkills.Add(ecouter);
            this.professions.Add(garde);

            Profession guerisseur = new Profession("guerisseur");
            guerisseur.jobSkills.Add(concocterPotion);
            guerisseur.jobSkills.Add(mondeNaturel);
            guerisseur.jobSkills.Add(occultisme);
            guerisseur.jobSkills.Add(premiersSoins);
            guerisseur.jobSkills.Add(sagacite);
            guerisseur.jobSkills.Add(trouverObjetCache);
            guerisseur.jobSkills.Add(ecouter);
            this.professions.Add(guerisseur);

            Profession marchand = new Profession("marchand");
            marchand.jobSkills.Add(baratin);
            marchand.jobSkills.Add(conduireAttelage);
            marchand.jobSkills.Add(langueEtrangere);
            marchand.jobSkills.Add(marchandage);
            marchand.jobSkills.Add(navigation);
            marchand.jobSkills.Add(royaumeNatal);
            marchand.jobSkills.Add(sagacite);
            this.professions.Add(marchand);

            Profession menestrel = new Profession("menestrel");
            menestrel.jobSkills.Add(art);
            menestrel.jobSkills.Add(baratin);
            menestrel.jobSkills.Add(marchandage);
            menestrel.jobSkills.Add(persuasion);
            menestrel.jobSkills.Add(royaumeNatal);
            menestrel.jobSkills.Add(sagacite);
            this.professions.Add(menestrel);

            Profession marin = new Profession("marin");
            marin.jobSkills.Add(baratin);
            marin.jobSkills.Add(grimper);
            marin.jobSkills.Add(mondeNaturel);
            marin.jobSkills.Add(navigation);
            marin.jobSkills.Add(piloterBateau);
            marin.jobSkills.Add(royaumesEtrangers);
            this.professions.Add(marin);

            Profession mendiant = new Profession("mendiant");
            mendiant.jobSkills.Add(baratin);
            mendiant.jobSkills.Add(dissimulation);
            mendiant.jobSkills.Add(marchandage);
            mendiant.jobSkills.Add(sagacite);
            mendiant.jobSkills.Add(ecouter);
            mendiant.jobSkills.Add(trouverObjetCache);
            this.professions.Add(mendiant);

            Profession moine = new Profession("moine");
            moine.jobSkills.Add(art);
            moine.jobSkills.Add(bibliotheque);
            moine.jobSkills.Add(ecouter);
            moine.jobSkills.Add(ecrireUneLangue);
            moine.jobSkills.Add(langueEtrangere);
            moine.jobSkills.Add(occultisme);
            this.professions.Add(moine);

            Profession negociant = new Profession("negociant");
            negociant.jobSkills.Add(baratin);
            negociant.jobSkills.Add(comptabilite);
            negociant.jobSkills.Add(ecrireUneLangue);
            negociant.jobSkills.Add(langueEtrangere);
            negociant.jobSkills.Add(marchandage);
            negociant.jobSkills.Add(royaumesEtrangers);
            negociant.jobSkills.Add(royaumeNatal);
            this.professions.Add(negociant);

            Profession pelerin = new Profession("pelerin");
            pelerin.jobSkills.Add(discretion);
            pelerin.jobSkills.Add(marchandage);
            pelerin.jobSkills.Add(mondeNaturel);
            pelerin.jobSkills.Add(navigation);
            pelerin.jobSkills.Add(royaumeNatal);
            this.professions.Add(pelerin);

            Profession pretre = new Profession("pretre");
            pretre.jobSkills.Add(baratin);
            pretre.jobSkills.Add(langueEtrangere);
            pretre.jobSkills.Add(occultisme);
            pretre.jobSkills.Add(persuasion);
            pretre.jobSkills.Add(sagacite);
            pretre.jobSkills.Add(statut);
            this.professions.Add(pretre);

            Profession sergent = new Profession("sergent");
            sergent.jobSkills.Add(baratin);
            sergent.jobSkills.Add(discretion);
            sergent.jobSkills.Add(marchandage);
            sergent.jobSkills.Add(sagacite);
            sergent.jobSkills.Add(statut);
            sergent.jobSkills.Add(trouverObjetCache);
            this.professions.Add(sergent);

            Profession serviteur = new Profession("serviteur");
            serviteur.jobSkills.Add(artisanat);
            serviteur.jobSkills.Add(baratin);
            serviteur.jobSkills.Add(discretion);
            serviteur.jobSkills.Add(dissimulation);
            serviteur.jobSkills.Add(ecouter);
            serviteur.jobSkills.Add(trouverObjetCache);
            this.professions.Add(serviteur);

            #endregion game careers
        }

     }
}