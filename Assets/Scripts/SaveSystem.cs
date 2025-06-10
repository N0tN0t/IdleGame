using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
    public static void SaveStats(Stats stats)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/clicker.lol";
        FileStream stream = new FileStream(path, FileMode.OpenOrCreate);

        DataForSaving data = new DataForSaving(stats);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static DataForSaving LoadStats()
    {
        string path = Application.persistentDataPath + "/clicker.lol";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            DataForSaving data = formatter.Deserialize(stream) as DataForSaving;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
