using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CarMovement : MonoBehaviour
{
    // Speed of the car
    public float speed = 5f;

    // Position to reset the car when it goes off-screen
    public float resetPositionX = -10f;
    public float startPositionX = 10f;

    void Update()
    {
        // Move the car to the left
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        // Reset position if the car goes off-screen
        if (transform.position.x < resetPositionX)
        {
            ResetCarPosition();
        }
    }

    void ResetCarPosition()
    {
        // Set the car back to the starting position
        transform.position = new Vector3(startPositionX, transform.position.y, transform.position.z);
    }

    // Trigger detection
    private void OnTriggerEnter(Collider other)
    {
        // Check if the car collides with the player
        if (other.CompareTag("Player"))
        {
            Debug.Log("Car hit the player!");

            // Get the PlayerStats component from the collided object
            PlayerStats playerStats = other.GetComponent<PlayerStats>();
            if (playerStats != null)
            {
                playerStats.TakeDamage(1); // Reduce health by 1
            }
        }
    }
}
