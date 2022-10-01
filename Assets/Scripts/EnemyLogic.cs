using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyLogic : MonoBehaviour {
    [SerializeField] 
    private AIDestinationSetter _targetSetter;
    [SerializeField] 
    private int _damage;
    [SerializeField] 
    private Transform _body;

    void Start() {
        _targetSetter.target = PlayerLocater.PlayerLocation;
        EventSystemService.Instance.AddListener(EventConstants.CHANGED_WORLD, OnChangedWorld);
    }

    private void OnChangedWorld(object[] data) {
        if (data != null && data.Length > 0 && data[0] is SwitchController.WorldName.HELL) {
            _targetSetter.ai.canMove = true;
        }
        else {
            _targetSetter.ai.canMove = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.TryGetComponent(out PlayerLogic player)) {
            player.GetHit(_damage);
        }
    }

    private void FixedUpdate() {
        if (_targetSetter.target.position.x > transform.position.x) {
            var scale = _body.localScale;
            scale.x = 1;
            _body.localScale = scale;
        } else{
            var scale = _body.localScale;
            scale.x = -1;
            _body.localScale = scale;
        }
    }
}
