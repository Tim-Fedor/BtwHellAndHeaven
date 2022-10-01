using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBase : MonoBehaviour
{
    [SerializeField] 
    protected GameObject _prefab;
    [SerializeField] 
    protected List<Transform> _spawnPoints;


    protected SwitchController.WorldName parentWorld;
    public int currentNumOfSpawn;

    protected virtual void OnChangeWorld(object[] data) {
        if (data != null && data.Length > 0 && data[0] is SwitchController.WorldName && (SwitchController.WorldName) data[0] == parentWorld) {
            SpawnEntity();
        }
    }

    protected virtual void SpawnEntity() {
        Debug.Log($"Wtf is here, worild is {parentWorld.ToString()}");
        for (int i = 0; i < currentNumOfSpawn; i++) {
            Debug.Log("Wtf is here 1");
            Instantiate(_prefab, _spawnPoints[Random.Range(0, _spawnPoints.Count)].position, Quaternion.identity);
        }

        AfterSpawn();
    }

    protected virtual void AfterSpawn() {
        
    }
}
