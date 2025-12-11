using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _badObjects;
    [SerializeField] private GameObject[] _goodObjects;
    private int _minTimeToSpawn = 1;
    private int _maxTimeToSpawn = 7;

    private void Start()
    {
        StartCoroutine(SpawnObjects());
    }

    private IEnumerator SpawnObjects()
    {
        while (true)
        {
            int randomIndexBadObjects = Random.Range(0, _badObjects.Length);
            int randomIndexGoodObjects = Random.Range(0, _goodObjects.Length);
            int randomSpawnTime = Random.Range(_minTimeToSpawn, _maxTimeToSpawn);

            Instantiate(_badObjects[randomIndexBadObjects], transform.position, Quaternion.identity);
            
            yield return new WaitForSeconds(randomSpawnTime);
        }
        
    }
    
}
