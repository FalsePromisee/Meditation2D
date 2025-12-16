using _Core.Scripts.Interfaces;
using _Core.Scripts.Player;
using _Core.Scripts;
using UnityEngine;

namespace _Core.Scripts.Objects.Collectable.Bad_Objects
{
    public class BadThoughts : MonoBehaviour, IMovable, IBadThoughts
    {
        
        [SerializeField] private float _moveSpeed;
        private int _currentHealth = 10;
        private PlayerStats _playerTransform;
        private Rigidbody2D _rigidbody;
        private Vector3 _objectVelocityDirection;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _playerTransform = FindFirstObjectByType<PlayerStats>().GetComponent<PlayerStats>();
            _objectVelocityDirection = (_playerTransform.transform.position - transform.position ).normalized;
            Move();
        }

        
        
        public void Move()
        {
            _rigidbody.linearVelocity = _objectVelocityDirection * _moveSpeed;
        }

        public void TakeDamage()
        {
            _currentHealth--;
            if (_currentHealth <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}