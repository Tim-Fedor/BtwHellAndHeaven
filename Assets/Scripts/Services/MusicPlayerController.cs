using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayerController : MonoBehaviour {
    public AudioSource hellMusic;
    public AudioSource heavenMusic;
    void Start()
    {
        hellMusic.Play();
        EventSystemService.Instance.AddListener(EventConstants.CHANGED_WORLD, OnChange);
        EventSystemService.Instance.AddListener(EventConstants.GAME_OVER, OnLose);
    }

    private void OnDestroy() {
        EventSystemService.Instance.RemoveListener(EventConstants.CHANGED_WORLD, OnChange);
        EventSystemService.Instance.RemoveListener(EventConstants.GAME_OVER, OnLose);
    }

    private void OnChange(object[] data) {
        if (data != null && data.Length > 0 && data[0] is SwitchController.WorldName) {
            switch ((SwitchController.WorldName) data[0]) {
                case SwitchController.WorldName.HELL:
                    heavenMusic.Pause();
                    hellMusic.PlayDelayed(0.1f);
                    break;
                case SwitchController.WorldName.HEAVEN:
                    hellMusic.Pause();
                    heavenMusic.PlayDelayed(0.1f);
                    break;
            }
        }
    }

    private void OnLose(object[] data) {
        hellMusic.Pause();
        heavenMusic.Stop();
        heavenMusic.PlayDelayed(0.1f);
    }
    
}
