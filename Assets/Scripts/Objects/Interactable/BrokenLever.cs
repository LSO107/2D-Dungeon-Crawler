// Lee (1720076)
using UI;
using UnityEngine;

namespace Objects.Interactable
{
    internal sealed class BrokenLever : InteractableObject
    {
        [SerializeField]
        private Notification m_Notification;
        [SerializeField]
        private string m_NotificationText = "This lever is broken.";

        private void OnMouseDown()
        {
            if (!IsPlayerInRange())
                return;

            Interact();
        }

        public override void Interact()
        {
            m_Notification.DisplayNotification(m_NotificationText);
        }
    }
}
