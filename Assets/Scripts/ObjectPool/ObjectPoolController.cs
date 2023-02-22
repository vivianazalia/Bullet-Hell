using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BulletHell.ObjectPool
{
    public class ObjectPoolController : MonoBehaviour
    {
        [System.Serializable]
        public struct Pool
        {
            public string tag;
            public GameObject prefab;
            public int size;
        }

        [SerializeField] private List<Pool> _pools;

        private Dictionary<string, Queue<GameObject>> _poolDictionary;

        public static ObjectPoolController Instance = null;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            _poolDictionary = new Dictionary<string, Queue<GameObject>>();

            InitializePool();
        }

        private void InitializePool()
        {
            foreach(var pool in _pools)
            {
                Queue<GameObject> objectPool = new Queue<GameObject>();

                int i = 0; 

                while(i < pool.size)
                {
                    GameObject obj = Instantiate(pool.prefab);
                    obj.transform.SetParent(transform);
                    obj.SetActive(false);
                    objectPool.Enqueue(obj);
                    i++;
                }

                _poolDictionary.Add(pool.tag, objectPool);
            }
        }

        public GameObject GetFromPool(string tag, Vector2 position, Quaternion rotation)
        {
            if (!_poolDictionary.ContainsKey(tag)) return null;
            
            GameObject objectToSpawn = _poolDictionary[tag].Dequeue();
            objectToSpawn.SetActive(true);
            objectToSpawn.transform.position = position;
            objectToSpawn.transform.rotation = rotation;

            _poolDictionary[tag].Enqueue(objectToSpawn);

            return objectToSpawn;
        }
    }
}

