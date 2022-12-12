using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    GameObject seedBagPanel;
    GameObject inventoryPanel;
    GameObject shop;
    GameObject shippingBox;
    PlayerController playerController;
    private void Start()
    {
        shop = GameManager.instance.shopPanel;
        shippingBox = GameManager.instance.shippingBoxPanel;
        playerController = GameManager.instance.player.GetComponent<PlayerController>();
        inventoryPanel = GameManager.instance.inventoryPanel;
        seedBagPanel = GameManager.instance.seedBagPanel;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            InventoryControl();
        }
    }

    public void InventoryControl()
    {
        if (shop.activeInHierarchy == false && shippingBox.activeInHierarchy == false)
        {
            inventoryPanel.SetActive(!inventoryPanel.activeInHierarchy);
            playerController.enabled = !playerController.enabled;
            playerController.rigidbody2d.velocity = Vector2.zero;
            seedBagPanel.SetActive(false);
        }
    }
}
