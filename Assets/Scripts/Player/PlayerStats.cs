using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BulletHell.Manager;

namespace BulletHell.Player
{
    public class PlayerStats : MonoBehaviour
    {
        [SerializeField] private int _health;

        private void Start()
        {
            UIManager.OnChangeHealthPlayer?.Invoke(_health);
        }

        public void DecreaseHealth()
        {
            if (_health <= 0)
            {
                GameManager.OnGameOver?.Invoke(true);
            }

            _health--;
            UIManager.OnChangeHealthPlayer?.Invoke(_health);
        }
    }
}

