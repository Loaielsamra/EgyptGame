using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed;
    public AudioClip hit1;
    public AudioClip hit2;
    // Start is called before the first frame update
    void Start()
    {
        PlayerController player;

        player = FindObjectOfType<PlayerController>();

        if (player.GetComponent<SpriteRenderer>().flipX == true)
        {
            speed = -speed;
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            AudioManager.instance.RandomizeSfx(hit1, hit2);
            Destroy(other.gameObject);

            Destroy(this.gameObject);
        }
    }
}
