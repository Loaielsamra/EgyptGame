using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class BirdSpawner : MonoBehaviour
{
    // Prefab of the bird to spawn
    public GameObject birdPrefab;

    // Spawn location
    public Transform spawnPoint;

    // Time between spawns in seconds
    public float spawnInterval = 4f;

    // Start is called before the first frame update
    void Start()
    {
        // Start spawning birds
        StartCoroutine(SpawnBirds());
    }

    // Coroutine to spawn birds at regular intervals
    IEnumerator SpawnBirds()
    {
        while (true)
        {
            // Wait for the spawn interval
            yield return new WaitForSeconds(spawnInterval);

            // Instantiate a new bird at the spawn point's position and rotation
            Instantiate(birdPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
}