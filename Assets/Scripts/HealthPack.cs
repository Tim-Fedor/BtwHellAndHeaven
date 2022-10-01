using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class HealthPack : MonoBehaviour {
    public int healthRestored = 2;
    
    private void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.TryGetComponent(out PlayerLogic player)) {
            player.GetHealth(healthRestored);
        }
        Destroy(gameObject);
    }
}
