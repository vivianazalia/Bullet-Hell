using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BulletHell.Enemy
{
    public class AngryEnemy : Enemy
    {
        public override void Attacked()
        {
            Debug.Log("Attacked!");
        }

        public override void Move()
        {
            rb.velocity = Vector2.right * speed;
        }

        public override void Died()
        {
            //Turn to pool
            Destroy(gameObject);
            Debug.Log("Died!");
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (gameObject.CompareTag("Player"))
            {
                Died();
            }
        }
    }
}
