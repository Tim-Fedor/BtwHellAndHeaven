using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public void StartGame() {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level1");
    }

    public void ToMenu() {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
}
