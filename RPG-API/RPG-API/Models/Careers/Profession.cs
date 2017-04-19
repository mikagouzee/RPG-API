using RPG_API.Models.Caracteristic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RPG_API.Models.Careers
{
    public class Profession : ICareer
    {
        public string name { get; set; }
        public List<Skills> jobSkills { get; set; }
        //public IGame game{ get; set; }

        public Profession(string name)
        {
            this.name = name;
            this.jobSkills = new List<Skills>();
        }
    }
}