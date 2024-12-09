using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FrenchSoldier : EnemyController
{
    public float speedIncreaseTimer = 0f;
    public int health = 2;  // Health for the French Soldier

    // Override the public virtual method for Flip if needed
    public override void Flip()
    {
        base.Flip();  // Use the base class method if no changes are needed
    }

    // Override the public virtual method for ChasePlayer to add specific logic for the French Soldier
    public override void ChasePlayer(float speed)
    {
        base.ChasePlayer(speed);  // Use the base class method for basic chasing

        // Custom behavior for French Soldier: Increase speed every 15 seconds
        speedIncreaseTimer += Time.deltaTime;
        if (speedIncreaseTimer >= 15f)
        {
            maxSpeed += 0.5f;
            speedIncreaseTimer = 0f;
        }

        // Call the base ChasePlayer with modified speed
        base.ChasePlayer(maxSpeed);
    }

    // Override the public virtual method for Attack to include firing bullets while moving towards the player
    public override void Attack()
    {
        // Custom attack logic for French Soldier when player flips
        if (player.transform.localScale.x < 0)  // Assuming the player flipped
        {
            FireBullets();
        }
    }

    void FireBullets()
    {
        // Logic to fire bullets towards the player
        BulletController bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.speed = 2f;  // Example speed while moving towards player
    }

    // Method to take damage if the player throws a knife
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    // Method for the French Soldier to die when health is zero
    void Die()
    {
        Destroy(gameObject);  // Destroy the soldier
    }

    void Update()
    {
        base.Update();  // Call base class Update for common behavior
        ChasePlayer(maxSpeed);  // Call the updated ChasePlayer method
    }
}
