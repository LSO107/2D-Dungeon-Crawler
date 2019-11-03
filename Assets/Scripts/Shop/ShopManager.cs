// Lee (1720076)

using ItemSystem.Inventory;
using UI.Coins;
using UnityEngine;
using UnityEngine.UI;

namespace Shop
{
    internal sealed class ShopManager : MonoBehaviour
    {
        [SerializeField]
        private CanvasGroup m_ShopUI;
        [SerializeField]
        private CanvasGroup m_ShopButtons;
        [SerializeField]
        private CanvasGroup m_ShopDialogue;

        private bool m_IsShopOpen;

        private static void ToggleCanvasGroup(CanvasGroup canvasGroup, bool isActive)
        {
            canvasGroup.alpha = isActive ? 1 : 0;
            canvasGroup.blocksRaycasts = isActive;
            canvasGroup.interactable = isActive;
        }

        private void CloseDialogue()
        {
            m_ShopDialogue.alpha = 0;
            m_ShopDialogue.blocksRaycasts = false;
            m_ShopDialogue.interactable = false;
        }

        public void OpenShop()
        {
            ToggleCanvasGroup(m_ShopUI, true);
            ToggleCanvasGroup(m_ShopButtons, false);
            CloseDialogue();
        }

        public void CloseShop()
        {
            ToggleCanvasGroup(m_ShopUI, false);
            ToggleCanvasGroup(m_ShopButtons, false);
            CloseDialogue();
        }
    }
}
