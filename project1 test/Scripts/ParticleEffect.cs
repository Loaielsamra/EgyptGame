using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;  
using System.Diagnostics;

public class ParticleEffect : MonoBehaviour
{
    private SpriteRenderer sr;
    public Sprite explodedBlock;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D others)
    {
        if (others.gameObject.tag == "Player" && others.GetContact(0).point.y < transform.position.y)
        {
            sr.sprite = explodedBlock;
            Object.Destroy(gameObject, .2f);
        }
    }
}

/*
 * UI Image:

Create an empty UI GameObject in your scene (right-click in the Hierarchy > UI > Image). This will be used to show the map.
Assign the Image component of this GameObject to the artifactLocationImage field in the TreasureBox script.
Initially, you may want to disable this UI image (enabled = false), so it doesn't appear when the box is closed.
Artifact Map Image:

Import the image you want to use for the artifact location (the map) into your Unity assets.
Assign this image (as a Sprite) to the artifactMapSprite field in the TreasureBox script.
Treasure Box Setup:

Set up your treasure box GameObject, making sure to have two states: one for when it is closed and one for when it is open. Assign these states to the treasureBoxClosed and treasureBoxOpen GameObjects*/