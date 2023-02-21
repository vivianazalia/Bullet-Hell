using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BulletHell.Player
{
    public class PlayerMovementController : MonoBehaviour
    {
        [SerializeField] private float _speed = 1f;

        private float _inputX;
        private float _inputY;
        private float _angle;
        private Vector2 _direction;
        private Rigidbody2D _rb;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            _inputX = Input.GetAxis("Horizontal");
            _inputY = Input.GetAxis("Vertical");
            _direction = new Vector2(_inputX, _inputY);
            _angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg - 90;
        }

        private void FixedUpdate()
        {
            _rb.velocity = new Vector2(_direction.x, _direction.y) * _speed;

            if(_direction != Vector2.zero)
            {
                _rb.rotation = _angle;
            }
        }
    }
}

