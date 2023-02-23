using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BulletHell.ObjectPool;
using BulletHell.Enemy;
using BulletHell.Manager;

namespace BulletHell.Enemy
{
    public class MotherEnemy : BaseEnemy
    {
        [SerializeField] private int _bulletAmounts = 5;
        [SerializeField] private float _startAngle = 90;
        [SerializeField] private float _endAngle = 270;

        protected override void OnEnable()
        {
            InvokeRepeating("Fire", 1f, 2f);
        }

        protected override void Start()
        {
            base.Start();
            _moveDirection = Vector2.down;
            _killScore = 100;
        }

        private void Fire()
        {
            float angleStep = (_endAngle - _startAngle) / _bulletAmounts;
            float angle = _startAngle;

            for (int i = 0; i < _bulletAmounts; i++)
            {
                float bulletDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180);
                float bulletDirY = transform.position.x + Mathf.Cos((angle * Mathf.PI) / 180);

                Vector3 bulletMove = new Vector3(bulletDirX, bulletDirY, 0f);
                Vector2 bulletDirection = (bulletMove - transform.position).normalized;

                GameObject enemy = ObjectPoolController.Instance.GetFromPool("BasicEnemy", transform.position, transform.rotation);
                enemy.GetComponent<BaseEnemy>().SetMoveDirection(bulletDirection);

                angle += angleStep;
            }
        }

        public override void Move()
        {
            base.Move();
            if(transform.localPosition.y <= 3f)
            {
                transform.localPosition = new Vector3(transform.position.x, 3f, transform.position.z);
            }
        }

        private void OnDisable()
        {
            CancelInvoke();
        }
    }
}

