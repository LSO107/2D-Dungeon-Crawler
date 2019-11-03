// Lee (1720076)

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ItemSystem.Definitions;
using ItemSystem.Inventory;
using Player;
using UI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using PlayerStat = ItemSystem.Definitions.PlayerStat;

namespace EquipmentSystem
{
    internal sealed class EquipmentUI : MonoBehaviour
    {
        private Item m_Item;
        public PlayerController Player;
        private PlayerInventory m_Inventory;
        private DisplayEquipmentUI m_EquipmentUI;

        public Text PlayerStatsLabel;
        public Text PlayerEquipmentLabel;

        private PlayerEquipment m_PlayerEquipment;
        public Dictionary<EquipmentSlotId, Equipment> CurrentEquipmentSlots;

        public List<EquipmentSlotUI> EquipmentSlots = new List<EquipmentSlotUI>();

        public void Instantiate()
        {
            m_PlayerEquipment = GameManager.instance.Player.PlayerEquipment;
            EquipmentSlots = GetComponentsInChildren<EquipmentSlotUI>().ToList();

            CurrentEquipmentSlots = new Dictionary<EquipmentSlotId, Equipment>
            {
                {EquipmentSlotId.Head, null},
                {EquipmentSlotId.Torso, null},
                {EquipmentSlotId.Legs, null},
                {EquipmentSlotId.Weapon, null},
                {EquipmentSlotId.Shield, null},
                {EquipmentSlotId.Gloves, null},
                {EquipmentSlotId.Boots, null},
                {EquipmentSlotId.Amulet, null},
                {EquipmentSlotId.Ring1, null},
                {EquipmentSlotId.Ring2, null},
                {EquipmentSlotId.Cape, null},
                {EquipmentSlotId.Bracelet, null}
            };

            // Register on click events for each button in our equipment window
            // each button will tell our callback which slot it represents
            // so that the buttons are implementation agnostic.
            //
            foreach (var button in EquipmentSlots)
            {
                var eventTrigger = button.GetComponent<EventTrigger>();
                AddCallbackToButton(eventTrigger, button.SlotId);
            }

            UpdateLabels();
        }

        /// <summary>
        /// Update the slot indexes item placeholder
        /// sprite with the itemDefinition sprite
        /// </summary>
        /// 
        public void UpdateSlot(EquipmentSlotId slot)
        {
            var definition = m_PlayerEquipment.GetEquipmentInSlot(slot);

            var matchingSlot = EquipmentSlots.Single(e => e.SlotId == slot);
            matchingSlot.UpdateItemSprite(definition);
        }

        /// <summary>
        /// Waits for mouse click to trigger an event
        /// </summary>
        /// 
        private void AddCallbackToButton(EventTrigger eventTrigger, EquipmentSlotId slotId)
        {
            var eventEntry = new EventTrigger.Entry
            {
                eventID = EventTriggerType.PointerClick,
            };

            eventEntry.callback.AddListener(eventData => ClickItem(eventData, slotId));

            eventTrigger.triggers.Add(eventEntry);
        }

        /// <summary>
        /// If item clicked, unequip the item then update the slot
        /// </summary>
        /// 
        public void ClickItem(BaseEventData eventData, EquipmentSlotId slotId)
        {
            // Get the equipment item in the slot we've just clicked
            var equipmentItem = m_PlayerEquipment.GetEquipmentInSlot(slotId);
            // If there isn't an item in that slot, return
            if (equipmentItem == null)
                return;

            // Tell the player to unequip the item in that slot
            Player.UnequipItem(slotId);
        }

        /// <summary> Update labels belonging to equipment UI with updated
        ///           player and equipment stats </summary>
        /// 
        public void UpdateLabels()
        {
            var player = GameManager.instance.Player;
            var playerStats = GameManager.instance.PlayerStats;
            var playerEquipment = player.PlayerEquipment;

            var equipmentStats = playerEquipment.GetEquipmentStatBonuses();

            PlayerStatsLabel.text = GetPlayerStatsLabelText(playerStats);
            PlayerEquipmentLabel.text = GetEquipmentStatsLabelText(equipmentStats);
        }

        /// <summary> Generate text for player stats label </summary>
        ///
        private static string GetPlayerStatsLabelText(PlayerStats combatStats)
        {
            return $"Health: {combatStats.CurrentHealth} / {combatStats.MaxHealth}\n" +
                   $"Experience: {combatStats.CurrentExperience} / {combatStats.MaxExperience}";
        }

        /// <summary> Generate text for equipment stats. Receives a
        ///           dictionary of stats and massages them in to a
        ///           single string, separated by new lines </summary>
        ///
        private static string GetEquipmentStatsLabelText(IReadOnlyDictionary<PlayerStat, int> stats)
        {
            var stringBuilder = new StringBuilder();
            foreach (PlayerStat stat in Enum.GetValues(typeof(PlayerStat)))
            {
                stringBuilder.Append($"{stat}: {stats[stat]}\n");
            }

            return stringBuilder.ToString();
        }
    }
}