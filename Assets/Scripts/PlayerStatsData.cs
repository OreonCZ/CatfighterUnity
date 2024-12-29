using System.Collections.Generic;

[System.Serializable]
public class PlayerStatsData
{
    public float playerMaxHP;
    public float playerDamage;
    public float playerMilk;
    public float playerMovementSpeed;
    public float playerMaxStamina;
    public int currentMoney;
    public List<int> purchasedItems;
    //public float[] playerPosition;

    public PlayerStatsData(PlayerStats playerStats)
    {
        playerMaxHP = playerStats.playerMaxHP;
        playerDamage = playerStats.playerDamage;
        playerMilk = playerStats.playerMilk;
        playerMovementSpeed = playerStats.playerMovementSpeed;
        playerMaxStamina = playerStats.playerMaxStamina;
        currentMoney = playerStats.currentMoney;

        //playerPosition = new float[3];
        //playerPosition[0] = playerStats.transform.position.x;
        //playerPosition[1] = playerStats.transform.position.y;
        //playerPosition[2] = playerStats.transform.position.z;
        purchasedItems = new List<int>();
        foreach (var item in playerStats.purchasedItems)
        {
            purchasedItems.Add((int)item); // Convert enum to int for serialization
        }
    }

}
