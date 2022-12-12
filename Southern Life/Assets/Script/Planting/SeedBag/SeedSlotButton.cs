using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SeedSlotButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] Image icon;
    [SerializeField] Text text;

    int myIndex;

    public void SetIndex(int index)
    {
        myIndex = index;
    }

    public void Set(SeedSlot slot)
    {
        icon.sprite = slot.plant.icon;

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
        SeedContainer seedBag = GameManager.instance.seedBagContainer;
        GameManager.instance.dragAndSowSeed.OnClick(seedBag.slots[myIndex]);
        transform.parent.GetComponent<SeedBagPanel>().Show();
    }
}
