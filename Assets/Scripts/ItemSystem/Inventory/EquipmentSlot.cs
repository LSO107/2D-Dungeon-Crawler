// Lee (1720076)
using ItemSystem.Definitions;

namespace ItemSystem.Inventory
{
    internal sealed class EquipmentSlot
    {
        public EquipmentSlotId SlotId;

        public Equipment Equipment;

        public EquipmentSlot(EquipmentSlotId slotId,
                             Equipment equipment)
        {
            SlotId = slotId;
            Equipment = equipment;
        }
    }
}
