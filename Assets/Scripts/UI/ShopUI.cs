using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using UnityEngine.SceneManagement;

public class ShopUI : MonoBehaviour
{
    public PlayerStats playerStats;
    private Transform itemContainer;
    private Transform itemTemplate;
    public Transform[] itemLocations; // Array to store predefined item positions
    GameObject buttonBack;

    void Awake()
    {
        itemContainer = transform.Find("ItemContainers");
        if (itemContainer != null)
        {
            itemTemplate = itemContainer.Find("ShopItemTemplate");
            if (itemTemplate != null)
            {
                itemTemplate.gameObject.SetActive(false);
            }
            else
            {
                Debug.LogError("ShopItemTemplate not found under ItemContainers.");
            }
        }
        else
        {
            Debug.LogError("ItemContainers not found in the hierarchy.");
        }

        buttonBack = GameObject.Find("BackButton");

    }

    void Start()
    {
        // Create buttons for the shop items
        CreateItemButton(Items.ItemType.sword_1, Items.GetSprite(Items.ItemType.sword_1), "Sword LVL1", Items.GetCost(Items.ItemType.sword_1), Items.GetItemLoc(Items.ItemType.sword_1));
        CreateItemButton(Items.ItemType.hp_1, Items.GetSprite(Items.ItemType.hp_1), "Health LVL1", Items.GetCost(Items.ItemType.hp_1), Items.GetItemLoc(Items.ItemType.hp_1));
        CreateItemButton(Items.ItemType.milk_1, Items.GetSprite(Items.ItemType.milk_1), "Milk LVL1", Items.GetCost(Items.ItemType.milk_1), Items.GetItemLoc(Items.ItemType.milk_1));
        CreateItemButton(Items.ItemType.boots_1, Items.GetSprite(Items.ItemType.boots_1), "Speed LVL1", Items.GetCost(Items.ItemType.boots_1), Items.GetItemLoc(Items.ItemType.boots_1));

        SaveSystem.LoadPlayer();
        Debug.Log(playerStats.currentMoney);
    }

    private void Update()
    {
        buttonBack.GetComponent<Button_UI>().ClickFunc = () =>
        {
            SaveSystem.SavePlayer(playerStats);
            SceneManager.LoadScene(sceneBuildIndex: 1);
        };
    }



    void BuyingItem(Items.ItemType itemType)
    {
        if (playerStats.currentMoney >= Items.GetCost(itemType))
        {
            Debug.Log($"Player bought: {itemType}");
            UpgradePlayerStats(itemType);
            playerStats.currentMoney -= Items.GetCost(itemType);
            Debug.Log($"Remaining Gold: {playerStats.currentMoney}");
        }
        else
        {
            Debug.Log("Not enough gold!");
        }
    }

    private void UpgradePlayerStats(Items.ItemType itemType)
    {
        if (itemType == Items.ItemType.sword_1)
        {
            playerStats.UpgradeDamage(Items.GetItemVariable(itemType));
            Debug.Log("Player damage upgraded!");
        }
        // Add more cases for other item types if needed
    }

    private void CreateItemButton(Items.ItemType itemType, Sprite itemSprite, string itemName, int itemCost, int itemLoc)
    {
        if (itemLoc < 0 || itemLoc >= itemLocations.Length)
        {
            Debug.LogError($"Invalid item location: {itemLoc}. Check the item location mapping.");
            return;
        }

        Transform itemTransform = Instantiate(itemTemplate, itemContainer);
        itemTransform.position = itemLocations[itemLoc].position;
        itemTransform.rotation = itemLocations[itemLoc].rotation;

        itemTransform.Find("NameOfItem").GetComponent<TextMeshProUGUI>().SetText(itemName);
        itemTransform.Find("PriceOfItem").GetComponent<TextMeshProUGUI>().SetText(itemCost.ToString());
        itemTransform.Find("ItemImage").GetComponent<Image>().sprite = itemSprite;

        itemTransform.GetComponent<Button_UI>().ClickFunc = () =>
        {
            BuyingItem(itemType);
            itemTransform.gameObject.SetActive(false);
        };

        itemTransform.gameObject.SetActive(true);
    }


    }


