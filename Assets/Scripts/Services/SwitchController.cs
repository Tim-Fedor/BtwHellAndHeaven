using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    public enum WorldName {
        HELL = 0,
        HEAVEN = 1,
    }
    public WorldName CurrentWorld { get; set; }
    
    [SerializeField] 
    private Transform _hellSpawn;
    [SerializeField] 
    private Transform _heavenSpawn;

    private void Start() {
        EventSystemService.Instance.AddListener(EventConstants.TIMER_UP, TimesUp);
    }


    public void SwitchWorld(int world) {
        switch (world) {
            case 0:
                SwitchWorld(WorldName.HELL);
                break;
            case 1:
                SwitchWorld(WorldName.HEAVEN);
                break;
        }
    }
    
    public void SwitchWorld(WorldName world) {
        switch (world) {
            case WorldName.HELL:
                CurrentWorld = WorldName.HELL;
                PlayerLocater.PlayerLocation.position = _hellSpawn.position;
                Camera.main.backgroundColor = Color.red;
                break;
            case WorldName.HEAVEN:
                CurrentWorld = WorldName.HEAVEN;
                PlayerLocater.PlayerLocation.position = _heavenSpawn.position;
                Camera.main.backgroundColor = Color.cyan;
                break;
        }
    }

    public void ChangeWorld() {
        switch (CurrentWorld) {
            case WorldName.HELL:
                SwitchWorld(WorldName.HEAVEN);
                break;
            case WorldName.HEAVEN:
                SwitchWorld(WorldName.HELL);
                break;
        }
    }

    private void TimesUp(object[] data) {
        ChangeWorld();
    }
}
