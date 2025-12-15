using System;
using UnityEngine;

namespace _Core.Scripts
{
    public class EventManager : MonoBehaviour
    {
        public static EventManager Instance;
        public static event Action OnPlayerTookDamage;
        public static event Action OnPlayerDied;
        public static event Action OnPlayerHealed;

        private void Awake()
        {
            Instance = this;
        }
        
        public static void OnPlayerTakeDamage()
        {
            OnPlayerTookDamage?.Invoke();
        }

        public static void OnPlayerDeath()
        {
            OnPlayerDied?.Invoke();
        }

        public static void OnPlayerHeal()
        {
            OnPlayerHealed?.Invoke();
        }
        
    }
}