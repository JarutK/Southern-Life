using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonTrigger : MonoBehaviour
{
    [SerializeField] SceneLoader sceneLoader;
    public void doNewGame()
    {
        sceneLoader.NewScene("DarkScene1");
    }

    //public void doLoadGame()
    //{
    //    SceneManager.sceneLoaded += OnSceneLoaded;
    //    sceneLoader.NewScene("MainScene");
    //}
    //private void OnSceneLoaded(Scene aScene, LoadSceneMode aMode)
    //{
    //}
    public void doSkip()
    {
        sceneLoader.NewScene("MainScene");
    }


    public void doExitGame()
    {
        Application.Quit();
    }

    
}
