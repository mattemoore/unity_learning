using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance { get; private set; }
    public Color TeamColor;
    private string _fileSavePath;

    void Awake()
    {
        _fileSavePath = Application.persistentDataPath + "/savefile.json";
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        LoadColor();
    }

    [System.Serializable]
    public class SaveData
    {
        public Color TeamColor;
    }

    public void SaveColor()
    {
        Debug.Log("Saving color...");
        SaveData saveData = new SaveData();
        saveData.TeamColor = this.TeamColor;
        File.WriteAllText(_fileSavePath, JsonUtility.ToJson(saveData));
    }

    public void LoadColor()
    {
        if (File.Exists(_fileSavePath))
        {
            Debug.Log("Loading color...");
            SaveData saveData = JsonUtility.FromJson<SaveData>(File.ReadAllText(_fileSavePath));
            this.TeamColor = saveData.TeamColor;
        }
    }
}

