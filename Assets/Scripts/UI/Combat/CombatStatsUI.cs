// Lee (1720076)

using System;
using System.Collections.Generic;
using System.Text;
using ItemSystem.Definitions;
using Player;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Combat
{
    internal sealed class CombatStatsUI : MonoBehaviour
    {
        /// <remarks>
        /// Duplicated code, figure out a way to access
        /// methods from EquipmentUI.
        /// Maybe make it public and not static.
        /// </remarks>
     
        public Text PlayerStatsLabel;
        public Text PlayerEquipmentLabel;

        private void Start()
        {
            UpdateLabels();
        }

        public void UpdateLabels()
        {
            var player = GameManager.instance.Player;
            var playerStats = GameManager.instance.PlayerStats;
            var playerEquipment = player.PlayerEquipment;

            var equipmentStats = playerEquipment.GetEquipmentStatBonuses();

            PlayerStatsLabel.text = GetPlayerStatsLabelText(playerStats);
            PlayerEquipmentLabel.text = GetEquipmentStatsLabelText(equipmentStats);
        }

        /// <summary> Generate text for player stats label </summary>
        ///
        private static string GetPlayerStatsLabelText(PlayerStats playerStats)
        {
            return $"Health: {playerStats.CurrentHealth} / {playerStats.MaxHealth}\n" +
                   $"Experience: {playerStats.CurrentExperience} / {playerStats.MaxExperience}";
        }

        /// <summary> Generate text for equipment stats. Receives a
        ///           dictionary of stats and massages them in to a
        ///           single string, separated by new lines </summary>
        ///
        private static string GetEquipmentStatsLabelText(IReadOnlyDictionary<PlayerStat, int> stats)
        {
            var stringBuilder = new StringBuilder();
            foreach (PlayerStat stat in Enum.GetValues(typeof(PlayerStat)))
            {
                stringBuilder.Append($"{stat}: {stats[stat]}\n");
            }

            return stringBuilder.ToString();
        }
    }
}
