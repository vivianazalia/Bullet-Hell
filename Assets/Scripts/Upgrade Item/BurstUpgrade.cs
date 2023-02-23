using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BulletHell.Player;
using BulletHell.Manager;

namespace BulletHell.UpgradeItem
{
    public class BurstUpgrade : BaseUpgradeItem
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                PlayerShooterController.OnIncreaseBulletCount?.Invoke();
                gameObject.SetActive(false);
            }
        }
    }
}

