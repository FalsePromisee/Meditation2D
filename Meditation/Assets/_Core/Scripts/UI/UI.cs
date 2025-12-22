using _Core.Scripts.Managers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _healthText;
    private int _score;
    private int _maxHealth = 10;
    private int _health = 10;

    private void Awake()
    {
        _scoreText.text = "Score: " + _score;
        _healthText.text = "Health: " + _health;
    }

    
    private void OnEnable() // subscribing and unsubscribing on events
    {
        EventManager.OnBadThoughtKilled += BadThoughtKill;
        EventManager.OnPlayerTookDamage += PlayerTookDamage;
        EventManager.OnGoodObjectCollected += GoodObjectCollected;
    }

    

    private void OnDisable()
    {
        EventManager.OnBadThoughtKilled -= BadThoughtKill;
        EventManager.OnPlayerTookDamage -= PlayerTookDamage;
    }

    //event's methods
    private void BadThoughtKill(int pointsAmount)
    {
        _score += pointsAmount;
        _scoreText.text = "Score: " + _score;
    }
    private void PlayerTookDamage(int damageAmount)
    {
        _health -= damageAmount;
        _healthText.text = "Health: " + _health;
    }
    private void GoodObjectCollected(int health, int pointsAmount)
    {
        _score += pointsAmount;
        _scoreText.text = "Score: " + _score;
        
        _health += health;
        _healthText.text = "Health: " + _health;
        if (_health >= _maxHealth)
        {
            _health = _maxHealth;
        }
    }
}
