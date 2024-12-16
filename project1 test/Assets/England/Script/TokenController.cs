using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TokenController : MonoBehaviour
{
    public GameObject eagle; // Reference to the eagle GameObject
    public Transform eagleSpawnPoint; // Spawn point for the eagle
    public float tokenEffectDuration = 25f; // Unified duration for all token effects

    public float speedBoostDuration = 5f; // Duration of speed boost
    public float doubleJumpDuration = 10f; // Duration of double jump if needed
    public int healthBoostAmount = 2; // Amount of health added by Key of Life Token
    public float invisibilityDuration = 15f; // Duration of invisibility effect

    private EagleController eagleController; // Reference to the EagleController
    private PlayerStats playerStats; // Reference to the PlayerStats
    // Start is called before the first frame update
    void Start()
    {
         playerStats = FindObjectOfType<PlayerStats>();
        // Get the EagleController component from the eagle GameObject
        eagleController = eagle.GetComponent<EagleController>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the colliding object is the player
        if (collision.tag == "Player")
        {
            PlayerController playerController = collision.GetComponent<PlayerController>();

            if (playerController != null)
            {
                // Handle token effects based on token type
                if (CompareTag("EagleToken"))
                {
                    // Call the ActivateEagle method and pass the duration
                    eagleController.ActivateEagle(tokenEffectDuration); // Activate the eagle with the token effect duration
                    Debug.Log("Collected eagle token.");
                }
                else if (CompareTag("SpeedToken"))
                {
                    playerController.ActivateSpeedBoost(speedBoostDuration);
                    Debug.Log("Collected speed token.");
                }
                else if (CompareTag("UpwordArrowToken"))
                {
                    playerController.EnableDoubleJump(doubleJumpDuration);
                    Debug.Log("Collected x2 Jump token.");
                }
                else if (CompareTag("KeyOfLifeToken"))
                {
                    BoostHealth(playerStats);
                    Debug.Log("Collected Key of Life token.");
                }
                else if (CompareTag("EyeOfHorusToken"))
                {
                    playerController.ActivateInvisibility(invisibilityDuration);
                    Debug.Log("Collected Eye of Horus token.");
                }

                // Destroy the token after applying its effect
                Destroy(gameObject);
            }
        }
    }

    private void BoostHealth(PlayerStats playerStats)
    {
        // Increase player health
        playerStats.health += healthBoostAmount;

        // Ensure health doesn't exceed the maximum allowed value (e.g., 6)
        if (playerStats.health > 6)
        {
            playerStats.health = 6;
        }

        Debug.Log("Player Health Boosted: " + playerStats.health);
    }
}

