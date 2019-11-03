// Lee (1720076)
using ItemSystem.Definitions;
using UnityEngine;
using UnityEngine.UI;

namespace UI.InventoryUI
{
    internal sealed class InventorySlotUI : MonoBehaviour
    {
        private Item ItemDefinition;
        private Image spriteImage;

        private void Awake()
        {
            spriteImage = GetComponent<Image>();
            UpdateItemSprite(null);
        }

        /// <summary>
        /// Updates the placeholder sprite to the itemDefinition sprite
        /// </summary>
        public void UpdateItemSprite(Item itemDefinition)
        {
            ItemDefinition = itemDefinition;

            if (ItemDefinition != null)
            {
                spriteImage.color = Color.white;
                spriteImage.sprite = ItemDefinition.Sprite;
            }
            else
            {
                spriteImage.color = Color.clear;
            }
        }
    }
}
