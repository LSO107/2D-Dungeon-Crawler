// Lee (1720076)
using System.Collections.Generic;
using ItemSystem.Definitions;

namespace ItemSystem.EquippableItems.Shields
{
    internal sealed class WoodenShield : Equipment
    {
        private static string iconPath = "ItemIcons/Equipment/Shields/Shield1";
        private const string ItemName = "Wooden Shield";
        private const EquipmentSlotId Slot = EquipmentSlotId.Shield;
        private static readonly IReadOnlyDictionary<PlayerStat, int> Bonuses = new Dictionary<PlayerStat, int>
        {
            { PlayerStat.Attack, 1 },
            { PlayerStat.Defence, 1 }
        };

        public WoodenShield()
            : base(ItemName,
                iconPath,
                Slot,
                Bonuses)
        { }
    }
}