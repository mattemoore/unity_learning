using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public GameObject titleScreen;
    public GameObject gameOverScreen;
    public GameObject scorePanel;
    public Button restartButton;
    public float spawnRate = 1.0f;
    public int startLivesRemaining = 3;
    public int currentLivesRemaining;
    private int score;
    private BGMusic bgMusic;
    private bool isPaused;
    public bool isGameRunning;

    void Start()
    {
        ShowTitle();
        bgMusic = GameObject.Find("BGMusic").GetComponent<BGMusic>();
    }

    void Update()
    {
        if (isGameRunning)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                isPaused = !isPaused;
                if (isPaused)
                {
                    Time.timeScale = 0;
                    bgMusic.StopBGMusic();
                }
                else
                {
                    Time.timeScale = 1;
                    bgMusic.PlayBGMusic();
                }
            }
        }
    }

    public void ShowTitle()
    {
        titleScreen.SetActive(true);
        gameOverScreen.SetActive(false);
    }

    public void StartGame()
    {
        isGameRunning = true;
        titleScreen.SetActive(false);
        gameOverScreen.SetActive(false);
        scorePanel.SetActive(true);
        StartCoroutine(SpawnRoutine());
        SetLivesRemaining(startLivesRemaining);
        ResetScore();
        bgMusic.PlayBGMusic();
    }

    private IEnumerator SpawnRoutine()
    {
        while (isGameRunning)
        {
            yield return new WaitForSeconds(spawnRate);
            GameObject targetToSpawn = targets[Random.Range(0, targets.Count)];
            Instantiate(targetToSpawn);
        }
    }

    public void AddToScore(int scoreToAdd)
    {
        if (isGameRunning)
        {
            score += scoreToAdd;
            scoreText.text = "Score:" + score;
        }
    }

    private void ResetScore()
    {
        score = 0;
        scoreText.text = "Score:" + score;
    }

    public void SetLivesRemaining(int livesRemaining)
    {
        if (isGameRunning)
        {
            this.currentLivesRemaining = livesRemaining;
            livesText.text = "Lives:" + livesRemaining;
            if (livesRemaining == 0)
            {
                EndGame();
            }
        }
    }

    public void LoseLife()
    {
        if (isGameRunning)
        {
            SetLivesRemaining(currentLivesRemaining - 1);
        }
    }

    public void EndGame()
    {
        StopAllCoroutines();
        titleScreen.SetActive(false);
        gameOverScreen.SetActive(true);
        scorePanel.SetActive(false);
        bgMusic.StopBGMusic();
        isGameRunning = false;
    }

}
