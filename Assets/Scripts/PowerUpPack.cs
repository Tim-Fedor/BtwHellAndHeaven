using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PowerUpPack : MonoBehaviour {
    public int powerGive = 1;
    
    private void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.TryGetComponent(out PlayerLogic player)) {
            Bullet.damage += powerGive;
        }
        Destroy(gameObject);
    }
}
