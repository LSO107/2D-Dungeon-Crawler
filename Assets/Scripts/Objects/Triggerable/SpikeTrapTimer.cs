// Lee (1720076)

using UnityEngine;

namespace Objects.Triggerable
{
    internal sealed class SpikeTrapTimer : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer m_SpriteRenderer;
        [SerializeField]
        private Sprite m_ActiveTrap;
        [SerializeField]
        private Sprite m_InactiveTrap;
        [SerializeField]
        private float m_TimeTillChange;
        [SerializeField]
        private int m_DamageInflicted;
        [SerializeField]
        private bool m_IsTrapActive;

        private float m_Timer;

        // Set 'active' traps to the active trap sprite
        private void Start()
        {
            m_SpriteRenderer = GetComponent<SpriteRenderer>();

            if (m_IsTrapActive)
            {
                m_SpriteRenderer.sprite = m_ActiveTrap;
            }
        }

        // Start timer
        // If timer is greater than or equal to m_TimeTillChance
        // swap the trap sprite and reset the timer
        private void Update()
        {
            m_Timer += Time.deltaTime;

            if (m_Timer >= m_TimeTillChange)
            {
                SwitchTrap();
                m_Timer = 0f;
            }
        }

        // If trap is active and player is colliding
        // reduce the players health by m_DamageInflicted
        private void OnTriggerStay2D(Collider2D other)
        {
            if (m_IsTrapActive && other.CompareTag("Player"))
            {
                GameManager.instance.PlayerStats.AddHealth(-m_DamageInflicted);
            }
        }

        /// <summary>
        /// Swap the sprite and m_IsTrapActive to the opposite,
        /// so we know whether the trap is active or inactive
        /// </summary>
        private void SwitchTrap()
        {
            if (m_SpriteRenderer.sprite == m_InactiveTrap)
            {
                m_SpriteRenderer.sprite = m_ActiveTrap;
                m_IsTrapActive = true;
            }
            else
            {
                m_SpriteRenderer.sprite = m_InactiveTrap;
                m_IsTrapActive = false;
            }
        }
    }
}
