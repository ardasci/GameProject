using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalSpawnerVagoon : MonoBehaviour
{
    public Collectable collectablePrefab;
    public List<Collectable> spawnedPrefabList = new List<Collectable>();
    public int maxSpawnCount = 10;
    public float spawnPeriod = 2f;
    private float nextSpawnTime = 0;
    void Update()
    {
        HandleNullElements();
        if (spawnedPrefabList.Count >= maxSpawnCount)
        {
            return;
        }

        if (Time.time >= nextSpawnTime)
        {
            nextSpawnTime = Time.time + spawnPeriod;
            SpawnObject();
        }

    }

    private void SpawnObject()
    {
        Vector3 spawnPosition = new Vector3(2, 1, 0);
        spawnPosition += transform.position;
        var collectable = Instantiate(collectablePrefab, transform);
        collectable.transform.position = spawnPosition;
        spawnedPrefabList.Add(collectable);

    }

    private void HandleNullElements()
    {
        for (int i = spawnedPrefabList.Count - 1; i >= 0; i--)
        {
            if (spawnedPrefabList[i] == null)
            {
                spawnedPrefabList.RemoveAt(i);
            }
        }

    }
}
