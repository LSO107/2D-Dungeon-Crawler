using UnityEngine;

namespace Temporary_Files
{
    internal sealed class SkeletonTest : MonoBehaviour
    {
        public float Speed = 1f;
        public Transform Player;
        private Rigidbody2D m_RigidBody;
        private Animator m_Animator;
        private Vector2 m_Direction;
        public float Distance;

        public float accelerationTime = 2f;
        private Vector2 prevLoc;
        private Vector2 movement;
        private float timeLeft;

        private void Start()
        {
            m_RigidBody = GetComponent<Rigidbody2D>();
            m_Animator = GetComponent<Animator>();
            m_RigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
        }

        private void Update()
        {
            Patrol();
            Direction();

            if (IsPlayerInRange())
            {
                AttackPlayer();
            }
        }

        private void FixedUpdate()
        {
            m_RigidBody.AddForce(movement * Speed);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            timeLeft = 0;
        }

        private void Patrol()
        {
            if (IsPlayerInRange())
                return;

            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0)
            {
                movement = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
                timeLeft += accelerationTime;
            }
        }

        /// <summary>
        /// Calculate the distance between two transform.positions
        /// </summary>
        private bool IsPlayerInRange()
        {
            return Vector3.Distance(transform.position, Player.position) < Distance;
        }

        private void Direction()
        {
            m_Direction = Vector2.zero;

            if (movement.x > prevLoc.x) // Right
            {
                m_Direction += Vector2.right;
            }
            else if (movement.x < prevLoc.x) // Left
            {
                m_Direction += Vector2.left;
            }

            else if (movement.y > prevLoc.y) // Up
            {
                m_Direction += Vector2.up;
            }

            else if (movement.y < prevLoc.y) // Down
            {
                m_Direction += Vector2.down;
            }

            // If direction X and Y are not equal to 0, use walk animation.
            if (!m_Direction.x.Equals(0) || (!m_Direction.y.Equals(0)))
            {
                AnimateWalk();
            }

            prevLoc = movement;
        }

        private void AnimateWalk()
        {
            const int walkAnimation = 1;
            m_Animator.SetLayerWeight(0, walkAnimation);
            m_Animator.SetFloat("x", m_Direction.x);
            m_Animator.SetFloat("y", m_Direction.y);
        }

        private void AttackPlayer()
        {
            var displacement = Player.position - transform.position;
            displacement = displacement.normalized;
            if (Vector2.Distance(Player.position, transform.position) > 0.8f)
            {
                transform.position += (displacement * Speed * Time.deltaTime);

            }
            else
            {
                GameManager.instance.Player.Speed = 0f;
                GameManager.instance.ChangeScene("Combat Scene");
            }
        }
    }
}
