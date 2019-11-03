// Lee (1720076)
using System.Collections.Generic;
using ItemSystem.Definitions;

namespace ItemSystem.EquippableItems.Amulet
{
    internal sealed class BrassNecklace : Equipment
    {
        private static string iconPath = "ItemIcons/Equipment/Amulets/Amulet1";
        private const string ItemName = "Brass Necklace";
        private const EquipmentSlotId Slot = EquipmentSlotId.Amulet;
        private static readonly IReadOnlyDictionary<PlayerStat, int> Bonuses = new Dictionary<PlayerStat, int>
        {
            { PlayerStat.Attack, 0 },
            { PlayerStat.Defence, 3 }
        };

        public BrassNecklace()
            : base(ItemName,
                   iconPath,
                   Slot,
                   Bonuses)
        { }
    }
}