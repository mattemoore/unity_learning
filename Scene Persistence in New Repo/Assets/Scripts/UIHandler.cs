using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
# if UNITY_EDITOR
using UnityEditor;
# endif

[DefaultExecutionOrder(1000)]
public class UIHandler : MonoBehaviour
{
    public TMPro.TMP_InputField PlayerNameInputField;

    void Start()
    {
        PlayerNameInputField.text = SettingsManager.Instance.GameSettings.PlayerName;
    }

    public void StartNewGame()
    {
        SceneManager.LoadScene(1);
    }

    public void OnPlayerNameChanged()
    {
        SettingsManager.Instance.GameSettings.PlayerName = PlayerNameInputField.text;
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    void OnApplicationQuit()
    {
        SettingsManager.Instance.SaveData();
    }
}
