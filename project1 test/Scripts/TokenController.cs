using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



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
    private RamseesController ramseesController = collision.GetComponent<RamseesController>();
    // Start is called before the first frame update
    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        // Get the EagleController component from the eagle GameObject
        eagleController = eagle.GetComponent<EagleController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the colliding object is the player
        if (collision.CompareTag("Player"))
        {        

            if (ramseesController != null)
            {
                // Handle token effects based on token type
                if (CompareTag("EagleToken"))
                {
                    // Call the ActivateEagle method and pass the duration
                    eagleController.ActivateEagle(tokenEffectDuration); // Activate the eagle with the token effect duration
                }
                else if (CompareTag("SpeedToken"))
                {
                    ramseesController.ActivateSpeedBoost(speedBoostDuration);
                }
                else if (CompareTag("UpwardArrowToken"))
                {
                    ramseesController.EnableDoubleJump(doubleJumpDuration);
                }
                else if (CompareTag("KeyOfLifeToken"))
                {
                    BoostHealth(playerStats);
                }
                else if (CompareTag("EyeOfHorusToken"))
                {
                    ramseesController.ActivateInvisibility(invisibilityDuration);
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