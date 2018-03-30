using RPG_API.Models.Caracteristic;
using RPG_API.Models.Careers;
using RPG_API.Models.GameRules;
using System.Collections.Generic;

namespace RPG_API.Models.Games
{
    public interface IGame
    {
        string Name { get; set; }
        List<BaseAttributes> BaseAttributes { get; set; }
        List<Stats> Stats { get; set; }
        List<Skills> Skills { get; set; }
        List<Spendpoints> SpendPoints { get; set; }
        List<Profession> professions { get; set; }

        GameRule rules { get; set; }
    }
}