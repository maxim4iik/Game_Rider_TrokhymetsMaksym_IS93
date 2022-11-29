using UnityEngine;

public class Spawner : ObjectsPool
{
    [SerializeField] private GameObject[] _enemyTemplates = new GameObject[2];
    [SerializeField] private float _interfalOfSpawn;
    [SerializeField] private float _timeToIntervalSpeedUp;
    [SerializeField] private Transform[] _spawnPositions;

    private float _timeBetweenSpawn = 0;
    private float _elapsedTime = 0;
    private const float SpeedUpInterval = 0.1f;
    
    private void Start()
    {
        Initialize(_enemyTemplates);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;
        _timeBetweenSpawn += Time.deltaTime;

        if (_timeBetweenSpawn >= _interfalOfSpawn)
        {
            Spawn();
        }

        SpeedTimeUp();
    }

    private void SetEnemy(GameObject enemy, Vector3 spawnPoint)
    {
        enemy.SetActive(true);
        enemy.transform.position = spawnPoint;
    }

    private void SpeedTimeUp()
    {
        if (_elapsedTime > _timeToIntervalSpeedUp)
        {
            _interfalOfSpawn -= SpeedUpInterval;
            _elapsedTime = 0;
        }
        
    }

    private void Spawn()
    {
        if (TryGetObject(out GameObject enemy))
        {
            _timeBetweenSpawn = 0;
            var numberOfSpawnPoint = Random.Range(0, _spawnPositions.Length);
            SetEnemy(enemy, _spawnPositions[numberOfSpawnPoint].position);
        }
    }

}