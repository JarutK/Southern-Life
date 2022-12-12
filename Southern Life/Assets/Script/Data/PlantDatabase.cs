using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Plant Database", menuName = "Data/Plant Database")]
public class PlantDatabase : ScriptableObject, ISerializationCallbackReceiver
{
    public Plant[] plants;
    public Dictionary<Plant, int> GetId = new Dictionary<Plant, int>();
    public Dictionary<int, Plant> GetPlant = new Dictionary<int, Plant>();

    public void OnAfterDeserialize()
    {
        GetId = new Dictionary<Plant, int>();
        GetPlant = new Dictionary<int, Plant>();
        for (int i = 0; i < plants.Length; i++)
        {
            GetId.Add(plants[i], i);
            GetPlant.Add(i, plants[i]);
        }
    }

    public void OnBeforeSerialize()
    {
    }
}
