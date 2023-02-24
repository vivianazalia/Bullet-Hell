using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using BulletHell.ObjectPool;
using BulletHell.Manager;

namespace BulletHell.Player
{
    public class PlayerShooterController : MonoBehaviour
    {
        [SerializeField] private GameObject _prefabBullet;
        [SerializeField] private Transform _bulletSpawner;
        [SerializeField] private float _speedBullet;

        private float _timeToShoot = .5f;
        private float _currentTimer;
        private float _burstDuration = 5f;
        private float _firerateTime = .1f;
        private float _firerateDuration = 3f;
        private int _bulletCount = 1;
        private bool _isBurst = false;
        private bool _isFirerate = false;

        public static UnityAction OnIncreaseBulletCount;
        public static UnityAction OnFirerate;

        private void OnEnable()
        {
            OnIncreaseBulletCount += GetBurstShoot;
            OnFirerate += GetFirerateShoot;
        }

        private void OnDisable()
        {
            OnIncreaseBulletCount -= GetBurstShoot;
            OnFirerate -= GetFirerateShoot;
        }

        private void Update()
        {
            if (!GameManager.Instance.GameOver)
            {
                BurstDuration();
                FirerateDuration();
                TimeToShoot();
            }
        }

        private void TimeToShoot()
        {
            _currentTimer -= Time.deltaTime;

            if (_currentTimer <= 0)
            {
                if (_isBurst)
                {
                    BurstShoot();
                }
                else
                {
                    NormalShoot();
                }

                if (_isFirerate)
                {
                    FirerateShoot();
                    return;
                }
                else
                {
                    NormalShoot();
                }

                _currentTimer = _timeToShoot;
            }
        }

        private void NormalShoot()
        {
            GameObject bullet = ObjectPoolController.Instance.GetFromPool("Bullet", _bulletSpawner.position, _bulletSpawner.rotation);

            Rigidbody2D rbBullet = bullet.GetComponent<Rigidbody2D>();
            if (rbBullet)
            {
                rbBullet.AddForce(_bulletSpawner.transform.up * _speedBullet);
            }
        }

        #region Burst Shoot
        private void BurstShoot()
        {
            float angleStep = 150 / _bulletCount;
            float angle = 0;

            for (int i = 0; i < _bulletCount; i++)
            {
                float bulletDirX = _bulletSpawner.position.x + Mathf.Sin((angle * Mathf.PI) / 180);
                float bulletDirY = _bulletSpawner.position.x + Mathf.Cos((angle * Mathf.PI) / 180);

                Vector3 bulletMove = new Vector3(bulletDirX, bulletDirY, 0f);
                Vector2 bulletDirection = (bulletMove - _bulletSpawner.position).normalized;

                GameObject bullet = ObjectPoolController.Instance.GetFromPool("Bullet", _bulletSpawner.position, _bulletSpawner.rotation);

                Rigidbody2D rbBullet = bullet.GetComponent<Rigidbody2D>();
                if (rbBullet)
                {
                    rbBullet.AddForce(bulletDirection * _speedBullet);
                }

                angle += angleStep;
            }
        }

        private void BurstDuration()
        {
            if (_isBurst)
            {
                _burstDuration -= Time.deltaTime;

                if (_burstDuration <= 0)
                {
                    _isBurst = false;
                    _burstDuration = 5f;
                }
            }
        }

        public void GetBurstShoot()
        {
            _isBurst = true;

            if(_bulletCount > 5)
            {
                _bulletCount = 1;
            }
            else
            {
                _bulletCount++;
            }
        }
        #endregion

        #region Firerate Shoot
        private void FirerateShoot()
        {
            _currentTimer = _firerateTime;
        }

        private void FirerateDuration()
        {
            if (_isFirerate)
            {
                _firerateDuration -= Time.deltaTime;

                if (_firerateDuration <= 0)
                {
                    _isFirerate = false;
                    _firerateDuration = 3f;
                }
            }
        }

        public void GetFirerateShoot()
        {
            _isFirerate = true;
        }
        #endregion
    }
}

