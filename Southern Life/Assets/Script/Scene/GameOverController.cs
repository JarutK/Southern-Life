using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverController : MonoBehaviour
{
    [SerializeField] SceneLoader sceneLoader;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            sceneLoader.NewScene("TitleScene");
    }
}
