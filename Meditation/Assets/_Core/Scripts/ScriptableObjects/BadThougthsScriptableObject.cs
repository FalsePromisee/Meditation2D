using UnityEngine;

[CreateAssetMenu(fileName = "BadThoughtsData", menuName = "ScriptableObjects/BadThoughts")]
public class BadThougthsScriptableObject : ScriptableObject
{
    public float speed;
    public int health;
    public int damageAmount;
}
