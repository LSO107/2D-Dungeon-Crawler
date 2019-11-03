// Lee (1720076)
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Combat
{
    // This script will be placed on all enemies
    internal sealed class StartCombat : MonoBehaviour
    {
        private new BoxCollider2D collider;
        [SerializeField]
        private Image transitionImage;
        [SerializeField]
        private GameObject LoadingImage;
    
        // Place a large collider around the enemies,
        // when the player is within a set range (collider space)
        // we prevent the player from moving before loading the combat scene
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                GameManager.instance.Player.Speed = 0;

                // Make enemy walk over to player
                // Once in range (in front of each other)
                // begin the transition to combat scene

                LoadingSceneTransition();
            }

            SceneManager.LoadScene("Combat Scene"); // Can be accessed via scene index also
        }

        /// <summary>
        /// Toggle whether the gameObject is active or inactive,
        /// as it does not need to be activated at all times
        /// </summary>
        private void ToggleLoadingImage()
        {
            LoadingImage.SetActive(!LoadingImage.activeSelf);
        }

        /// <summary>
        /// Fills an image from 0 - 100% to give a transitioning effect
        /// </summary>
        public void LoadingSceneTransition()
        {
            ToggleLoadingImage();

            while (transitionImage.fillAmount < 1)
            {
                transitionImage.fillAmount += 1f * Time.unscaledDeltaTime;
            }

            ToggleLoadingImage();
        }
    }
}
