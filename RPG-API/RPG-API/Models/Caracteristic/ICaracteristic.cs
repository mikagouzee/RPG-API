namespace RPG_API.Models.Caracteristic
{
    public interface ICaracteristic
    {
        int Value { get; set; }
        int Max { get; set; }

        string Name { get; set; }

        void Increment();

        void Decrement();

        bool Validate();
    }
}