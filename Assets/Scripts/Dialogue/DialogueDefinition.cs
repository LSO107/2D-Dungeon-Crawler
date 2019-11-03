// Lee (1720076)

using UnityEngine;
using UnityEngine.UI;

namespace Dialogue
{
    internal abstract class DialogueDefinition : MonoBehaviour
    {
        [SerializeField]
        protected CanvasGroup DialogueCanvasGroup;
        [SerializeField]
        protected Text NameTextComponent;
        [SerializeField]
        protected Text DialogueTextComponent;
        [SerializeField]
        protected string Name;
        [TextArea]
        public string[] Dialogue;

        protected const int FirstDialogue = 0;
        protected const int SecondDialogue = 1;
        protected const int ThirdDialogue = 2;

        private bool m_DialogueActive;

        /// <summary>
        /// Sets the dialogue text to the string
        /// at the array element provided
        /// </summary>
        protected void SetDialogue(int index)
        {
            NameTextComponent.text = Name;
            DialogueTextComponent.text = Dialogue[index];
        }

        /// <summary>
        /// Toggles the canvas group alpha to the opposite
        /// of the current value
        /// </summary>
        protected void ToggleDialogueUI()
        {
            m_DialogueActive = !m_DialogueActive;
            DialogueCanvasGroup.alpha = m_DialogueActive ? 1 : 0;
        }
    }
}
