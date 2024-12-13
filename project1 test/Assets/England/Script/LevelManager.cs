using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject CurrentCheckpoint;
    public Transform enemy;
    public GameObject enemySpawnPoint;
    public float enemySpawnInterval = 1f;
    // Start is called before the first frame update
    void Start()
    {
        if (enemy != null && enemySpawnPoint != null)
        {
            InvokeRepeating("RespawnEnemy", enemySpawnInterval, enemySpawnInterval);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RespawnPlayer()
    {
        FindObjectOfType<PlayerController>().transform.position = CurrentCheckpoint.transform.position;
    }

    public void RespawnEnemy()
    {
        Instantiate(enemy, enemySpawnPoint.transform.position, enemySpawnPoint.transform.rotation);
    }
}
