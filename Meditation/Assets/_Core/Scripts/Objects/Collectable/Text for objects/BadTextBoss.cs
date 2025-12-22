using TMPro;
using UnityEngine;

public class BadTextBoss : MonoBehaviour
{
    [SerializeField] private TextMeshPro _BossText;
    void Start()
    {
        int randomIndex = Random.Range(0, 3);
        RandomText(randomIndex);
    }

    private void RandomText(int randomIndex)
    {
        switch (randomIndex)
        {
            case 0:
                _BossText.text = "Drink alcohol";
                break;
                case 1:
                _BossText.text = "Play Dota2";
                break;
                case 2:
                _BossText.text = "Play CS";
                break;
        }

    }
    
}
