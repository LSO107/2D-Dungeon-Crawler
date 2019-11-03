// Lee (1720076)

using Combat;
using Enemies.Definitions;
using UnityEngine;

namespace AI.Enemy_AI
{
    public class EnemyEngage : MonoBehaviour
    {
        [SerializeField]
        private float m_Speed;
        [SerializeField]
        private float m_Distance;

        public Transform TargetTransform;

        private Vector3 m_PrevLoc;
        private Vector3 m_Velocity;
        private Animator m_Anim;
        private PatrolAI m_PatrolAI;
        private BoxCollider2D m_BoxCollider;

        public string Name;
        public int CombatLevel;
        public int CurrentHealth = 100;
        public int MaxHealth = 100;
        public int AttackBonus;
        public int DefenceBonus;
        public int ExperienceRewarded;

        private void Start()
        {
            m_Anim = GetComponent<Animator>();
            m_PatrolAI = GetComponent<PatrolAI>();
            m_BoxCollider = GetComponent<BoxCollider2D>();
        }

        private void Update()
        {
            if (IsPlayerInRange())
            {
                m_PatrolAI.CanPatrol = false;
                m_BoxCollider.enabled = false;
                MoveTowardsPlayer();
            }
        }

        /// <summary>
        /// Stop AI patrolling, and move the current transform.position
        /// towards target transform.
        /// Call Direction.
        /// </summary>
        private void MoveTowardsPlayer()
        {
            GameManager.instance.Player.Speed = 0;
            transform.position = Vector2.MoveTowards(transform.position, TargetTransform.position, m_Speed * Time.deltaTime);
            Direction(transform, TargetTransform);
        }

        // If collision has "Player" tag, load combat scene.
        // Setup Combat Scene with an enemy,
        // Reset Player Speed and destroy the enemy GameObject
        // in the Main Game, so it is no longer there after combat
        //
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player"))
                return;

            GameManager.instance.ChangeScene("Combat Scene");
            BattleManager.instance.SetupCombatScene(new Skeleton(Name,
                                                                 CombatLevel, 
                                                                 CurrentHealth, 
                                                                 MaxHealth, 
                                                                 AttackBonus,
                                                                 DefenceBonus,
                                                                 ExperienceRewarded,
                                                                 ""));
            Destroy(gameObject);
            GameManager.instance.Player.Speed = 2f;
        }

        /// <summary>
        /// Calculate the distance between two transform.positions
        /// </summary>
        protected bool IsPlayerInRange()
        {
            return Vector3.Distance(transform.position, TargetTransform.position) < m_Distance;
        }

        /// <summary>
        /// Set animation parameters depending on the movement
        /// </summary>
        private void Direction(Transform myTransform, Transform targetTransform)
        {
            if (myTransform.position.x > TargetTransform.position.x)
            {
                m_Anim.SetFloat("x", -1);
            }
            if (myTransform.position.x < targetTransform.position.x)
            {
                m_Anim.SetFloat("x", 1);
            }
            if (myTransform.position.y > targetTransform.position.y)
            {
                m_Anim.SetFloat("y", -1);
            }
            if (myTransform.position.y < targetTransform.position.y)
            {
                m_Anim.SetFloat("y", 1);
            }
        }
    }
}
