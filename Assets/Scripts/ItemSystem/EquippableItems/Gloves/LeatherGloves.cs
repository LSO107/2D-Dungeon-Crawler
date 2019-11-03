// Lee (1720076)
using System.Collections.Generic;
using ItemSystem.Definitions;

namespace ItemSystem.EquippableItems.Gloves
{
    internal sealed class LeatherGloves : Equipment
    {
        private static string iconPath = "ItemIcons/Equipment/Gloves/Gloves1";
        private const string ItemName = "Leather Gloves";
        private const EquipmentSlotId slot = EquipmentSlotId.Gloves;
        private static readonly IReadOnlyDictionary<PlayerStat, int> Bonuses = new Dictionary<PlayerStat, int>
        {
            { PlayerStat.Attack, 2 },
            { PlayerStat.Defence, 5 }
        };

        public LeatherGloves()
            : base(ItemName,
                   iconPath,
                   slot,
                   Bonuses)
        {}
    }
}
