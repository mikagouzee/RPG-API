using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RPG_API.Models.Caracteristic
{
    public class Skills : ICaracteristic
    {
        public int max { get; set; }
        public int value { get; set; }
        public string name { get; set; }


        public Skills()
        {

        }

        public Skills(string name, int max)
        {
            this.name = name;
            this.max = max;
            this.value = 0;
        }

        public Skills(string myName, int myMax, int myValue)
        {
            this.max = myMax;
            this.value = myValue;
            this.name = myName;
        }

        public void Increment()
        {

        }

        public void Decrement()
        {

        }

        public int Increment(int skillPoint)
        {
            if (!(this.value >= this.max))
            {
                this.value++;
                skillPoint--;
            }
            return skillPoint;
        }

        public int Decrement(int skillPoint)
        {
            if (!(this.value <= 0))
            {
                this.value--;
                skillPoint++;
            }
            return skillPoint;
        }

    }
}