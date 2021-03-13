using System.Collections.Generic;
using Bullet;
using Enemies;
using GameSystems;
using UnityEngine;
using UnityEngine.Serialization;

namespace DataScripts
{
    [CreateAssetMenu(fileName = "gameData", menuName = "GameData/GameSettings", order = 0)]
    public class GameSettings : ScriptableObject
    {
        [Header("Pools")] 
        public List<PoolObject> pools;

        [Header("AsteroidsSprites")] 
        public List<Sprite> asteroids;
    }
}