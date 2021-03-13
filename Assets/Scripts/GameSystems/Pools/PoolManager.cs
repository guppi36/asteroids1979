using UnityEngine;

namespace GameSystems.Pools
{
    public static class PoolManager
    {
        private static Pool _pool;

        public static void SetPool(Pool pool)
        {
            _pool = pool;
        }

        public static GameObject SetActiveObject(string objectType, Vector2 position, Quaternion quaternion)
        {
            var objectsPool = _pool.PoolData[objectType];
            foreach (var t in objectsPool)
            {
                if(t.GameObject.activeSelf) continue;
                t.GameObject.SetActive(true);
                t.GameObject.transform.localPosition = position;
                t.GameObject.transform.rotation = quaternion;
                t.PoolObject.StartSpawn();
                return t.GameObject;
            }

            return null;
        }

        public static GameObject SetNoActiveObject(string objectType, int objectID)
        {
            var objectsPool = _pool.PoolData[objectType];
            foreach (var t in objectsPool)
            {
                if(t.GameObject.GetInstanceID() != objectID) continue;
                t.GameObject.SetActive(false);
                t.GameObject.transform.rotation = new Quaternion();
                t.GameObject.transform.localPosition = Vector2.zero;
                t.PoolObject.StopSpawn();
                return t.GameObject;
            }

            return null;
        }
    }
}