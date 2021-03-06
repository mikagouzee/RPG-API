﻿namespace RPG_API.Models.Caracteristic
{
    public class Spendpoints : ICaracteristic
    {
        public int Max { get; set; }
        public int Value { get; set; }
        public string Name { get; set; }

        public Spendpoints()
        {
        }

        public Spendpoints(string name, int max)
        {
            Name = name;
            Max = max;
            Value = 0;
        }

        public Spendpoints(string myName, int myMax, int myValue)
        {
            Max = myMax;
            Value = myValue;
            Name = myName;
        }

        public void Increment()
        {
            if (!(this.Value >= this.Max))
            {
                this.Value++;
            }
        }

        public void Decrement()
        {
            if (!(this.Value <= 0))
            {
                this.Value--;
            }
        }

        public bool Validate()
        {
            return (Value <= Max);
        }

    }
}