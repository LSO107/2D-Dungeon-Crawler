// Lee (1720076)
using ItemSystem.Definitions;

namespace ItemSystem.Inventory
{
    internal sealed class InventorySlot
    {
        public Item ItemDefinition { get; private set; }
        public int ItemQuantity { get; private set; }

        public InventorySlot(Item itemDefinition, int itemQuantity)
        {
            ItemDefinition = itemDefinition;
            ItemQuantity = itemQuantity;
        }

        /// <summary>
        /// Sets the slot equal to null, with a quantity of 0
        /// </summary>
        public void Empty()
        {
            ItemDefinition = null;
            ItemQuantity = 0;
        }

        /// <summary>
        /// Sets the quantity equal to the given value
        /// </summary>
        public void SetQuantity(int quantity)
        {
            ItemQuantity = quantity;
        }

        /// <summary>
        /// Sets the inventory slot to the item, with a default quantity of 1
        /// </summary>
        public void SetItem(Item itemDefinition)
        {
            ItemDefinition = itemDefinition;
            ItemQuantity = 1;
        }

        /// <summary>
        /// Sets the inventory slot to the item, with the quantity
        /// </summary>
        public void SetItem(Item itemDefinition, int quantity)
        {
            ItemDefinition = itemDefinition;
            ItemQuantity = quantity;
        }
    }
}