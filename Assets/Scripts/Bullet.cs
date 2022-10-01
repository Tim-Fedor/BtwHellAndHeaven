using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public float timeOfLiving = 5f;
    [SerializeField]
    private GameObject _hitEffect;

    private void Start() {
        StartCoroutine(TimeDestroy());
    }
    private void OnCollisionEnter2D(Collision2D col) {
        DestroyBullet(true);
    }

    private void DestroyBullet(bool isHit) {
        if(isHit){
            var effect =  Instantiate(_hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 5);
        }
        Destroy(gameObject);
    }

    private IEnumerator TimeDestroy() {
        yield return new WaitForSeconds(timeOfLiving);
        DestroyBullet(false);
    }
}
