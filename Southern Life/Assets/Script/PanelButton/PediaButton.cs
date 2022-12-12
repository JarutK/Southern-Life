using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PediaButton : MonoBehaviour
{
    [SerializeField] GameObject pediaPanel;
    GameObject player;
    Transform playerPosition;
    GameObject inventory;
    GameObject seedBagPanel;
    GameObject shop;
    GameObject shippingBox;
    PlayerController playerController;

    private void Start()
    {
        player = GameManager.instance.player;
        playerPosition = player.transform;
        playerController = player.GetComponent<PlayerController>();

        inventory = GameManager.instance.inventoryPanel;
        seedBagPanel = GameManager.instance.seedBagPanel;

        shop = GameManager.instance.shopPanel;
        shippingBox = GameManager.instance.shippingBoxPanel;
    }

    public void PanelController()
    {
        if (shop.activeInHierarchy == false && shippingBox.activeInHierarchy == false)
        {
            pediaPanel.SetActive(!pediaPanel.activeInHierarchy);
            playerController.enabled = !playerController.enabled;
            playerController.rigidbody2d.velocity = Vector2.zero;
            seedBagPanel.SetActive(false);
        }
    }
}
