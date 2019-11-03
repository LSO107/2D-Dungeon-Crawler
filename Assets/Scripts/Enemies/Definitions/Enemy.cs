// Lee (1720076)

using UnityEngine;

namespace Enemies.Definitions
{
    public abstract class Enemy
    {
        public string Name;

        public int CombatLevel;

        public int CurrentHealth;

        public int MaxHealth;

        public int AttackBonus;

        public int DefenceBonus;

        public int ExperienceRewarded;

        public Sprite EnemyIcon;

        protected Enemy(string name,
                        int combatLevel,
                        int currentHealth,
                        int maxHealth,
                        int attackBonus,
                        int defenceBonus,
                        int experienceRewarded,
                        string iconPath)
        {
            Name = name;
            CombatLevel = combatLevel;
            CurrentHealth = currentHealth;
            MaxHealth = maxHealth;
            AttackBonus = attackBonus;
            DefenceBonus = defenceBonus;
            ExperienceRewarded = experienceRewarded;
            //LoadIcon(iconPath);
        }

        /// <summary>
        /// Pass the iconPath, and set the sprite equal to the file
        /// </summary>
        protected void LoadIcon(string iconPath)
        {
            var icon = Resources.Load(iconPath);

            if (icon == null)
                Debug.LogError($"Resource did not exist at path {iconPath}");

            EnemyIcon = Resources.Load<Sprite>(iconPath);
        }
    }
}
