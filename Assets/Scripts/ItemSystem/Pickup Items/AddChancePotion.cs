// Lee (1720076)

using ItemSystem.Consumables;
using UnityEngine;

namespace ItemSystem.Pickup_Items
{
    internal sealed class AddChancePotion : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            Destroy(gameObject);
            GameManager.instance.Player.PlayerInventory.AddItem(new ChancePotion());
        }
    }
}