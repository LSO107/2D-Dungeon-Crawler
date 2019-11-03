// Lee (1720076)
using System.Collections.Generic;
using ItemSystem.Definitions;

namespace ItemSystem.EquippableItems.Pants
{
    internal sealed class LeatherPants : Equipment
    {
        private static string iconPath = "ItemIcons/Equipment/Pants/Pants1";
        private const string ItemName = "Leather Pants";
        private const EquipmentSlotId Slot = EquipmentSlotId.Legs;
        private static readonly IReadOnlyDictionary<PlayerStat, int> Bonuses = new Dictionary<PlayerStat, int>
        {
            { PlayerStat.Attack, 0 },
            { PlayerStat.Defence, 2 }
        };

        public LeatherPants()
            : base(ItemName,
                iconPath,
                Slot,
                Bonuses)
        { }
    }
}