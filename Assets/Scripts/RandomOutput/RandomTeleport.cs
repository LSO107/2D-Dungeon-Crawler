// Lee (1720076)
using UnityEngine;

namespace RandomOutput
{
    internal sealed class RandomTeleport : MonoBehaviour
    {
        [SerializeField]
        private Transform[] m_TeleportTransforms;
        [SerializeField]
        private Transform m_PlayerTransform;
        [SerializeField]
        private GameObject m_TeleportGfx;

        private int m_Index;

        // Array of 4 GameObjects containing transforms
        // Get random index of array and set player
        // position to the GameObject transform position
        //
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                m_Index = Random.Range(0, m_TeleportTransforms.Length);
                other.transform.position = m_TeleportTransforms[m_Index].position;
                var effect = Instantiate(m_TeleportGfx, m_PlayerTransform.position, m_PlayerTransform.rotation);
                effect.transform.SetParent(GameManager.instance.Player.transform);
            }
        }
    }
}