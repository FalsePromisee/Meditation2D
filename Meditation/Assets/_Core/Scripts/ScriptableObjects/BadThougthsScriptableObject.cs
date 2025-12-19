using _Core.Scripts.Enum;
using UnityEngine;

[CreateAssetMenu(fileName = "BadThoughtsData", menuName = "ScriptableObjects/BadThoughts")]
public class BadThougthsScriptableObject : ScriptableObject
{
    public float speed;
    public int health;
    public int damageAmount;
    public int pointsAmount;
    public ThoughtType  thoughtType;
}
