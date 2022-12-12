using BayatGames.SaveGameFree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BedManager : MonoBehaviour
{
    [SerializeField] GameObject saveAndLoadPanel;
    [SerializeField] Text saveText;
    PlayerController playerController;
    public GameObject changeScene;
    private void OnTriggerEnter2D(Collider2D other)
    {
        saveAndLoadPanel.SetActive(true);
        saveText.text = "Select File to Save";
        saveAndLoadPanel.GetComponent<SaveAndLoadPanel>().save = true;
    }
}
