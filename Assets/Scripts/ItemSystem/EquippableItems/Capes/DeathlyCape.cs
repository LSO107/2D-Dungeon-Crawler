// Lee (1720076)
using System.Collections.Generic;
using ItemSystem.Definitions;

namespace ItemSystem.EquippableItems.Capes
{
    internal sealed class DeathlyCape : Equipment
    {
        private static string iconPath = "ItemIcons/Equipment/Capes/Cape7";
        private const string ItemName = "Deathly Cape";
        private const EquipmentSlotId Slot = EquipmentSlotId.Cape;
        private static readonly IReadOnlyDictionary<PlayerStat, int> Bonuses = new Dictionary<PlayerStat, int>
        {
            { PlayerStat.Attack, 10 },
            { PlayerStat.Defence, 12 }
        };

        public DeathlyCape()
            : base(ItemName,
                iconPath,
                Slot,
                Bonuses)
        { }
    }
}