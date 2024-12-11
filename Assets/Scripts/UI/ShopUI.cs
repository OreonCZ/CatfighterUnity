using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopUI : MonoBehaviour
{
    private Transform itemContainer;
    private Transform itemTemplate;
    public Transform[] itemLocations; // Array to store empty GameObjects for locations
    private Animator kevinAnimator;

    void Awake()
    {
        itemContainer = transform.Find("ItemContainers");
        itemTemplate = itemContainer.Find("ShopItemTemplate");
        itemTemplate.gameObject.SetActive(false);
    }

    void Start()
    {
        CreateItemButton(Items.ItemType.sword_1, Items.GetSprite(Items.ItemType.sword_1), "Sword LVL1", Items.GetCost(Items.ItemType.sword_1), Items.GetItemLoc(Items.ItemType.sword_1));
        //CreateItemButton(Items.GetSprite(Items.ItemType.sword_2), "Sword 2", Items.GetCost(Items.ItemType.sword_2), 1);
        CreateItemButton(Items.ItemType.hp_1, Items.GetSprite(Items.ItemType.hp_1), "Health LVL1", Items.GetCost(Items.ItemType.hp_1), Items.GetItemLoc(Items.ItemType.hp_1));
        CreateItemButton(Items.ItemType.milk_1, Items.GetSprite(Items.ItemType.milk_1), "Milk LVL1", Items.GetCost(Items.ItemType.milk_1), Items.GetItemLoc(Items.ItemType.milk_1));
        CreateItemButton(Items.ItemType.boots_1, Items.GetSprite(Items.ItemType.boots_1), "Speed LVL1", Items.GetCost(Items.ItemType.boots_1), Items.GetItemLoc(Items.ItemType.boots_1));

        kevinAnimator = GameObject.Find("Kevin").GetComponent<Animator>();
    }

    private void CreateItemButton(Items.ItemType itemType , Sprite itemSprite, string itemName, int itemCost, int itemLoc)
    {
        if (itemLoc < 0 || itemLoc >= itemLocations.Length)
        {
            Debug.LogError($"Invalid itemLoc: {itemLoc}. Make sure it corresponds to an existing location.");
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
            PlayAnimationAndWait("KevinShopHappy");
        };

        itemTransform.gameObject.SetActive(true);
    }

    void BuyingItem(Items.ItemType itemType)
    {
        Debug.Log("Hrac si koupil " + itemType);
    }

    IEnumerator KevinAnimationWait(string animationName)
    {
        AnimatorStateInfo stateInfo = kevinAnimator.GetCurrentAnimatorStateInfo(0);

        if (stateInfo.IsName(animationName))
        {
            float animationLength = stateInfo.length;
            kevinAnimator.SetBool("KevinShopIdle", false);
            yield return new WaitForSeconds(animationLength);
            kevinAnimator.SetBool("KevinShopIdle", true);
        }
    }

    public void PlayAnimationAndWait(string animationName)
    {
        kevinAnimator.SetBool(animationName, true);
        StartCoroutine(KevinAnimationWait(animationName));
    }
}