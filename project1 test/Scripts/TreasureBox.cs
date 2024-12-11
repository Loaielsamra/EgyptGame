using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;  
using System.Diagnostics;

public class TreasureBox : MonoBehaviour
{
    public GameObject treasureBoxClosed;  // Reference to the treasure box when closed
    public GameObject treasureBoxOpen;    // Reference to the treasure box when open
    public Image artifactLocationImage;   // UI Image to display the artifact location image
    public Sprite artifactMapSprite;      // The sprite representing the artifact location
    public int requiredTokens = 5;        // Tokens needed to open the box
    private bool isOpened = false;        // Boolean to track whether the box has been opened

    private PlayerStats playerScript;    // Reference to the player's script to get the token count

    void Start()
    {
        // Initialize the player script
        playerScript = FindObjectOfType<PlayerStats>();
        treasureBoxOpen.SetActive(false);  // Make sure the box is closed initially
        artifactLocationImage.enabled = false; // Hide the artifact location image initially
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player touches the treasure box
        if (other.CompareTag("Player") && !isOpened)
        {
            if (playerScript.hieroglyphTokens >= requiredTokens)
            {
                OpenTreasureBox();
            }
            else
            {
                Debug.Log("You need more tokens to open this treasure box.");
            }
        }
    }

    void OpenTreasureBox()
    {
        isOpened = true;
        treasureBoxClosed.SetActive(false);  // Hide the closed box
        treasureBoxOpen.SetActive(true);     // Show the open box

        // Display the artifact location image
        artifactLocationImage.sprite = artifactMapSprite;
        artifactLocationImage.enabled = true; // Enable the image to show the map

        // Display a message or any other action that you want to do when the box opens
        Debug.Log("Treasure Box Opened! A map to the artifact location is now shown.");
    }
}

/*
 * UI Image:

Create an empty UI GameObject in your scene (right-click in the Hierarchy > UI > Image). This will be used to show the map.
Assign the Image component of this GameObject to the artifactLocationImage field in the TreasureBox script.
Initially, you may want to disable this UI image (enabled = false), so it doesn't appear when the box is closed.
Artifact Map Image:

Import the image you want to use for the artifact location (the map) into your Unity assets.
Assign this image (as a Sprite) to the artifactMapSprite field in the TreasureBox script.
Treasure Box Setup:

Set up your treasure box GameObject, making sure to have two states: one for when it is closed and one for when it is open. Assign these states to the treasureBoxClosed and treasureBoxOpen GameObjects*/