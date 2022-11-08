using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnView : MonoBehaviour
{
    [SerializeField]
    private List<Transform> _spawnPoints;

    public float SpawnTime = 1f;
    public float Speed = 5f;
    public float Distance = 30f;

    private PoolManager<Cube> pool;
    private IEnumerator spawnCoroutine;
   
    public void Init(PoolManager<Cube> pool)
    {
        this.pool = pool;

        spawnCoroutine = SpawnCubeCoroutine();
    }
    public void StartSpawnCoroutine()
    {
        StartCoroutine(spawnCoroutine);
    }
    public void StopSpawnCoroutine()
    {
        StopCoroutine(spawnCoroutine);
        pool.ReturnAllObjects();
    }
    private IEnumerator SpawnCubeCoroutine()
    {
        int spawnPlace = 0;
        while (true)
        {
            var cube = pool.GetFreeElement();
            var newPosition = _spawnPoints[Random.Range(0, _spawnPoints.Count)].transform.position;
            cube.Init(Speed, Distance, newPosition);
            cube.Move();
            spawnPlace++;
            yield return new WaitForSeconds(SpawnTime);
        }
    }
}
