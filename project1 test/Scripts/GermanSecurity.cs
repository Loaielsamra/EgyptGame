using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GermanSecurity : EnemyController
{
    public float speedIncreaseTimer = 0f;

    // Override the public virtual method for Flip if needed
    public override void Flip()
    {
        base.Flip();  // Use the base class method if no changes are needed
    }

    // Override the public virtual method for ChasePlayer to add specific logic for the German Security
    public override void ChasePlayer(float speed)
    {
        base.ChasePlayer(speed);  // Use the base class method for basic chasing

        // Custom behavior for German Security: Increase speed every 20 seconds
        speedIncreaseTimer += Time.deltaTime;
        if (speedIncreaseTimer >= 20f)
        {
            maxSpeed += 0.5f;
            speedIncreaseTimer = 0f;
        }

        // Call the base ChasePlayer with modified speed
        base.ChasePlayer(maxSpeed);
    }

    // Override the public virtual method for Attack to include firing bullets if player flips
    public override void Attack()
    {
        // Custom attack logic for German Security when player flips
        if (player.transform.localScale.x < 0)  // Assuming the player flipped
        {
            // Fire bullets here
            FireBullets();
        }
    }

    void FireBullets()
    {
        // Logic to fire bullets at the player
        BulletController bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.speed = 10f;  // Example speed
    }

    void Update()
    {
        base.Update();  // Call base class Update for common behavior
        ChasePlayer(maxSpeed);  // Call the updated ChasePlayer method
    }
}
