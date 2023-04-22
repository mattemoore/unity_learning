using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public GameObject titleScreen;
    public GameObject gameOverScreen;
    public Button restartButton;
    private int score;
    public float spawnRate = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        ShowTitle();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowTitle()
    {
        titleScreen.SetActive(true);
        gameOverScreen.SetActive(false);
    }

    public void StartGame()
    {
        titleScreen.SetActive(false);
        gameOverScreen.SetActive(false);
        StartCoroutine(SpawnRoutine());
        UpdateScore(0);
    }

    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            GameObject targetToSpawn = targets[Random.Range(0, targets.Count)];
            Instantiate(targetToSpawn);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score:" + score;
    }

    public void EndGame()
    {
        StopAllCoroutines();
        titleScreen.SetActive(false);
        gameOverScreen.SetActive(true);
    }
}
