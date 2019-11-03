// Lee (1720076)

using UI.Tutorial.HighlightUI;
using UnityEngine;

namespace UI.Tutorial.MouseOverObjects
{
    internal sealed class TutorialMouseOver : MonoBehaviour
    {
        public TutorialMessage TutorialMessage;
        private HighlightManager m_HighlightManager;

        [TextArea(15, 20)]
        public string Message;

        private void Start()
        {
            TutorialMessage = FindObjectOfType<TutorialMessage>();
            m_HighlightManager = FindObjectOfType<HighlightManager>();
        }

        // When the mouse is over the object,
        // display the UI and text input
        //
        private void OnMouseOver()
        {
            if (m_HighlightManager.TutorialActive)
                return;

            TutorialMessage.CanvasGroup.alpha = 1;
            TutorialMessage.Message.text = Message;
        }

        // When the mouse is no longer over the object,
        // hide the UI
        //
        private void OnMouseExit()
        {
            TutorialMessage.CanvasGroup.alpha = 0;
        }
    }
}
