using System;
using _Core.Scripts.Objects.Collectable.Bad_Objects;
using UnityEngine;

namespace _Core.Scripts.Player
{
    public class PlayerStats : MonoBehaviour
    {
        private int _maxHealth = 10;
        public int _currentHealth { get; private set; }

        private void Awake()
        {
            _currentHealth = _maxHealth;
        }
        

        public void TakeDamage(int damageAmount)
        {
            _currentHealth =- damageAmount;
            Debug.Log("Health left" + _currentHealth);
            if (_currentHealth <= 0)
            {
                Debug.Log("Player dead");
            }
        }
    }
}