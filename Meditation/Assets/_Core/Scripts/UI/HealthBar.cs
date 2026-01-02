using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;

    private void Awake()
    {
        gameObject.SetActive(false);
    }
    public void UpdateHealthBar(float currantHealth, float maxHealth)
    {
        gameObject.SetActive(true);
        slider.value = currantHealth / maxHealth;
    }
}
