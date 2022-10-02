using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public float timeOfLiving = 5f;
    public static float damage = 5;
    [SerializeField]
    private GameObject _hitEffect;

    private void Start() {
        StartCoroutine(TimeDestroy());
    }
    private void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.TryGetComponent(out IShootable target)) {
            target.Shoot(damage);
        }
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
