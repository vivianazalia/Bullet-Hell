using BulletHell.Manager;
using BulletHell.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BulletHell.UpgradeItem
{
    public class FirerateUpgrade : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private Rigidbody2D _rb;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (!GameManager.Instance.GameOver)
            {
                Move();
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                PlayerShooterController.OnIncreaseBulletCount?.Invoke();
                gameObject.SetActive(false);
            }
        }

        public void Move()
        {
            _rb.velocity = Vector2.down * _speed;
        }
    }
}
