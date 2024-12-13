using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    private GameObject dialogueCanvas;

    public KeyCode interactKey;

    private bool dialogueActivated;

    [TextArea]
    public string[] dialogueWords;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(interactKey))
        {
            dialogueCanvas.SetActive(true);

        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            dialogueActivated = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            dialogueActivated = false;
        }
    }
}
