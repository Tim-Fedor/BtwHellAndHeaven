using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyLogic : MonoBehaviour {
    [SerializeField] 
    private AIDestinationSetter _targetSetter;

    void Start() {
        _targetSetter.target = PlayerLocater.PlayerLocation;
    }


}
