using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : WalkingEnemy
{
    public GameObject poopPrefab;
    public Transform poopSpawnPoint;
    public float poopInterval = 3f;

    void Start()
    {
        InvokeRepeating("Poop", poopInterval, poopInterval);
    }

    void Update()
    {

    }

    void Poop()
    {
        if (poopPrefab == null || poopSpawnPoint == null) return;

        Instantiate(poopPrefab, poopSpawnPoint.position, Quaternion.identity);
    }
}
