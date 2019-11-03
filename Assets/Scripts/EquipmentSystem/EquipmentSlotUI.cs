// Lee (1720076)
using ItemSystem.Definitions;
using UnityEngine;
using UnityEngine.UI;

namespace EquipmentSystem
{
    internal sealed class EquipmentSlotUI : MonoBehaviour
    {
        private Item ItemDefinition;
        public Image spriteImage;

        public Sprite DefaultIcon;

        public EquipmentSlotId SlotId;

        private void Awake()
        {
            spriteImage = GetComponent<Image>();
            UpdateItemSprite(null);
        }

        /// <summary>
        /// Updates the placeholder sprite to the itemDefinition sprite
        /// </summary>
        public void UpdateItemSprite(Equipment item)
        {
            spriteImage.sprite = item != null ? item.Sprite : DefaultIcon;
        }
    }
}