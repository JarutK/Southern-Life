using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropManager : MonoBehaviour
{
    public PlantContainer plantation;
    public List<Crop> crops;
    void Awake()
    {
        SetIndex();
    }

    private void SetIndex()
    {
        for (int i = 0; i < plantation.slots.Count; i++)
        {
            crops[i].SetIndex(i);
        }
    }

    public void LoadAllCrop()
    {
        for (int i = 0; i < plantation.slots.Count; i++)
        {
            crops[i].LoadCrop();
        }
    }
}
