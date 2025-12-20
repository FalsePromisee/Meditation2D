using System;
using UnityEngine;

namespace _Core.Scripts.Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        
        public bool isPlayerAlive = true;
        private void Awake()
        {
            Instance = this;
        }

        public void StopGame()
        {
            
        }

        public void ResumeGame()
        {
            
        }
        
        private void OnEnable()
        {
            EventManager.OnPlayerDied += PlayerDead;
        }

        private void PlayerDead()
        {
            Debug.Log("Player Dead");
            isPlayerAlive = false;
        }
    }
}
