// Lee (1720076)

namespace Enemies.Definitions
{
    internal sealed class Skeleton : Enemy
    {
        public Skeleton(string name, 
                        int combatLevel,
                        int currentHealth,
                        int maxHealth,
                        int attackBonus,
                        int defenceBonus,
                        int experienceRewarded,
                        string iconPath) 
            : base(name,
                   combatLevel,
                   currentHealth,
                   maxHealth,
                   attackBonus,
                   defenceBonus,
                   experienceRewarded,
                   iconPath)
        {

        }
    }
}
