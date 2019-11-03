// Lee (1720076)
using ItemSystem.Definitions;

namespace ItemSystem.Consumables
{
    internal sealed class ExperiencePotion : Consumable
    {
        private static string iconPath = "ItemIcons/Consumables/ExperiencePotion";
        private const string ItemName = "Experience Potion";
        private const int ExperienceAmount = 20;
        private const int StackAmount = 5;

        public ExperiencePotion() 
            : base(ItemName,
                   iconPath,
                   StackAmount)
        {
        }

        public override void Use()
        {
            GameManager.instance.PlayerStats.AddExperience(ExperienceAmount);
        }
    }
}
