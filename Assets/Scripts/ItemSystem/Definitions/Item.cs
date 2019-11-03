// Lee (1720076)
using UnityEngine;

namespace ItemSystem.Definitions
{
    // Base class for all items in the system
    public abstract class Item
    {
        /// <summary>
        /// Can be duplicate across items
        /// </summary>
        public string Name;

        public Sprite Sprite;

        protected Item(string name, string iconPath)
        {
            Name = name;
            
            LoadIcon(iconPath);
        }

        /// <summary>
        /// Pass the iconPath, and set the sprite equal to the file
        /// </summary>
        protected void LoadIcon(string iconPath)
        {
            var icon = Resources.Load(iconPath);

            if (icon == null)
                Debug.LogError($"Resource did not exist at path {iconPath}");

            Sprite = Resources.Load<Sprite>(iconPath);
        }
    }
}
