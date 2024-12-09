using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Police : EnemyController
{
    public float speedIncreaseTimer = 0f;

    // Override the public virtual method for Flip if needed
    public override void Flip()
    {
        base.Flip();  // Use the base class method if no changes are needed
    }

    // Override the public virtual method for ChasePlayer to add specific logic for the Police
    public override void ChasePlayer(float speed)
    {
        base.ChasePlayer(speed);  // Use the base class method for basic chasing

        // Custom behavior for Police: Increase speed every 30 seconds
        speedIncreaseTimer += Time.deltaTime;
        if (speedIncreaseTimer >= 30f)
        {
            maxSpeed += 0.5f;
            speedIncreaseTimer = 0f;
        }

        // Call the base ChasePlayer with modified speed
        base.ChasePlayer(maxSpeed);
    }

    // Override the public virtual method for Attack if needed
    public override void Attack()
    {
        // Add police-specific attack logic here if necessary
    }

    void Update()
    {
        base.Update();  // Call base class Update for common behavior
        ChasePlayer(maxSpeed);  // Call the updated ChasePlayer method
    }
}
