using UnityEngine;
using _Core.Scripts.Interfaces;
using Random = UnityEngine.Random;
using _Core.Scripts.Managers;
using _Core.Scripts.Player;

namespace _Core.Scripts.Objects.Collectable.GoodObjects
{
    public class GoodObjectTest : MonoBehaviour, IMovable
    {
        [SerializeField] private float _moveSpeed;
        [SerializeField] private ParticleSystem _goodExplosionParticle;
        [SerializeField] private ParticleSystem _badExplosionParticle;

        private Rigidbody2D _rigidbody;
        private CapsuleCollider2D _collider;
        private TestDirectionObjects[] _objectVelocityDirection;
        
        private Vector3 _startDragPos;
        private Vector3 _objectDirection;

        public int additionalPoints { get; private set; } = 25;
        public int additionalHealth { get; private set; } = 1;
        public int damage {  get; private set; } = 2;  //Amount of damage that object deals if object fly away and player didn't try to catch it

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _collider = GetComponent<CapsuleCollider2D>();
            _objectVelocityDirection = FindObjectsByType<TestDirectionObjects>(FindObjectsSortMode.None);
            int randomValue = Random.Range(0, _objectVelocityDirection.Length);
            _objectDirection = (_objectVelocityDirection[randomValue].transform.position - transform.position).normalized;
            Move();
        }

        public void Move()
        {
            _rigidbody.linearVelocity = _objectDirection * _moveSpeed;
        }

        private void OnMouseDown()
        {
            _startDragPos = transform.position;
            transform.position = GetMousePosInWorld();
        }

        private void OnMouseDrag()
        {
            transform.position = GetMousePosInWorld();
        }

        private void OnMouseUp()
        {
            _collider.enabled = false;
            Collider2D hitCollider = Physics2D.OverlapPoint(transform.position);
            _collider.enabled = true;
            if (hitCollider != null && hitCollider.TryGetComponent(out IGoodObjectDrop playerPosition))
            {
                playerPosition.OnGoodObjectDrop(this);
                GoodExplode();
                Destroy(gameObject);
            }
            else
            {
                EventManager.Instance.OnPlayerTakeDamage(damage);
                BadExplode();
                Destroy(gameObject);
            }
        }

        private Vector3 GetMousePosInWorld()
        {
            Vector3 mousePosition =  Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            return mousePosition;
        }

        private void GoodExplode()
        {
            ParticleSystem particle = Instantiate(_goodExplosionParticle, transform.position, Quaternion.identity);
            particle.Play();
        }
        private void BadExplode()
        {
            ParticleSystem badParticle = Instantiate(_badExplosionParticle, transform.position, Quaternion.identity);
            badParticle.Play();
        }
        
    }
}
