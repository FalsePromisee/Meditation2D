using TMPro;
using UnityEngine;

public class GoodThougthText : MonoBehaviour
{
    [SerializeField] private TextMeshPro _goodThoughtText;
    void Start()
    {
        int randomIndex = Random.Range(0, 3);
        RandomGoodText(randomIndex);
    }

    private void RandomGoodText(int randomIndex)
    {
        switch (randomIndex)
        {
            case 0:
                    _goodThoughtText.text = "Sleep 8 hours";
                break;
            case 1:
                _goodThoughtText.text = "Don't eat shit";
                break;
            case 2:
                _goodThoughtText.text = "Read books";
                break;
            case 3:
                _goodThoughtText.text = "Learn new staff";
                break;
        }
    }
}
