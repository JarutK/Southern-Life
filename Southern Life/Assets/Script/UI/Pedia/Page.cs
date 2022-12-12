using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = ("Data/BookPage"))]
public class Page : ScriptableObject
{
    public Sprite[] pic;
    [TextArea(3, 10)]
    public string[] desText;
}
