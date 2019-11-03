// Lee (1720076)
using System;
using System.Collections.Generic;
using System.Linq;
using Exceptions;
using ItemSystem.Definitions;
using UnityEngine;

namespace ItemSystem.Inventory
{
    internal sealed class PlayerInventory
    {
        private readonly InventorySlot[] Slots;
        private const int BackpackSize = 20;

        public PlayerInventory(IEnumerable<Item> items)
        {
            Slots = new InventorySlot[BackpackSize];
            for (var i = 0; i < Slots.Length; i++)
            {
                Slots[i] = new InventorySlot(null, 0);
            }
            var itemArray = items.ToArray();
            for (var i = 0; i < itemArray.Length; i++)
            {
                Slots[i].SetItem(itemArray[i]);
            }
        }

        /// <summary>
        /// Iterates over the inventory to check whether item type exists in any slots
        /// </summary>
        public bool HasItem(Type itemType)
        {
            return Slots.Where(slot => slot.ItemDefinition != null)
                        .Any(slot => slot.ItemDefinition.GetType() == itemType);
        }

        /// <summary>
        /// Iterates over the entire inventory for the type instances,
        /// then adds the item quantity in each slot that exists
        /// </summary>
        public int FindItemAmount(Type itemType)
        {
            return Slots.Where(slot => slot.ItemDefinition.GetType() == itemType)
                        .Sum(slot => slot.ItemQuantity);
        }

        /// <summary>
        /// Adds one of the item to the first empty slot
        /// </summary>
        public void AddItem(Item itemDefinition)
        {
            if (!HasEmptySlots(1))
            {
                throw new InventoryException
                    ("Could not add item to inventory as inventory is full");
            }

            var firstEmptySlot = GetFirstEmptySlot();

            Slots[firstEmptySlot].SetItem(itemDefinition);
            GameManager.instance.InventoryUI.UpdateSlots();
            Debug.Log($"{itemDefinition.Name} was added to the inventory!");
        }

        /// <summary>
        /// Adds X amount of the item to the first empty slot(s)
        /// </summary>
        public void AddItem(Item itemDefinition, int quantity)
        {
            if (!HasEmptySlots(1)) // Issue if item is stackable and the quantity is higher than the amount of slots
                return;

            var firstEmptySlot = GetFirstEmptySlot();

            Slots[firstEmptySlot].SetItem(itemDefinition, quantity);
        }

        /// <summary>
        /// Finds the item ID in the inventory and empties the slot
        /// </summary>
        public void RemoveItem(int slotIndex)
        {
            var slot = Slots[slotIndex];

            if (slot.ItemDefinition == null)
            {
                throw new InventoryException
                    ($"Could not empty slot at index {slotIndex}" +
                     " as it was already empty.");
            }

            slot.Empty();
        }

        /// <summary>
        /// Filters out all the itemDefinitions that are null,
        /// Finds the first <see cref="Item"/> in the remaining slots.
        /// Then we call the Empty method on it
        /// </summary>
        public void RemoveItem(Type itemType)
        {
            var slotsWithItems = Slots.Where(slot => slot.ItemDefinition != null);
            var matchingSlot = slotsWithItems.FirstOrDefault
                    (slot => slot.ItemDefinition.GetType() == itemType);

            if (matchingSlot == null)
            {
                throw new InventoryException
                    ($"Could not remove Item {itemType} as" +
                     " it did not exist inventory.");
            }

            matchingSlot.Empty();
        }

        /// <summary>
        /// Iterates over the inventory to check if there are X amount of slots empty
        /// </summary>
        public bool HasEmptySlots(int amountOfSlots)
        {
            return Slots.Count(slot => slot.ItemDefinition == null) >= amountOfSlots;
        }

        /// <summary>
        /// If there are any empty slots, finds the first one in the inventory
        /// </summary>
        public int GetFirstEmptySlot()
        {
            for (var i = 0; i < Slots.Length; i++)
            {
                if (Slots[i].ItemDefinition == null)
                {
                    return i;
                }
            }

            Debug.Log("No free slots available.");
            return 0;
        }

        /// <summary>
        /// Returns the <see cref="Item"/> in the slot at the given index.
        /// Can return null.
        /// </summary>
        public Item GetItemInSlot(int slotIndex)
        {
            return Slots[slotIndex].ItemDefinition;
        }

        /// <summary>
        /// Use the item in the slot with the given index
        /// </summary>
        public void UseItem(int slotIndex)
        {
            var item = GetItemInSlot(slotIndex);

            var consumable = item as Consumable;
            if (consumable != null)
            {
                consumable.Use();
                RemoveItem(slotIndex);
            }
            else if (item is Equipment)
            {
                GameManager.instance.Player.EquipItem(slotIndex);
            }
        }

        /// <summary>
        /// Find the first slot containing the type
        /// </summary>
        public int FindFirstSlotContainingItem(Type itemType)
        {
            for (var i = 0; i < Slots.Length; i++)
            {
                if (Slots[i].ItemDefinition?.GetType() == itemType)
                {
                    return i;
                }
            }

            return -1;
        }

        public IEnumerable<int> GetItemIndexesOfType<T>() where T : Item
        {
            return Slots.Where(s => s.ItemDefinition is T)
                        .Select((s, i) => i);
        }
    }
}