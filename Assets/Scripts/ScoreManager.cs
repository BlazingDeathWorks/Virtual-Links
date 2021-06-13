using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Text scoreDisplay;
    float score = 0;

    private void Awake()
    {
        PlayerCollision.GameOverFunc += OnGameOver;
        EnemyController.EnemyKilledFunc += OnEnemyKilled;
    }

    private void Update()
    {
        //Increase Points naturally
        score += Time.deltaTime;
        UpdateScoreDisplay();
    }

    private void UpdateScoreDisplay()
    {
        scoreDisplay.text = Mathf.Floor(score).ToString();
    }

    private void OnEnemyKilled(int scorePerKill)
    {
        score += scorePerKill;
        UpdateScoreDisplay();
    }

    private void OnGameOver()
    {
        if(PlayerPrefs.GetInt("Highscore") < score)
        {
            PlayerPrefs.SetInt("Highscore", (int)score);
        }
        SceneManager.LoadScene("Game Over");
    }
}
