using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public void StartGame(int level) {
        Time.timeScale = 1;
        SceneManager.LoadScene($"Level{level}");
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
