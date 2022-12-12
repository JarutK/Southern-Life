using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolManager : MonoBehaviour
{
    [SerializeField] Sprite basic;
    [SerializeField] Sprite focus;
    [SerializeField] List<GameObject> quickSlot;

    void Update()
    {
        if(ToolScript.currentTool == "Hoe")
        {
            for (int i = 0; i < quickSlot.Count; i++)
            {
                quickSlot[i].GetComponent<Image>().sprite = basic;
            }
            quickSlot[0].GetComponent<Image>().sprite = focus;
        }
        if (ToolScript.currentTool == "SeedBag")
        {
            for (int i = 0; i < quickSlot.Count; i++)
            {
                quickSlot[i].GetComponent<Image>().sprite = basic;
            }
            quickSlot[1].GetComponent<Image>().sprite = focus;
        }
        if (ToolScript.currentTool == "WateringCan")
        {
            for (int i = 0; i < quickSlot.Count; i++)
            {
                quickSlot[i].GetComponent<Image>().sprite = basic;
            }
            quickSlot[2].GetComponent<Image>().sprite = focus;
        }
        if (ToolScript.currentTool == "FertilizerBag")
        {
            for (int i = 0; i < quickSlot.Count; i++)
            {
                quickSlot[i].GetComponent<Image>().sprite = basic;
            }
            quickSlot[3].GetComponent<Image>().sprite = focus;
        }
        if (ToolScript.currentTool == "Scythe")
        {
            for (int i = 0; i < quickSlot.Count; i++)
            {
                quickSlot[i].GetComponent<Image>().sprite = basic;
            }
            quickSlot[4].GetComponent<Image>().sprite = focus;
        }
        if (ToolScript.currentTool == "None")
        {
            for (int i = 0; i < quickSlot.Count; i++)
            {
                quickSlot[i].GetComponent<Image>().sprite = basic;
            }
        }
    }
}
