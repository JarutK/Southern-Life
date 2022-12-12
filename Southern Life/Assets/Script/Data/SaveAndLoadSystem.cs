using BayatGames.SaveGameFree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class SaveAndLoadSystem
{
    public static void SaveData(GameData data, int id)
    {
        if (id == 1)
        {
            SaveGame.Save<GameData>("Data1", data);
        }
        else if (id == 2)
        {
            SaveGame.Save<GameData>("Data2", data);
        }
        else if (id == 3)
        {
            SaveGame.Save<GameData>("Data3", data);
        }
    }

    public static GameData LoadData(int id)
    {
        if (id == 1)
        {
            GameData data = SaveGame.Load<GameData>("Data1");
            return data;
        }
        else if (id == 2)
        {
            GameData data = SaveGame.Load<GameData>("Data2");
            return data;
        }
        else if (id == 3)
        {
            GameData data = SaveGame.Load<GameData>("Data3");
            return data;
        }

        return null;
    }

    public static void DeleteData(int id)
    {
        if (id == 1)
        {
            SaveGame.Delete("Data1");
        }
        else if (id == 2)
        {
            SaveGame.Delete("Data2");
        }
        else if (id == 3)
        {
            SaveGame.Delete("Data3");
        }
    }
}
