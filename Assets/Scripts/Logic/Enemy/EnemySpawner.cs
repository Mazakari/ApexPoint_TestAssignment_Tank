using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawners;

   private int _currentEnemyCount = 0;

   private IPoolService _poolService;
   private IEnemyService _enemyService;

    private void OnEnable()
    {
        GetReferences();

        EnemyHealth.OnEnemyDestroyed += HandleEnemyDestruction;
    }

    private void OnDisable()
    {
        EnemyHealth.OnEnemyDestroyed -= HandleEnemyDestruction;
    }

    private void HandleEnemyDestruction(GameObject enemy)
    {
        _currentEnemyCount--;
        _poolService.ReturnEnemy(enemy);
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        if (_currentEnemyCount < Constants.MAX_ENEMIES_ON_SCREEN)
        {
            Spawn();
            _currentEnemyCount++;
        }
    }

    private void GetReferences()
    {
        _poolService = AllServices.Container.Single<IPoolService>();
        _enemyService = AllServices.Container.Single<IEnemyService>();
    }

    public void FirstEnemySpawn()
    {
        for (int i = 0; i < _enemyService.MaxOnScreenEnemies; i++)
        {
            SpawnEnemy();
        }
    }

    private void Spawn()
    {
        try
        {
            GameObject enemy = _poolService.GetEnemy();
            enemy.transform.position = GetRandomSpawner().position;
            enemy.SetActive(true);
        }
        catch (System.Exception e)
        {
            Debug.Log(e.Message);
        }
    }

    private Transform GetRandomSpawner()
    {
        Transform rndTransform = _spawners[0];
        try
        {
            int rnd = Random.Range(0, _spawners.Length);
            rndTransform = _spawners[rnd];
        }
        catch (System.Exception e)
        {
            Debug.Log(e.Message);
        }

        return rndTransform;
    }
}
