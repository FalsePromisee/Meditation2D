using System;
using UnityEngine;

namespace _Core.Scripts.Managers
{
    public class EventManager : MonoBehaviour
    {
        public static EventManager Instance;
        public static event Action<int> OnPlayerTookDamage;
        public static event Action OnPlayerDied;
        public static event Action OnGamePaused;
        public static event Action OnGameUnpaused;
        public static event Action<int, int> OnGoodObjectCollected;

        public static event Action<int> OnBadThoughtKilled;

        public static event Action OnMouseRelesed;
        public static event Action OnMouseHolded;
        public static event Action OnMouseIdled;

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
        
        public void OnBadThoughtKill(int pointsAmount)
        {
            OnBadThoughtKilled?.Invoke(pointsAmount);
        }

        public void OnGoodObjectCollect(int health, int pointsAmount)
        {
            OnGoodObjectCollected?.Invoke(health, pointsAmount);
        }

        public void OnGamePause()
        {
            OnGamePaused?.Invoke();
        }

        public void OnGameUnpause()
        {
            OnGameUnpaused?.Invoke();
        }

        public void OnMouseRelese()
        {
            OnMouseRelesed?.Invoke();
        }

        public void OnMouseHold()
        {
            OnMouseHolded?.Invoke();
        }
        public void OnMouseIdle()
        {
            OnMouseIdled?.Invoke();
        }
    }
}