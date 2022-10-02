using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    private const string _prefKeyFireMode = "FireModeBHAH";
    public Toggle toggle;
    public static bool IsPressFireMode {
        get {
            return PlayerPrefs.GetInt(_prefKeyFireMode, 0) == 1;
        }
        set {
            int num;
            if (value) {
                num = 1;
            }
            else {
                num = 0;
            }
            PlayerPrefs.SetInt(_prefKeyFireMode, num);
        }
    }

    private void Start() {
        if (toggle != null) {
            toggle.isOn = IsPressFireMode;
        }
    }

    public void StartGame(int level) {
        Time.timeScale = 1;
        SceneManager.LoadScene($"Level{level}");
    }
    
    public void ChangeFireMode() {
        IsPressFireMode = toggle.isOn;
    }
    
    public void RestartGame() {
        Time.timeScale = 1;
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void ToMenu() {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
}
