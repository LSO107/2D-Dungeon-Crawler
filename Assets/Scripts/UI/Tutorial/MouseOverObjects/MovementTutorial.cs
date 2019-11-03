// Lee (1720076)

using UnityEngine;

namespace UI.Tutorial.MouseOverObjects
{
    internal sealed class MovementTutorial : MonoBehaviour
    {
        private TutorialMouseOver m_TutorialMouseOver;

        // Make text area in the inspector larger,
        // as it is much easier to work with
        //
        [TextArea(10, 10)]
        public string Message;

        private void Start()
        {
            m_TutorialMouseOver = FindObjectOfType<TutorialMouseOver>();
        }

        // Display the message when player is within collider
        private void OnTriggerStay2D(Collider2D other)
        {
            m_TutorialMouseOver.TutorialMessage.Message.text = Message;
            m_TutorialMouseOver.TutorialMessage.CanvasGroup.alpha = 1;
        }

        // If it is the player that has left the collider,
        // hide the UI and destroy this gameObject with the collider
        // as we only want the message to be displayed once at the start
        //
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                m_TutorialMouseOver.TutorialMessage.CanvasGroup.alpha = 0;
                Destroy(gameObject);
            }
        }
    }
}
