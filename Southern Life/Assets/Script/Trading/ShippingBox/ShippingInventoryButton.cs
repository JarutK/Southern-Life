using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShippingInventoryButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] Image icon;
    [SerializeField] Text text;
    [SerializeField] ShippingBoxManager shippingBoxManager;
    Item item;
    int count;

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
        this.item = slot.item;
        this.count = slot.count;
    }

    public void Clean()
    {
        icon.sprite = null;
        icon.gameObject.SetActive(false);

        text.gameObject.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        GameManager.instance.shippingBox.Add(item, count);
        shippingBoxManager.Show();
        GameManager.instance.inventoryContainer.slots[myIndex].Clear();
        Clean();
    }
}
