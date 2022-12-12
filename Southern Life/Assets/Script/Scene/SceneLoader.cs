using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Animator changeSceneAnim;
    public float waitTime;

    public void NewScene(string sceneName)
    {
        StartCoroutine(LoadNewScene(sceneName));
    }

    IEnumerator LoadNewScene(string sceneName)
    {
        changeSceneAnim.SetTrigger("Start");
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(sceneName);
    }

    
}
