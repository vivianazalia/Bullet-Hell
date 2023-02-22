using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BulletHell.Enemy;
using BulletHell.ObjectPool;

namespace BulletHell.Spawner
{
    public class EnemySpawner : MonoBehaviour
    {
        [System.Serializable]
        public struct EnemyType
        {
            public string tag;
        }

        [SerializeField] private List<EnemyType> _enemyList = new List<EnemyType>();
        [SerializeField] private Transform _angryEnemySpawner;
        [SerializeField] private Transform _basicEnemySpawner;
        [SerializeField] private Transform _tankerEnemySpawner;
        [SerializeField] private Transform _motherEnemySpawner;
        [SerializeField] private int _angryEnemyCount;
        [SerializeField] private int _basicEnemyCount;
        [SerializeField] private int _tankerEnemyCount;
        [SerializeField] private int _motherEnemyCount;

        private void Start()
        {
            Spawn("AngryEnemy", _angryEnemySpawner);
        }

        private void Update()
        {
            
        }

        private void Spawn(string tag, Transform spawner)
        {
            foreach(var enemy in _enemyList)
            {
                if(enemy.tag == tag)
                {
                    ObjectPoolController.Instance.GetFromPool(tag, spawner.position, spawner.rotation);
                }
            }
        }

        IEnumerator SpawnAngryEnemy()
        {
            for(int i = 0; i < _angryEnemyCount; i++)
            {
                Spawn("AngryEnemy", _angryEnemySpawner);
            }
            yield return new WaitForSeconds(3f);
        }
    }
}

