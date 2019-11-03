// Lee (1720076)

using UnityEngine;

namespace UI.Combat
{
    internal sealed class BattleUIManager : MonoBehaviour
    {
        public CanvasGroup CombatCanvasGroup;
        public CanvasGroup InventoryCanvasGroup;
        public CanvasGroup StatsCanvasGroup;

        private bool m_CombatUIShown = true;
        private bool m_InventoryUIShown = false;

        /// <summary>
        /// Turn MainUI canvas group alpha to 1,
        /// set Inventory and Stats to 0
        /// </summary>
        public void SwitchToMainUI()
        {
            ToggleCanvasGroup(CombatCanvasGroup, true);
            ToggleCanvasGroup(InventoryCanvasGroup, false);
            ToggleCanvasGroup(StatsCanvasGroup, false);
        }

        /// <summary>
        /// Set InventoryUI canvas group alpha to 1,
        /// set MainUI and Stats to 0
        /// </summary>
        public void SwitchToInventoryUI()
        {
            ToggleCanvasGroup(InventoryCanvasGroup, true);
            ToggleCanvasGroup(CombatCanvasGroup, false);
            ToggleCanvasGroup(StatsCanvasGroup, false);
        }

        /// <summary>
        /// Set StatsUI canvas group alpha to 1,
        /// set MainUI and InventoryUI to 0
        /// </summary>
        public void SwitchToStatsUI()
        {
            ToggleCanvasGroup(StatsCanvasGroup, true);
            ToggleCanvasGroup(CombatCanvasGroup, false);
            ToggleCanvasGroup(InventoryCanvasGroup, false);
        }

        /// <summary>
        /// Toggles the options on a given canvas group
        /// </summary>
        private void ToggleCanvasGroup(CanvasGroup canvasGroup, bool display)
        {
            canvasGroup.alpha = display ? 1 : 0;
            canvasGroup.blocksRaycasts = display;
            canvasGroup.interactable = display;
        }
    }
}
