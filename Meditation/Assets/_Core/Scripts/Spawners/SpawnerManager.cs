using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Core.Scripts.Spawners
{
    public class SpawnerManager : MonoBehaviour
    {
        [SerializeField] private SpawnerBadObjects[] badSpawners;
        [SerializeField] private SpawnerGoodObjects[] goodSpawners;

        private float _minDelayBadObjects = 1.5f;
        private float _maxDelayBadObjects = 3;
        
        private float _minDelayGoodObjects = 5f;
        private float _maxDelayGoodObjects = 9f;

        private void Start()
        {
            StartCoroutine(ActivateBadSpawners());
            StartCoroutine(ActivateGoodSpawners());
        }

        private IEnumerator ActivateBadSpawners()
        {
            while (true)
            {
                float delay = Random.Range(_minDelayBadObjects, _maxDelayBadObjects);
                yield return new WaitForSeconds(delay);
                
                int randomSpawnerIndex = Random.Range(0, badSpawners.Length);
                
                SpawnerBadObjects randomSpawnerBadObjects = badSpawners[randomSpawnerIndex];
                randomSpawnerBadObjects.SpawnBadThought();
            }   
        }

        private IEnumerator ActivateGoodSpawners()
        {
            while (true)
            {
                float delay = Random.Range(_minDelayGoodObjects, _maxDelayGoodObjects);
                yield return new WaitForSeconds(delay);
                
                int randomSpawnerIndex = Random.Range(0, goodSpawners.Length);
                
                SpawnerGoodObjects randomSpawnerGoodObjects = goodSpawners[randomSpawnerIndex];
                randomSpawnerGoodObjects.SpawnGoodObject();
            }
        }
        
    }
}
