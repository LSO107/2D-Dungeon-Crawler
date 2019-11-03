// Lee (1720076)
using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Stats
{
    public class BarGUI : MonoBehaviour
    {
        private float m_BarFillAmount;
        [SerializeField]
        private Image m_BarImage;
        [SerializeField]
        private float m_FillSpeed;

        // Constants as the values will not be changing, improves readability.
        private const float MinimumStatValue = 0;
        private const float MaximumStatValue = 100;
        private const float MinimumBarFill = 0;
        private const float MaximumBarFill = 1;

        public float MaxValue { get; set; }

        // Set the bar fill amount based on our calculation
        public float Value
        {
            set
            {
                m_BarFillAmount = BarCalculation(value,
                                                 MinimumStatValue, 
                                                 MaximumStatValue, 
                                                 MinimumBarFill, 
                                                 MaximumBarFill);
            }
        }

        private void Update()
        {
            UpdateBar();
        }

        /// <summary>
        /// If value of the bar changes, lerp barImage fillAmount for
        /// a smooth transition
        /// </summary>
        private void UpdateBar()
        {
            if (Math.Abs(m_BarFillAmount - m_BarImage.fillAmount) > 0)
            {
                m_BarImage.fillAmount = Mathf.Lerp(m_BarImage.fillAmount, m_BarFillAmount, Time.deltaTime * m_FillSpeed);
            }
        }


        /// <summary>
        /// Bars move between a value of 0 and 1.
        /// The calculation ensures the bar is always relative despite the value
        /// </summary>
        private static float BarCalculation(float value, 
                                            float minimumStatValue, 
                                            float maximumStatValue, 
                                            float minimumBarFill, 
                                            float maximumBarFill)
        {
            return (value - minimumStatValue) * (maximumBarFill - minimumBarFill) / (maximumStatValue - minimumStatValue) + minimumBarFill;
        }
    }
}
