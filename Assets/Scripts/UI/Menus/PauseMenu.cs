// Lee (1720076)
using UnityEngine;

namespace UI.Menus
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField]
        private GameObject m_PausePanel;

        private bool m_IsPaused;

        /// <summary>
        /// Toggle the Pause Menu UI, and the <see cref="Time"/>.timescale between 0 and 1
        /// </summary>
        public void TogglePauseGame()
        {
            if (m_PausePanel.gameObject.activeSelf)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }

        /// <summary>
        /// Turn <see cref="Time"/>.timescale to 0
        /// </summary>
        public void PauseGame()
        {
            m_PausePanel.gameObject.SetActive(true);
            Time.timeScale = 0;
        }

        /// <summary>
        /// Turn <see cref="Time"/>.timescale to 1
        /// </summary>
        public void ResumeGame()
        {
            m_PausePanel.gameObject.SetActive(false);
            Time.timeScale = 1;
        }

        /// <summary>
        /// Quit the game using <see cref="Application"/>
        /// </summary>
        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
