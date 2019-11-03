// Lee (1720076)

using UnityEngine;

namespace Enemies.Definitions
{
    public class EnemyStats
    {
        public int CombatLevel;
        public int CurrentHealth;
        public int MaxHealth;
        public int ExperienceRewarded;
        public int AttackBonus;
        public int DefenceBonus;

        public EnemyStats()
        {
            CurrentHealth = MaxHealth;
            AttackBonus = CombatLevel * 5;
            DefenceBonus = CombatLevel * 3;
        }
    }
}
