using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BulletHell.Enemy
{
    public class BasicEnemy : BaseEnemy
    {
        public override void Move()
        {
            _rb.velocity = Vector2.up * _speed;
        }
    }
}
