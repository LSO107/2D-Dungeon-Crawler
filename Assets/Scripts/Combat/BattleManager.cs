// Lee (1720076)

using Enemies.Definitions;
using ItemSystem.Consumables;
using ItemSystem.Inventory;
using Player;
using UI.Combat;
using UI.Stats;
using UnityEngine;
using UnityEngine.UI;

namespace Combat
{
    internal sealed class BattleManager : MonoBehaviour
    {
        [SerializeField]
        private BarGUI m_PlayerHealthBar;
        [SerializeField]
        private BarGUI m_PlayerExperienceBar;
        [SerializeField]
        private BarGUI m_EnemyHealthBar;
        [SerializeField]
        private Text m_CombatLevelText;
        [SerializeField]
        private Text m_EnemyName;

        [SerializeField]
        private Image m_TurnBaseColour;
        [SerializeField]
        private Text m_TurnBaseText;

        private const string PlayerTurnText = "Your Turn";
        private readonly Color32 m_PlayerColour = new Color32(150, 240, 250, 255);
        private const string EnemyTurnText = "Enemy Turn";
        private readonly Color32 m_EnemyColor = new Color32(245, 150, 150, 255);

        [SerializeField]
        private Button[] m_CombatButtons;

        [SerializeField]
        private CombatInventoryUI CombatInventoryUI;

        private PlayerInventory m_Inventory;

        private PlayerStats m_PlayerStats;

        public bool IsPlayerTurn;

        private Enemy m_Enemy;

        public static BattleManager instance;

        public void Awake()
        {
            if (instance == null)
                instance = this;

            else if (instance != this)
                Destroy(gameObject);

            DontDestroyOnLoad(this);
        }

        private void Start()
        {
            IsPlayerTurn = true;
            m_PlayerStats = GameManager.instance.PlayerStats;
            m_Inventory = GameManager.instance.PlayerInventory;
            m_TurnBaseColour.color = m_PlayerColour;
            m_TurnBaseText.text = PlayerTurnText;
        }

        private void DisableButtons()
        {
            foreach (var buttons in m_CombatButtons)
            {
                buttons.interactable = false;
            }
        }

        private void EnableButtons()
        {
            foreach (var buttons in m_CombatButtons)
            {
                buttons.interactable = true;
            }
        }

        private void PlayerDeath()
        {
            // Play death animation - use animator
            // Load Main Game (scene)
            // Respawn player at respawn location - transform.position
            // Display feedback that player has died - text
            // Remove money from pouch as a death penalty 

            if (m_PlayerStats.HealthBar.CurrentValue <= 0)
            {
                GameManager.instance.ChangeScene("Main Game");
                GameManager.instance.Player.transform.position =
                    GameManager.instance.RespawnLocation.transform.position;
            }

        }

        private void EnemyDeath()
        {
            // Play death animation - use animator
            // Load Main Game (scene)
            // Respawn player at the last location they were stood
            // Add gold and/or items to the players inventory as a reward
            // Add experience based on the enemies level

            Debug.Log("Enemy is dead!");
            m_Inventory.AddItem(new HealthPotion());
            GameManager.instance.PlayerCoins.PlayerGoldQuantity += m_Enemy.CombatLevel * 20;
            GameManager.instance.ChangeScene("Main Game");
            GameManager.instance.PlayerStats.AddExperience(m_Enemy.ExperienceRewarded);
        }

        /// <summary>
        /// Sets the player and enemy health bars accordingly
        /// </summary>
        public void SetupCombatScene(Enemy enemy)
        {
            m_Enemy = enemy;
            m_PlayerHealthBar.MaxValue = m_PlayerStats.MaxHealth;
            m_PlayerHealthBar.Value = m_PlayerStats.CurrentHealth;
            m_PlayerExperienceBar.MaxValue = m_PlayerStats.MaxExperience;
            m_PlayerExperienceBar.Value = m_PlayerStats.CurrentExperience;

            m_EnemyHealthBar.MaxValue = enemy.MaxHealth;
            m_EnemyHealthBar.Value = enemy.CurrentHealth;
            m_CombatLevelText.text = enemy.CombatLevel.ToString();
            m_EnemyName.text = enemy.Name;

            CombatInventoryUI.Initialize();
        }

        public void DoPlayerAttack()
        {
            if (!IsPlayerTurn)
                return;

            m_Enemy.CurrentHealth -= DamageFormulas.GetDamage();
            UpdateUIBars();

            if (m_Enemy.CurrentHealth <= 0)
            {
                EnemyDeath();
            }

            InvokeEnemyAttack();
        }

        private void DoEnemyAttack()
        {
            // Generate random damage based on enemy level/stats
            // Subtract from player's health
            // Check PlayerDeath & handle it

            if (IsPlayerTurn)
                return;

            var rand = new System.Random();

            var baseDamage = 100 / (m_PlayerStats.BuffedDefence / 2);
            var minDamage = baseDamage * (int)1f;
            var maxDamage = baseDamage * (int)2.5f;
            var enemyHit = rand.Next(minDamage, maxDamage);

            m_PlayerStats.AddHealth(-enemyHit);
            UpdateUIBars();

            IsPlayerTurn = true;
            m_TurnBaseColour.color = m_PlayerColour;
            m_TurnBaseText.text = PlayerTurnText;
            EnableButtons();
        }

        public void InvokeEnemyAttack()
        {
            IsPlayerTurn = false;
            DisableButtons();
            m_TurnBaseColour.color = m_EnemyColor;
            m_TurnBaseText.text = EnemyTurnText;
            Invoke(nameof(DoEnemyAttack), 2.5f);
        }

        public void FleeCombat()
        {
            GameManager.instance.ChangeScene("Main Game");
            GameManager.instance.PlayerCoins.PlayerGoldQuantity -= 500;

            var penaltyDamage = FleeDamage();

            m_PlayerStats.AddHealth(-FleeDamage());
            Debug.Log($"The enemy managed to hit {penaltyDamage} whilst you were running away.");
            // Add reasonable penalty for fleeing (remove gold/experience?)
            // Display some kind of feedback/message about the penalty
        }

        private int FleeDamage()
        {
            var rand = new System.Random();

            var fleeDamage = rand.Next(0, m_PlayerStats.CurrentHealth - 1);

            return fleeDamage;
        }

        public void UpdateUIBars()
        {
            m_PlayerHealthBar.Value = m_PlayerStats.CurrentHealth;
            m_PlayerExperienceBar.Value = m_PlayerStats.CurrentExperience;
            m_EnemyHealthBar.Value = m_Enemy.CurrentHealth;
        }
    }
}
