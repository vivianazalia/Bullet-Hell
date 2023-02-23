using BulletHell.Manager;
using BulletHell.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BulletHell.UpgradeItem
{
    public class BaseUpgradeItem : MonoBehaviour
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

        public void Move()
        {
            _rb.velocity = Vector2.down * _speed;
        }
    }
}

