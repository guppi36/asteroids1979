using System;
using GameSystems.Pools;
using UnityEngine;

namespace Bullet
{
    public class PlayerBullet : MonoBehaviour, IPoolObject
    {
        private Rigidbody2D _rbody;
        private float _lifeTime = 3.0f;
        private float _timer;
        private void OnEnable()
        {
            _rbody = GetComponent<Rigidbody2D>();
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer == 8)
            {
                PoolManager.SetNoActiveObject("player_bullets", gameObject.GetInstanceID());
            }
        }

        private void FixedUpdate()
        {
            _timer -= Time.fixedDeltaTime;
            if (_timer <= 0)
            {
                PoolManager.SetNoActiveObject("player_bullets", gameObject.GetInstanceID());
            }
        }

        public void StartSpawn()
        {
            _timer = _lifeTime;
            _rbody.AddForce(transform.up * 10f, ForceMode2D.Impulse);
        }

        public void StopSpawn()
        {
            
        }
    }
}
