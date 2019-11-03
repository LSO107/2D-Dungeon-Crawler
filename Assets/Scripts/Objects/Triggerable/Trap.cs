// Lee (1720076)
using UnityEngine;

namespace Objects.Triggerable
{
    internal sealed class Trap : TriggerableObject
    {
        private SpriteRenderer spriteRenderer;
        private BoxCollider2D col;
        private bool playerOnTrap;

        [SerializeField]
        private bool trapIsActive;
        [SerializeField]
        private Sprite inactiveTrap;
        [SerializeField]
        private Sprite activeTrap;

        // Call isTrapActivated so we can set traps to active/inactive on start
        private void Start ()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            IsTrapActivated();
        }

        // Set the sprite to it's opposite and
        // set the trapIsActive depending on the state
        // so we can tell whether the trap is active or inactive
        public override void TriggerInteraction()
        {
                if (spriteRenderer.sprite == inactiveTrap)
                {
                    spriteRenderer.sprite = activeTrap;
                    trapIsActive = true;
                }
                else
                {
                    spriteRenderer.sprite = inactiveTrap;
                    trapIsActive = false;
                }
        }

        // Check that what is colliding is the player,
        // set playerOnTrap to true if it is.
        // Call BeginDamagingPlayerOverTime as the player is
        // standing on the trap
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.transform.CompareTag("Player"))
            {
                playerOnTrap = true;
            }
            
            BeginDamagingPlayerOverTime(0f, 0.5f);
        }

        // Check that what is colliding is the player,
        // and set playerOnTrap to false if it is.
        // Call StopDamagingPlayerOverTime as the player is no longer 
        // standing on the trap
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.transform.CompareTag("Player"))
            {
                playerOnTrap = false;
            }
            
            StopDamagingPlayerOverTime();
        }

        /// <summary>
        /// Subtract 10 health from the player's lifepoints
        /// </summary>
        private void DamagePlayer()
        {
            GameManager.instance.PlayerStats.AddHealth(-10);
        }

        /// <summary>
        /// If the trap is active and the player is standing on the trap,
        /// call DamagePlayer on a time, and how frequent to repeat the method
        /// </summary>
        public void BeginDamagingPlayerOverTime(float time, float repeatRate)
        {
            if (playerOnTrap && trapIsActive)
            {
                InvokeRepeating(nameof(DamagePlayer), time, repeatRate);
            }
        }
        
        /// <summary>
        /// If the player is not standing on the trap, or the trap is inactive,
        /// stop calling DamagePlayer on repeat
        /// </summary>
        public void StopDamagingPlayerOverTime()
        {
            if (!playerOnTrap || !trapIsActive)
            {
                CancelInvoke(nameof(DamagePlayer));
            }
        }

        /// <summary>
        /// Sets the corrosponding sprite,
        /// depending whether trapIsActive is true or false
        /// </summary>
        private void IsTrapActivated()
        {
            spriteRenderer.sprite = trapIsActive ? activeTrap : inactiveTrap;
        }
    }
}
