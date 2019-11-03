// Lee (1720076)
using System.Collections.Generic;
using ItemSystem.Definitions;

namespace ItemSystem.EquippableItems.Torso
{
    internal sealed class LeatherBody : Equipment
    {
        private static string iconPath = "ItemIcons/Equipment/Chest/Chest1";
        private const string ItemName = "Leather Body";
        private const EquipmentSlotId Slot = EquipmentSlotId.Torso;
        private static readonly IReadOnlyDictionary<PlayerStat, int> Bonuses = new Dictionary<PlayerStat, int>
        {
            { PlayerStat.Attack, 0 },
            { PlayerStat.Defence, 2 }
        };

        public LeatherBody()
            : base(ItemName,
                iconPath,
                Slot,
                Bonuses)
        { }
    }
}