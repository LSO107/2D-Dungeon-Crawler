// Lee (1720076)
using UnityEngine;

namespace Objects.Interactable
{
    internal sealed class EmptyChestInteract : InteractableObject
    {
        private SpriteRenderer spriteRenderer;
        private bool isChestOpen;

        private void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        // If object has been clicked, and player is in range
        // call Interact();
        private void OnMouseDown()
        {
            if (!IsPlayerInRange()) return;
            Interact();
        }

        // Check isChestOpen, if true, do nothing.
        // If false, set chest sprite to opened chest and isChestOpen to true
        public override void Interact()
        {
            if (isChestOpen)
                return;

            spriteRenderer.sprite = Sprite2;
            isChestOpen = true;
        }
    }
}
