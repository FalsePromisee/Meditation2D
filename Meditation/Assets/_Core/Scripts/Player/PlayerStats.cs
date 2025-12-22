using _Core.Scripts.Managers;
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
            _currentHealth = _currentHealth - damageAmount;
            EventManager.Instance.OnPlayerTakeDamage(damageAmount);
            Debug.Log("Health left" + _currentHealth);
            if (_currentHealth <= 0)
            {
                Debug.Log("Player dead (Player stats log)");
                EventManager.Instance.OnPlayerDeath();
            }
        }
    }
}