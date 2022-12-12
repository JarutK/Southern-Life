using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Plant")]
public class Plant : ScriptableObject
{
    public Sprite icon;
    public Sprite state0;
    public Sprite state1;
    public Sprite state2;
    public Sprite state3;
    public string Name;
    public int timeToGrow1;
    public int timeToGrow2;
    public int timeToGrow3;
    public bool tree;
    public Item product;
    public bool pickable;
    public int pickTime;
    public int pickCoolDown;
    public int price;
    public int dropCount;
}
