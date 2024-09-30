using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SavePlayer(GameManager gm)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = GetSavePath();

        try
        {
            FileStream stream = new FileStream(path, FileMode.Create);
            PlayerData data = new PlayerData(gm);
            formatter.Serialize(stream, data);
            stream.Close();
            Debug.Log("Game saved to: " + path);
        }
        catch (IOException e)
        {
            Debug.LogError("Failed to save the game: " + e.Message);
        }
    }

    public static PlayerData LoadPlayer()
    {
        string path = GetSavePath();
        if (File.Exists(path))
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);
                PlayerData data = formatter.Deserialize(stream) as PlayerData;
                stream.Close();
                Debug.Log("Game loaded from: " + path);
                return data;
            }
            catch (IOException e)
            {
                Debug.LogError("Failed to load the game: " + e.Message);
                return null;
            }
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }

    private static string GetSavePath()
    {
        // Tenta usar o persistentDataPath da Unity
        string path = Application.persistentDataPath + "/game.fun";
        Debug.Log("Attempting to save/load at: " + path);

        // Se estiver em um build final no desktop, use a pasta "Documents" como fallback
        if (!Directory.Exists(Application.persistentDataPath))
        {
            path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "game.fun");
            Debug.Log("Fallback path for saving/loading: " + path);
        }

        return path;
    }
}

