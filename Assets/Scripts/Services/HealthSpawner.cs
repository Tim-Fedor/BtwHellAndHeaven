using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSpawner : SpawnerBase {
    
    void Start() {
        currentNumOfSpawn = 1;
        parentWorld = SwitchController.WorldName.HEAVEN;
        EventSystemService.Instance.AddListener(EventConstants.CHANGED_WORLD, OnChangeWorld);
    }

    protected override void AfterSpawn() {
        base.AfterSpawn();
        if (Random.Range(0, 3) == 2) {
            currentNumOfSpawn++;
        }
    }
}
