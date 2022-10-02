using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour {
    public TMP_Text text;
    private const string key = "HighScoreBetweenHellAndHeaven";
    private int Score { get; set; }

    private int HighScore {
        get => PlayerPrefs.GetInt(key, 0);
        set => PlayerPrefs.SetInt(key, value);
    }

    void Start()
    {
        EventSystemService.Instance.AddListener(EventConstants.KILL_ENEMY, OnUpScore);
        EventSystemService.Instance.AddListener(EventConstants.GAME_OVER, OnLose);
        UpdateText();
    }

    private void OnDestroy() {
        EventSystemService.Instance.RemoveListener(EventConstants.KILL_ENEMY, OnUpScore);
        EventSystemService.Instance.RemoveListener(EventConstants.GAME_OVER, OnLose);
    }

    private void OnUpScore(object[] data) {
        Score += 100;
        UpdateText();
    }    
    
    private void OnLose(object[] data) {
        if (Score > HighScore) {
            HighScore = Score;
        }
    }
    
    private void UpdateText() {
        text.text = $"Score: {Score.ToString()}\nHighscore: {HighScore.ToString()}\n";
    }
}
