// Lee (1720076)

using UnityEngine;

namespace Objects.Triggerable
{
    internal sealed class MetalGate : TriggerableObject
    {
        [SerializeField]
        private Animator m_Animator;
        private BoxCollider2D m_Collider;
        private SpriteRenderer m_SpriteRenderer;
        private bool m_IsOpen;

        private void Start()
        {
            m_Animator = GetComponent<Animator>();
            m_Collider = GetComponent<BoxCollider2D>();
            m_SpriteRenderer = GetComponent<SpriteRenderer>();
            m_Animator.SetBool("isGateOpen", false);
        }

        // If condition is met, play "Close Gate Anim" and set the boolean
        // within the animator and the collider isTrigger to true.
        // Else, we play "Open Gate Anim" and set the boolean and isTrigger to false
        // Toggle sorting order so the player doesn't look like he is walking through
        // the gate sprite at any point
        //
        public override void TriggerInteraction()
        {
            if (!m_IsOpen)
            {
                m_Animator.Play("Open Gate Anim");
                m_Animator.SetBool("isGateOpen", false);
                m_Collider.isTrigger = true;
                m_SpriteRenderer.sortingOrder = 5;
            }
            else
            {
                m_Animator.Play("Close Gate Anim");
                m_Animator.SetBool("isGateOpen", true);
                m_Collider.isTrigger = false;
                m_SpriteRenderer.sortingOrder = 1;
            }

            m_IsOpen = !m_IsOpen;
        }
    }
}
