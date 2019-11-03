// Lee (1720076)
using UnityEngine;

namespace Objects.Interactable
{
    internal sealed class DoorInteract : InteractableObject
    {
        private SpriteRenderer m_SpriteRenderer;
        private BoxCollider2D m_Collider;
        [SerializeField]
        private AudioSource m_OpenDoorAudio;
        [SerializeField]
        private AudioSource m_CloseDoorAudio;
        [SerializeField]
        private bool m_PlayerInDoorSpace;

        private void Start()
        {
            m_SpriteRenderer = GetComponent<SpriteRenderer>();
            m_Collider = GetComponent<BoxCollider2D>();
        }

        private void OnMouseDown()
        {
            if (!IsPlayerInRange())
                return;
            
            Interact();
        }

        // If player is not in the door space, switch the sprite from closed
        // door to open door and toggle the collider isTrigger for movement
        // Play Audio for open or close door
        public override void Interact()
        {
            if (m_PlayerInDoorSpace)
                return;

            if (m_SpriteRenderer.sprite == Sprite1)
            {
                m_SpriteRenderer.sprite = Sprite2;
                m_Collider.isTrigger = true;
                m_OpenDoorAudio.Play();
            }
            else
            {
                m_SpriteRenderer.sprite = Sprite1;
                m_Collider.isTrigger = false;
                m_CloseDoorAudio.Play();
            }
        }

        // Use OnTriggerStay2D as the player collider overlaps with
        // the door collider when the player is pressed up against
        // the door, in which case OnTriggerEnter2D would not fire
        //
        private void OnTriggerStay2D(Collider2D other)
        {
            // If the player is already inside the door space,
            // there's no point in comparing the tag of the collider
            // as we'd only set it to have the same value anyway
            //
            if (m_PlayerInDoorSpace)
                return;

            if (other.transform.CompareTag("Player"))
            {
                m_PlayerInDoorSpace = true;
            }
        }

        // Once the player leaves the collider on the door space
        // set playerInDoorSpace to false so we know the player
        // is not in the area
        //
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.transform.CompareTag("Player"))
            {
                m_PlayerInDoorSpace = false;
            }
        }
    }
}
