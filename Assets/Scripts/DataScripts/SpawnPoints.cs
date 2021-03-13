using System.Collections.Generic;
using UnityEngine;

namespace DataScripts
{
    [CreateAssetMenu(fileName = "points", menuName = "GameData/SpawnPoints", order = 0)]
    public class SpawnPoints : ScriptableObject
    {
        public List<Vector2> spawnPoints;
    }
}