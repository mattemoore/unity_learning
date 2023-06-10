using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public static SettingsManager Instance;
    public Settings GameSettings;

    private string _saveFilePath;

    private void Awake()
    {
        _saveFilePath = Application.persistentDataPath + "/savedata.json";
        if (SettingsManager.Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        LoadData();
    }

    public void SaveData()
    {
        string json = JsonUtility.ToJson(GameSettings);
        Debug.Log(json);
        File.WriteAllText(_saveFilePath, json);
    }

    public void LoadData()
    {
        if (File.Exists(_saveFilePath))
        {
            string json = File.ReadAllText(_saveFilePath);
            Debug.Log(json);
            GameSettings = JsonUtility.FromJson<Settings>(json);
        }
        else
        {
            GameSettings = new Settings();
            GameSettings.PlayerName = "PlayerName";
        }
    }

    [System.Serializable]
    public class Settings
    {
        public string PlayerName;
        public int HighScorePoints;
        public string HighScorePlayerName;
    }
}
