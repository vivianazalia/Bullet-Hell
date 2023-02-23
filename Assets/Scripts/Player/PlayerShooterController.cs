using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

        private void Start()
        {
            //InvokeRepeating("Shoot", 0f, .5f);
        }

        private void Update()
        {
            if (!GameManager.Instance.GameOver)
            {
                TimeToShoot();
            }
        }

        private void Shoot()
        {
            GameObject bullet = ObjectPoolController.Instance.GetFromPool("Bullet", _bulletSpawner.position, _bulletSpawner.rotation);

            Rigidbody2D rbBullet = bullet.GetComponent<Rigidbody2D>();
            if (rbBullet)
            {
                rbBullet.AddForce(_bulletSpawner.transform.up * _speedBullet);
            }
        }

        private void TimeToShoot()
        {
            _currentTimer -= Time.deltaTime;

            if (_currentTimer <= 0)
            {
                Shoot();
                _currentTimer = _timeToShoot;
            }
        }
    }
}

