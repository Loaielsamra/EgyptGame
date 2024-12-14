using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public float fallDelay = 0.5f; // Time before the platform starts falling
    public float respawnDelay = 3f; // Time before the platform respawns
    private Rigidbody2D rb;         // Rigidbody2D component of the platform
    private Vector3 initialPosition; // Store the platform's initial position

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D component is missing on " + gameObject.name);
            return;
        }

        // Ensure the platform is initially static
        rb.bodyType = RigidbodyType2D.Static;

        // Save the initial position of the platform
        initialPosition = transform.position;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player triggered the collision
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player collided with platform: " + gameObject.name);
            // Start the falling process
            Invoke(nameof(StartFalling), fallDelay);
        }
    }

    void StartFalling()
    {
        if (rb == null) return; // Safety check
        rb.bodyType = RigidbodyType2D.Dynamic;

        // Schedule platform respawn
        Invoke(nameof(RespawnPlatform), respawnDelay);
    }

    void RespawnPlatform()
    {
        if (rb == null) return; // Safety check

        // Reset the platform's position and state
        rb.bodyType = RigidbodyType2D.Static;
        rb.velocity = Vector2.zero; // Stop any movement
        rb.angularVelocity = 0f;    // Stop any rotation
        transform.position = initialPosition; // Reset position
    }
}
