using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    private Transform playerPosition;

    private void Start()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    private void OnMouseDown() 
    {
        if (Vector2.Distance(transform.position, playerPosition.position) <= 5)
        {
            if (ToolScript.currentTool == "WateringCan")
            {
                ToolScript.fillWaterCan = 10;
            }
        }
            
    }
}
