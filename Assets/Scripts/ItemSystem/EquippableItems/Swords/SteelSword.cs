// Lee (1720076)
using System.Collections.Generic;
using ItemSystem.Definitions;

namespace ItemSystem.EquippableItems.Swords
{
    internal sealed class SteelSword : Equipment
    {
        private static string iconPath = "ItemIcons/Equipment/Swords/Sword2";
        private const string ItemName = "Steel Sword";
        private const EquipmentSlotId Slot = EquipmentSlotId.Weapon;
        private static readonly IReadOnlyDictionary<PlayerStat, int> Bonuses = new Dictionary<PlayerStat, int>
        {
            { PlayerStat.Attack, 10 },
            { PlayerStat.Defence, 0 }
        };

        public SteelSword()
            : base(ItemName,
                iconPath,
                Slot,
                Bonuses)
        { }
    }
}
