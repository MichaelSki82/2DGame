using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Skipin2D
{
    public class EnemyController : MonoBehaviour
    {
        public float pointToX;
        public float moveSpeed;
        //public bool canAttack;

        private float pointFromX;
        private float movePoint;

        private SpriteRenderer spriteRenderer;
        private Rigidbody2D rigidBody2D;
        private Animator animator;



        void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            rigidBody2D = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();

            pointFromX = transform.position.x;
            movePoint = pointToX;

        }


        void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(movePoint, transform.position.y, transform.position.z), moveSpeed * Time.deltaTime);

            if (Vector2.Distance(transform.position, new Vector2(movePoint, transform.position.y)) < 0.1f)
            {
                if (movePoint == pointToX)
                {
                    movePoint = pointFromX;
                    spriteRenderer.flipX = false;
                }
                else
                {
                    movePoint = pointToX;
                    spriteRenderer.flipX = true;
                }
            }

        }
    }
}
