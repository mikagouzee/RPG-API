using RPG_API.Models.Caracteristic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_API.Models.Careers
{
    public interface ICareer
    {
        string name { get; set; }
        List<Skills> jobSkills { get; set; }
        //IGame game { get; set; }
    }
}
