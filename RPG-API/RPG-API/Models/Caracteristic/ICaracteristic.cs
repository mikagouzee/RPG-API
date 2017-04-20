using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_API.Models.Caracteristic
{
    public interface ICaracteristic
    {
        int value { get; set; }
        int max { get; set; }

        string name { get; set; }

        void Increment();
        void Decrement();
    }
}
