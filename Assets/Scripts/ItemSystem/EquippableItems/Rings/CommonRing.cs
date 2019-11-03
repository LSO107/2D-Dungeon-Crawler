// Lee (1720076)
using System.Collections.Generic;
using ItemSystem.Definitions;

namespace ItemSystem.EquippableItems.Rings
{
    internal sealed class CommonRing : Equipment
    {
        private static string iconPath = "ItemIcons/Equipment/Rings/Ring1";
        private const string ItemName = "Common Ring";
        private const EquipmentSlotId Slot = EquipmentSlotId.Ring1;
        private static readonly IReadOnlyDictionary<PlayerStat, int> Bonuses = new Dictionary<PlayerStat, int>
        {
            { PlayerStat.Attack, 1 },
            { PlayerStat.Defence, 1 }
        };

        public CommonRing()
            : base(ItemName,
                iconPath,
                Slot,
                Bonuses)
        { }
    }
}