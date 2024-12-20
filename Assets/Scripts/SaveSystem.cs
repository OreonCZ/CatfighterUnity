using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SavePlayer(PlayerStats playerStats)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/playerStats.xd";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerStatsData playerData = new PlayerStatsData(playerStats);
        binaryFormatter.Serialize(stream, playerData);
        stream.Close();
    }

    public static PlayerStatsData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/playerStats.xd";
        if (File.Exists(path))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerStatsData data = binaryFormatter.Deserialize(stream) as PlayerStatsData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("Save file not loaded | " + path);
            return null;
        }
    }
}
