using System;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class HealthSpawner : SpawnerBase {
    
    void Start() {
        parentWorld = SwitchController.WorldName.HEAVEN;
        EventSystemService.Instance.AddListener(EventConstants.CHANGED_WORLD, OnChangeWorld);
    }

    private void OnDestroy() {
        EventSystemService.Instance.RemoveListener(EventConstants.CHANGED_WORLD, OnChangeWorld);
    }

    protected override void AfterSpawn() {
        base.AfterSpawn();
        if (Random.Range(0, 3) == 2) {
            currentNumOfSpawn++;
        }
    }
}
