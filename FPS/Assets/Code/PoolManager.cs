using UnityEngine;
using System.Collections.Generic;

public class PoolManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _prefab;
    
    private Queue<GameObject> _pool;

    void Start()
    {
        _pool = new Queue<GameObject>();
        AddObjectsToPool(10);
    }

    private void AddObjectsToPool(int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject newPooledObject = (GameObject)GameObject.Instantiate(_prefab);
            newPooledObject.SetActive(false);
            _pool.Enqueue(newPooledObject);
        }
    }

    public GameObject GetPooledObject()
    {
        if (_pool.Count == 0)
            AddObjectsToPool(10);

        return _pool.Dequeue();
    }

    public void DeactivateObjectAndAddToPool(GameObject objectToReAdd)
    {
        objectToReAdd.SetActive(false);
        _pool.Enqueue(objectToReAdd);
    }
}
