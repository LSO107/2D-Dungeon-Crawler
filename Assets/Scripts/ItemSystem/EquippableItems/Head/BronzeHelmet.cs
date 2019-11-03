// Lee (1720076)
using System.Collections.Generic;
using ItemSystem.Definitions;

namespace ItemSystem.EquippableItems.Head
{
    internal sealed class BronzeHelmet : Equipment
    {
        private static string iconPath = "ItemIcons/Equipment/Head/Head1";
        private const string ItemName = "Bronze Helmet";
        private const EquipmentSlotId Slot = EquipmentSlotId.Head;
        private static readonly IReadOnlyDictionary<PlayerStat, int> Bonuses = new Dictionary<PlayerStat, int>
        {
            { PlayerStat.Attack, 0 },
            { PlayerStat.Defence, 3 }
        };

        public BronzeHelmet()
            : base(ItemName,
                iconPath,
                Slot,
                Bonuses)
        { }
    }
}
