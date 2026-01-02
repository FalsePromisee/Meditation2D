using TMPro;
using UnityEngine;

public class TextPopup : MonoBehaviour
{
    private TextMeshPro _textPopup;
    private Color _textPopupColor;

    private int _moveYSpeed = 3;
    private float _dissapearTime = .5f;
    private float _dissapearSpeed = 3f;


    private void Awake()
    {
        _textPopup = GetComponent<TextMeshPro>();
    }
    private void Update()
    {
        transform.position += new Vector3(0, _moveYSpeed) * Time.deltaTime;

        _dissapearTime -= Time.deltaTime;
        if (_dissapearTime <= 0)
        {
            _textPopupColor.a -= _dissapearSpeed * Time.deltaTime;
            _textPopup.color = _textPopupColor;
            if (_textPopupColor.a <= 0)
            {
                Destroy(gameObject);
            }
        }
        
    }

    public static TextPopup Create(Vector3 position, int damage)
    {
        Transform damagePopupTransform = Instantiate(PrefabManager.Inst.damagePopup, position, Quaternion.identity);
        TextPopup damagePopup = damagePopupTransform.GetComponent<TextPopup>();
        damagePopup.Setup(damage);
        return damagePopup;
    }

    public void Setup(int damageTaken)
    {
        _textPopup.SetText(damageTaken.ToString());
        _textPopupColor = _textPopup.color;
    }

    

}
