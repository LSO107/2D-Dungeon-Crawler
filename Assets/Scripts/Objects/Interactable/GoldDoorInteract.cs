// Lee (1720076)
using ItemSystem.Inventory;
using ItemSystem.Keys;
using Player;
using UI;
using UnityEngine;

namespace Objects.Interactable
{
    internal sealed class GoldDoorInteract : InteractableObject
    {
        private SpriteRenderer m_SpriteRenderer;
        private BoxCollider2D m_Collider;
        public PlayerController PlayerController;
        private PlayerInventory m_Inventory;
        private AudioSource m_OpenDoorAudio;

        [SerializeField]
        private Notification m_Notification;
        [SerializeField]
        private string m_NotificationText = "You require a gold key to open this door.";


        private void Start()
        {
            m_SpriteRenderer = GetComponent<SpriteRenderer>();
            m_Collider = GetComponent<BoxCollider2D>();
            m_OpenDoorAudio = GetComponent<AudioSource>();
        }

        private void OnMouseDown()
        {
            if (!IsPlayerInRange())
                return;
            
            Interact();
        }

        // If there is a SilverKey in the inventory,
        // open door and toggle the collider isTrigger for movement
        // Delete the key from the inventory afterwards
        public override void Interact()
        {
            m_Inventory = PlayerController.PlayerInventory;
            if (!m_Inventory.HasItem(typeof(GoldKey)))
            {
                m_Notification.DisplayNotification(m_NotificationText);
                return;
            }

            m_OpenDoorAudio.Play();
            m_SpriteRenderer.sprite = Sprite2;
            m_Collider.isTrigger = true;
            m_Inventory.RemoveItem(typeof(GoldKey));
        }
    }
}
