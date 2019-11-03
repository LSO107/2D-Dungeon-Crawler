// Lee (1720076)
using Dialogue;
using ItemSystem.Inventory;
using UnityEngine;

namespace AI.NPCs
{
    internal sealed class Sevilla : DialogueDefinition
    {
        private PlayerInventory m_PlayerInventory;
        [SerializeField]
        private CanvasGroup m_ShopButtons;
        [SerializeField]
        private CanvasGroup m_ShopCanvasGroup;

        private bool m_IsShopOpen;
        private bool m_IscanvasOpen;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player"))
                return;

            ToggleDialogueUI();
            SetDialogue(FirstDialogue);
            ToggleCanvas(m_ShopButtons, true);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (!other.CompareTag("Player"))
                return;

            ToggleDialogueUI();
            ToggleCanvas(m_ShopButtons, false);
        }

        private static void ToggleCanvas(CanvasGroup canvasGroup, bool canvasOpen)
        {
            canvasGroup.alpha = canvasOpen ? 1 : 0;
            canvasGroup.blocksRaycasts = canvasOpen;
            canvasGroup.interactable = canvasOpen;
        }
    }
}