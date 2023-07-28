using UnityEngine;
using Zenject;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemyPrefabs;
    [SerializeField] private int _enemyesCount;

    private GameObject currentPrefab;

    [SerializeField] private float timeBetweenSpawns;
    private float nextSpawnTime;

    [SerializeField, Inject] private DiContainer container;

    private PlayerHealth _playerHealth;
    private EnemyesPool _enemyesPool;

    [Inject]
    private void Construct(EnemyesPool enemyesPool, PlayerHealth playerHealth)
    {
        _enemyesPool = enemyesPool;
        _playerHealth = playerHealth;
    }

    private void Start()
    {
        for (int i = 0; i < _enemyesCount; i++)
        {
            _enemyesPool.AddObject(GetRandomEnemy(), SetPosition());
        }
    }

    private void FixedUpdate()
    {
        if (Time.time > nextSpawnTime)
        {
            Spawn();
            nextSpawnTime = Time.time + timeBetweenSpawns;
        }
    }
    private void Spawn()
    {
        var enemy = _enemyesPool.GetRandomObject();
        if (enemy == null)
            Debug.Log("! enemy");

        int randomNumber = Random.Range(0, _enemyPrefabs.Length);
        switch (randomNumber)
        {
            case 1: currentPrefab = _enemyPrefabs[0]; break;
            case 2: currentPrefab = _enemyPrefabs[1]; break;
            case 3: currentPrefab = _enemyPrefabs[2]; break;
            case 4: currentPrefab = _enemyPrefabs[3]; break;
        }
        //Instantiate(currentPrefab, SetPosition(), Quaternion.identity);
        //container.InstantiatePrefab(currentPrefab, SetPosition(), Quaternion.identity, null);
        enemy.transform.position = SetPosition();
        enemy.SetActive(true);
    }

    private Vector3 SetPosition()
    {
        return new Vector3(Random.Range(-2f, 2f), 6f, 0);
    }

    public void ReduceTimeBetweenSpawns()
    {
        timeBetweenSpawns -= 0.05f;
    }

    private GameObject GetRandomEnemy()
    {
        int index;
        index = Random.Range(0, _enemyPrefabs.Length);
        return _enemyPrefabs[index];
    }
}
