using System;
using System.Collections;
using System.Collections.Generic;
using DataScripts;
using GameSystems;
using GameSystems.Pools;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace Enemies
{
    public class Asteroid : MonoBehaviour, IPoolObject
    {
        [SerializeField] private GameSettings settings;
        private Rigidbody2D _rbody;
        private SpriteRenderer _sprite;
        private float _movementSpeed = 1f;
        private AsteroidType _type;
        private Vector2 _endPoint;

        private Vector3 _rotation;
        private Action _moving;

        private void OnEnable()
        {
            _rbody = GetComponent<Rigidbody2D>();
            _sprite = GetComponentInChildren<SpriteRenderer>();
        }

        void FixedUpdate()
        {
            _moving?.Invoke();
        }

        public void SetType(AsteroidType type)
        {
            _type = type;
        }
        
        private void MoveToPosition()
        {
            Vector2 currentPos = _rbody.position;
            Vector2 normPosit = new Vector2(_endPoint.x - currentPos.x, _endPoint.y - currentPos.y);
            normPosit = Vector2.ClampMagnitude(normPosit, 1);
            Vector2 movement = normPosit * _movementSpeed;
            Vector2 newPos = currentPos + movement * Time.fixedDeltaTime;
            _rbody.MovePosition(newPos);
        }
        
        private void Rotate()
        {
            transform.Rotate(_rotation);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer != 9) return;
            if (_type == AsteroidType.Small)
            {
                PoolManager.SetNoActiveObject("asteroids", gameObject.GetInstanceID());
            }
            else
            {
                int smallAsteroidsCount = Random.Range(1, 4);
                for (int i = 0; i < smallAsteroidsCount; i++)
                {
                    var aster = PoolManager.SetActiveObject("asteroids", transform.position, transform.rotation);
                    aster.GetComponent<Asteroid>().SetType(AsteroidType.Small);
                    aster.GetComponent<Asteroid>().StartSpawn();
                }

                PoolManager.SetNoActiveObject("asteroids", gameObject.GetInstanceID());
            }
            ScoreController.ChangeScore(1);
        }

        public void StartSpawn()
        {
            _rotation = new Vector3(0,0, Random.Range(-1, 1));
            _sprite.sprite = settings.asteroids[Random.Range(0, 4)];
            _endPoint = new Vector2(transform.position.x * -1, transform.position.y * -1);
            if (_type == AsteroidType.Small)
            {
                transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                _moving = null;
                _moving += Rotate;
                _moving += DeathByScreen;
                _rbody.AddForce(new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)) * 1.0f, ForceMode2D.Impulse);
            }
            else
            {
                transform.localScale = Vector3.one;
                _moving += Rotate;
                _moving += MoveToPosition;
                _moving += DeathByScreen;
            }
        }

        public void StopSpawn()
        {
            _type = AsteroidType.Big;
        }

        private void DeathByScreen()
        {
            if((Math.Abs(transform.position.x) > 10 || Math.Abs(transform.position.y) > 10) 
               || Vector2.Distance(transform.position, _endPoint) < 0.5)
                PoolManager.SetNoActiveObject("asteroids", gameObject.GetInstanceID());
        }
    }

    public enum AsteroidType
    {
        Big,
        Small
    }
}
