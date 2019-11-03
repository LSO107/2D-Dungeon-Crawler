// Lee (1720076)

using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class Notification : MonoBehaviour
    {
        [SerializeField]
        private GameObject m_IncompleteBox;
        [SerializeField]
        private Text m_NotificationText;

        /// <summary>
        /// Open notification UI, display GameObject's notification message.
        /// close UI after 3 seconds
        /// </summary>
        public void DisplayNotification(string notification)
        {
            OpenNotification();
            m_NotificationText.text = $"{notification}";
            Invoke(nameof(CloseNotification), 3);
        }

        /// <summary>
        /// Activate notification gameObject
        /// </summary>
        private void OpenNotification()
        {
            m_IncompleteBox.SetActive(true);
        }

        /// <summary>
        /// Disable notification gameObject
        /// </summary>
        private void CloseNotification()
        {
            m_IncompleteBox.SetActive(false);
        }


    }
}

