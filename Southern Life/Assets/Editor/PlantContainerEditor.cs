using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PlantContainer))]
public class PlantContainerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        PlantContainer container = target as PlantContainer;
        if (GUILayout.Button("Clear container"))
        {
            for (int i = 0; i < container.slots.Count; i++)
            {
                container.slots[i].AllCropClear();
            }
        }
        DrawDefaultInspector();
    }
}
