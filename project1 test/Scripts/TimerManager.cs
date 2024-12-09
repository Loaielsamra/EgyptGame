﻿using UnityEngine;
using TMPro;

public class TimerManager : MonoBehaviour
{
    // Time in seconds (1:30 = 90 seconds)
    private float timeRemaining = 90f;

    // Reference to the UI Text
    public TextMeshProUGUI timeText;

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            // Time is up, restart the scene
            RestartScene();
        }

        // Update the UI text to show the time remaining
        UpdateTimerUI();

        // Change text color to red at 30 seconds remaining
        if (timeRemaining <= 30f)
        {
            timeText.color = Color.red;  // Set the text color to red
        }
        else
        {
            timeText.color = Color.white;  // Reset the color to white before 30 seconds
        }
    }

    // Restart the scene when time reaches 0
    void RestartScene()
    {
        // This will restart the current scene
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    // Update the UI to display the remaining time
    void UpdateTimerUI()
    {
        // Display the remaining time in minutes:seconds format
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}

