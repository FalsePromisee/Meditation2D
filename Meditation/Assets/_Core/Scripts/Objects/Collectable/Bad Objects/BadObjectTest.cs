using System;
using _Core.Scripts.Player;
using UnityEngine;

namespace _Core.Scripts.Objects.Collectable.Bad_Objects
{
    public class BadObjectTest : MonoBehaviour, ICollectable
    {
        [SerializeField] private Transform _playerTransform;
        [SerializeField] private float _moveSpeed;
        private Rigidbody2D _rigidbody;
        private Vector3 _test;
        public bool isReflected { get; private set; }

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _test = (_playerTransform.position - transform.position ).normalized;
        }

        private void FixedUpdate()
        {
            if (!isReflected)
            {
                Move();
            }

        }

        public void Move()
        {
            _rigidbody.linearVelocity = _test * (_moveSpeed * Time.fixedDeltaTime);
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