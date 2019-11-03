// Lee (1720076)
using UnityEngine;

namespace Objects
{
    // All TriggerableObjects will have a TriggerInteraction method
    internal abstract class TriggerableObject : MonoBehaviour
    {
        public abstract void TriggerInteraction();
    }
}