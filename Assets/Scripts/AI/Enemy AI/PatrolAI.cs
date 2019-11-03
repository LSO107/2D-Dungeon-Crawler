// Lee (1720076)
using UnityEngine;

namespace AI.Enemy_AI
{
    internal sealed class PatrolAI : MonoBehaviour
    {
        private Transform m_SkeletonTransform;
        private Rigidbody2D m_Rb;
        private Animator m_Anim;
        private Vector3 m_StartingPosition;
        private Vector3 m_Velocity;

        [SerializeField]
        private float m_Distance = 2f;
        [SerializeField]
        private float m_Speed = 1f;
        [SerializeField]
        private float m_DistanceTravelled;
        [SerializeField]
        private bool m_WalkingLeft;

        public bool CanPatrol;

        public void Start()
        {
            m_SkeletonTransform = GetComponent<Transform>();
            m_Rb = GetComponent<Rigidbody2D>();
            m_Anim = GetComponent<Animator>();
            m_Velocity = new Vector3(m_Speed, 0, 0);
            m_SkeletonTransform.Translate(m_Velocity.x * Time.deltaTime, 0, 0);
            m_StartingPosition = gameObject.transform.position;
            CanPatrol = true;
        }

        // Freeze rigidbody rotation so the enemy always moves on the X or Y axis.
        // Constantly track the distanceTravelled so we know when to change direction
        private void Update()
        {
            if (CanPatrol)
            {
                m_Rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                m_DistanceTravelled = transform.position.x - m_StartingPosition.x;

                EnemyPatrol();
                ChangeAnimDirection();
            }
        }

        /// <summary>
        /// Patrols the given distance along the X axis.
        /// When the distance is reached, it moves in the opposite direction
        /// </summary>
        private void EnemyPatrol()
        {
            if (m_WalkingLeft)
            {
                if (m_DistanceTravelled < -m_Distance)
                    ChangeDirection();

                m_SkeletonTransform.Translate(-m_Velocity.x * Time.deltaTime, 0, 0);
            }
            else
            {
                if (m_DistanceTravelled > m_Distance)
                    ChangeDirection();

                m_SkeletonTransform.Translate(m_Velocity.x * Time.deltaTime, 0, 0);
            }
        }

        /// <summary>
        /// Toggles the bool walkingLeft 
        /// </summary>
        private void ChangeDirection()
        {
            m_WalkingLeft = !m_WalkingLeft;
        }

        /// <summary>
        /// Float runs between -1 and 1.
        /// Set the animator float to negative or positive
        /// to determine Left or Right walk animation
        /// </summary>
        private void ChangeAnimDirection()
        {
            if (m_WalkingLeft)
            {
                m_Anim.SetFloat("x", -1);
            }
            else if (!m_WalkingLeft)
            {
                m_Anim.SetFloat("x", 1);
            }
        }
    }
}