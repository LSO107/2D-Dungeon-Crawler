// Lee (1720076)

using UnityEngine;
using static Utils.UserInterfaceUtils;

namespace UI.Tutorial.HighlightUI
{
    internal sealed class HighlightManager : MonoBehaviour
    {
        public CanvasGroup TutorialButton;
        public CanvasGroup CancelButton;
        public CanvasGroup NextButton;
        public CanvasGroup FinishButton;

        public CanvasGroup TutorialCanvasGroup;
        public CanvasGroup ButtonPanelCanvasGroup;
        public CanvasGroup MinimapButtonsCanvasGroup;
        public CanvasGroup PlayerUICanvasGroup;

        private bool m_OptionOne;
        private bool m_OptionTwo;
        public bool TutorialActive;

        // Display tutorial UI panel on start
        private void Start()
        {
            ToggleCanvasGroup(TutorialCanvasGroup, true);
            TutorialActive = true;
            Time.timeScale = 0;
        }

        /// <summary>
        /// Begins the tutorial by highlighting the first feature,
        /// then changing the button to "Next"
        /// </summary>
        public void ClickTutorialButton()
        {
            ToggleCanvasGroup(TutorialButton, false);
            ToggleCanvasGroup(NextButton, true);
            ToggleCanvasGroup(MinimapButtonsCanvasGroup, true);
            m_OptionOne = true;
        }

        /// <summary>
        /// Turns all the tutorial UI elements canvas groups alpha to 0
        /// </summary>
        public void ClickCancelButton()
        {
            ToggleCanvasGroup(TutorialCanvasGroup, false);
            TutorialActive = false;
            Time.timeScale = 1;
        }

        /// <summary>
        /// Check which option the user is on, then display/hide
        /// UI elements based on how far they are into the tutorial
        /// </summary>
        public void ClickNextButton()
        {
            if (m_OptionOne)
            {
                ToggleCanvasGroup(ButtonPanelCanvasGroup, true);
                m_OptionOne = false;
                m_OptionTwo = true;
            }
            else if (m_OptionTwo)
            {
                ToggleCanvasGroup(PlayerUICanvasGroup, true);
                ToggleCanvasGroup(NextButton, false);
                ToggleCanvasGroup(FinishButton, true);
            }
        }
    }
}
