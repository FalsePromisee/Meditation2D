using System;
using _Core.Scripts.Objects.Collectable.Bad_Objects;
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


        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponent<BadObjectTest>())
            {
                TakeDamage();
                Debug.Log("Hit");
                Destroy(other.gameObject);
            }
        }


        private void TakeDamage()
        {
            _currentHealth --;
            Debug.Log("Health left" + _currentHealth);
            if (_currentHealth <= 0)
            {
                Debug.Log("Player dead");
            }
        }
    }
}