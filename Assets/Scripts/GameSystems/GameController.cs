using System;
using System.Collections.Generic;
using DataScripts;
using GameSystems.Pools;
using Player;
using UI;
using UnityEngine;

namespace GameSystems
{
    public class GameController: MonoBehaviour
    {
        [SerializeField] private GameSettings _gameSettings;
        [SerializeField] private SpawnPoints _spawnPoints;
        private HealthBarHolder _barHolder;
        private GameMenuController _gameMenuController;
        private GameObject _player;
        
        private Pool _pool;
        private Spawner _spawner;

        private void Start()
        {
            _pool = new Pool(_gameSettings);
            _spawner = new Spawner(_spawnPoints);
            PoolManager.SetPool(_pool);
            
            _gameMenuController = GetComponent<GameMenuController>();
            _barHolder = GetComponent<HealthBarHolder>();
            _player = GameObject.FindWithTag("Player");
            _player.GetComponent<PlayerDamageController>().SetGameController(this);
            
            StartCoroutine(_spawner.SpawnWorker());
        }

        public void ChangeHealth(int health)
        {
            _barHolder.ChangeHealthPointsBar(health);
        }
        
        public void GameOver()
        {
            _player.SetActive(false);
            _gameMenuController.GameOverScreen();
        }
    }
}