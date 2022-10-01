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
        EventSystemService.Instance.DispatchEvent(EventConstants.PLAYER_HIT, new object[]{currentHealth});
        if (currentHealth <= 0) {
            EventSystemService.Instance.DispatchEvent(EventConstants.GAME_OVER);
            Time.timeScale = 0;
        }
        
    }
}
