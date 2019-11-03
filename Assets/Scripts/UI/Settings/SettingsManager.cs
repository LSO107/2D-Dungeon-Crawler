// Lee (1720076)
using Audio;
using UnityEngine;
using Utils;

namespace UI.Settings
{
    internal sealed class SettingsManager : MonoBehaviour
    {
        private CanvasGroup m_SettingsCanvasGroup;
        public SoundEffectsAudio SoundEffectsAudio;

        private void Start()
        {
            m_SettingsCanvasGroup = GetComponent<CanvasGroup>();
            SoundEffectsAudio = FindObjectOfType<SoundEffectsAudio>();
        }

        /// <summary>
        /// enable settings UI canvas group
        /// </summary>
        public void OpenSettings()
        {
            UserInterfaceUtils.ToggleCanvasGroup(m_SettingsCanvasGroup, true);
        }

        /// <summary>
        /// Disable settings UI canvas group
        /// </summary>
        public void CloseSettings()
        {
            UserInterfaceUtils.ToggleCanvasGroup(m_SettingsCanvasGroup, false);
        }
    }
}
