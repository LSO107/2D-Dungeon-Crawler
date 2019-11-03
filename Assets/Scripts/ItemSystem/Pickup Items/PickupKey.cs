// Lee (1720076)

using ItemSystem.Keys;
using UnityEngine;

namespace ItemSystem.Pickup_Items
{
    internal sealed class PickupKey : MonoBehaviour
    {
        private BoxCollider2D m_Collider;

        private void Start()
        {
            m_Collider = GetComponent<BoxCollider2D>();
        }

        // Add key to players inventory if collided with key
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (m_Collider.CompareTag("Silver Key"))
            {
                GameManager.instance.Player.PlayerInventory.AddItem(new SilverKey());
            }
            else if (m_Collider.CompareTag("Gold Key"))
            {
                GameManager.instance.Player.PlayerInventory.AddItem(new GoldKey());
            }

            Destroy(gameObject);
        }
    }
}