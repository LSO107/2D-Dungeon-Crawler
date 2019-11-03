// Lee (1720076)
using System.Collections.Generic;
using ItemSystem.Definitions;

namespace ItemSystem.EquippableItems.Swords
{
    internal sealed class IronSword : Equipment
    {
        private static string iconPath = "ItemIcons/Equipment/Swords/Sword1";
        private const string ItemName = "Iron Sword";
        private const EquipmentSlotId Slot = EquipmentSlotId.Weapon;
        private static readonly IReadOnlyDictionary<PlayerStat, int> Bonuses = new Dictionary<PlayerStat, int>
        {
            { PlayerStat.Attack, 5 },
            { PlayerStat.Defence, 0 }
        };

        public IronSword()
            : base(ItemName,
                iconPath,
                Slot,
                Bonuses)
        { }
    }
}
