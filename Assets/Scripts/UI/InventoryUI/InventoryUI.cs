// Lee (1720076)
using System.Collections.Generic;
using ItemSystem.Definitions;
using ItemSystem.Inventory;
using Player;
using UI.ToolTip;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI.InventoryUI
{
    internal sealed class InventoryUI : MonoBehaviour
    {
        private Item m_Item;
        public TooltipManager TooltipManager;
        public Text ItemName;
        public Text ItemDescription;
        public PlayerController Player;
        private PlayerInventory m_Inventory;

        public List<InventorySlotUI> ItemUI = new List<InventorySlotUI>();
        public GameObject SlotPrefab;
        public Transform SlotPanel;
        private const int MaxSlots = 20;

        // Fill inventory with slots
        public void Instantiate()
        {
            m_Inventory = GameManager.instance.PlayerInventory;
            for (var i = 0; i < MaxSlots; i++)
            {
                var instance = Instantiate(SlotPrefab);
                instance.transform.SetParent(SlotPanel);
                var inventorySlot = instance.GetComponentInChildren<InventorySlotUI>();
                ItemUI.Add(inventorySlot);

                var eventTrigger = instance.GetComponentInChildren<EventTrigger>();

                AddCallbackToButton(eventTrigger, i);

                UpdateSlot(i);
            }
        }

        /// <summary>
        /// Iterate over inventory slots,
        /// call UpdateItemSprite on every slot
        /// </summary>
        public void UpdateSlots()
        {
            for (var i = 0; i < MaxSlots; i++)
            {
                var definition = m_Inventory.GetItemInSlot(i);

                ItemUI[i].UpdateItemSprite(definition);
            }

        }

        /// <summary>
        /// Update the slot indexes item placeholder
        /// sprite with the itemDefinition sprite
        /// </summary>
        private void UpdateSlot(int slot)
        {
            var definition = m_Inventory.GetItemInSlot(slot);

            ItemUI[slot].UpdateItemSprite(definition);
        }

        /// <summary>
        /// Waits for mouse click to trigger an event
        /// </summary>
        private void AddCallbackToButton(EventTrigger eventTrigger, int index)
        {
            var eventEntry = new EventTrigger.Entry
            {
                eventID = EventTriggerType.PointerClick,
            };

            eventEntry.callback.AddListener(eventData => ClickItem(eventData, index));

            eventTrigger.triggers.Add(eventEntry);
        }

        /// <summary>
        /// If item clicked, use the item then update the slot
        /// </summary>
        public void ClickItem(BaseEventData eventData, int slotIndex)
        {
            m_Inventory.UseItem(slotIndex);
            UpdateSlot(slotIndex);
        }
    }
}
