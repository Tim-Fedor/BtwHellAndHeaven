using System;
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
    public Animator anim;
    private bool _isIDDQD;
    void Start() {
        currentHealth = maxHealth;
        EventSystemService.Instance.DispatchEvent(EventConstants.PLAYER_MAX_HEALTH, new object[]{maxHealth});
        EventSystemService.Instance.AddListener(EventConstants.CHANGED_WORLD, OnChangeWorld);
    }

    private void OnDestroy() {
        EventSystemService.Instance.RemoveListener(EventConstants.CHANGED_WORLD, OnChangeWorld);
    }

    private void OnChangeWorld(object[] data) {
        if (data != null && data.Length > 0 && data[0] is SwitchController.WorldName.HELL) {
            StartCoroutine(EnableTempIDDQD());
        }
    }

    private IEnumerator EnableTempIDDQD() {
        _isIDDQD = true;
        yield return new WaitForSeconds(1f);
        _isIDDQD = false;
    }

    public void GetHit(int damage) {
        if (_isIDDQD) {
            return;
        }
        
        currentHealth -= damage;
        ChangeSprite();
        EventSystemService.Instance.DispatchEvent(EventConstants.PLAYER_HIT);
        EventSystemService.Instance.DispatchEvent(EventConstants.PLAYER_UPDATE_HEALTH, new object[]{currentHealth});
        if (currentHealth <= 0) {
            EventSystemService.Instance.DispatchEvent(EventConstants.GAME_OVER);
            Time.timeScale = 0;
        }
        else {
            anim.Play("Hit");
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
