using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
public static class SaveSystem 
{
   public static void SavePlayer (PlayerData Data)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "player.enes";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerDataSave data = new PlayerDataSave(Data);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerDataSave LoadPlayer()
    {
        string path = Application.persistentDataPath + "player.enes";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerDataSave data = formatter.Deserialize(stream) as PlayerDataSave;
            stream.Close();

            return data;
        } else
        {
            Debug.LogError("Save file not found in" + path);
            return null;
        }
    }
}
