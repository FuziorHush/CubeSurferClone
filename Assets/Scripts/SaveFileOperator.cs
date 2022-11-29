using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveFileOperator : MonoBehaviour
{
    private static readonly string _gameSavePath;

    static SaveFileOperator()
    {
        _gameSavePath = Application.persistentDataPath + "/gamesave.save";
    }

    public static bool SaveGame(IGameSave gameSave)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream fileStream = new FileStream(_gameSavePath, FileMode.Create);

        try
        {
            binaryFormatter.Serialize(fileStream, gameSave);
            fileStream.Close();
            Debug.Log("Game saved " + _gameSavePath);
            return true;
        }
        catch (System.Exception)
        {
            Debug.LogError("Save failed");
            fileStream.Close();
            return false;
        }
    }

    public static IGameSave LoadGame()
    {
        if (!File.Exists(_gameSavePath))
        {
            if (DataSystem.Instance != null)
                DataSystem.Instance.CreateDefaultGameSave();
        }

        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream fileStream = new FileStream(_gameSavePath, FileMode.Open);

        IGameSave gameSave;
        try
        {
            gameSave = (IGameSave)binaryFormatter.Deserialize(fileStream);
            fileStream.Close();
            Debug.Log("Game loaded " + _gameSavePath);
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
