using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BulletHell.ObjectPool;

namespace BulletHell.Player
{
    public class PlayerShooterController : MonoBehaviour
    {
        [SerializeField] private GameObject _prefabBullet;
        [SerializeField] private Transform _bulletSpawner;
        [SerializeField] private float _speedBullet;

        private void Update()
        {
            InputHandle();
        }

        private void InputHandle()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Shoot();
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
    }
}

