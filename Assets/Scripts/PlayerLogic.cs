using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour {
    public int maxHealth;
    public int currentHealth;
    void Start() {
        currentHealth = maxHealth;
        EventSystemService.Instance.DispatchEvent(EventConstants.PLAYER_MAX_HEALTH, new object[]{maxHealth});
    }

    public void GetHit(int damage) {
        currentHealth -= damage;
        EventSystemService.Instance.DispatchEvent(EventConstants.PLAYER_UPDATE_HEALTH, new object[]{currentHealth});
        if (currentHealth <= 0) {
            EventSystemService.Instance.DispatchEvent(EventConstants.GAME_OVER);
            Time.timeScale = 0;
        }
        
    }

    public void GetHealth(int health) {
        currentHealth += health;
        if (currentHealth > maxHealth) {
            currentHealth = maxHealth;
        }
        EventSystemService.Instance.DispatchEvent(EventConstants.PLAYER_UPDATE_HEALTH, new object[]{currentHealth});
    }
}
