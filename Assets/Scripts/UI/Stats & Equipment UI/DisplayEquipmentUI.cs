// Lee (1720076)
using UnityEngine;

namespace UI
{
    public class DisplayEquipmentUI : MonoBehaviour
    {
        private bool m_IsShown;

        public void ToggleEquipmentUI()
        {
            m_IsShown = !m_IsShown;
            var canvasGroup = GetComponent<CanvasGroup>();
            canvasGroup.alpha = m_IsShown ? 1 : 0;
            canvasGroup.blocksRaycasts = m_IsShown;
            canvasGroup.interactable = m_IsShown;
        }
    }
}
