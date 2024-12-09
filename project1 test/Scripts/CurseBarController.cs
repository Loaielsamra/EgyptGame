using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CurseBarController : MonoBehaviour
{
    public Slider curseBar; // Attach a UI Slider in Unity
    public int maxCurse = 100; // Maximum curse value
    public int totalArtifacts = 3; // Total number of artifacts to collect

    private int currentCurse;
    private int artifactsCollected = 0;

    void Start()
    {
        // Initialize curse bar
        currentCurse = maxCurse;
        curseBar.maxValue = maxCurse;
        curseBar.value = currentCurse;
    }

    public void CollectArtifact()
    {
        if (artifactsCollected < totalArtifacts)
        {
            artifactsCollected++;
            int curseDecrease = maxCurse / totalArtifacts;
            currentCurse -= curseDecrease;

            if (currentCurse < 0)
                currentCurse = 0;

            curseBar.value = currentCurse;

            // Check for victory condition
            if (artifactsCollected == totalArtifacts)
            {
                OnAllArtifactsCollected();
            }
        }
    }

    private void OnAllArtifactsCollected()
    {
        Debug.Log("All artifacts collected! The curse is lifted!");
        // Add victory logic here, e.g., display a message, load a new scene, etc.
        (new NavigationController()).GoToVictoryScene();

    }
}
    
