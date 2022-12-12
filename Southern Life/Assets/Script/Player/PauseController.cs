using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    [SerializeField] GameObject pausePanel;
    public bool isPasued;

    private void Start()
    {
        isPasued = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPasued = !isPasued;
        }

        if (isPasued)
        {
            pausePanel.SetActive(true);
            GameManager.instance.player.GetComponent<PlayerController>().enabled = false;
            Time.timeScale = 0f;
        }
        else
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1f;
            GameManager.instance.player.GetComponent<PlayerController>().enabled = true;
        }
    }
}
