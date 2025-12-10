using System;
using _Core.Scripts.Player;
using UnityEngine;

namespace _Core.Scripts.Objects.Collectable.Bad_Objects
{
    public class BadObjectTest : MonoBehaviour, ICollectable
    {
        private Rigidbody2D _rigidbody;
        [SerializeField] private Transform _playerTransform;
        [SerializeField] private float _moveSpeed;
        private Vector3 _test;
        private bool isReflected;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _test = (_playerTransform.position - transform.position ).normalized;
        }

        private void Update()
        {
            if (!isReflected)
            {
                Move();
            }

        }

        public void Move()
        {
            _rigidbody.linearVelocity = _test * (_moveSpeed * Time.deltaTime);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.GetComponent<PlayerStats>())
            {
                EventManager.OnPlayerTakeDamage();
                Debug.Log("Took Damage");
                Destroy(gameObject);
            }
        }
        
        

    }
}