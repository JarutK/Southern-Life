using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveAndLoadPanel : MonoBehaviour
{
    public bool save;
    bool isActive;
    private void OnEnable()
    {
        isActive = true;
    }

    private void OnDisable()
    {
        isActive = false;
    }

    private void Update()
    {
        if (isActive)
        {
            GameManager.instance.player.GetComponent<PlayerController>().enabled = false;
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
            GameManager.instance.player.GetComponent<PlayerController>().enabled = true;
        }
    }
}
