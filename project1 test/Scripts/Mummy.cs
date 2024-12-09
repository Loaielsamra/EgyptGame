using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine;
using System.Collections;
using System;
using System.Numerics;

public class Mummy : EnemyController
{
    public int health = 15;
    public float reawakeDelay = 5f;          // Time before reawakening
    public float jumpDisableDuration = 5f;  // Duration to disable player's jump
    public int maxMultiplications = 3;      // Maximum number of multiplications
    public GameObject mummyPrefab;          // Prefab of the mummy to spawn

    private Transform player;
    private bool isDead = false;
    private int multiplicationCount = 0;    // Tracks the number of times this mummy has multiplied

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (!isDead)
        {
            ChasePlayer();
        }
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
        DisablePlayerJump();
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        if (health <= 0 && !isDead)
        {
            isDead = true;
            MultiplyMummy(); // Trigger multiplication when killed
            StartCoroutine(Reawake());
        }
    }

    private IEnumerator Reawake()
    {
        yield return new WaitForSeconds(reawakeDelay);
        health = 15; // Reset health
        isDead = false;
    }

    private void MultiplyMummy()
    {
        if (multiplicationCount < maxMultiplications)
        {
            multiplicationCount++;

            // Spawn a new mummy at a random nearby position
            Vector3 spawnPosition = transform.position + new Vector3(Random.Range(-2f, 2f), Random.Range(-2f, 2f), 0f);
            Instantiate(mummyPrefab, spawnPosition, Quaternion.identity);
        }
    }

    private void DisablePlayerJump()
    {
        PlayerController playerController = FindObjectOfType<PlayerController>();
        if (playerController != null)
        {
            playerController.DisableJump(jumpDisableDuration);
        }
    }
}
