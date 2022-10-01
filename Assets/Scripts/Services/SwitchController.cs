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
        Vector3 temp;
        switch (world) {
            case WorldName.HELL:
                CurrentWorld = WorldName.HELL;
                temp = new Vector3(_heavenSpawn.position.x - _hellSpawn.position.x,0,0);
                PlayerLocater.PlayerLocation.position -= temp;
                Camera.main.backgroundColor = Color.red;
                break;
            case WorldName.HEAVEN:
                CurrentWorld = WorldName.HEAVEN;
                temp = new Vector3(_hellSpawn.position.x - _heavenSpawn.position.x,0,0);
                PlayerLocater.PlayerLocation.position -= temp;
                Camera.main.backgroundColor = Color.cyan;
                break;
        }
        EventSystemService.Instance.DispatchEvent(EventConstants.CHANGED_WORLD, new object[]{world});
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
