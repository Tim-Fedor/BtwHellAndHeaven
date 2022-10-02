using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenController : MonoBehaviour {
    public GameObject loseScreen;
    public GameObject winScreen;
    void Start()
    {
        EventSystemService.Instance.AddListener(EventConstants.GAME_OVER, OnLose);
    }

    private void OnDestroy() {
        EventSystemService.Instance.RemoveListener(EventConstants.GAME_OVER, OnLose);
    }

    void OnLose(object[] data) {
        loseScreen.SetActive(true);
    }
}
