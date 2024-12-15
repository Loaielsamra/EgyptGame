using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    //private bool isClimbing; // To check if the player is climbing
    private GameObject player; // Reference to the player

    public float climbSpeed = 5f; // Speed at which the player climbs the ladder

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the player enters the ladder's trigger zone
        if (collision.CompareTag("Player"))
        {
            player = collision.gameObject;
            player.GetComponent<Rigidbody2D>().gravityScale = 0; // Disable gravity while on the ladder
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        // Check if the player exits the ladder's trigger zone
        if (collision.CompareTag("Player"))
        {
            player.GetComponent<Rigidbody2D>().gravityScale = 1; // Reset gravity
            //isClimbing = false; // Stop climbing
            player = null;
        }
    }

    void Update()
    {
        if (player != null)
        {
            float verticalInput = Input.GetAxis("Vertical"); // Use "W/S" or "Up/Down" keys for climbing
            if (verticalInput != 0)
            {
                //isClimbing = true;
                player.transform.Translate(Vector2.up * verticalInput * climbSpeed * Time.deltaTime);
            }
            else
            {
                //isClimbing = false;
            }
        }
    }
}