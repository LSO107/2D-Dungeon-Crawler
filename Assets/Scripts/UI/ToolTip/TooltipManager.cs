// Lee (1720076)
using UnityEngine;
using Utils;

namespace UI.ToolTip
{
    internal sealed class TooltipManager : MonoBehaviour
    {
        private CanvasGroup m_TooltipCanvasGroup;

        private void Start()
        {
            m_TooltipCanvasGroup = GetComponent<CanvasGroup>();
        }

        public void OpenTooltip()
        {
            UserInterfaceUtils.ToggleCanvasGroup(m_TooltipCanvasGroup, true);
        }

        public void CloseTooltip()
        {
            UserInterfaceUtils.ToggleCanvasGroup(m_TooltipCanvasGroup, false);
        }
    }
}
