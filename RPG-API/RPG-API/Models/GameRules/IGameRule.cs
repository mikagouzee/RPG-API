using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_API.Models.GameRules
{
    public interface IGameRule
    {
        void setStats(Character myCharac);
        void setSpendablePoints(Character myCharac);
        void setSkills(Character myCharac);
        void setBaseAttr(Character myCharac);
    }
}
