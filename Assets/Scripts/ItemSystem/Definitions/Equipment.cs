// Lee (1720076)
using System.Collections.Generic;

namespace ItemSystem.Definitions
{
    /// <summary>
    /// An <see cref="Item"/> which can be equipped by the player
    /// </summary>
    public abstract class Equipment : Item
    {
        /// <summary>
        /// Denotes the slot that this equipment item
        /// can be equipped in
        /// <see cref="EquipmentSlotId"/>
        /// </summary>
        public EquipmentSlotId SlotId;

        /// <summary>
        /// Dictionary of stat bonuses that this item provides,
        /// which are uniquely identified by the <see cref="EquipmentSlotId"/>
        /// </summary>
        public IReadOnlyDictionary<PlayerStat, int> StatBonuses;

        protected Equipment(string name,
                            string iconPath,
                            EquipmentSlotId slotId,
                            IReadOnlyDictionary<PlayerStat, int> bonuses)
            : base(name, iconPath)
        {
            SlotId = slotId;
            StatBonuses = bonuses;
        }
    }

    // Give the equipment slots an 'id' to refer to
    public enum EquipmentSlotId
    {
        Head = 0,
        Torso = 1,
        Legs = 2,
        Weapon = 3,
        Shield = 4,
        Gloves = 5,
        Boots = 6,
        Amulet = 7,
        Ring1 = 8,
        Ring2 = 9,
        Cape = 10,
        Bracelet = 11
    }
}
