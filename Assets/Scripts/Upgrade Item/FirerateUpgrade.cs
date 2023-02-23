using BulletHell.Manager;
using BulletHell.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BulletHell.UpgradeItem
{
    public class FirerateUpgrade : BaseUpgradeItem
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                PlayerShooterController.OnFirerate?.Invoke();
                gameObject.SetActive(false);
            }
        }
    }
}
