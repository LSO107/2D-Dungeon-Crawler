// Lee (1720076)

using Dialogue;
using ItemSystem.EquippableItems.Swords;
using ItemSystem.Keys;
using UnityEngine;

namespace AI.NPCs
{
    internal sealed class Hans : DialogueDefinition
    {
        [SerializeField]
        private Rigidbody2D m_RigidBody;

        private bool m_ReceivedGoldKey;
        private bool m_ReceivedSteelSword;

        private bool m_FirstDialogue = true;
        private bool m_SecondDialogue;
        private bool m_ThirdDialogue;

        // Prevent NPC from being moved around
        // by the player
        //
        private void Start()
        {
            m_RigidBody = GetComponent<Rigidbody2D>();
            m_RigidBody.constraints = RigidbodyConstraints2D.FreezeAll;
        }

        // If player is colliding, open dialogue and
        // add a gold key to the inventory
        // set the boolean so we can prevent giving more than one
        //
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player"))
                return;

            if (!m_ReceivedGoldKey)
            {
                GameManager.instance.PlayerInventory.AddItem(new GoldKey());
                m_ReceivedGoldKey = true;
            }
            else if (m_ReceivedGoldKey && !m_ReceivedSteelSword)
            {
                GameManager.instance.PlayerInventory.AddItem(new SteelSword());
                m_ReceivedSteelSword = true;
            }

            ToggleDialogueUI();

            if (m_FirstDialogue)
            {
                SetDialogue(FirstDialogue);
            }
            else if (m_SecondDialogue)
            {
                SetDialogue(SecondDialogue);
            }
            else if (m_ThirdDialogue)
            {
                SetDialogue(ThirdDialogue);
            }
        }

        // Close the dialogue on exiting the collider
        //
        private void OnTriggerExit2D(Collider2D other)
        {
            ToggleDialogueUI();

            if (m_FirstDialogue)
            {
                m_FirstDialogue = false;
                m_SecondDialogue = true;
            }
            else if (m_SecondDialogue)
            {
                m_SecondDialogue = false;
                m_ThirdDialogue = true;
            }
        }
    }
}
