using UnityEngine;

public class SpawnerGoodObjects : MonoBehaviour
{
    [SerializeField] private GameObject _goodObject;

    public void SpawnGoodObject()
    {
        Instantiate(_goodObject, transform.position, _goodObject.transform.rotation);
    }
}
