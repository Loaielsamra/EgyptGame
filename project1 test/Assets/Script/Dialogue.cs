using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TMP_Text dialogueText;

    public GameObject dialogueCanvas;

    public KeyCode interactKey;

    private bool dialogueActivated;

    [TextArea]
    public string[] dialogueWords;
    private int step;

    private bool DialogueDone = false;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {

        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(interactKey) && dialogueActivated == true)
        {
            if (step == dialogueWords.Length)
            {
                dialogueCanvas.SetActive(false);
                DialogueDone = true;
                anim.SetBool("done", DialogueDone);
                Time.timeScale = 1;
            }
            else
            {
                Time.timeScale = 0;
                dialogueCanvas.SetActive(true);
                dialogueText.text = dialogueWords[step];
                step += 1;
            }
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
