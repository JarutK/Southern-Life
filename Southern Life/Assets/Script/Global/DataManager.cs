using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BayatGames.SaveGameFree;
using UnityEngine.SceneManagement;

public class DataManager : MonoBehaviour
{
    private Scene scene;

    private void Start()
    {
        SaveGame.Encode = true;
    }
    public void Save()
    {
        SaveGame.Save<Scene>("myFile", scene);
    }
}
