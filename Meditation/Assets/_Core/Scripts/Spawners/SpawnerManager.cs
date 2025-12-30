using System.Collections;
using UnityEngine;

namespace _Core.Scripts.Spawners
{
    public class SpawnerManager : MonoBehaviour
    {
        [SerializeField] private SpawnerBadObjects[] badSpawners;
        [SerializeField] private SpawnerGoodObjects[] goodSpawners;
        

        private float _minDelayBadObjects = 2f;
        private float _maxDelayBadObjects = 4f;
        
        private float _minDelayGoodObjects = 7f;
        private float _maxDelayGoodObjects = 10f;


        private void Start()
        {
            StartCoroutine(ActivateBadSpawners());
            StartCoroutine(ActivateGoodSpawners());
            StartCoroutine(DecraseGoodSpawnTime());
            StartCoroutine(DecraseBadSpawnTime());
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

        private IEnumerator DecraseBadSpawnTime()
        {
            while (true)
            {
                if (_minDelayBadObjects >= 1.5f && _maxDelayBadObjects >= 3.5f)
                {
                    _minDelayBadObjects -= .05f;
                    _maxDelayBadObjects -= .05f;
                }
                else
                {
                    StopCoroutine(DecraseBadSpawnTime());
                }

                yield return new WaitForSeconds(Random.Range(6,8));
            }

        }

        private IEnumerator DecraseGoodSpawnTime()
        {
            while (true)
            {
                if (_minDelayGoodObjects >= 5 && _maxDelayGoodObjects >= 8)
                {
                    _minDelayGoodObjects -= 0.2f;
                    _maxDelayGoodObjects -= 0.2f;
                }
                else
                {
                    StopCoroutine(DecraseGoodSpawnTime());
                }
                yield return new WaitForSeconds(Random.Range(7, 12));
            }
        }
    }
}
