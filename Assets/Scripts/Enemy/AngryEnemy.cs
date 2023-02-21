using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BulletHell.Enemy
{
    public class AngryEnemy : Enemy
    {
        public override void Attacked()
        {
            base.Attacked();
            _speed = 3;
            Debug.Log("Angry Enemy Attacked!");
        }

        public override void Move()
        {
            _rb.velocity = Vector2.right * _speed;
        }
    }
}
