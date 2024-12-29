using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float playerMaxHP = 9f;
    public float playerDamage = 1f;
    public float playerMilk = 2f;
    public float playerMovementSpeed = 150f;
    public float playerMaxStamina = 50f;
    public int currentMoney = 0;
    public HashSet<Items.ItemType> purchasedItems = new HashSet<Items.ItemType>();

    private void Awake()
    {
        LoadPlayer();
        Debug.Log(playerMaxHP);
    }
    private void Start()
    {
        //LoadPlayer();
        Debug.Log(playerMaxHP);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            ResetStats();
        }
        SavePlayerStats();
    }

    public void UpgradeHP(float amount) { playerMaxHP += amount; }
    public void UpgradeDamage(float amount) { playerDamage += amount; }
    public void UpgradeSpeed(float amount) { playerMovementSpeed += amount; }
    public void UpgradeStamina(float amount) { playerMaxStamina += amount; }
    public void UpgradeNumberOfMilk(float amount) { playerMilk += amount; }
    public void IncreaseMoney(int amount) { currentMoney += amount;
        Debug.Log("money hehe " + currentMoney);
    }

 
    public void SavePlayerStats()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerStatsData data = SaveSystem.LoadPlayer();

        if (data != null)
        {
            playerMaxHP = data.playerMaxHP;
            playerDamage = data.playerDamage;
            playerMilk = data.playerMilk;
            playerMovementSpeed = data.playerMovementSpeed;
            playerMaxStamina = data.playerMaxStamina;
            currentMoney = data.currentMoney;

            purchasedItems.Clear();
            foreach (int itemTypeInt in data.purchasedItems)
            {
                purchasedItems.Add((Items.ItemType)itemTypeInt);
            }
        }
    }

    public void ResetStats()
    {
        playerMaxHP = 9;
        playerDamage = 1f;
        playerMilk = 2;
        playerMovementSpeed = 150f;
        playerMaxStamina = 50f;
        currentMoney = 1000;
        purchasedItems.Clear();
        Debug.Log("Pome default");
        PlayerPrefs.SetInt("BossDefeated_Kevin", 0);
        PlayerPrefs.SetInt("BossDefeated_Yuki", 0);
        PlayerPrefs.SetInt("BossDefeated_Bingus", 0);
        PlayerPrefs.SetInt("BossDefeated_Miscar", 0);
        PlayerPrefs.SetInt("BossDefeated_Oscar", 0);
    }

    public void AddPurchasedItem(Items.ItemType itemType)
    {
        purchasedItems.Add(itemType);
    }

    public bool HasPurchasedItem(Items.ItemType itemType)
    {
        return purchasedItems.Contains(itemType);
    }

}