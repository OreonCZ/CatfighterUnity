using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.EnumTypes;

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
        
    }

    public void SaveStats()
    {
        PlayerPrefs.SetFloat("playerMaxHP", playerMaxHP);
        PlayerPrefs.SetFloat("playerDamage", playerDamage);
        PlayerPrefs.SetInt("playerMilk", playerMilk);
        PlayerPrefs.SetFloat("playerMovementSpeed", playerMovementSpeed);
        PlayerPrefs.SetFloat("playerMaxStamina", playerMaxStamina);
        PlayerPrefs.SetInt("currentMoney", currentMoney);
        PlayerPrefs.Save();
    }
}



