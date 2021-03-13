using System;
using System.Collections.Generic;
using DataScripts;
using UnityEngine;
using Object = UnityEngine.Object;

namespace GameSystems.Pools
{
    public class Pool
    {
        private readonly GameSettings _gameSettings;
        private readonly Dictionary<String, PoolGameObject[]> _pool = new Dictionary<string, PoolGameObject[]>();
        
        public Dictionary<String, PoolGameObject[]> PoolData => _pool;
        
        public Pool(GameSettings gameSettings)
        {
            _gameSettings = gameSettings;
            Initialisation();
        }

        private void Initialisation()
        {
            foreach (var pool in _gameSettings.pools)
            {
                var objectsPool = new PoolGameObject[pool.size];

                for (int i = 0; i < pool.size; i++)
                {
                    GameObject obj = Object.Instantiate(pool.prefab);
                    obj.SetActive(false);
                    objectsPool[i] = new PoolGameObject();
                    objectsPool[i].GameObject = obj;
                    objectsPool[i].PoolObject = obj.GetComponent<IPoolObject>();
                }
                
                _pool.Add(pool.tag, objectsPool);
            }
        }
    }
}