// Lee (1720076)
using UnityEngine;
using UnityEngine.UI;

namespace UI.Coins
{
    public class GoldButton : MonoBehaviour
    {
        [SerializeField]
        private PlayerCoins m_PlayerCoins;
        [SerializeField]
        public Text GoldButtonText;
        [SerializeField]
        private GameObject m_GoldBackground;

        // Update every frame, directly from PlayerCoins class
        // so we can get instant updates about whether the gold 
        // has increased or decreased
        private void Update()
        {
            GoldButtonText.text = m_PlayerCoins.PlayerGoldQuantity.ToString();
        }

        /// <summary>
        /// Toggle the background and text layer to display gold quantity
        /// </summary>
        public void ToggleGoldQuantity()
        {
            m_GoldBackground.gameObject.SetActive(!m_GoldBackground.activeSelf);
        }

        /// <summary>
        /// Sets the gameObject to active, displaying the background
        /// and text of the Gold Quantity
        /// </summary>
        public void DisplayGoldQuantity()
        {
            m_GoldBackground.gameObject.SetActive(true);
        }
    }
}
