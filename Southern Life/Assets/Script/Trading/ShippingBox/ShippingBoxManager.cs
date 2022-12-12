using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShippingBoxManager : MonoBehaviour
{
    [SerializeField] ItemContainer shippingBox;
    [SerializeField] List<ShippingBoxSlot> slots;
    int price;
    int count;
    void Start()
    {
        SetIndex();
        Show();
    }

    private void OnEnable()
    {
        Show();
    }

    private void SetIndex()
    {
        for (int i = 0; i < shippingBox.slots.Count; i++)
        {
            slots[i].SetIndex(i);
        }
    }

    public void Show()
    {
        for (int i = 0; i < shippingBox.slots.Count; i++)
        {
            if (shippingBox.slots[i].item == null)
            {
                slots[i].Clean();
            }
            else
            {
                slots[i].Set(shippingBox.slots[i]);
            }
        }
    }

    public void Clear()
    {
        for (int i = 0; i < shippingBox.slots.Count; i++)
        {
            shippingBox.slots[i].Clear();
        }
        Show();
    }

    public void Sell()
    {
        for (int i = 0; i < shippingBox.slots.Count; i++)
        {
            if(shippingBox.slots[i].item != null)
            {
                price = shippingBox.slots[i].item.price;
                count = shippingBox.slots[i].count;
                GameManager.instance.moneyManager.money += price * count;
            }
        }
        Clear();
    }

    public void DrawBack()
    {
        for (int i = 0; i < shippingBox.slots.Count; i++)
        {
            if (shippingBox.slots[i].item != null)
            {
                count = shippingBox.slots[i].count;
                GameManager.instance.inventoryContainer.Add(shippingBox.slots[i].item, count);
                GameManager.instance.inventoryContainer.OnAfterDeserialize();
            }
        }
        Clear();
    }
}
