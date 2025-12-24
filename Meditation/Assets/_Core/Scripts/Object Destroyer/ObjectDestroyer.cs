using _Core.Scripts.Managers;
using _Core.Scripts.Objects.Collectable.GoodObjects;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<GoodObjectTest>() != null)
        {
            GoodObjectTest goodObject = collision.GetComponent<GoodObjectTest>();
            EventManager.Instance.OnPlayerTakeDamage(goodObject.damage);
            Destroy(collision.gameObject);
        }
    }
}
