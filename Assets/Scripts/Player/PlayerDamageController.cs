using System;
using GameSystems;
using UnityEngine;

namespace Player
{
    public class PlayerDamageController : MonoBehaviour
    {
        private int _health = 3;
        private GameController _gameController;
        
        private readonly CooldownCounter _cooldownCounter = new CooldownCounter(2.0f);
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!_cooldownCounter.IsCooldown && other.gameObject.layer == 8)
            {
                _cooldownCounter.CooldownTrigger();
                _health--;
                HealthChecker();
            }
        }

        public void SetGameController(GameController controller)
        {
            _gameController = controller;
        }
        
        private void FixedUpdate()
        {
            _cooldownCounter.CooldownCount();
        }

        private void HealthChecker()
        {
            _gameController.ChangeHealth(_health);
            if (_health == 0)
            {
                _gameController.GameOver();
            }
        }

    }
}
