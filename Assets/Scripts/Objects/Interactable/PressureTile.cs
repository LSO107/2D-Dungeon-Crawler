// Lee (1720076)
using UnityEngine;

namespace Objects.Interactable
{
    internal sealed class PressureTile : InteractableObject
    {
        public TriggerableObject Object;
        private SpriteRenderer m_SpriteRenderer;
        private bool m_PlayerStandingOnTile;

        private void Start()
        {
            m_SpriteRenderer = GetComponent<SpriteRenderer>();
        }

        // Switch between two sprites, depending whether the player is 
        // standing on the pressure tile to show when it is inactive/active
        public override void Interact()
        {
            m_SpriteRenderer.sprite = m_PlayerStandingOnTile ? Sprite2 : Sprite1;
        }

        // Check if the player is standing on the tile
        // Call the TriggerInteraction each time we enter the pressure tile
        // Call Interact to change the sprite on the PressureTile
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.transform.CompareTag("Player"))
            {
                m_PlayerStandingOnTile = true;
            }

            Object.TriggerInteraction();
            Interact();
        }

        // Set that the player is not standing on the PressureTile
        // Call Interact to change the sprite again
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.transform.CompareTag("Player"))
            {
                m_PlayerStandingOnTile = false;
            }

            Interact();
        }
    }
}
