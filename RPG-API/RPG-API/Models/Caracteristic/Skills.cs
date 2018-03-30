namespace RPG_API.Models.Caracteristic
{
    public class Skills : ICaracteristic
    {
        public int Max { get; set; }
        public int Value { get; set; }
        public string Name { get; set; }

        //required to keep track of points spent in the skill
        public int baseValue { get; set; }

        public Skills()
        {
        }

        public Skills(string name, int max)
        {
            Name = name;
            Max = max;
            Value = 0;
            baseValue = 0;
        }

        public Skills(string myName, int myMax, int myValue)
        {
            Max = myMax;
            Value = myValue;
            Name = myName;
            baseValue = myValue;
        }

        public void Increment()
        {
        }

        public void Decrement()
        {
        }

        public int Increment(int skillPoint)
        {
            if (!(this.Value >= this.Max))
            {
                this.Value++;
                skillPoint--;
            }
            return skillPoint;
        }

        public int Decrement(int skillPoint)
        {
            if (!(this.Value <= 0))
            {
                this.Value--;
                skillPoint++;
            }
            return skillPoint;
        }

        public int GetNumberOfPointSpent()
        {
            return this.Value - this.baseValue;
        }

        public bool Validate()
        {
            return (Value <= Max);
        }

        public void SetBasevalue(int val)
        {
            this.baseValue = val;
        }
    }
}