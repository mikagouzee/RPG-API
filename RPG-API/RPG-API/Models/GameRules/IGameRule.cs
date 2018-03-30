namespace RPG_API.Models.GameRules
{
    public interface IGameRule
    {
        void SetStats(Character myCharac);

        void SetSpendablePoints(Character myCharac);

        void SetSkills(Character myCharac);

        void SetBaseAttr(Character myCharac);

        void SetCareerSkills(Character myCharac);
    }
}