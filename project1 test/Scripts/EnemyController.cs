using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    public bool isFacingRight = false;
    public float maxSpeed = 3f;
    public int damage = 6;
    public AudioClip hit1;
    public AudioClip hit2;

    // Start is called before the first frame update
    void Start()
    {
        // Your initialization logic if needed
    }

    // Update is called once per frame
    void Update()
    {
        // Your common update logic if needed
    }

    // Public and virtual so it can be accessed and overridden by subclasses
    public virtual void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector3(-(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    }

    // Public and virtual so it can be accessed and overridden by subclasses
    public virtual void ChasePlayer(float speed)
    {
        if (player == null) return;

        Vector2 targetPosition = new Vector2(player.transform.position.x, transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }

    // Public and virtual so it can be accessed and overridden by subclasses
    public virtual void Attack()
    {
        // Add common attack logic here, if necessary
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            AudioController.instance.RandomizeSfx(hit2, hit1);
            FindObjectOfType<PlayerStats>().TakeDamage(damage);
        }
    }
}
