using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BulletHell.Enemy
{
    public abstract class Enemy : MonoBehaviour
    {
        [SerializeField] protected int _health;
        [SerializeField] protected float _speed;

        protected Rigidbody2D _rb;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                Died();
            }
        }

        public virtual void Attacked()
        {
            _health -= 2;
        }

        public virtual void Died()
        {
            //Turn to pool
            if (_health <= 0)
            {
                Destroy(gameObject);
                Debug.Log("Died!");
            }
        }

        public abstract void Move();
    }
}
