// Lee (1720076)
using UnityEngine;

namespace Objects
{
    // These fields that are all shared across the objects that can be interacted with
    internal abstract class InteractableObject : MonoBehaviour
    {
        [SerializeField]
        protected Sprite Sprite1;
        [SerializeField]
        protected Sprite Sprite2;
        [SerializeField]
        protected float Distance = 3f;
        [SerializeField]
        protected Transform Player;

        public abstract void Interact();

        /// <summary>
        /// Calculate the distance between the object and player position
        /// Check if the distance between them is less than the "distance" value
        /// </summary>
        protected bool IsPlayerInRange()
        {
            return Vector3.Distance(transform.position, Player.position) < Distance;
        }
    }
}
