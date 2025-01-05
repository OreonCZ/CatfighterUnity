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
    GameObject kevin;
    Image shopImage;
    public Sprite noKevin;

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
        SaveSystem.LoadPlayer();

        InitializeShopItem(Items.ItemType.sword_1);
        InitializeShopItem(Items.ItemType.hp_1);
        InitializeShopItem(Items.ItemType.milk_1);
        InitializeShopItem(Items.ItemType.boots_1);
        InitializeShopItem(Items.ItemType.stamina_1);

        if(PlayerPrefs.GetInt("BossDefeated_Kevin") != 2)
        {
            InitializeShopItem(Items.ItemType.fish);
            InitializeShopItem(Items.ItemType.gear);
            InitializeShopItem(Items.ItemType.ball);
        }

        Debug.Log(playerStats.currentMoney);
        kevin = GameObject.Find("Kevin");
        shopImage = GetComponent<Image>();
    }

    void ItemTemplate(Items.ItemType itemType)
    {
        CreateItemButton(itemType, Items.GetSprite(itemType), Items.GetItemName(itemType), Items.GetCost(itemType), Items.GetItemLoc(itemType));
    }

    private void Update()
    {
        buttonBack.GetComponent<Button_UI>().ClickFunc = () =>
        {
            SaveSystem.SavePlayer(playerStats);
            SceneManager.LoadScene(sceneBuildIndex: 1);
        };
        if(PlayerPrefs.GetInt("BossDefeated_Kevin") == 2)
        {
            kevin.SetActive(false);
            shopImage.sprite = noKevin;
            shopImage.color = new Color32(55, 55, 55, 255);
        }
    }

    void InitializeShopItem(Items.ItemType baseItem)
    {
        Items.ItemType? itemToDisplay = baseItem;

        while (itemToDisplay != null && playerStats.HasPurchasedItem(itemToDisplay.Value))
        {
            itemToDisplay = Items.GetNextItem(itemToDisplay.Value);
        }
        if (itemToDisplay != null)
        {
            ItemTemplate(itemToDisplay.Value);
        }
    }


    void BuyingItem(Items.ItemType itemType)
    {
        bool isFree = PlayerPrefs.GetInt("BossDefeated_Kevin") == 2;

        if (isFree || playerStats.currentMoney >= Items.GetCost(itemType))
        {
            Debug.Log($"Player bought: {itemType}");
            playerStats.AddPurchasedItem(itemType);
            UpgradePlayerStats(itemType);

            if (!isFree)
            {
                playerStats.currentMoney -= Items.GetCost(itemType);
                Debug.Log($"Remaining Gold: {playerStats.currentMoney}");
            }

            ReplaceItem(itemType);
            SaveSystem.SavePlayer(playerStats);
        }
        else
        {
            Debug.Log("Not enough gold!");
        }
    }


    private void ReplaceItem(Items.ItemType oldItemType)
    {
        Items.ItemType? newItemType = null;

        if (oldItemType == Items.ItemType.sword_1) newItemType = Items.ItemType.sword_2;
        if (oldItemType == Items.ItemType.sword_2) newItemType = Items.ItemType.sword_3;
        if (oldItemType == Items.ItemType.sword_3) newItemType = Items.ItemType.sword_4;

        if (oldItemType == Items.ItemType.hp_1) newItemType = Items.ItemType.hp_2;
        if (oldItemType == Items.ItemType.hp_2) newItemType = Items.ItemType.hp_3;
        if (oldItemType == Items.ItemType.hp_3) newItemType = Items.ItemType.hp_4;

        if (oldItemType == Items.ItemType.boots_1) newItemType = Items.ItemType.boots_2;
        if (oldItemType == Items.ItemType.boots_2) newItemType = Items.ItemType.boots_3;
        if (oldItemType == Items.ItemType.boots_3) newItemType = Items.ItemType.boots_4;

        if (oldItemType == Items.ItemType.milk_1) newItemType = Items.ItemType.milk_2;
        if (oldItemType == Items.ItemType.milk_2) newItemType = Items.ItemType.milk_3;
        if (oldItemType == Items.ItemType.milk_3) newItemType = Items.ItemType.milk_4;

        if (oldItemType == Items.ItemType.stamina_1) newItemType = Items.ItemType.stamina_2;
        if (oldItemType == Items.ItemType.stamina_2) newItemType = Items.ItemType.stamina_3;
        if (oldItemType == Items.ItemType.stamina_3) newItemType = Items.ItemType.stamina_4;

        if (newItemType == null) return;

        int itemLoc = Items.GetItemLoc(oldItemType);
        if (itemLoc < 0 || itemLoc >= itemLocations.Length)
        {
            Debug.LogError($"Invalid item location: {itemLoc} for item {oldItemType}");
            return;
        }

        CreateItemButton(newItemType.Value, Items.GetSprite(newItemType.Value),
                         Items.GetItemName(newItemType.Value), Items.GetCost(newItemType.Value), itemLoc);
    }

    private void UpgradePlayerStats(Items.ItemType itemType)
    {
        if (itemType == Items.ItemType.sword_1)
        {
            playerStats.UpgradeDamage(Items.GetItemVariable(itemType));
            Debug.Log("Player damage upgraded!");
        }
        if (itemType == Items.ItemType.sword_2)
        {
            playerStats.UpgradeDamage(Items.GetItemVariable(itemType));
            Debug.Log("Player damage upgraded!");
        }
        if (itemType == Items.ItemType.sword_3)
        {
            playerStats.UpgradeDamage(Items.GetItemVariable(itemType));
            Debug.Log("Player damage upgraded!");
        }
        if (itemType == Items.ItemType.sword_4)
        {
            playerStats.UpgradeDamage(Items.GetItemVariable(itemType));
            Debug.Log("Player damage upgraded!");
        }
        //SWORD

        if (itemType == Items.ItemType.hp_1)
        {
            playerStats.UpgradeHP(Items.GetItemVariable(itemType));
            Debug.Log("Player hp upgraded!");
        }
        if (itemType == Items.ItemType.hp_2)
        {
            playerStats.UpgradeHP(Items.GetItemVariable(itemType));
            Debug.Log("Player hp upgraded!");
        }
        if (itemType == Items.ItemType.hp_3)
        {
            playerStats.UpgradeHP(Items.GetItemVariable(itemType));
            Debug.Log("Player hp upgraded!");
        }
        if (itemType == Items.ItemType.hp_4)
        {
            playerStats.UpgradeHP(Items.GetItemVariable(itemType));
            Debug.Log("Player hp upgraded!");
        }
        //HP

        if (itemType == Items.ItemType.milk_1)
        {
            playerStats.UpgradeNumberOfMilk(Items.GetItemVariable(itemType));
            Debug.Log("Player milk upgraded!");
        }
        if (itemType == Items.ItemType.milk_2)
        {
            playerStats.UpgradeNumberOfMilk(Items.GetItemVariable(itemType));
            Debug.Log("Player milk upgraded!");
        }
        if (itemType == Items.ItemType.milk_3)
        {
            playerStats.UpgradeNumberOfMilk(Items.GetItemVariable(itemType));
            Debug.Log("Player milk upgraded!");
        }
        if (itemType == Items.ItemType.milk_4)
        {
            playerStats.UpgradeNumberOfMilk(Items.GetItemVariable(itemType));
            Debug.Log("Player milk upgraded!");
        }
        //MILK

        if (itemType == Items.ItemType.boots_1)
        {
            playerStats.UpgradeSpeed(Items.GetItemVariable(itemType));
            Debug.Log("Player speed upgraded!");
        }
        if (itemType == Items.ItemType.boots_2)
        {
            playerStats.UpgradeSpeed(Items.GetItemVariable(itemType));
            Debug.Log("Player speed upgraded!");
        }
        if (itemType == Items.ItemType.boots_3)
        {
            playerStats.UpgradeSpeed(Items.GetItemVariable(itemType));
            Debug.Log("Player speed upgraded!");
        }
        if (itemType == Items.ItemType.boots_4)
        {
            playerStats.UpgradeSpeed(Items.GetItemVariable(itemType));
            Debug.Log("Player speed upgraded!");
        }
        //SPEED

        if (itemType == Items.ItemType.stamina_1)
        {
            playerStats.UpgradeStamina(Items.GetItemVariable(itemType));
            Debug.Log("Player stamina upgraded!");
        }
        if (itemType == Items.ItemType.stamina_2)
        {
            playerStats.UpgradeStamina(Items.GetItemVariable(itemType));
            Debug.Log("Player stamina upgraded!");
        }
        if (itemType == Items.ItemType.stamina_3)
        {
            playerStats.UpgradeStamina(Items.GetItemVariable(itemType));
            Debug.Log("Player stamina upgraded!");
        }
        if (itemType == Items.ItemType.stamina_4)
        {
            playerStats.UpgradeStamina(Items.GetItemVariable(itemType));
            Debug.Log("Player stamina upgraded!");
        }
        //STAMINA

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

        bool isFree = PlayerPrefs.GetInt("BossDefeated_Kevin") == 2;

        if (isFree)
        {
            itemTransform.Find("PriceOfItem").GetComponent<TextMeshProUGUI>().SetText("FREE");

            string itemTypeName = itemType.ToString();
            if (itemTypeName.EndsWith("_4"))
            {
                itemTransform.GetComponent<Button_UI>().enabled = false;
                itemTransform.Find("PriceOfItem").GetComponent<TextMeshProUGUI>().SetText("UNAVAILABLE");
            }
        }
        else
        {
            itemTransform.Find("PriceOfItem").GetComponent<TextMeshProUGUI>().SetText(itemCost.ToString());
        }

        itemTransform.Find("ItemImage").GetComponent<Image>().sprite = itemSprite;

        itemTransform.GetComponent<Button_UI>().ClickFunc = () =>
        {
            if (isFree || playerStats.currentMoney >= Items.GetCost(itemType))
            {
                itemTransform.gameObject.SetActive(false);
                BuyingItem(itemType);
            }
            else
            {
                Debug.Log("Not enough gold!");
            }
        };

        itemTransform.gameObject.SetActive(true);
    }
}



