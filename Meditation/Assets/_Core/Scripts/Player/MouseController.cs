using _Core.Scripts.Interfaces;
using _Core.Scripts.Managers;
using System;
using UnityEngine;

namespace _Core.Scripts.Player
{
    public class MouseController : MonoBehaviour
    {
        [SerializeField] private float _mouseMinVelocity = 0.1f;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Sprite _holdSprite;
        [SerializeField] private Sprite _reflectSprite;
        [SerializeField] private Sprite _idleSprite;


        public Vector3 mouseDirection{get; private set;}
        private Vector3 _newMousePosition;
        
        private Camera _camera;
        private CircleCollider2D _mouseCollider;
        
        private bool _isMousePressed;
        private bool _isGamePaused = false;

        private bool _isGoodObjectHold = false;

        private void Awake()
        {
            _camera = Camera.main;
            _mouseCollider = GetComponent<CircleCollider2D>();
        }


        private void Update()
        {

            if (!_isGamePaused)
            {
                InputHandler();

                MouseSpriteFollow();
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
                EventManager.Instance.OnMouseIdle();
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
            EventManager.Instance.OnMouseRelese();
        }

        private void StopReflectObjects() // player release button
        {
            _isMousePressed = false;
            _mouseCollider.enabled = false;


            //_spriteRenderer.enabled = false;
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
            if (collision.gameObject.GetComponent<IBadThoughts>() != null && _isMousePressed && !_isGoodObjectHold)
            {
                IBadThoughts badThoughts = collision.gameObject.GetComponent<IBadThoughts>();
                badThoughts.TakeDamage();
            }
        }


        private void MouseSpriteFollow()
        {
            _newMousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
            _newMousePosition.z = 0;
            transform.position = _newMousePosition;
        }

        private void OnEnable() //refresh mouse before start
        {
            StopReflectObjects();
            EventManager.OnGamePaused += GamePause;
            EventManager.OnGameUnpaused += GameUnpause;
            EventManager.OnMouseRelesed += MouseRelesed;
            EventManager.OnMouseHolded += MouseHold;
            EventManager.OnMouseIdled += MouseIdle;
        }


        private void OnDisable()
        {
            StopReflectObjects();
            EventManager.OnGamePaused -= GamePause;
            EventManager.OnGameUnpaused -= GameUnpause;
            EventManager.OnMouseRelesed -= MouseRelesed;
            EventManager.OnMouseHolded -= MouseHold;
            EventManager.OnMouseIdled -= MouseIdle;
        }

        private void MouseHold()
        {
            _spriteRenderer.sprite = _holdSprite;
            _isGoodObjectHold = true;
        }

        private void MouseRelesed()
        {
            if (!_isGoodObjectHold)
            {
                _spriteRenderer.sprite = _reflectSprite;
            }
            
            
        }
        private void MouseIdle()
        {
            _spriteRenderer.sprite = _idleSprite;
            _isGoodObjectHold = false;
        }

        private void GameUnpause()
        {
            _isGamePaused = false;
        }

        private void GamePause()
        {
            _isGamePaused = true;
        }

        
    }
}
