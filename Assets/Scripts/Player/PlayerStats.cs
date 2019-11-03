// Lee (1720076)

using Combat;
using ItemSystem.Definitions;
using ItemSystem.Inventory;
using UI.Stats;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    internal sealed class PlayerStats : CombatStats
    {
        public int CurrentExperience { get; private set; }
        public int MaxExperience { get; } = 100;

        public StatBar HealthBar;
        public StatBar ExperienceBar;

        public PlayerEquipment Equipment => GameManager.instance.Player.PlayerEquipment;

        public int BuffedAttack => BaseAttack + Equipment.GetEquipmentStatBonuses()[PlayerStat.Attack];

        public int BuffedDefence => BaseDefence + Equipment.GetEquipmentStatBonuses()[PlayerStat.Defence];


        
        [SerializeField]
        private AudioSource m_LevelUpAudio;
        [SerializeField]
        private GameObject m_LevelUpGfx;
        [SerializeField]
        private GameObject m_HitMarkGfx;
        [SerializeField]
        private Text m_CombatLevelText;

        private void Awake()
        {
            // Set our health and experience values (current and max)
            HealthBar.Initialize();
            ExperienceBar.Initialize();
            BaseAttack = 25;
            BaseDefence = 25;
            BaseStrength = 5;
            BaseDexterity = 5;
            BaseAgility = 5;
            CombatLevel = 1;
            m_CombatLevelText.text = CombatLevel.ToString();
        }

        /// <summary>
        /// Adds X amount of health to the current health.
        /// If health 'added' is below 0, instantiate HitMarkGfx
        /// </summary>
        public void AddHealth(int health)
        {
            CurrentHealth += health;
            HealthBar.CurrentValue += health;
            GameManager.instance.EquipmentUI.UpdateLabels();

            if (health < 0)
            {
                Instantiate(m_HitMarkGfx, transform.position, transform.rotation);
            }
        }

        /// <summary>
        /// Adds X amount of experience to the current experience
        /// </summary>
        public void AddExperience(int experience)
        {
            CurrentExperience += experience;
            ExperienceBar.CurrentValue += experience;
        }

        /// <summary>
        /// Increases the combat level by 1, then resets the experience
        /// bar to 0
        /// </summary>
        public void AddLevel()
        {
            m_LevelUpAudio.Play();
            Instantiate(m_LevelUpGfx, transform.position, transform.rotation);

            CombatLevel += 1;
            ExperienceBar.CurrentValue = 0;
            m_CombatLevelText.text = CombatLevel.ToString();
        }
    }
}
