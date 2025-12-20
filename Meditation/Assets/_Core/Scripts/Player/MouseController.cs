using System;
using _Core.Scripts.Interfaces;
using _Core.Scripts.Managers;
using UnityEngine;

namespace _Core.Scripts.Player
{
    public class MouseController : MonoBehaviour
    {
        [SerializeField] private float _mouseMinVelocity = 0.1f;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        public Vector3 mouseDirection{get; private set;}
        private Vector3 _newMousePosition;
        
        private Camera _camera;
        private CircleCollider2D _mouseCollider;
        
        private bool _isMousePressed;
        private bool _isGamePaused = false;

        private void Awake()
        {
            _camera = Camera.main;
            _mouseCollider = GetComponent<CircleCollider2D>();
            _spriteRenderer.enabled = false;
        }
        private void Update()
        {
            if (!_isGamePaused)
            {
                InputHandler();
            }
        }

        private void InputHandler()
        {
            if (Input.GetMouseButton(0))
            {
                StartReflectObjects();
            }
            if(Input.GetMouseButtonUp(0))
            {
                StopReflectObjects();
            }
            if(_isMousePressed)
            {
                ContinueReflectingObjects();
            }
        }

        private void StartReflectObjects() // player press button
        {
            _newMousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
            _newMousePosition.z = 0;
            
            _isMousePressed = true;
            _mouseCollider.enabled = true;
            _spriteRenderer.enabled = true;
        }

        private void StopReflectObjects() // player release button
        {
            _isMousePressed = false;
            _mouseCollider.enabled = false;
            _spriteRenderer.enabled = false;
        }

        private void ContinueReflectingObjects() // player pressed and holding button
        {
            _newMousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
            _newMousePosition.z = 0;
            mouseDirection = _newMousePosition - transform.position;
            var velocity = mouseDirection.magnitude / Time.deltaTime;
            _mouseCollider.enabled = velocity > _mouseMinVelocity;
            
            transform.position = _newMousePosition;
        }

       
        //checking if mouse is touching bad thought's objects
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.GetComponent<IBadThoughts>() != null && _isMousePressed)
            {
                IBadThoughts badThoughts = collision.gameObject.GetComponent<IBadThoughts>();
                badThoughts.TakeDamage();
            }
        }

        private void OnEnable() //refresh mouse before start
        {
            StopReflectObjects();
            EventManager.OnGamePaused += GamePause;
            EventManager.OnGameUnpaused += GameUnpause;
        }

        private void GameUnpause()
        {
            _isGamePaused = false;
        }

        private void GamePause()
        {
            _isGamePaused = true;
        }

        private void OnDisable()
        {
            StopReflectObjects();
        }
    }
}
