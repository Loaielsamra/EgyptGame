using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ItemCollectionHandler : MonoBehaviour
{
    public Text messageText; // Reference to the UI Text element for messages
    private float messageDisplayDuration = 3f; // Duration to display each message
    private float messageTimer = 0f;

    private void Update()
    {
        // Hide the message after the display duration
        if (messageTimer > 0)
        {
            messageTimer -= Time.deltaTime;
            if (messageTimer <= 0)
            {
                messageText.text = ""; // Clear the message
            }
        }
    }

    public void CollectItem(string itemName)
    {
        switch (itemName)
        {
            case "KeyOfLife":
                DisplayMessage("Key of Life collected! Your health has increased, so you can survive longer in the game.");
                IncreaseHealth();
                break;

            case "EyeOfHorus":
                DisplayMessage("Eye of Horus collected! You are now temporarily invisible. Use it to escape enemies and reveal hidden paths.");
                ActivateInvisibility();
                break;

            case "EagleToken":
                DisplayMessage("Eagle Token collected! An eagle  will assist you by scouting ahead and attacking enemies from above.");
                SummonEagle();
                break;

            case "SpeedToken":
                DisplayMessage("Speed Token collected! Your movement speed has temporarily increased. Stay ahead of danger!");
                IncreaseSpeed();
                break;

            case "Map":
                DisplayMessage("Map collected! This will guide you to the location of the Rosetta Stone.");
                ShowMap();
                break;

            case "UpwardArrow":
                DisplayMessage("Upward Arrow Token collected! You can now double jump to avoid obstacles, reach higher platforms, and escape enemies.");
                EnableDoubleJump();
                break;

            default:
                Debug.LogWarning("Unknown item collected: " + itemName);
                break;
        }
    }

    private void DisplayMessage(string message)
    {
        messageText.text = message;
        messageTimer = messageDisplayDuration; // Reset the timer
    }

    private void IncreaseHealth()
    {
        // Logic to increase the player's health
    }

    private void ActivateInvisibility()
    {
        // Logic to make the player temporarily invisible
    }

    private void SummonEagle()
    {
        // Logic to summon the eagle ally
    }

    private void IncreaseSpeed()
    {
        // Logic to temporarily increase the player's speed
    }

    private void ShowMap()
    {
        // Logic to display the map to the player
    }

    private void EnableDoubleJump()
    {
        // Logic to enable the double jump ability
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check for item collisions
        if (other.CompareTag("Player"))
        {
            CollectItem(other.gameObject.name);
            Destroy(other.gameObject); // Destroy the item after collection
        }
    }
}