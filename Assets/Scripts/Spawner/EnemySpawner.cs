using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BulletHell.Enemy;
using BulletHell.ObjectPool;
using BulletHell.Manager;

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
        [SerializeField] private Transform _tankerEnemySpawner;
        [SerializeField] private Transform _motherEnemySpawner;

        private float _timeToSpawnAngryEnemy = .5f;
        private float _timeToSpawnTankerEnemy = 1.5f;
        private float _timeToSpawnMotherEnemy = 10f;
        private float _currentTimerAngryEnemy;
        private float _currentTimerTankerEnemy;
        private float _currentTimerMotherEnemy;

        private void Update()
        {
            if (!GameManager.Instance.GameOver)
            {
                ReduceTimer();
            }
        }

        private void Spawn(string tag, Vector2 position, Quaternion rotation)
        {
            foreach(var enemy in _enemyList)
            {
                if(enemy.tag == tag)
                {
                    ObjectPoolController.Instance.GetFromPool(tag, position, rotation);
                }
            }
        }

        private void SpawnAngryEnemy()
        {
            float randomX = Random.Range(-2.5f, 2.5f);
            Vector2 position = new Vector2(randomX, _angryEnemySpawner.position.y);
            Spawn("AngryEnemy", position, _angryEnemySpawner.rotation);
        }

        private void SpawnMotherEnemy()
        {
            float randomX = Random.Range(-2, 2);
            Vector2 position = new Vector2(randomX, _motherEnemySpawner.position.y);
            Spawn("MotherEnemy", position, _motherEnemySpawner.rotation);
        }

        private void SpawnTankerEnemy()
        {
            float randomX = Random.Range(-2.5f, 2.5f);
            Vector2 position = new Vector2(randomX, _tankerEnemySpawner.position.y);
            Spawn("TankerEnemy", position, _tankerEnemySpawner.rotation);
        }

        private void ReduceTimer()
        {
            _currentTimerAngryEnemy -= Time.deltaTime;
            _currentTimerTankerEnemy -= Time.deltaTime;
            _currentTimerMotherEnemy -= Time.deltaTime;

            if(_currentTimerAngryEnemy <= 0)
            {
                SpawnAngryEnemy();
                _currentTimerAngryEnemy = _timeToSpawnAngryEnemy;
            }

            if (_currentTimerMotherEnemy <= 0)
            {
                SpawnMotherEnemy();
                _currentTimerMotherEnemy = _timeToSpawnMotherEnemy;
            }

            if (_currentTimerTankerEnemy <= 0)
            {
                SpawnTankerEnemy();
                _currentTimerTankerEnemy = _timeToSpawnTankerEnemy;
            }
        }
    }
}

