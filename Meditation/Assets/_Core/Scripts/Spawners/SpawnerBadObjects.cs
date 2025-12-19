
using UnityEngine;

public class SpawnerBadObjects : MonoBehaviour
{
    [SerializeField] private GameObject[] _badObjects;
    [SerializeField] private GameObject _badBossThought;
 
    private float _timer;

    
    private void Update()
    {
        _timer += Time.deltaTime;
    }
    public void SpawnBadThought()
    {
        int randomIndex = Random.Range(0, _badObjects.Length);
        Instantiate(_badObjects[randomIndex], transform.position, Quaternion.identity);
        
        if (_timer > 5f) //spawn boss
        {
            Instantiate(_badBossThought, transform.position, Quaternion.identity);
            _timer = 0f;
        }
    }

    


   
    
}
