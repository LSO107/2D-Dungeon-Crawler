// Lee (1720076)

using UnityEngine;
using Random = System.Random;

namespace RandomOutput
{
    public class RandomDamage : MonoBehaviour
    {
        private const int MinimumDamageAmount = -12;
        private const int MaximumDamageAmount = 0;

        // Check it is the player colliding,
        // then call DealRandomDamage if it is
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                DealRandomDamage(MinimumDamageAmount, MaximumDamageAmount);
            }
        }

        /// <summary>
        /// Deal random damage to player's health between a minimum and maximum value
        /// </summary>
        public static void DealRandomDamage(int min, int max)
        {
            var rand = new Random();
            var randomNumber = rand.Next(min, max + 1);
            GameManager.instance.PlayerStats.AddHealth(randomNumber);
        }
    }
}
