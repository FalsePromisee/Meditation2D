using System;
using _Core.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    private int _score = 0;

    private void Awake()
    {
        _scoreText.text = "Score: " + _score;
        
    }

    private void OnEnable()
    {
        EventManager.OnBadThoughtKilled += BadThoughtKill;
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
