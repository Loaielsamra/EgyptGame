using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CarMovement : MonoBehaviour
{
    // Speed of the car
    public float speed = 5f;
    public int damage = 1;
    // Position to reset the car when it goes off-screen
    public float resetPositionX = -10f;
    public float startPositionX = 10f;
    bool isFacingRight ;

    void Update()
    {
        // Move the car to the left
        //transform.Translate(Vector3.left * speed * Time.deltaTime);

        // Reset position if the car goes off-screen
        /*if (transform.position.x < resetPositionX)
        {
            ResetCarPosition();
        }*/
    }

    void ResetCarPosition()
    {
        // Set the car back to the starting position
        transform.position = new Vector3(startPositionX, transform.position.y, transform.position.z);
    }

    void FixedUpdate()
    {
        if (this.isFacingRight == true)
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, this.GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, this.GetComponent<Rigidbody2D>().velocity.y);
        }
    }

    // Trigger detection
   
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<PlayerStats>().TakeDamage(damage);
        }
    }
}

