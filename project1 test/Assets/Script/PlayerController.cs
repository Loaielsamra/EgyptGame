using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpHeight;

    public KeyCode Spacebar;
    public KeyCode L;
    public KeyCode R;

    public int damage; // Base damage for attacks
    public float attackRange = 1.5f; // Range of attack
    public float attackCooldown = 0.5f; // Time between attacks
    public Transform attackPoint; // Position where the attack originates

    public KeyCode attack1Key;
    public KeyCode attack2Key;
    public KeyCode attack3Key;
    public KeyCode defendKey;
    public bool isAttacking;

    private float attackCooldownTimer;

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


        // Attack Animations
        /*
        if (Input.GetKeyDown(attack1Key))
        {
            anim.SetTrigger("Attack1");
            isAttacking = true;
        }
        else if (Input.GetKeyDown(attack2Key))
        {
            anim.SetTrigger("Attack2");
            isAttacking = true;
        }
        else if (Input.GetKeyDown(attack3Key))
        {
            anim.SetTrigger("Attack3");
            isAttacking = true;
        }
        */

        HandleAttacks();

        if (attackCooldownTimer > 0)
        {
            attackCooldownTimer -= Time.deltaTime;
        }

        // Defend Animation
        if (Input.GetKey(defendKey))
        {
            //anim.SetBool("Defending", true);
        }
        else
        {
            //anim.SetBool("Defending", false);
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

        this.gameObject.GetComponent<PlayerStats>().GrantImmunity();
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
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "NextScene")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if (collider.tag == "Enemy")
        {
            collider.GetComponent<EnemyController>().TakeDamage(damage);
            Debug.Log("Enemy hit!");
        }
    }

    void HandleAttacks()
    {
        if (isAttacking || attackCooldownTimer > 0)
        {
            return; // Prevent attacking while in cooldown or during an ongoing attack
        }

        if (Input.GetKeyDown(attack1Key))
        {
            PerformAttack("Attack1", damage);
        }
        else if (Input.GetKeyDown(attack2Key))
        {
            PerformAttack("Attack2", damage * 2); // Stronger attack
        }
        else if (Input.GetKeyDown(attack3Key))
        {
            PerformAttack("Attack3", damage * 3); // Special attack
        }
    }

    void PerformAttack(string animationTrigger, int attackDamage)
{
    if (anim == null || attackPoint == null)
    {
        Debug.LogError("Animator or AttackPoint is not assigned.");
        return;
    }

    isAttacking = true;
    anim.SetTrigger(animationTrigger);
    Debug.Log("Attack triggered with animation: " + animationTrigger);

    // Detect enemies in the attack range
    Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange);
    Debug.Log("Number of enemies hit: " + hitEnemies.Length);

    foreach (Collider2D enemy in hitEnemies)
    {
        if (enemy.CompareTag("Enemy"))
        {
            EnemyController enemyController = enemy.GetComponent<EnemyController>();
            if (enemyController != null)
            {
                Debug.Log("Enemy hit: " + enemy.name);
                enemyController.TakeDamage(attackDamage);
            }
            else
            {
                Debug.LogError("EnemyController component missing on: " + enemy.name);
            }
        }
    }

    // Start attack cooldown
    attackCooldownTimer = attackCooldown;

    // Reset attack state after animation ends
    StartCoroutine(ResetAttackState(anim.GetCurrentAnimatorStateInfo(0).length));
}

IEnumerator ResetAttackState(float delay)
{
    yield return new WaitForSeconds(delay);
    isAttacking = false;
    Debug.Log("Attack state reset after delay: " + delay);
}

}
