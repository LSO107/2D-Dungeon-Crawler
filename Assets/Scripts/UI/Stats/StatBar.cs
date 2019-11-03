// Lee (1720076)
using System;
using UnityEngine;

namespace UI.Stats
{
    [Serializable]
    public class StatBar
    {
        /// Serialized Fields so we can modify values in Unity
        [SerializeField]
        private BarGUI bar;
        [SerializeField]
        private float maxValue;
        [SerializeField]
        private float currentValue;

        private const float minValue = 0;

        /// <summary>
        /// Ensures the bar always stays within minimum and maximum values
        /// </summary>
        public float CurrentValue
        {
            get { return currentValue; }

            set
            {
                currentValue = Mathf.Clamp(value, minValue, MaxValue);
                bar.Value = currentValue;
            }
        }

        /// <summary>
        /// Set max value
        /// </summary>
        public float MaxValue
        {
            get { return maxValue; }
            set
            {
                maxValue = value;
                bar.MaxValue = maxValue;
            }
        }

        /// <summary>
        /// Set maximum and current value of bar
        /// </summary>
        public void Initialize()
        {
            MaxValue = maxValue;
            CurrentValue = currentValue;
        }
    }
}
