using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
        if (Input.GetKeyDown(PauseButton))
        {
            if (!paused)
            {
                Pause();
            }
            else
            {
                Resume();
            }
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
        paused = false;
        Time.timeScale = 1;
    }
    public void Restart()
    {
        Time.timeScale = 1; // Ensure the game is running normally
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
    }
}