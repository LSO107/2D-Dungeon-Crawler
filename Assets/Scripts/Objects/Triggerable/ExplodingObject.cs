// Lee (1720076)
using RandomOutput;
using UnityEngine;

namespace Objects.Triggerable
{
    internal sealed class ExplodingObject : InteractableObject
    {
        [SerializeField]
        private GameObject m_ExplodingGfx;

        private bool m_Exploded;

        // If player is colliding and m_Exploded is false
        // call Interact()
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player") && !m_Exploded)
            {
                Interact();
            }
        }

        // Change m_Exploded to true so we can
        // prevent the object being exploded more than once
        private void OnTriggerExit2D(Collider2D other)
        {
            if (CompareTag("Player"))
            {
                m_Exploded = false;
            }
        }

        // Instantiate GameObject (Particle System)
        // Deal random damage between 0-20
        // Destroy the gameObject once we are done
        public override void Interact()
        {
            Instantiate(m_ExplodingGfx, transform.position, transform.rotation);
            RandomDamage.DealRandomDamage(-20, 0);
            Destroy(gameObject);
        }
    }
}
