// Lee (1720076)
using UI.Coins;
using UnityEngine;

namespace Objects.Interactable
{
    internal sealed class LootChestInteract : InteractableObject
    {
        [SerializeField]
        private PlayerCoins playerCoins;
        [SerializeField]
        private int coinsInChest;
        private SpriteRenderer spriteRenderer;
        private bool isChestOpen;
        private bool chestLooted;

        private void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        // If object has been clicked, and player is in range
        // call Interact();
        private void OnMouseDown()
        {
            if (!IsPlayerInRange())
                return;

            Interact();
        }

        // Check isChestOpen, if true, do nothing.
        // If false, set chest sprite to opened chest and isChestOpen to true
        // Add 500 coins to the players inventory gold pouch
        public override void Interact()
        {
            if (isChestOpen)
                return;

            spriteRenderer.sprite = Sprite2;
            LootChest();
            isChestOpen = true;
            // Need to switch sprite to empty chest once chest has been searched/looted.
        }

        /// <summary>
        /// Add gold to the PlayerCoins. Set chestLooted to true,
        /// and reset the coinsInChest to 0
        /// </summary>
        private void LootChest()
        {
            if (chestLooted)
                return;

            playerCoins.AddGold(coinsInChest);
            chestLooted = true;
            coinsInChest = 0;
        }
    }
}
