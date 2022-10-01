using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour {
    public int maxHealth;
    public int currentHealth;
    public SpriteRenderer body;
    public Sprite full;
    public Sprite yellow;
    public Sprite red;
    void Start() {
        currentHealth = maxHealth;
        EventSystemService.Instance.DispatchEvent(EventConstants.PLAYER_MAX_HEALTH, new object[]{maxHealth});
    }

    public void GetHit(int damage) {
        currentHealth -= damage;
        ChangeSprite();
        EventSystemService.Instance.DispatchEvent(EventConstants.PLAYER_HIT);
        EventSystemService.Instance.DispatchEvent(EventConstants.PLAYER_UPDATE_HEALTH, new object[]{currentHealth});
        if (currentHealth <= 0) {
            EventSystemService.Instance.DispatchEvent(EventConstants.GAME_OVER);
            Time.timeScale = 0;
        }
        
    }

    private void ChangeSprite() {
        float procentage = (float) currentHealth / maxHealth;
        if (procentage <= 0.2f) {
            body.sprite = red;
        }
        else if(procentage <= 0.5f) {
            body.sprite = yellow;
        }
        else {
            body.sprite = full;
        }
    }

    public void GetHealth(int health) {
        currentHealth += health;
        ChangeSprite();
        if (currentHealth > maxHealth) {
            currentHealth = maxHealth;
        }
        EventSystemService.Instance.DispatchEvent(EventConstants.PLAYER_POWER_UP);
        EventSystemService.Instance.DispatchEvent(EventConstants.PLAYER_UPDATE_HEALTH, new object[]{currentHealth});
    }
}
