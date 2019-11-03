using UnityEngine;
using UnityEngine.UI;

namespace UI.ToolTip
{
    internal sealed class ConsumableTip : MonoBehaviour
    {
        public TooltipManager TooltipManager;

        public Text ItemName;
        public Text ItemDescription;
 
        public string Name;
        public string Description;
        public int Value;

        private void OnMouseOver()
        {
            TooltipManager.OpenTooltip();
            UpdateText();
        }

        private void OnMouseExit()
        {
            TooltipManager.CloseTooltip();
        }

        private void UpdateText()
        {
            ItemName.text = Name;
            ItemDescription.text = $"{Description}";
        }
    }
}
