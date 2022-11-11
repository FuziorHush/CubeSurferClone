using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveFileOperator : MonoBehaviour
{
    private static string GameSavePath;

    static SaveFileOperator()
    {
        GameSavePath = Application.persistentDataPath + "/gamesave.save";
    }

    public static bool SaveGame(GameSave gameSave)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream fileStream = new FileStream(GameSavePath, FileMode.Create);

        try
        {
            binaryFormatter.Serialize(fileStream, gameSave);
            fileStream.Close();
            Debug.Log("Game saved " + GameSavePath);
            return true;
        }
        catch (System.Exception)
        {
            Debug.LogError("Save failed");
            fileStream.Close();
            return false;
        }
    }

    public static GameSave LoadGame()
    {
        if (!File.Exists(GameSavePath))
        {
            if (DataSystem.Instance != null)
            {
                DataSystem.Instance.CreateDefaultGameSave();
            }
        }

        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream fileStream = new FileStream(GameSavePath, FileMode.Open);

        GameSave gameSave;
        try
        {
            gameSave = (GameSave)binaryFormatter.Deserialize(fileStream);
            fileStream.Close();
            Debug.Log("Game loaded " + GameSavePath);
            return gameSave;
        }
        catch (System.Exception)
        {
            Debug.LogError("Load failed");
            fileStream.Close();
            return null;
        }
    }
}
