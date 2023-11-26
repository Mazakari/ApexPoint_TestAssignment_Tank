using System;
using System.Collections.Generic;
using UnityEngine;

public class PoolService : IPoolService
{
    private readonly IGameFactory _gameFactory;
    private readonly IStaticDataService _staticDataService;
    private readonly IEnemyService _enemyService;

    private ObjectPoolStaticData _poolStaticData;
    public List<GameObject> EnemyPool { get; private set; }
    public Transform EnemySpawnParent { get; private set; }

    private int _poolSize = 20;

    public PoolService(IGameFactory gameFactory, IStaticDataService staticDataService, IEnemyService enemyService)
    {
        _gameFactory = gameFactory;
        _staticDataService = staticDataService;
        _enemyService = enemyService;

        GetObjectPoolStaticDataReference();
    }

    public void InitEnemyPool()
    {
        CreatePool();
        CreateEnemySpawnParent();
        PopulateEnemiesPoolInParent(EnemySpawnParent);
        DeactivateEnemies();
    }

    public GameObject GetEnemy()
    {
        GameObject enemy = null;

        while (!FreeEnemiesLeft())
        {
            IncreaseEnemyPoolSize();
        }

        foreach (GameObject item in EnemyPool)
        {
            if (!item.activeSelf)
            {
                enemy = item;
                break;
            }
        }

        return enemy;
    }
    public void ReturnEnemy(GameObject enemy)
    {
        enemy.transform.SetParent(EnemySpawnParent.transform);
        EnemyPool.Add(enemy);
    }

    private void CreatePool()
    {
        _poolSize = _poolStaticData.enemyPoolSize;
        EnemyPool = new();
    }
    private void PopulateEnemiesPoolInParent(Transform parent)
    {
        GameObject enemy;
        EnemyType spawnType = EnemyType.Light;
        try
        {
            for (int i = 0; i < _poolSize; i++)
            {
                enemy = _gameFactory.CreateEnemy(parent);

                if (_poolStaticData.randomizeEnemyTypes)
                {
                    spawnType = GetRandomEnemyType();
                }

                EnemyStaticData enemyData = _staticDataService.GetEnemyData(spawnType);
                enemy.GetComponent<EnemyConstructor>().Construct(enemyData, _enemyService);
                EnemyPool.Add(enemy);
            }
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
    }

    private EnemyType GetRandomEnemyType()
    {
        int enemyTypesAmount = Enum.GetValues(typeof(EnemyType)).Length;
        int rndType = UnityEngine.Random.Range(0, enemyTypesAmount);

        return (EnemyType)rndType;
    }

    private void IncreaseEnemyPoolSize()
    {
        
        GameObject enemy;
        for (int i = 0; i < _poolSize; i++)
        {
            enemy = _gameFactory.CreateEnemy(EnemySpawnParent.transform);
            EnemyPool.Add(enemy);
            enemy.SetActive(false);
        }
    }

    private bool FreeEnemiesLeft()
    {
        bool freeLeft = false;

        foreach (GameObject pickable in EnemyPool)
        {
            if (!pickable.activeSelf)
            {
                freeLeft = true;
                return freeLeft;
            }
        }

        return freeLeft;
    }
   
   
    private void CreateEnemySpawnParent()
    {
        EnemySpawnParent = GameObject.FindGameObjectWithTag(Constants.ENEMY_PARENT_TAG).transform;

        if (EnemySpawnParent == null)
        {
            GameObject newParent = new();
            EnemySpawnParent = newParent.transform;
            EnemySpawnParent.transform.position = Vector3.zero;
            EnemySpawnParent.name = Constants.ENEMY_PARENT_TAG;
        }
       
    }
    private void DeactivateEnemies()
    {
        foreach (GameObject enemy in EnemyPool)
        {
            enemy.SetActive(false);
        }
    }

    private void GetObjectPoolStaticDataReference()
    {
        try
        {
            _poolStaticData = _gameFactory.GetPoolStaticData();
        }
        catch (System.Exception e)
        {
            Debug.Log(e.Message);
        }
    }
}