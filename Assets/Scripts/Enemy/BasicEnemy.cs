using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BulletHell.Enemy
{
    public class BasicEnemy : BaseEnemy
    {
        protected override void Start()
        {
            base.Start();
            _killScore = 10;
        }

        protected override void OnEnable()
        {
            Invoke("Died", 3f);
        }

        private void OnDisable()
        {
            CancelInvoke();
        }
    }
}
