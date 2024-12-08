using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EagleController : MonoBehaviour
{
    public float speedTowardEnemy = 3f; // Speed at which the eagle follows the enemy
    private GameObject enemy; // Reference to the enemy
    private bool isActive = false; // To check if the eagle is active
    private float duration; // Duration of the eagle's effect

    // Start is called before the first frame update
    void Start()
    {
        // Initially, set the eagle to inactive
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // If the eagle is active and an enemy is found, move the eagle toward it
        if (isActive && enemy != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, enemy.transform.position, speedTowardEnemy * Time.deltaTime);
        }
    }

    // Trigger event to destroy the enemy on collision
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject); // Destroy the enemy object
        }
    }

    // Call this function to activate the eagle and make it follow the target enemy
    public void ActivateEagle(float effectDuration)
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy"); // Find the first enemy tagged "Enemy"
        isActive = true; // Set the eagle as active
        duration = effectDuration; // Set the duration for the eagle's effect
        gameObject.SetActive(true); // Activate the eagle GameObject

        // After the duration, deactivate the eagle
        Invoke("DeactivateEagle", duration);
    }

    // Call this function to deactivate the eagle
    private void DeactivateEagle()
    {
        isActive = false; // Set the eagle as inactive
        gameObject.SetActive(false); // Deactivate the eagle GameObject
    }
}