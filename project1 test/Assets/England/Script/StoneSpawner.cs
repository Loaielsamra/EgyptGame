using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneSpawner : MonoBehaviour
{
    // Prefab of the stone to spawn
    public GameObject stonePrefab;

    // Position where the stone will spawn
    public Vector3 spawnPosition;

    // Lifetime of the stone in seconds
    public float stoneLifetime = 5f;

    // Time interval between each respawn
    public float respawnInterval = 8f;

    void Start()
    {
        // Start the repeating stone spawn
        InvokeRepeating("SpawnStone", 4f, respawnInterval);
    }

    // Method to spawn the stone
    void SpawnStone()
    {
        if (stonePrefab != null)
        {
            // Instantiate the stone prefab at the given position
            GameObject spawnedStone = Instantiate(stonePrefab, spawnPosition, Quaternion.identity);

            // Destroy the stone after 'stoneLifetime' seconds
            Destroy(spawnedStone, stoneLifetime);

            Debug.Log("Stone Spawned! It will disappear after " + stoneLifetime + " seconds.");
        }
        else
        {
            Debug.LogError("Stone Prefab is not assigned in the Inspector!");
        }
    }
}
