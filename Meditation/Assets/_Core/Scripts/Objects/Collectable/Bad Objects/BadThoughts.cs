using System;
using _Core.Scripts.Interfaces;
using _Core.Scripts.Player;
using _Core.Scripts.Managers;
using UnityEngine;

namespace _Core.Scripts.Objects.Collectable.Bad_Objects
{
    public class BadThoughts : MonoBehaviour, IMovable, IBadThoughts
    {
        [SerializeField] private BadThougthsScriptableObject badThoughtsData;
        [SerializeField] private ParticleSystem _explosionEffect;
        
        private PlayerStats _playerTransform;
        private Rigidbody2D _rigidbody;
        private Vector3 _objectVelocityDirection;

        private int _currentHealth;
        
        private void Start()
        {
            _currentHealth = badThoughtsData.health;
            _rigidbody = GetComponent<Rigidbody2D>();
            _playerTransform = FindFirstObjectByType<PlayerStats>().GetComponent<PlayerStats>();
            _objectVelocityDirection = (_playerTransform.transform.position - transform.position ).normalized;
            Move();
        }
        

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponent<PlayerStats>())
            {
                PlayerStats playerStats = other.GetComponent<PlayerStats>();
                playerStats.TakeDamage(badThoughtsData.damageAmount);
                Destroy(gameObject);
            }
        }
        
        
        public void Move()  //giving object direction and velocity to move
        {
            _rigidbody.linearVelocity = _objectVelocityDirection * badThoughtsData.speed;
        }

        public void TakeDamage()
        {
            _currentHealth--;
            if (_currentHealth <= 0)
            {
                Explode();
                Destroy(this.gameObject);
                EventManager.Instance.OnBadThoughtKill(badThoughtsData.pointsAmount);
            }
        }

        private void Explode()
        {
            ParticleSystem _particleTest = Instantiate(_explosionEffect, transform.position, Quaternion.identity);
                _particleTest.Play();
             
        }
    }
}