using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    private SpriteRenderer sr;
    public Sprite explodeblock;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag=="Player" && other.GetContact(0).point.y < transform.position.y)
        {
            sr.sprite = explodeblock;
            Object.Destroy(gameObject, .2f);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    
}
