using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Core.Scripts.Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        [SerializeField] private GameObject _pauseMenu;
        [SerializeField] private GameObject _pauseButton;
        [SerializeField] private GameObject _gameOverMenu;
        
        private void Awake()
        {
            Time.timeScale = 1;
            Instance = this;
            _pauseMenu.SetActive(false);
            _gameOverMenu.SetActive(false);
            Cursor.visible = false;
        }

        public void StopGame()
        {
            _pauseMenu.SetActive(true);
            _pauseButton.SetActive(false);
            EventManager.Instance.OnGamePause();
            Time.timeScale = 0;
            Cursor.visible = true;
        }

        public void ResumeGame()
        {
            _pauseMenu.SetActive(false);
            _pauseButton.SetActive(true);
            EventManager.Instance.OnGameUnpause();
            Time.timeScale = 1;
            Cursor.visible = false;
        }

        public void ReturnToMenu()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(0);
        }

        public void RestartGame()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Cursor.visible = false;
        }
        
        private void OnEnable()
        {
            EventManager.OnPlayerDied += PlayerDead;
        }

        private void OnDisable()
        {
            EventManager.OnPlayerDied -= PlayerDead;
        }

        private void PlayerDead()
        {
            Time.timeScale = 0;
            _pauseButton.SetActive(false);
            _gameOverMenu.SetActive(true);
            Debug.Log("Player Dead (game manager log)");
        }
        
    }
}
