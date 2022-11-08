using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager
{
    private SpawnView spawnView;

    public SpawnManager(PoolManager<Cube> pool, ResourceLoaderService resourceLoaderService)
    {
        spawnView = GameObject.Instantiate(resourceLoaderService.Prefabs.SPAWN_VIEW.GetComponent<SpawnView>());
        spawnView.Init(pool);

        InitActions();
    }

    private void InitActions()
    {
        EventManager.Instance.OnStartSpawnCoroutineEvent.AddListener(spawnView.StartSpawnCoroutine);
        EventManager.Instance.OnStopSpawnCoroutineEvent.AddListener(spawnView.StopSpawnCoroutine);

        EventManager.Instance.OnTimeSpawnChangedEvent.AddListener((float spawnTime) => spawnView.SpawnTime = spawnTime);
        EventManager.Instance.OnSpeedCubeChangedEvent.AddListener((float speed) => spawnView.Speed = speed);
        EventManager.Instance.OnDistanceCubeChangedEvent.AddListener((float distance) => spawnView.Distance = distance);
    }
    
}
