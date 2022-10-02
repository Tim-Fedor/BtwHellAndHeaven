using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PowerUpPack : MonoBehaviour {
    public int powerGive = 2;
    
    private void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.TryGetComponent(out PlayerLogic player)) {
            EventSystemService.Instance.DispatchEvent(EventConstants.PLAYER_POWER_UP);
            Bullet.damage += powerGive;
        }
        Destroy(gameObject);
    }
}
