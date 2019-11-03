// Lee (1720076)
using System.Collections.Generic;
using ItemSystem.Consumables;
using ItemSystem.Definitions;
using ItemSystem.EquippableItems.Amulet;
using ItemSystem.EquippableItems.Rings;
using ItemSystem.EquippableItems.Swords;
using ItemSystem.Inventory;
using UnityEngine;

namespace Player
{
    internal sealed class PlayerController : MonoBehaviour
    {
        // Movement variables
        public float Speed = 2f;
        private float m_HorizontalMovement;
        private float m_VerticalMovement;

        private Vector2 m_Direction;
        private Animator m_Animator;
        private Rigidbody2D m_RigidBody;

        // Inventory
        public PlayerInventory PlayerInventory;
        public PlayerEquipment PlayerEquipment;
        public PlayerStats PlayerStats;

        [SerializeField]
        private AudioSource m_EquipItemAudio;
        [SerializeField]
        private AudioSource m_UnequipItemAudio;

        private void Start()
        {
            PlayerStats = GameManager.instance.PlayerStats;

            var inventory = new List<Item>
            {
            };

            PlayerInventory = new PlayerInventory(inventory);
            PlayerEquipment = new PlayerEquipment();

            m_Animator = GetComponent<Animator>();
            m_RigidBody = GetComponent<Rigidbody2D>();

            GameManager.instance.InventoryUI.Instantiate();
            GameManager.instance.EquipmentUI.Instantiate();
        }

        // TODO: Move AddLevel out of update, and call it when
        // TODO: we reach max experience / reset or something
        private void Update()
        {
            if (PlayerStats.ExperienceBar.CurrentValue >= PlayerStats.ExperienceBar.MaxValue)
            {
                PlayerStats.AddLevel();
            }
        }

        private void FixedUpdate()
        { // Call direction and movement
            // Prevent player from moving on Z axis since we are using 2D.
            Direction();
            Move();
            m_RigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
        }

        /// <summary>
        /// Get player input then changes the direction based on which key is down
        /// </summary>
        private void Direction()
        {
            m_Direction = Vector2.zero;

            if (Input.GetKey(KeyCode.D)) // Right
            {
                m_Direction += Vector2.right;
            }
            else if (Input.GetKey(KeyCode.A)) // Left
            {
                m_Direction += Vector2.left;
            }

            else if (Input.GetKey(KeyCode.W)) // Up
            {
                m_Direction += Vector2.up;
            }

            else if (Input.GetKey(KeyCode.S)) // Down
            {
                m_Direction += Vector2.down;
            }

            // If direction X and Y are not equal to 0, use walk animation.
            if (!m_Direction.x.Equals(0) || (!m_Direction.y.Equals(0)))
            {
                AnimateWalk();
            }
            else // Else set Walk Animation to 0 (inactive), so idle animation will be played
            {
                const int idleAnimation = 0;
                m_Animator.SetLayerWeight(1, idleAnimation);
            }
        }

        /// <summary>
        /// Check the players direction, then move the player accordingly using transform.Translate
        /// </summary>
        private void Move()
        {
            if (m_Direction == Vector2.left)
            {
                m_HorizontalMovement = -Speed * Time.deltaTime;
                m_VerticalMovement = 0;
                transform.Translate(m_HorizontalMovement, m_VerticalMovement, 0);
            }
            else if (m_Direction == Vector2.right)
            {
                m_HorizontalMovement = Speed * Time.deltaTime;
                m_VerticalMovement = 0;
                transform.Translate(m_HorizontalMovement, m_VerticalMovement, 0);
            }
            else if (m_Direction == Vector2.down)
            {
                m_VerticalMovement = -Speed * Time.deltaTime;
                m_HorizontalMovement = 0;
                transform.Translate(m_HorizontalMovement, m_VerticalMovement, 0);
            }
            else if (m_Direction == Vector2.up)
            {
                m_VerticalMovement = Speed * Time.deltaTime;
                m_HorizontalMovement = 0;
                transform.Translate(m_HorizontalMovement, m_VerticalMovement, 0);
            }
        }

        /// <summary>
        /// Set Walk Animation weight to 1 (Overrides the idle animation).
        /// Change axis value in Animator to determine direction
        /// </summary>
        private void AnimateWalk()
        {
            const int walkAnimation = 1;
            m_Animator.SetLayerWeight(1, walkAnimation);
            m_Animator.SetFloat("x", m_Direction.x);
            m_Animator.SetFloat("y", m_Direction.y);
        }

        public void EquipItem(int slotIndex)
        {
            m_EquipItemAudio.Play();

            var equipment = PlayerInventory.GetItemInSlot(slotIndex) as Equipment;

            // May have been called by mistake, item in the given slot was not equipment
            if (equipment == null)
                return;

            // Check player's equipment to see if something is in there already
            var item = PlayerEquipment.GetEquipmentInSlot(equipment.SlotId);

            // Set equipment slot to be equal to the thing we're trying to equip
            PlayerEquipment.Equip(equipment);

            PlayerInventory.RemoveItem(slotIndex);

            if (item != null)
            {
                PlayerInventory.AddItem(item);
            }

            GameManager.instance.EquipmentUI.UpdateSlot(equipment.SlotId);
        }

        public void UnequipItem(EquipmentSlotId slotId)
        {
            m_UnequipItemAudio.Play();

            // Get item currently in slot
            var equipment = PlayerEquipment.GetEquipmentInSlot(slotId);

            // If inventory is full, do nothing
            if (!PlayerInventory.HasEmptySlots(1))
                return;

            // Otherwise, set the equipment slot to null
            PlayerEquipment.Unequip(slotId);
            
            // Add the item to the inventory
            PlayerInventory.AddItem(equipment);

            // Finally, update the inventory and equipment's user interface
            GameManager.instance.EquipmentUI.UpdateSlot(equipment.SlotId);
            GameManager.instance.InventoryUI.UpdateSlots();
        }
    }
}
