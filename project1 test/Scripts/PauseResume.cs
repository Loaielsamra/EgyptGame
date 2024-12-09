using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseResume : MonoBehaviour
{

    public GameObject PauseScreen;
    public static bool paused;
    public KeyCode PauseButton;
    // Start is called before the first frame update
    void Start()
    {
        paused = false;
        PauseScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(PauseButton) && !paused)
        {
            Pause();
        }else if(Input.GetKey(PauseButton) && paused) {
            Resume();
        }
    }
    void Pause()
    {
        PauseScreen.SetActive(true);
        paused = true;
        Time.timeScale = 0;
    }
    public void Resume()
    {
        PauseScreen.SetActive(false);
        paused= false;
        Time.timeScale = 1;
    }
}