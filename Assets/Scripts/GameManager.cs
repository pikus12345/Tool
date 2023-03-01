using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool IsGameRunning;
    public static float GameSpeed;
    public static float score;
    public static float maxScore;
    [Header("UI Elements Links")]
    public TextMeshProUGUI scoreText;
    public GameObject menu;
    public GameObject toolsButtonsMenu;
    public TextMeshProUGUI maxScoreText;
    [Header("Player Links")]
    public PlayerMovement player;
    private void Start()
    {
        RefreshMaxScore();
        LoadData();
    }
    public void StartGame()
    {
        IsGameRunning = true;
        GameSpeed = 1f;
        score = 0;
        RefreshScoreText();
        Spawner[] spawners = FindObjectsOfType<Spawner>();
        menu.SetActive(false);
        toolsButtonsMenu.SetActive(true);
        scoreText.gameObject.SetActive(true);
    }
    public void StopGame()
    {
        player.Initialize();
        IsGameRunning = false;
        GameSpeed = 1f;
        menu.SetActive(true);
        scoreText.gameObject.SetActive(false);
        toolsButtonsMenu.SetActive(false);
        RefreshMaxScore();
    }
    public void RefreshMaxScore()
    {
        if (score > maxScore)
        {
            maxScore = score;
            SaveData();
        }
        RefreshMaxScoreText();
    }
    private void Update()
    {
        if (IsGameRunning)
        {
            GameSpeed += Time.deltaTime/40;
            Time.timeScale = GameSpeed;
            //Debug.Log($"Game Coefficient is: {GameSpeed}");
        }
    }
    private void RefreshScoreText()
    {
        scoreText.text = score.ToString();
    }
    private void RefreshMaxScoreText()
    {
        maxScoreText.text = $"Max score: {maxScore}";
    }

    public void AddScore()
    {
        score++;
        RefreshScoreText();
    }
    public void LoadData()
    {
        if (PlayerPrefs.HasKey("MaxScore"))
        {
            maxScore = PlayerPrefs.GetFloat("MaxScore");
            RefreshMaxScore();
        }
    }
    public void SaveData()
    {
        PlayerPrefs.SetFloat("MaxScore", maxScore);
    }
}
