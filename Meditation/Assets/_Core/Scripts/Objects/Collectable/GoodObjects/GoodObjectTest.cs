using UnityEngine;

namespace _Core.Scripts.Objects.Collectable.GoodObjects
{
    public class GoodObjectTest : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed;

        private Rigidbody2D _rigidbody;
        private TestDirectionObjects[] _objectVelocityDirection;
        private Vector3 _objectDirection;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _objectVelocityDirection = FindObjectsByType<TestDirectionObjects>(FindObjectsSortMode.None);
            int randomValue = Random.Range(0, _objectVelocityDirection.Length);
            _objectDirection = (_objectVelocityDirection[randomValue].transform.position - transform.position).normalized;
            Move();
        }

        private void Move()
        {
            _rigidbody.linearVelocity = _objectDirection * _moveSpeed;
        }
    }
}
