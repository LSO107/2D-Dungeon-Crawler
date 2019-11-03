// George (1714245)
using System;
using UnityEngine;

namespace AI.Enemy_AI
{
    public class SkeletonAI : MonoBehaviour
    {
        [SerializeField]
        private float speed = 2;
        [SerializeField]
        private float timeTillChange = 2f;
        [SerializeField]
        private Vector2 direction;
        private Animator anim;
        private Rigidbody2D rb;

        private float horizontalMovement;
        private float verticalMovement;

        // Set default direction and animation (up),
        // begin calling Decrease method on repeat
        private void Start()
        {
            anim = GetComponent<Animator>();
            rb = GetComponent<Rigidbody2D>();
            direction += Vector2.up;
            anim.SetFloat("y", 1);
            InvokeRepeating(nameof(Decrease), 2, 1);
        }

        // Freeze Z axis of the AI so we only get X and Y movement.
        // Update movement, change direction if timer has reached 0
        private void Update()
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            transform.Translate(direction * Time.deltaTime);

            if (Math.Abs(timeTillChange) <= 0)
            {
                Direction();
                timeTillChange = timeTillChange + 4f;
            }
        }
    
        /// <summary>
        /// Countdown timer from <see cref="timeTillChange"/>
        /// </summary>
        private void Decrease()
        {
            timeTillChange--;
        }

        /// <summary>
        /// Set movement for AI and the corresponding walk animation,
        /// then change direction
        /// </summary>
        private void Direction()
        {
            if (direction == Vector2.left)
            {
                horizontalMovement = 0;
                anim.SetFloat("x", 0);
                anim.SetFloat("y", 1);
                horizontalMovement = -speed * Time.deltaTime;
                verticalMovement = 0;
                transform.Translate(horizontalMovement, verticalMovement, 0);
                direction = Vector2.up;
            }
            else if (direction == Vector2.right)
            {
                horizontalMovement = 0;
                anim.SetFloat("x", 0);
                anim.SetFloat("y", -1);
                horizontalMovement = speed * Time.deltaTime;
                verticalMovement = 0;
                transform.Translate(horizontalMovement, verticalMovement, 0);

                direction = Vector2.down;
            }
            else if (direction == Vector2.down)
            {
                verticalMovement = 0;
                anim.SetFloat("x", -1);
                anim.SetFloat("y", 0);
                verticalMovement = -speed * Time.deltaTime;
                horizontalMovement = 0;
                transform.Translate(horizontalMovement, verticalMovement, 0);
                direction = Vector2.left;
            }
            else if (direction == Vector2.up)
            {
                verticalMovement = 0;
                anim.SetFloat("x", 1);
                anim.SetFloat("y", 0);
                verticalMovement = speed * Time.deltaTime;
                horizontalMovement = 0;
                transform.Translate(horizontalMovement, verticalMovement, 0);

                direction = Vector2.right;
            }
        }
    }
}
