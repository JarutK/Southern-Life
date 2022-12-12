using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotificationButton : MonoBehaviour
{
    [SerializeField] GameObject notification;
    [SerializeField] GameObject sceneLoader;
    public bool gameOver;

    public void doClose()
    {
        if (gameOver)
        {
            sceneLoader.GetComponent<SceneLoader>().NewScene("GameOver");
        }
        notification.SetActive(false);
    }
}
