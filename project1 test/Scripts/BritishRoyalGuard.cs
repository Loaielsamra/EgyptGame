using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


using UnityEngine;
using System;
using System.Numerics;

public class BritishRoyalGuard : EnemyController
{
    public int health = 20;    // Higher health for guards
    public float speedIncreaseInterval = 15f;
    public float speedIncreaseAmount = 1f;

    private float timeSinceLastSpeedIncrease = 0f;
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        timeSinceLastSpeedIncrease += Time.deltaTime;

        // Increase speed every interval
        if (timeSinceLastSpeedIncrease >= speedIncreaseInterval)
        {
            maxSpeed += speedIncreaseAmount;
            timeSinceLastSpeedIncrease = 0f;
        }

        ChasePlayer();
    }

    public override void ChasePlayer()
    {
        if (player != null)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * maxSpeed * Time.deltaTime;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Attack();
        }
    }

    public override void Attack()
    {
        FindObjectOfType<PlayerStats>().TakeDamage(damage);
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
