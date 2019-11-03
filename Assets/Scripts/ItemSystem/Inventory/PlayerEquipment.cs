// Lee (1720076)

using System;
using System.Collections.Generic;
using ItemSystem.Definitions;

namespace ItemSystem.Inventory
{
    internal sealed class PlayerEquipment
    {
        private readonly Dictionary<EquipmentSlotId, Equipment> m_EquipmentSlots;

        public PlayerEquipment()
        {
            m_EquipmentSlots = new Dictionary<EquipmentSlotId, Equipment>
            {
                { EquipmentSlotId.Head, null },
                { EquipmentSlotId.Torso, null },
                { EquipmentSlotId.Legs, null },
                { EquipmentSlotId.Weapon, null },
                { EquipmentSlotId.Shield, null },
                { EquipmentSlotId.Gloves, null },
                { EquipmentSlotId.Boots, null },
                { EquipmentSlotId.Amulet, null },
                { EquipmentSlotId.Ring1, null },
                { EquipmentSlotId.Ring2, null },
                { EquipmentSlotId.Cape, null },
                { EquipmentSlotId.Bracelet, null }
            };
        }

        /// <summary>
        /// Equip the <see cref="Item"/> in the corresponding equipment slot
        /// </summary>
        public void Equip(Equipment item)
        {
            m_EquipmentSlots[item.SlotId] = item;
            GameManager.instance.EquipmentUI.UpdateLabels();
        }

        /// <summary> Sets the <see cref="EquipmentSlot"/> in the corresponding equipment
        /// slot to null, unequipping the item
        /// </summary>
        public void Unequip(EquipmentSlotId slotId)
        {
            m_EquipmentSlots[slotId] = null;
            GameManager.instance.EquipmentUI.UpdateLabels();
        }

        /// <summary>
        /// Get the <see cref="Equipment"/> in the slot
        /// </summary>
        public Equipment GetEquipmentInSlot(EquipmentSlotId slotId)
        {
            return m_EquipmentSlots[slotId];
        }

        /// <summary>
        /// Adds all the item bonuses of the equipped items
        /// into a new dictionary
        /// </summary>
        /// <remarks>Always contains an entry for each available stat</remarks>
        public Dictionary<PlayerStat, int> GetEquipmentStatBonuses()
        {
            var dictionary = new Dictionary<PlayerStat, int>();
            foreach(var value in Enum.GetValues(typeof(PlayerStat)))
            {
                dictionary.Add((PlayerStat)value, 0);
            }
            foreach (var equipmentSlot in m_EquipmentSlots)
            {
                var itemDictionary = equipmentSlot.Value?.StatBonuses;

                if (itemDictionary == null)
                    continue;

                foreach (var entry in itemDictionary)
                {
                    if (dictionary.ContainsKey(entry.Key))
                    {
                        dictionary[entry.Key] += entry.Value;
                    }
                    else
                    {
                        dictionary.Add(entry.Key, entry.Value);
                    }
                }
            }

            return dictionary;
        }
    }
}
