using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class ObjectsPool : MonoBehaviour
{
    [SerializeField] private int _capacity;
    [SerializeField] private GameObject _container;

    private List<GameObject> _pool = new List<GameObject>();

    protected void Initialize(GameObject prefab)
    {
        for (int i = 0; i < _capacity; i++)
        {
            var spawned = Instantiate(prefab, _container.transform);
            spawned.SetActive(false);
        
            _pool.Add(spawned);
        }
    }
    
    protected void Initialize(GameObject[] prefab)
    {
        for (int i = 0; i < _capacity; i++)
        {
            var indexOfEnemy = Random.Range(0, 2);
            var spawned = Instantiate(prefab[indexOfEnemy], _container.transform);
            spawned.SetActive(false);
        
            _pool.Add(spawned);
        }
    }

    protected bool TryGetObject(out GameObject enemy)
    {
        enemy = _pool.FirstOrDefault(opponent => opponent.activeSelf == false);
        return enemy != null;
    }
}
