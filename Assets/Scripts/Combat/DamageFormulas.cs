// Lee (1720076)
using UnityEngine;

namespace Combat
{
    internal sealed class DamageFormulas : MonoBehaviour
    {
        /// <summary>
        /// Generates random damage based on player attack
        /// </summary>
        public static int GetDamage()
        {
            var rand = new System.Random();

            var attack = GameManager.instance.PlayerStats.BuffedAttack;

            var range = rand.Next(attack - 8, attack + 8);
            var dmgReduction = GetDamageReduction(attack, 0);

            var reducedDamage = range * dmgReduction;
            return Mathf.RoundToInt(reducedDamage);
        }

        /// <summary>
        /// returns damage reduction based on attack and defence
        /// </summary>
        private static float GetDamageReduction(int attack, int defence)
        {
            // get defence - attack
            var value = defence - attack;
            // if it's less than 0, set it to 0
            if (value <= 0)
                value = 0;

            // damage reduction is 100 / (100 + (defence - attack)
            var damageReduction = 100 / (100 + (value));
            // return damage
            return damageReduction;
        }
    }
}
