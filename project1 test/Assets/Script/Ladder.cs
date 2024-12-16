using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    public float climbSpeed = 4f;
    private bool isClimbing = false;
    private GameObject player;
    private Rigidbody2D playerRb;
    private Animator playerAnim;
    private float originalGravityScale;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerRb = player.GetComponent<Rigidbody2D>();
            playerAnim = player.GetComponent<Animator>();
            originalGravityScale = playerRb.gravityScale;
        }
    }

    void Update()
    {
        if (isClimbing && player != null)
        {
            float vertical = Input.GetAxis("Vertical");
            // Climbing movement
            playerRb.velocity = new Vector2(playerRb.velocity.x, vertical * climbSpeed);
            //playerRb.gravityScale = 0.5f; // Disable gravity while climbing
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            isClimbing = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            isClimbing = false;
            playerRb.gravityScale = originalGravityScale; // Restore gravity when not climbing
        }
    }
}