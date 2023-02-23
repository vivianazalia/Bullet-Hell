using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BulletHell.Enemy
{
    public class AngryEnemy : BaseEnemy
    {
        protected override void Start()
        {
            base.Start();
            _moveDirection = Vector2.down;
            _killScore = 50;
        }

        protected override void OnEnable()
        {
            _speed = 3;
            Invoke("Died", 3f);
        }

        public override void Attacked()
        {
            base.Attacked();
            _speed = 5;
        }

        private void OnDisable()
        {
            CancelInvoke();
        }
    }
}
