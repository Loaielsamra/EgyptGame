using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NavigationController : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GoToLevel1Scene1()
    {
        SceneManager.LoadScene(0);
    }

    public void GoToLevel1Scene2()
    {
        SceneManager.LoadScene(1);
    }

    public void GoToLevel1Scene3()
    {
        SceneManager.LoadScene(2);
    }

    public void GoToLevel1Scene4()
    {
        SceneManager.LoadScene(3);
    }

    // Level 2 Scenes
    public void GoToLevel2Scene1()
    {
        SceneManager.LoadScene(4);
    }

    public void GoToLevel2Scene2()
    {
        SceneManager.LoadScene(5);
    }

    public void GoToLevel2Scene3()
    {
        SceneManager.LoadScene(6);
    }

    public void GoToLevel2Scene4()
    {
        SceneManager.LoadScene(7);
    }

    // Level 3 Scenes
    public void GoToLevel3Scene1()
    {
        SceneManager.LoadScene(8);
    }

    public void GoToLevel3Scene2()
    {
        SceneManager.LoadScene(9);
    }

    public void GoToLevel3Scene3()
    {
        SceneManager.LoadScene(10);
    }

    public void GoToLevel3Scene4()
    {
        SceneManager.LoadScene(11);
    }

    // Level 4 Scenes
    public void GoToLevel4Scene1()
    {
        SceneManager.LoadScene(12);
    }

    public void GoToLevel4Scene2()
    {
        SceneManager.LoadScene(13);
    }

    public void GoToLevel4Scene3()
    {
        SceneManager.LoadScene(14);
    }

    public void GoToLevel4Scene4()
    {
        SceneManager.LoadScene(15);
    }

    public void GoToLevel4Scene5()
    {
        SceneManager.LoadScene(16);
    }

    public void GoToGameOverScene()
    {
        SceneManager.LoadScene(17);
    }

    public void GoToVictoryScene()
    {
        SceneManager.LoadScene(18);
    }

    public void Quit()
    {
        Application.Quit();
    }

    /* public void GoToIntroScene()
    {
        SceneManager.LoadScene(0);
    }
    */ 
}