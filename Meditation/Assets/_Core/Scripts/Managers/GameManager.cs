using System;
using UnityEngine;

namespace _Core.Scripts.Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        [SerializeField] private GameObject _pauseMenu;
        [SerializeField] private GameObject _pauseButton;
        
        private void Awake()
        {
            Instance = this;
            _pauseMenu.SetActive(false);
        }

        public void StopGame()
        {
            _pauseMenu.SetActive(true);
            _pauseButton.SetActive(false);
            Time.timeScale = 0;
        }

        public void ResumeGame()
        {
            _pauseMenu.SetActive(false);
            _pauseButton.SetActive(true);
            Time.timeScale = 1;
        }
        
        private void OnEnable()
        {
            EventManager.OnPlayerDied += PlayerDead;
        }

        private void PlayerDead()
        {
            Debug.Log("Player Dead");
        }
    }
}
