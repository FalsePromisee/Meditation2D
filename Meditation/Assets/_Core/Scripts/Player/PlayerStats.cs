using _Core.Scripts.Interfaces;
using _Core.Scripts.Managers;
using _Core.Scripts.Objects.Collectable.GoodObjects;
using System;
using TMPro;
using UnityEngine;

namespace _Core.Scripts.Player
{
    public class PlayerStats : MonoBehaviour, IGoodObjectDrop
    {
        [SerializeField] private ParticleSystem _takeDamageParticle;
        private int _maxHealth = 10;
        public int _currentHealth { get; private set; }

        private void Awake()
        {
            _currentHealth = _maxHealth;
        }

        private void RestoreHealth()
        {
            _currentHealth++;
            if (_currentHealth > _maxHealth)
            {
                _currentHealth = _maxHealth;
            };
        }


        public void TakeDamage(int damageAmount)
        {
            _currentHealth = _currentHealth - damageAmount;
            Debug.Log("Health left" + _currentHealth);
            ExplodeParitcleOnTakeDamage();
            if (_currentHealth <= 0)
            {
                EventManager.Instance.OnPlayerDeath();
            }
        }

        public void OnGoodObjectDrop(GoodObjectTest goodThought)
        {
            goodThought.transform.position = transform.position;
            RestoreHealth();
            EventManager.Instance.OnGoodObjectCollect(goodThought.additionalHealth, goodThought.additionalPoints);
        }

        private void ExplodeParitcleOnTakeDamage()
        {
            ParticleSystem damageParticle = Instantiate(_takeDamageParticle, transform.position, Quaternion.identity);
            damageParticle.Play();
        }

        private void OnEnable()
        {
            EventManager.OnPlayerTookDamage += TakeDamage;
        }
        private void OnDisable()
        {
            EventManager.OnPlayerTookDamage -= TakeDamage;
        }

    }
}