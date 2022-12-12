using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    public GameObject pausePanel;
    [SerializeField] PauseController pauseController;
    [SerializeField] GameObject saveAndLoadPanel;
    [SerializeField] Text loadText;

    public void doResume()
    {
        pauseController.isPasued = false;
    }

    public void doLoad()
    {
        saveAndLoadPanel.SetActive(true);
        loadText.text = "Select File to Load";
        saveAndLoadPanel.GetComponent<SaveAndLoadPanel>().save = false;
        pausePanel.SetActive(false);
    }

    public void doQuit()
    {
        Application.Quit();
    }
}
