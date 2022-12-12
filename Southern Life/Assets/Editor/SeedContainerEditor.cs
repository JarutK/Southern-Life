using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SeedContainer))]
public class SeedContainerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        SeedContainer container = target as SeedContainer;
        if (GUILayout.Button("Clear container"))
        {
            for (int i = 0; i < container.slots.Count; i++)
            {
                container.slots[i].Clear();
            }
        }
        DrawDefaultInspector();
    }
}
