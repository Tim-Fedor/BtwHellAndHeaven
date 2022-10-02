using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : SpawnerBase {

    void Start() {
        parentWorld = SwitchController.WorldName.HELL;
        EventSystemService.Instance.AddListener(EventConstants.CHANGED_WORLD, OnChangeWorld);
        SpawnEntity();
    }

    private void OnDestroy() {
        EventSystemService.Instance.RemoveListener(EventConstants.CHANGED_WORLD, OnChangeWorld);
    }

    protected override void SpawnEntity() {
        StartCoroutine(SpawnWithDelay());
    }

    private IEnumerator SpawnWithDelay() {
        for (int i = 0; i < currentNumOfSpawn; i++) {
            yield return new WaitForSeconds(1f);
            Instantiate(_prefab, _spawnPoints[Random.Range(0, _spawnPoints.Count)].position, Quaternion.identity);
        }

        AfterSpawn();
    }

    protected override void AfterSpawn() {
        base.AfterSpawn();
        currentNumOfSpawn += 2;
    }
}
