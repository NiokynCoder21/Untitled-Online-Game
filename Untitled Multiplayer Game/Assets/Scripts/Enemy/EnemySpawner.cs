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
    public bool isSpawn = false; //has an enemy spawned yet
    private Coroutine spawnRoutine; //this is so we use later

    public override void OnStartServer()
    {
        base.OnStartServer();

        for (int i = 0; i < initialEnemyCount && i < initialSpawnPoints.Length; i++)
        {
            SpawnEnemy(initialSpawnPoints[i].position); //spawn intital enemies at spawn points
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
    private IEnumerator SpawnAdditionalEnemies() //spawns enemies over an interval i have selected
    {
        while (isSpawn == true) // Infinite loop to spawn enemies indefinitely
        {
            yield return new WaitForSeconds(spawnInterval);

            Vector3 randomSpawnPosition = GetRandomSpawnPosition();
            SpawnEnemy(randomSpawnPosition);
        }
    }

    [Server]
    public void StartSpawning() //this starts the spawning courtine function
    {
        if (spawnRoutine == null)
        {
            isSpawn = true; //spawning is true
            spawnRoutine = StartCoroutine(SpawnAdditionalEnemies());
        }
    }

    [Server]
    public void StopSpawning() //a void that allows me to stop spawning
    {
        if (spawnRoutine != null)
        {
            StopCoroutine(spawnRoutine); //stop the spawning
            spawnRoutine = null;
            isSpawn = false; //spawning is false
        }
    }

    private Vector3 GetRandomSpawnPosition()
    {
        Transform randomPoint = initialSpawnPoints[Random.Range(0, initialSpawnPoints.Length)]; 
        return randomPoint.position; //gets a spawn position from the set points in the scence
    }
}
