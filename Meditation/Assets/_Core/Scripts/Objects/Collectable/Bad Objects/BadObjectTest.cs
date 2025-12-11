using System;
using System.Collections;
using _Core.Scripts.Player;
using UnityEngine;

namespace _Core.Scripts.Objects.Collectable.Bad_Objects
{
    public class BadObjectTest : MonoBehaviour
    {
        
        [SerializeField] private float _moveSpeed;
        private int _delayBeforeMove = 2;
        private PlayerStats _playerTransform;
        private Rigidbody2D _rigidbody;
        private Vector3 _objectVelocityDirection;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _playerTransform = FindFirstObjectByType<PlayerStats>().GetComponent<PlayerStats>();
            _objectVelocityDirection = (_playerTransform.transform.position - transform.position ).normalized;
            StartCoroutine(DelayBeforeMove());
            //Move();
        }


        public void Move()
        {
            _rigidbody.linearVelocity = _objectVelocityDirection * _moveSpeed;
        }

        private IEnumerator DelayBeforeMove()
        {
            
            yield return new WaitForSeconds(_delayBeforeMove);
            Move();
        }
        

    }
}