// Lee (1720076)
using ItemSystem.Definitions;

namespace ItemSystem.Consumables
{
    internal sealed class HealthPotion : Consumable
    {
        private const string IconPath = "ItemIcons/Consumables/HealthPotion";
        private const string ItemName = "Health Potion";
        private const int HealingAmount = 10;
        private const int StackAmount = 5;

        public HealthPotion()
            : base(ItemName,
                   IconPath,
                   StackAmount)
        {}

        public override void Use()
        {
            GameManager.instance.PlayerStats.AddHealth(HealingAmount);
        }
    }
}
