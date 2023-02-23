using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BulletHell.Player;
using BulletHell.Manager;

namespace BulletHell.Enemy
{
    public class BaseEnemy : MonoBehaviour
    {
        [SerializeField] protected int _health;
        [SerializeField] protected float _speed;

        protected Rigidbody2D _rb;
        protected Vector2 _moveDirection;
        protected int _killScore = 0;

        private bool _isDied = false;

        protected virtual void OnEnable()
        {
            _isDied = false;
        }

        protected virtual void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            GameManager.OnAddScore?.Invoke(_killScore);
        }

        private void Update()
        {
            Died();
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                collision.gameObject.GetComponent<PlayerStats>().DecreaseHealth();
            }
        }

        public void SetMoveDirection(Vector2 direction)
        {
            _moveDirection = direction;
        }

        public virtual void Attacked()
        {
            _health--;
        }

        public virtual void Died()
        {
            if(_health <= 0 && !_isDied)
            {
                gameObject.SetActive(false);
                GameManager.OnAddScore?.Invoke(_killScore);
                _isDied = true;
            }
        }

        public virtual void Move()
        {
            _rb.velocity = _moveDirection * _speed;
        }
    }
}
