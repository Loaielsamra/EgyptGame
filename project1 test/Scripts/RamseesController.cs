using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RamseesController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpHeight;

    public KeyCode Spacebar;
    public KeyCode L;
    public KeyCode R;

    public KeyCode attack1Key;
    public KeyCode attack2Key;
    public KeyCode attack3Key;
    public KeyCode defendKey;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool grounded;

    private Animator anim;
    public KeyCode Return;

    public AudioClip jump1;
    public AudioClip jump2;

    public PhysicsMaterial2D defaultMaterial; // Normal friction material
    public PhysicsMaterial2D stickyMaterial;  // Low friction material
    private Collider2D playerCollider;

    bool isInvisible = false; // To track invisibility status
    private float invisibilityTimer = 0f; // Timer for invisibility
    private SpriteRenderer spriteRenderer; // Reference to the player's sprite renderer

    private float speedBoostTimer = 0f;

    public float doubleJumpHeight; // Height for double jump
    private bool canDoubleJump = false; // Flag to track if double jump is available
    private float doubleJumpTimer = 0f; // Timer for double jump duration


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        playerCollider = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Jump
        if (Input.GetKeyDown(Spacebar))
        {
            if (grounded)
            {
                Jump(); // Perform normal jump
            }
            else if (canDoubleJump)
            {
                DoubleJump(); // Perform double jump
            }
        }

        anim.SetBool("Grounded", grounded);

        // Move Left
        if (Input.GetKey(L))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            if (GetComponent<SpriteRenderer>() != null)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
        }

        // Move Right
        if (Input.GetKey(R))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            if (GetComponent<SpriteRenderer>() != null)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
        }

        anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));

        // Shoot
        if (Input.GetKeyDown(Return))
        {

        }

        // Attack Animations
        if (Input.GetKeyDown(attack1Key))
        {
            anim.SetTrigger("Attack1");
        }
        else if (Input.GetKeyDown(attack2Key))
        {
            anim.SetTrigger("Attack2");
        }
        else if (Input.GetKeyDown(attack3Key))
        {
            anim.SetTrigger("Attack3");
        }

        // Defend Animation
        if (Input.GetKey(defendKey))
        {
            anim.SetBool("Defending", true);
        }
        else
        {
            anim.SetBool("Defending", false);
        }
        // Handle invisibility timer
        if (isInvisible)
        {
            invisibilityTimer -= Time.deltaTime;
            if (invisibilityTimer <= 0)
            {
                DeactivateInvisibility();
            }
        }
        if (speedBoostTimer > 0)
        {
            speedBoostTimer -= Time.deltaTime;
            if (speedBoostTimer <= 0)
            {
                DeactivateSpeedBoost(); // Revert back to normal speed
            }
        }
        if (canDoubleJump)
        {
            doubleJumpTimer -= Time.deltaTime;
            if (doubleJumpTimer <= 0)
            {
                canDoubleJump = false; // Disable double jump after the timer runs out
            }
        }
    }

    void Jump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);


    }

    void DoubleJump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, doubleJumpHeight);
        canDoubleJump = false; // Disable double jump after it's used
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }



    public void GetHit()
    {
        anim.SetTrigger("Hit");
    }
    /*void OnCollisionEnter2D(Collision2D collision)
{
    // Check if the object is tagged as "Sticky"
    if (collision.gameObject.CompareTag("Sticky"))
    {
        Debug.Log("Touched a sticky object!");
        playerCollider.sharedMaterial = stickyMaterial; // Apply sticky material
    }
}

void OnCollisionExit2D(Collision2D collision)
{
    // Revert back to default material when leaving the sticky object
    if (collision.gameObject.CompareTag("Sticky"))
    {
        Debug.Log("Left the sticky object.");
        playerCollider.sharedMaterial = defaultMaterial;
    }
}*/

    public void ActivateSpeedBoost(float duration)
    {
        moveSpeed *= 2; // Double the speed
        speedBoostTimer = duration; // Set the timer to the duration of the boost
    }

    private void DeactivateSpeedBoost()
    {
        moveSpeed /= 2; // Reset the speed to normal
    }
    public void ActivateInvisibility(float duration)
    {
        isInvisible = true;
        invisibilityTimer = duration;

        // Make the player visually semi-transparent
        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0.5f);

        // Ignore enemy collisions
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Enemy"), true);
    }
    private void DeactivateInvisibility()
    {
        isInvisible = false;

        // Restore player visibility
        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 1f);

        // Re-enable enemy collisions
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Enemy"), false);
    }
    public void EnableDoubleJump(float duration)
    {
        canDoubleJump = true;
        doubleJumpTimer = 15f; // Set the double jump timer
    }
    // Set the double jump timer to 15 seconds
}


}