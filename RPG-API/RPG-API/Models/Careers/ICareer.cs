using RPG_API.Models.Caracteristic;
using System.Collections.Generic;

namespace RPG_API.Models.Careers
{
    public interface ICareer
    {
        string name { get; set; }
        List<Skills> jobSkills { get; set; }
        //IGame game { get; set; }
    }
}