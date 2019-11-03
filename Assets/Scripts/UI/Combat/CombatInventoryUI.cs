// Lee (1720076)

using System;
using System.Collections.Generic;
using System.Linq;
using Combat;
using ItemSystem.Definitions;
using ItemSystem.Inventory;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI.Combat
{
    internal sealed class CombatInventoryUI : MonoBehaviour
    {
        private PlayerInventory m_PlayerInventory;

        private Dictionary<Type, int> Items;
        
        [SerializeField]
        private GameObject m_UseItemPrefab;

        [SerializeField]
        private List<GameObject> m_ItemButtons;

        public void Initialize()
        {
            m_PlayerInventory = GameManager.instance.PlayerInventory;

            var consumableItemIndexes = m_PlayerInventory.GetItemIndexesOfType<Consumable>()
                                                         .ToArray();

            var itemDefinitions = consumableItemIndexes.Select
                (i => m_PlayerInventory.GetItemInSlot(i));

            var groups = itemDefinitions.GroupBy(i => i.GetType());

            Items = groups.ToDictionary(group => group.Key, group => group.Count());

            GenerateButtons();
        }

        /// <summary>
        /// Waits for mouse click to trigger an event
        /// </summary>
        private void AddCallbackToButton(EventTrigger eventTrigger, Type itemType)
        {
            var eventEntry = new EventTrigger.Entry
            {
                eventID = EventTriggerType.PointerClick,
            };

            eventEntry.callback.AddListener(eventData => UseItem(itemType));

            eventTrigger.triggers.Add(eventEntry);
        }

        /// <summary>
        /// Finds the first slot containing <see cref="Item"/> and uses it,
        /// then destroys the item.
        /// </summary>
        private void UseItem(Type item)
        {
            var index = m_PlayerInventory.FindFirstSlotContainingItem(item);

            if (index == -1)
                return;

            m_PlayerInventory.UseItem(index);

            Items[item]--;
            if (Items[item] == 0)
            {
                Items.Remove(item);
            }

            foreach (var b in m_ItemButtons)
            {
                Destroy(b);
            }

            BattleManager.instance.UpdateUIBars();
            BattleManager.instance.InvokeEnemyAttack();
            GenerateButtons();
        }

        /// <summary>
        /// Regenerates the buttons so we get updated count on inventory items
        /// </summary>
        private void GenerateButtons()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                var dictionaryEntry = Items.ElementAt(i);
                // Instantiate the prefab
                var useItemButton = Instantiate(m_UseItemPrefab);
                // Set it to be a child of the combat inventory ui
                useItemButton.transform.SetParent(transform, false);
                // Readjust its position 
                var buttonRect = useItemButton.GetComponent<RectTransform>();
                var anchor = buttonRect.anchoredPosition;

                buttonRect.anchoredPosition = new Vector2(anchor.x, anchor.y -= 40 * i);
                // Set the text of the button to be the key, plus the count
                var useItemText = useItemButton.GetComponentInChildren<Text>();
                // ie $"{group.Key} {group.Count()}"
                useItemText.text = $"{dictionaryEntry.Key.Name} {dictionaryEntry.Value}";
                // Set callback
                AddCallbackToButton(useItemButton.GetComponent<EventTrigger>(), dictionaryEntry.Key);

                m_ItemButtons.Add(useItemButton);
            }
        }
    }
}
