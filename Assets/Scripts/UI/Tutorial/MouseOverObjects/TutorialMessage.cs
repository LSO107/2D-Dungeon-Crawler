// Lee (1720076)

using UnityEngine;
using UnityEngine.UI;

namespace UI.Tutorial.MouseOverObjects
{
    internal sealed class TutorialMessage : MonoBehaviour
    {
        public CanvasGroup CanvasGroup;
        public Text Message;
        private bool m_MessageShown;

        /// <summary>
        /// Checks to see if the message is being displayed,
        /// and toggles the canvas group to the opposite
        /// </summary>
        public void ToggleMessage()
        {
            m_MessageShown = !m_MessageShown;
            CanvasGroup.alpha = m_MessageShown ? 1 : 0;
            CanvasGroup.blocksRaycasts = m_MessageShown;
            CanvasGroup.interactable = m_MessageShown;
        }

        /// <summary>
        /// Changes the text component to the text provided
        /// in the inspector window
        /// </summary>
        public void ChangeMessage(string message)
        {
            Message.text = message;
        }
    }
}
