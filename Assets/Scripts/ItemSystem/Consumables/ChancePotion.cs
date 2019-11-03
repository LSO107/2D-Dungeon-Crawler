// Lee (1720076)
using ItemSystem.Definitions;
using Random = System.Random;

namespace ItemSystem.Consumables
{
    internal sealed class ChancePotion : Consumable
    {
        private const int MinimumHealAmount = -20;
        private const int MaximumHealAmount = 20;

        private static string iconPath = "ItemIcons/Consumables/ChancePotion";
        private const string ItemName = "Chance Potion";
        private const int StackAmount = 5;

        public ChancePotion() 
            : base(ItemName,
                   iconPath,
                   StackAmount)
        {
        }

        public override void Use()
        {
            var rand = new Random();
            var randomNumber = rand.Next(MinimumHealAmount, MaximumHealAmount + 1);
            GameManager.instance.PlayerStats.AddHealth(randomNumber);
        }
    }
}
