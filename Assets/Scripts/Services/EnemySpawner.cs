using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    [SerializeField] 
    private GameObject _enemyPrefab;
    [SerializeField] 
    private List<Transform> _enemySpawnPoints;
    
    public int currentNumOfEnemy = 5;
    void Start()
    {
        EventSystemService.Instance.AddListener(EventConstants.CHANGED_WORLD, ChangeWorld);
        SpawnEnemy();
    }

    private void ChangeWorld(object[] data) {
        if (data != null && data.Length > 0 && data[0] is SwitchController.WorldName.HELL) {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy() {
        for (int i = 0; i < currentNumOfEnemy; i++) {
            Instantiate(_enemyPrefab, _enemySpawnPoints[Random.Range(0, _enemySpawnPoints.Count)]);
        }

        currentNumOfEnemy++;
    }
}
