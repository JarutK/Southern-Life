using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dirt Database", menuName = "Data/Dirt Database")]
public class DirtDatabase : ScriptableObject, ISerializationCallbackReceiver
{
    public Sprite[] dirts;
    public Dictionary<Sprite, int> GetId = new Dictionary<Sprite, int>();
    public Dictionary<int, Sprite> GetDirt = new Dictionary<int, Sprite>();

    public void OnAfterDeserialize()
    {
        GetId = new Dictionary<Sprite, int>();
        GetDirt = new Dictionary<int, Sprite>();
        for (int i = 0; i < dirts.Length; i++)
        {
            GetId.Add(dirts[i], i);
            GetDirt.Add(i, dirts[i]);
        }
    }

    public void OnBeforeSerialize()
    {
    }
}
