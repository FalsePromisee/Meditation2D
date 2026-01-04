using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _gameSettingsMenu;
    [SerializeField] private GameObject _howToPlayMenu;
    [SerializeField] private GameObject _mainMenu;

    private void Awake()
    {
        _mainMenu.SetActive(true);
        _gameSettingsMenu.SetActive(false);
        _howToPlayMenu.SetActive(false);
    }


    public void GameStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void HowToPlayMenuOpen()
    {
        _howToPlayMenu.SetActive(true);
        _mainMenu.SetActive(false);
    }

    public void HowToPlayMenuClose()
    {
        _howToPlayMenu.SetActive(false);
        _mainMenu.SetActive(true);
    }

    public void SettingsMenuOpen()
    {
        _gameSettingsMenu.SetActive(true);
        _mainMenu.SetActive(false);
    }

    public void SettingsMenuClose()
    {
        _mainMenu.SetActive(true);
        _gameSettingsMenu.SetActive(false);
    }
    
    
    
    
}
