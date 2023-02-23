using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BulletHell.Enemy;

namespace BulletHell.Bullet
{
    public class BulletController : MonoBehaviour
    {
        private void OnEnable()
        {
            Invoke("DestroyBullet", 1f);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                BaseEnemy enemy = collision.gameObject.GetComponent<BaseEnemy>();
                if (enemy)
                {
                    enemy.Attacked();
                }

                DestroyBullet();
            }
        }

        private void DestroyBullet()
        {
            gameObject.SetActive(false);
        }
    }
}
