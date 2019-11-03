// Lee (1720076)
using UnityEngine;

namespace Objects.Interactable
{
    internal sealed class LeverInteract : InteractableObject
    {
        [SerializeField]
        private TriggerableObject m_Object;
        [SerializeField]
        private bool m_LeverActive;

        private AudioSource m_LeverAudioSource;
        private SpriteRenderer m_SpriteRenderer;

        private void Start()
        {
            m_LeverAudioSource = GetComponent<AudioSource>();
            m_SpriteRenderer = GetComponent<SpriteRenderer>();
        }

        // If player is in range of the object and clicks the sprite,
        // interact with this object and trigger the interaction
        private void OnMouseDown()
        {
            if (!IsPlayerInRange())
                return;

            Interact();
        }

        // Call MetalGate TriggerInteraction.
        // Switch sprite of the lever state
        public override void Interact()
        {
            m_LeverAudioSource.Play();
            m_Object.TriggerInteraction();

            if (m_SpriteRenderer.sprite == Sprite1)
            {
                m_SpriteRenderer.sprite = Sprite2;
                m_LeverActive = true;
            }
            else
            {
                m_SpriteRenderer.sprite = Sprite1;
                m_LeverActive = false;
            }
        }
    }
}