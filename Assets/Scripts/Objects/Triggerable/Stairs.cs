// Lee (1720076)
using UnityEngine;

namespace Objects.Triggerable
{
    internal sealed class Stairs : TriggerableObject
    {
        // gameObject we supply via Unity Inspector,
        // we get the transform information so we can
        // teleport to this location
        [SerializeField]
        private Transform m_TeleportToTransform;

        // We must have a TriggerInteraction method to declare
        // it as a TriggerableObject, even if it does not do anything
        public override void TriggerInteraction()
        {
        }

        // Check that it is the player colliding with the stairs
        // if it is, change transform to the transform of the
        // gameObject we have given (teleportToTransform)
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                other.transform.position = m_TeleportToTransform.transform.position;
            }
        }
    }
}
