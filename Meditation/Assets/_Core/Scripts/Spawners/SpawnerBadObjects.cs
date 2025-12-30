using System.Collections;
using UnityEngine;

public class SpawnerBadObjects : MonoBehaviour
{
    [SerializeField] private GameObject[] _badObjects;
    [SerializeField] private GameObject _badBossThought;


    private float _minBossSpawnTime = 3;
    private float _maxBossSpawnTime = 7;
    private float _timer;

    private void Start()
    {
        StartCoroutine(DecreaseBossSpawnTime());
    }

    private void Update()
    {
        _timer += Time.deltaTime;
    }

    public void SpawnBadThought()
    {
        int randomIndex = Random.Range(0, _badObjects.Length);
        Instantiate(_badObjects[randomIndex], transform.position, Quaternion.identity);

        float randomBossSpawnTime = Random.Range(_minBossSpawnTime, _maxBossSpawnTime);
        if (_timer > randomBossSpawnTime) //spawn boss
        {
            Instantiate(_badBossThought, transform.position, Quaternion.identity);
            _timer = 0f;
        }
    }

    
    private IEnumerator DecreaseBossSpawnTime()
    {
        while (true)
        {
            if (_minBossSpawnTime >= 2 && _maxBossSpawnTime >= 5)
            {
                _minBossSpawnTime -= 0.05f;
                _maxBossSpawnTime -= 0.1f;
                //Debug.Log("Min and max time: " + _minBossSpawnTime + " " + _maxBossSpawnTime);
            }
            else
            {
                StopCoroutine(DecreaseBossSpawnTime());
            }
                yield return new WaitForSeconds(Random.Range(5, 12));
        }
    }

   
    
}
