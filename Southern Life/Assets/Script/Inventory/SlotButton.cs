using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotButton : MonoBehaviour, IPointerClickHandler
{
    public Image icon;
    public Text text;

    public int myIndex;

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

    public void OnPointerClick(PointerEventData eventData)
    {
        ItemContainer inventory = GameManager.instance.inventoryContainer;
        GameManager.instance.dragAndDropItem.OnClick(inventory.slots[myIndex]);
        transform.parent.GetComponent<InventoryPanel>().Show();
    }
}
