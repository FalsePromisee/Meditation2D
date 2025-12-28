using _Core.Scripts.Managers;
using _Core.Scripts.Objects.Collectable.GoodObjects;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<GoodObjectTest>() != null)
        {
            GoodObjectTest goodObject = collision.collider.GetComponent<GoodObjectTest>();
            EventManager.Instance.OnPlayerTakeDamage(goodObject.damage);
            Destroy(collision.gameObject);
        }
    }
   
}
