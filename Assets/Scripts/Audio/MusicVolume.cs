// Lee (1720076)
using UnityEngine;

namespace Audio
{
    internal sealed class MusicVolume : MonoBehaviour
    {
        private AudioSource m_AudioSource;

        private float m_AudioVolume = 1f;

        private void Start()
        {
            m_AudioSource = GetComponent<AudioSource>();
        }

        // Set volume to the music volume.
        // TODO: Look into a way to update volume only when it has been adjusted
        //
        private void Update()
        {
            m_AudioSource.volume = m_AudioVolume;
        }

        /// <summary>
        /// Set volume of audio source to value of volume
        /// </summary>
        public void AdjustMusicVolume(float volume)
        {
            m_AudioVolume = volume;
        }
    }
}
