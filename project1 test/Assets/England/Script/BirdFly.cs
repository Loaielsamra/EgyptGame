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

   // public AudioClip chirpSound;
    public float chirpInterval = 1f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Chirp", chirpInterval, chirpInterval);
       
    }

    // Update is called once per frame
    void Update()
    {
        // Move the bird in the specified direction
        transform.Translate(flyDirection * speed * Time.deltaTime);
    }

    /*public void Chirp()
    {
        AudioManager.instance.PlaySingle(chirpSound);
    }*/
}
