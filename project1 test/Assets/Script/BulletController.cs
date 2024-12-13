using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletController : MonoBehaviour
{

    public float speed;
    public float timeremaining;
    public int damage;

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);

        if (timeremaining > 0)
        {
            timeremaining -= Time.deltaTime;
        }
        else if (timeremaining <= 0)
        {
            Destroy(this.gameObject);
        }

        anim.SetFloat("speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<PlayerStats>().TakeDamage(damage);
            Destroy(this.gameObject);
        }
        if (other.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
    }

}