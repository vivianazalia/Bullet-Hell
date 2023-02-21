using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BulletHell.Bullet
{
    public class BulletController : MonoBehaviour
    {
        [SerializeField] private float _speed = 1f;

        private Rigidbody2D _rb;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            Move();
        }

        private void Move()
        {
            _rb.AddForce(Vector2.up * _speed);
        }
    }
}
