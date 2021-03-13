using System;
using UnityEngine;
using GameSystems.Pools;

namespace Player
{
    public class PlayerShootController : MonoBehaviour
    {
        private readonly CooldownCounter _cooldownCounter = new CooldownCounter(0.2f);

        private void Update()
        {
            if (Input.GetKey(KeyCode.Space) && !_cooldownCounter.IsCooldown)
            {
                _cooldownCounter.CooldownTrigger();
                Shoot();
            }

            _cooldownCounter.CooldownCount();
        }

        private void Shoot()
        {
            PoolManager.SetActiveObject("player_bullets", transform.position, transform.rotation);
        }
    }
}