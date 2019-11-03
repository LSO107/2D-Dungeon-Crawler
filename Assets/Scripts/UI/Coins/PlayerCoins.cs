// Lee (1720076)
using UnityEngine;
using UnityEngine.UI;

namespace UI.Coins
{
    internal sealed class PlayerCoins : MonoBehaviour
    {
        // Reference to the gold quantity text so we can update it,
        // variable to keep track of the players gold quantity
        public Text GoldQuantityText;
        public int PlayerGoldQuantity { get; set; }

        /// <summary>
        /// Add gold to the current gold quantity,
        /// update gold amount (text) when quantity changes
        /// </summary>
        public void AddGold(int gold)
        {
            PlayerGoldQuantity += gold;
            UpdateGold();
        }

        /// <summary>
        /// Remove gold from the current gold quantity,
        /// if gold quantity goes below 0, set it to 0.
        /// Update gold text.
        /// </summary>
        public void RemoveGold(int gold)
        {
            PlayerGoldQuantity -= gold;

            if (PlayerGoldQuantity < 0)
                PlayerGoldQuantity = 0;

            UpdateGold();
        }

        /// <summary>
        /// Set the Gold Quantity <see cref="Text"/> to the current Gold Quantity
        /// </summary>
        public void UpdateGold()
        {
            GoldQuantityText.text = PlayerGoldQuantity.ToString();
        }
    }
}
