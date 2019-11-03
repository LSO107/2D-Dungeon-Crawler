// Lee (1720076)

using Dialogue;
using ItemSystem.EquippableItems.Gloves;
using ItemSystem.EquippableItems.Head;
using ItemSystem.EquippableItems.Pants;
using ItemSystem.EquippableItems.Shields;
using ItemSystem.EquippableItems.Swords;
using ItemSystem.EquippableItems.Torso;
using ItemSystem.Inventory;
using UnityEngine;

namespace AI.NPCs
{
    internal sealed class Saffron : DialogueDefinition
    {
        private PlayerInventory m_PlayerInventory;
        private bool m_ReceivedItems;

        private bool m_SecondDialogue;

        // Display first dialogue and add items to
        // the players inventory. If m_SecondDialogue is 
        // true, set the dialogue to the second message
        //
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player"))
                return;

            ToggleDialogueUI();
            SetDialogue(FirstDialogue);

            if (!m_ReceivedItems)
            {
                m_PlayerInventory = GameManager.instance.PlayerInventory;
                m_PlayerInventory.AddItem(new IronSword());
                m_PlayerInventory.AddItem(new LeatherGloves());
                m_PlayerInventory.AddItem(new BronzeHelmet());
                m_PlayerInventory.AddItem(new LeatherBody());
                m_PlayerInventory.AddItem(new LeatherPants());
                m_PlayerInventory.AddItem(new WoodenShield());
                m_ReceivedItems = true;
            }

            if (m_SecondDialogue)
            {
                SetDialogue(SecondDialogue);
            }
        }

        // Display dialogue,
        // Set m_SecondDialogue to true, so next time we
        // collide, we can play the second dialogue message
        //
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                ToggleDialogueUI();
                m_SecondDialogue = true;
            }
        }
    }
}
