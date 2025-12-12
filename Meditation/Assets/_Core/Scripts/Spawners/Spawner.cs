using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _badObjects;
    [SerializeField] private GameObject[] _goodObjects;
    private int _minTimeToSpawnBadObject = 1;
    private int _maxTimeToSpawnBadObject = 7;
    
    private int _minTimeToSpawnGoodObject = 5;
    private int _maxTimeToSpawnGoodObject = 15;

    private void Start()
    {
        //StartCoroutine(SpawnObjects());
        StartCoroutine(SpawnGoodObjects());
    }

    private IEnumerator SpawnObjects()
    {
        while (true)
        {
            int randomIndexBadObjects = Random.Range(0, _badObjects.Length);
           
            int randomSpawnTime = Random.Range(_minTimeToSpawnBadObject, _maxTimeToSpawnBadObject);

            Instantiate(_badObjects[randomIndexBadObjects], transform.position, Quaternion.identity);
            
            yield return new WaitForSeconds(randomSpawnTime);
        }
        
    }

    private IEnumerator SpawnGoodObjects()
    {
        
        int randomIndexGoodObjects = Random.Range(0, _goodObjects.Length); 
        int randomSpawnTime = Random.Range(_minTimeToSpawnGoodObject, _maxTimeToSpawnGoodObject);
        
        yield return new WaitForSeconds(randomSpawnTime);
        Instantiate(_goodObjects[randomIndexGoodObjects], transform.position, Quaternion.identity);
        
    }
    
}
