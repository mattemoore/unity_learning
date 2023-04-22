using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficulyButton : MonoBehaviour
{
    // Start is called before the first frame update
    private Button button;
    private GameManager gameManager;
    void Start()
    {
        button = this.gameObject.GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetDifficulty()
    {
        switch (gameObject.name)
        {
            case ("EasyButton"):
                SetEasy();
                break;
            case ("MediumButton"):
                SetMedium();
                break;
            case ("HardButton"):
                SetHard();
                break;
            default:
                SetEasy();
                break;
        }
    }

    public void SetEasy()
    {
        gameManager.spawnRate = 2f;
        gameManager.StartGame();
    }

    public void SetMedium()
    {
        gameManager.spawnRate = 1.0f;
        gameManager.StartGame();
    }

    public void SetHard()
    {
        gameManager.spawnRate = 0.5f;
        gameManager.StartGame();
    }
}
