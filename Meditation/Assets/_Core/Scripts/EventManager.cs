using System;
using UnityEngine;

namespace _Core.Scripts
{
    public class EventManager : MonoBehaviour
    {
        public static EventManager Instance;
        public static event Action<int> OnPlayerTookDamage;
        public static event Action OnPlayerDied;
        public static event Action OnPlayerHealed;

        public static event Action<int> OnBadThoughtKilled;

        private void Awake()
        {
            Instance = this;
        }
        
        public void OnPlayerTakeDamage(int damage)
        {
            OnPlayerTookDamage?.Invoke(damage);
        }

        public void OnPlayerDeath()
        {
            OnPlayerDied?.Invoke();
        }

        public void OnPlayerHeal()
        {
            OnPlayerHealed?.Invoke();
        }
        
        public void OnBadThoughtKill(int pointsAmount)
        {
            OnBadThoughtKilled?.Invoke(pointsAmount);
        }
    }
}