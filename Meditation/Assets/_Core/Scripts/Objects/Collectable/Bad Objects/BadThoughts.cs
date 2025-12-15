using System;
using System.Collections;
using _Core.Scripts.Interfaces;
using _Core.Scripts.Player;
using UnityEngine;

namespace _Core.Scripts.Objects.Collectable.Bad_Objects
{
    public class BadThoughts : MonoBehaviour, IMovable, IBadThoughts
    {
        
        [SerializeField] private float _moveSpeed;
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

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                DealDamage();
            }
        }
        
        public void Move()
        {
            _rigidbody.linearVelocity = _objectVelocityDirection * _moveSpeed;
        }


        public void DealDamage()
        {
            Debug.Log("Dealing damage");
        }
    }
}