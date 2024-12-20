[System.Serializable]
public class PlayerStatsData
{
    public float playerMaxHP;
    public float playerDamage;
    public int playerMilk;
    public float playerMovementSpeed;
    public float playerMaxStamina;
    public int currentMoney;
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
    }

}
