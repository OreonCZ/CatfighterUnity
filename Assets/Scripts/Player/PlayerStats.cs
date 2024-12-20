using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float playerMaxHP = 9;
    public float playerDamage = 1f;
    public int playerMilk = 2;
    public float playerMovementSpeed = 150f;
    public float playerMaxStamina = 50f;
    public int currentMoney = 0;


    private void Awake()
    {
        Debug.Log(playerMaxHP);
    }
    private void Start()
    {
        LoadPlayer();
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

        playerMaxHP = data.playerMaxHP;
        playerDamage = data.playerDamage;
        playerMilk = data.playerMilk;
        playerMovementSpeed = data.playerMovementSpeed;
        playerMaxStamina = data.playerMaxStamina;
        currentMoney = data.currentMoney;

        //Vector3 position;
        //position.x = data.playerPosition[0];
        //position.y = data.playerPosition[1];
        //position.z = data.playerPosition[2];
        //transform.position = position;

    }

    public void ResetStats()
    {
        playerMaxHP = 9;
        playerDamage = 1f;
        playerMilk = 2;
        playerMovementSpeed = 150f;
        playerMaxStamina = 50f;
        currentMoney = 0;
        Debug.Log("Player stats reset to default values.");
    }
}