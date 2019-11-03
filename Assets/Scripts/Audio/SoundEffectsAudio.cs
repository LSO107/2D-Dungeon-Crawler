// Lee (1720076)
using UnityEngine;

namespace Audio
{
    internal sealed class SoundEffectsAudio : MonoBehaviour
    {
        private AudioSource[] m_SoundEffects;

        private float m_AudioVolume = 1f;

        private void Start()
        {
            m_SoundEffects = FindObjectsOfType<AudioSource>();
        }

        private void Update()
        {
            foreach (var soundEffect in m_SoundEffects)
            {
                soundEffect.volume = m_AudioVolume;
            }
        }

        /// <summary>
        /// Set volume of audio source to value of volume
        /// </summary>
        public void AdjustSFXVolume(float volume)
        {
            m_AudioVolume = volume;
        }
    }
}
