using System;

namespace RPG_API.Models.Caracteristic
{
    public class BaseAttributes : ICaracteristic
    {
        public int Max { get; set; }
        public int Value { get; set; }
        public string Name { get; set; }
        private Random r = new Random();

        public BaseAttributes()
        {

        }

        public BaseAttributes(string name, int max)
        {
            Name = name;
            Max = max;
            Value = 0;
        }

        public BaseAttributes(int myMax, int myValue, string myName)
        {
            Max = myMax;
            Value = myValue;
            Name = myName;
        }

        public void Increment()
        {
            if (!(Value >= Max))
            {
                Value++;
            }
        }

        public void Decrement()
        {
            if (!(Value <= 0))
            {
                Value--;
            }
        }

        public bool Validate()
        {
            return (Value <= Max);
        }
    }
}