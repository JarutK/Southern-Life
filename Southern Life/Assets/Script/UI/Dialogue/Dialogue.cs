using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Dialogue")]
public class Dialogue : ScriptableObject
{
    public string[] characterName;
    [TextArea(3, 10)]
    public string[] text;
}
