using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyLogic : MonoBehaviour {
    [SerializeField] 
    private AIDestinationSetter _targetSetter;
    [SerializeField] 
    private int damage;

    void Start() {
        _targetSetter.target = PlayerLocater.PlayerLocation;
    }

    private void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.TryGetComponent(out PlayerLogic player)) {
            player.GetHit(damage);
        }
    }
}
