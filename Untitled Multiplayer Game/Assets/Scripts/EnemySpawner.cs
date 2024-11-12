using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class EnemySpawner : NetworkBehaviour
{
    public GameObject enemyPrefab; // Enemy prefab to spawn
    public Transform[] initialSpawnPoints; // Array of predefined spawn points
    public int initialEnemyCount; // Initial number of enemies
    public float spawnInterval; // Time interval for additional spawns
    public bool isSpawn = false;
    private Coroutine spawnRoutine;

    public override void OnStartServer()
    {
        base.OnStartServer();

        // Spawn initial enemies
        for (int i = 0; i < initialEnemyCount && i < initialSpawnPoints.Length; i++)
        {
            SpawnEnemy(initialSpawnPoints[i].position);
        }

        StartSpawning();
    }

    [Server]
    private void SpawnEnemy(Vector3 spawnPosition)
    {
        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        NetworkServer.Spawn(enemy); // Spawns the enemy across the network
    }

    [Server]
    private IEnumerator SpawnAdditionalEnemies()
    {
        while (isSpawn == true) // Infinite loop to spawn enemies indefinitely
        {
            yield return new WaitForSeconds(spawnInterval);

            Vector3 randomSpawnPosition = GetRandomSpawnPosition();
            SpawnEnemy(randomSpawnPosition);
        }
    }

    [Server]
    public void StartSpawning()
    {
        if (spawnRoutine == null)
        {
            isSpawn = true;
            spawnRoutine = StartCoroutine(SpawnAdditionalEnemies());
        }
    }

    [Server]
    public void StopSpawning()
    {
        if (spawnRoutine != null)
        {
            StopCoroutine(spawnRoutine);
            spawnRoutine = null;
            isSpawn = false;
        }
    }

    private Vector3 GetRandomSpawnPosition()
    {
        Transform randomPoint = initialSpawnPoints[Random.Range(0, initialSpawnPoints.Length)];
        return randomPoint.position;
    }
}
