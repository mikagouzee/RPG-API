using RPG_API.Models.Caracteristic;
using RPG_API.Models.Careers;
using RPG_API.Models.GameRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_API.Models.Games
{
    public interface IGame
    {
        string name { get; set; }
        List<BaseAttributes> BaseAttributes { get; set; }
        List<Stats> Stats { get; set; }
        List<Skills> Skills { get; set; }
        List<spendpoints> SpendPoints { get; set; }
        List<Profession> professions { get; set; }

        GameRule rules { get; set; }
    }
}
