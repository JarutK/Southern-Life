using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSceneToD2 : MonoBehaviour
{
    public SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader.NewScene("DarkScene2");
    }
}
