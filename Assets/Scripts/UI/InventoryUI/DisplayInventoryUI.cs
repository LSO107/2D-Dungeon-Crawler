// Lee (1720076)
using static Utils.UserInterfaceUtils;
using UI.Coins;
using UnityEngine;

namespace UI.InventoryUI
{
    public class DisplayInventoryUI : MonoBehaviour
    {
        private bool m_IsShown;
        [SerializeField]
        private PlayerCoins m_PlayerCoins;
        private CanvasGroup m_CanvasGroup;

        private void Start()
        {
            m_CanvasGroup = GetComponent<CanvasGroup>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                ToggleInventoryUI();
            }
        }

        public void ToggleInventoryUI()
        {
            m_IsShown = !m_IsShown;
            ToggleCanvasGroup(m_CanvasGroup, m_IsShown);
            m_PlayerCoins.UpdateGold();
        }
    }
}
