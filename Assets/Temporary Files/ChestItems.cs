// Lee (1720076)

using System;
using ItemSystem.Consumables;
using ItemSystem.Definitions;
using ItemSystem.EquippableItems.Amulet;
using ItemSystem.EquippableItems.Capes;
using ItemSystem.EquippableItems.Head;
using ItemSystem.EquippableItems.Rings;
using ItemSystem.EquippableItems.Shields;
using ItemSystem.EquippableItems.Swords;
using Objects;
using UnityEngine;

namespace Temporary_Files
{
    internal sealed class ChestItems : InteractableObject
    {
        private bool m_ChestLooted;
        [SerializeField]
        private int m_AmountOfItems;

        // Add items to player inventory when chest is clicked.
        // Use bool to ensure the player can only receive the items once.
        // It is not ideal to hard code the items for the chest like this,
        // but have not figured out a method to pass in the items via
        // the inspector yet.
        //
        private void OnMouseDown()
        {
            if (!IsPlayerInRange())
                return;

            Interact();
        }

        public override void Interact()
        {
            if (!m_ChestLooted)
            {
                RandomItem(m_AmountOfItems);
                m_ChestLooted = true;
            }
        }

        /// <summary>
        /// Generate random indexes, then call AddItem with them
        /// </summary>
        private void RandomItem(int amountOfItems)
        {
            var rand = new System.Random(DateTime.UtcNow.Millisecond);

            var indexes = new int[amountOfItems];

            for (var i = 0; i < amountOfItems; i++)
            {
                indexes[i] = rand.Next(0, 9);
            }

            for (var i = 0; i < amountOfItems; i++)
            {
                AddItem(indexes[i]);
            }

        }

        /// <summary>
        /// Takes an index, and chooses an item from the array
        /// </summary>
        private void AddItem(int randomItem)
        {
            var inventory = GameManager.instance.PlayerInventory;

            var items = new Item[9];

            items[0] = new HealthPotion();
            items[1] = new ExperiencePotion();
            items[2] = new ChancePotion();
            items[3] = new BrassNecklace();
            items[4] = new CommonRing();
            items[5] = new DeathlyCape();
            items[6] = new WoodenShield();
            items[7] = new BronzeHelmet();
            items[8] = new SteelSword();

            inventory.AddItem(items[randomItem]);
        }
    }
}