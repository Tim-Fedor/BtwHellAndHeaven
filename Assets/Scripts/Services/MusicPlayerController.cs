using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayerController : MonoBehaviour {
    public AudioSource hellMusic;
    public AudioSource heavenMusic;
    public AudioSource powerUp;
    void Start()
    {
        hellMusic.Play();
        EventSystemService.Instance.AddListener(EventConstants.CHANGED_WORLD, OnChange);
    }

    private void OnDestroy() {
        EventSystemService.Instance.RemoveListener(EventConstants.CHANGED_WORLD, OnChange);
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
    
}
