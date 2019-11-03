// Lee (1720076)
using System.Collections;
using UnityEngine;

namespace Objects
{
    internal sealed class SelfDestruct : MonoBehaviour
    {
        [SerializeField]
        private bool m_Deactivate;

        // Begins CheckIfActive courotine when an
        // instance of the particle system is enabled
        private void OnEnable()
        {
            StartCoroutine(nameof(CheckIfActive));
        }

        private IEnumerator CheckIfActive()
        {
            var ps = GetComponent<ParticleSystem>();

            // while Particle System is not null
            while (ps != null)
            {
                // Wait 0.5 seconds
                yield return new WaitForSeconds(0.5f);

                // If Particle System is still alive,
                // don't bother executing the rest of the method
                if (ps.IsAlive(true))
                    continue;

                // If Deactivated, set gameObject to inactive
                if (m_Deactivate)
                {
                    gameObject.SetActive(false);
                }
                else
                {
                    // Otherwise destory gameObject, and break out of the while loop
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
}
