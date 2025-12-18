using System;
using _Core.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _healthText;
    private int _score;
    private int _health = 10;

    private void Awake()
    {
        _scoreText.text = "Score: " + _score;
        _healthText.text = "Health: " + _health;
    }

    private void OnEnable()
    {
        EventManager.OnBadThoughtKilled += BadThoughtKill;
        EventManager.OnPlayerTookDamage += PlayerTookDamage;
    }

    private void PlayerTookDamage(int damageAmount)
    {
        _health -= damageAmount;
        _healthText.text = "Health: " + _health;
    }

    private void OnDisable()
    {
        EventManager.OnBadThoughtKilled -= BadThoughtKill;
    }

    private void BadThoughtKill(int pointsAmount)
    {
        _score += pointsAmount;
        _scoreText.text = "Score: " + _score;
    }
}
