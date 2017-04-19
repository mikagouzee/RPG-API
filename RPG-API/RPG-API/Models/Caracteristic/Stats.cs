using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RPG_API.Models.Caracteristic
{
    public class Stats : ICaracteristic
    {
        public int max { get; set; }
        public int value { get; set; }
        public string name { get; set; }

        public Stats()
        {

        }

        public Stats(string name, int max)
        {
            this.name = name;
            this.max = max;
            this.value = 0;
        }

        public Stats(string myName, int myMax, int myValue)
        {
            this.max = myMax;
            this.value = myValue;
            this.name = myName;
        }

        public void Increment()
        {
            if (!(this.value >= this.max))
            {
                this.value++;
            }
        }

        public void Decrement()
        {
            if (!(this.value <= 0))
            {
                this.value--;
            }
        }


    }
}