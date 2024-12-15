using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdFly : MonoBehaviour
{
    // Speed of the bird's movement
    public float speed = 5f;

    // Direction the bird will fly
    public Vector3 flyDirection = Vector3.forward;

    // Time before the bird is destroyed
    public float lifetime = 10f;

    // Start is called before the first frame update
    void Start()
    {
        // Destroy the bird after its lifetime expires
        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        // Move the bird in the specified direction
        transform.Translate(flyDirection * speed * Time.deltaTime);
    }
}
