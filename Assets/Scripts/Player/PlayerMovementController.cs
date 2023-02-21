using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BulletHell.Player
{
    public class PlayerMovementController : MonoBehaviour
    {
        [SerializeField] private float speed = 1f;

        private float inputX;
        private float inputY;
        private Vector2 direction;
        private Rigidbody2D rb;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            inputX = Input.GetAxis("Horizontal");
            inputY = Input.GetAxis("Vertical");
            direction = new Vector2(inputX, inputY);
        }

        private void FixedUpdate()
        {
            rb.velocity = new Vector2(direction.x, direction.y) * speed;
        }
    }
}

