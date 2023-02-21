using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            GameObject bullet = Instantiate(_prefabBullet, _bulletSpawner.position, _bulletSpawner.rotation);
            bullet.transform.SetParent(_bulletSpawner);

            Rigidbody2D rbBullet = bullet.GetComponent<Rigidbody2D>();
            if (rbBullet)
            {
                rbBullet.AddForce(_bulletSpawner.transform.up * _speedBullet);
            }
        }
    }
}

