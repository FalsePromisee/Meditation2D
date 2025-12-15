using System;
using UnityEngine;

namespace _Core.Scripts.Player
{
    public class MouseController : MonoBehaviour
    {
        [SerializeField] private float _mouseMinVelocity = 0.2f;
        public Vector3 _mouseDirection{get; private set;}
        private Vector3 newMousePosition;
        
        private Camera _camera;
        private CircleCollider2D _mouseCollider;
        
        private bool _isMousePressed;

        private void Awake()
        {
            _camera = Camera.main;
            _mouseCollider = GetComponent<CircleCollider2D>();
        }
        private void Update()
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

        private void StartReflectObjects()
        {
            newMousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
            newMousePosition.z = 0;
            
            _isMousePressed = true;
            _mouseCollider.enabled = true;
        }

        private void StopReflectObjects()
        {
            _isMousePressed = false;
            _mouseCollider.enabled = false;
        }

        private void ContinueReflectingObjects()
        {
            newMousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
            newMousePosition.z = 0;
            _mouseDirection = newMousePosition - transform.position;
            float velocity = _mouseDirection.magnitude / Time.deltaTime;
            _mouseCollider.enabled = velocity > _mouseMinVelocity;
            
            transform.position = newMousePosition;
        }

        private void OnEnable()
        {
            StopReflectObjects();
        }

        private void OnDisable()
        {
            StopReflectObjects();
        }
    }
}
