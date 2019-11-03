// Lee (1720076)
using System.Collections;
using UI;
using UI.Coins;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    internal sealed class PlayerDeath : MonoBehaviour
    {
        [SerializeField]
        private Transform m_RespawnTransform;

        [SerializeField]
        public GoldButton GoldButton;
        [SerializeField]
        private PlayerCoins m_PlayerCoins;
        [SerializeField]
        private Text m_PlayerGoldText;

        [SerializeField]
        private Notification m_Notification;
        [SerializeField]
        private string m_DeathMessage = "Oh dear, you have died!";

        public Color FlashColor = Color.red;
        [SerializeField]
        private int m_AmountOfFlashes = 6;
        [SerializeField]
        private float m_FlashDelay = 0.3f;

        [SerializeField]
        private bool m_PlayerDead;
        [SerializeField]
        private GameObject m_DeathGfx;

        private void Update()
        {
            HandlePlayerDeath();
        }

        /// <summary>
        /// Check if the player is dead, if true,
        /// call all of the methods that are needed when a player dies
        /// </summary>
        public void HandlePlayerDeath()
        {
            IsPlayerDead();

            if (!m_PlayerDead)
                return;

            DeathMessage();
            RespawnPlayer();
            DeathPenalty(500);
            Instantiate(m_DeathGfx, transform.position, transform.rotation);
        }

        /// <summary>
        /// Check if the players health is equal to or less than 0,
        /// if so set playerDead to true
        /// </summary>
        private void IsPlayerDead()
        {
            if (GameManager.instance.PlayerStats.CurrentHealth <= 0)
            {
                m_PlayerDead = true;
            }
        }

        /// <summary>
        /// DisplayNotification is called to display the DeathMessage
        /// </summary>
        private void DeathMessage()
        {
            m_Notification.DisplayNotification(m_DeathMessage);
        }


        /// <summary>
        /// Changes the players transform position to the respawnTransform gameObjects.
        /// Set the players health back to 100, and set playerDead to false"/>
        /// </summary>
        private void RespawnPlayer()
        {
            GameManager.instance.Player.transform.position = m_RespawnTransform.position;
            GameManager.instance.PlayerStats.AddHealth(100);
            m_PlayerDead = false;
        }

        /// <summary>
        /// Removes gold from player coins,
        /// displays the gold UI and flashes text to show the loss
        /// </summary>
        private void DeathPenalty(int gold)
        {
            m_PlayerCoins.RemoveGold(gold);
            GoldButton.DisplayGoldQuantity();
            StartCoroutine(TextFlash(m_PlayerGoldText));
        }

        /// <summary>
        /// Switch between the input colour and the text
        /// default colour, with a delay for flash effect.
        /// </summary>
        private IEnumerator TextFlash(Text input)
        {
            var defaultColor = input.color;

            for (var i = 0; i < m_AmountOfFlashes; i++)
            {
                input.color = input.color == defaultColor ? FlashColor : defaultColor;
                yield return new WaitForSeconds(m_FlashDelay);
            }
        }
    }
}
