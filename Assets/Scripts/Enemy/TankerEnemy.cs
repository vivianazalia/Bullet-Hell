using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BulletHell.Enemy
{
    public class TankerEnemy : BaseEnemy
    {
        protected override void Start()
        {
            base.Start();
            _moveDirection = Vector2.down;
            _killScore = 80;
        }

        protected override void OnEnable()
        {
            _speed = 1;
            Invoke("Died", 5f);
        }

        private void OnDisable()
        {
            CancelInvoke();
        }
    }
}

