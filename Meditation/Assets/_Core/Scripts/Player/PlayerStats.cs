using System;
using UnityEngine;

namespace _Core.Scripts.Player
{
    public class PlayerStats : MonoBehaviour
    {
        private int _maxHealth = 5;
        public int _currentHealth { get; private set; }

        private void Awake()
        {
            _currentHealth = _maxHealth;
        }

        
        
        public void TakeDamage()
        {
            _currentHealth --;
            if (_currentHealth <= 0)
            {
                Debug.Log("Player dead");
            }
        }

        public void Heal()
        {
            _currentHealth ++;
            if (_currentHealth > _maxHealth)
            {
                _currentHealth = _maxHealth;
            }
        }
    }
}