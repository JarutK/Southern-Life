using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterText : MonoBehaviour
{

    private Text waterText;

    private void Start()
    {
        waterText = GetComponent<Text>();
    }
    void Update()
    {
        waterText.text = ToolScript.fillWaterCan.ToString();
    }
}
