using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace GameSystems
{
    [Serializable]
    public class PoolObject
    {
        public String tag;
        public GameObject prefab;
        public int size;
    }
}