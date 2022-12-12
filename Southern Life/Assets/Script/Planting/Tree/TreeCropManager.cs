using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeCropManager : MonoBehaviour
{
    public PlantContainer field;
    public List<TreeCrop> treeCrops;
    void Start()
    {
        SetIndex();
    }

    private void SetIndex()
    {
        for (int i = 0; i < field.slots.Count; i++)
        {
            treeCrops[i].SetIndex(i);
        }
    }
}
