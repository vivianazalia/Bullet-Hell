using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BulletHell.Enemy
{
    public abstract class Enemy : MonoBehaviour
    {
        [SerializeField] protected int health;
        [SerializeField] protected float speed;

        protected Rigidbody2D rb;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            Move();
        }

        public abstract void Move();
        public abstract void Attacked();

        public abstract void Died();
    }
}
