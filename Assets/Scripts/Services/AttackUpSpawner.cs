using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AttackUpSpawner : SpawnerBase {
    
    void Start() {
        Bullet.damage = 5;
        parentWorld = SwitchController.WorldName.HEAVEN;
        EventSystemService.Instance.AddListener(EventConstants.CHANGED_WORLD, OnChangeWorld);
    }

    private void OnDestroy() {
        EventSystemService.Instance.RemoveListener(EventConstants.CHANGED_WORLD, OnChangeWorld);
    }
    
    protected override void SpawnEntity() {
        if (Random.Range(0, 100) >= 15) {
            return;
        }
        
        for (int i = 0; i < currentNumOfSpawn; i++) {
            Instantiate(_prefab, _spawnPoints[Random.Range(0, _spawnPoints.Count)].position, Quaternion.identity);
        }

        AfterSpawn();
    }
    
}
