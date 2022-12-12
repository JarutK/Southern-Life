using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShippingBoxSlot : MonoBehaviour
{
    [SerializeField] Image icon;
    [SerializeField] Text text;

    int myIndex;

    public void SetIndex(int index)
    {
        myIndex = index;
    }

    public void Set(ItemSlot slot)
    {
        icon.sprite = slot.item.icon;
        icon.gameObject.SetActive(true);
        text.gameObject.SetActive(true);
        text.text = slot.count.ToString();
    }

    public void Clean()
    {
        icon.sprite = null;
        icon.gameObject.SetActive(false);

        text.gameObject.SetActive(false);
    }
}
