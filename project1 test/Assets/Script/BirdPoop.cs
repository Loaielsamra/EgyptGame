using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdPoop : MonoBehaviour
{
    public float timeremaining;
    public int damage;

    void Start()
    {
        GetComponent<Rigidbody2D>().gravityScale = 1;
    }

    void Update()
    {
        if (timeremaining > 0)
        {
            timeremaining -= Time.deltaTime;
        }
        else if (timeremaining <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<PlayerStats>().TakeDamage(damage);
            Destroy(this.gameObject);
        }

        if (other.gameObject.layer == LayerMask.NameToLayer("ground"))
        {
            // Optional: Add splatter effect or animation here
            Destroy(this.gameObject);
        }
    }
}
