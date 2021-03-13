using System.Collections;
using DataScripts;
using GameSystems.Pools;
using UnityEngine;

namespace GameSystems
{
    public class Spawner
    {
        private readonly SpawnPoints _points;
        private readonly float _timerSeconds = 1.0f;
        public Spawner(SpawnPoints points)
        {
            _points = points;
        }

        public IEnumerator SpawnWorker()
        {
            while (true)
            {
                yield return new WaitForSeconds(_timerSeconds);
                PoolManager.SetActiveObject("asteroids", _points.spawnPoints[Random.Range(0, _points.spawnPoints.Count - 1)], new Quaternion());
            }
        }
    }
}