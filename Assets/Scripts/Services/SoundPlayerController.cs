using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayerController : MonoBehaviour {
    public AudioSource shootObject;
    public AudioSource hitPlayer;
    public AudioSource powerUp;
    public AudioSource enemyDie;
    void Start()
    {
        EventSystemService.Instance.AddListener(EventConstants.SHOOT, OnShoot);
        EventSystemService.Instance.AddListener(EventConstants.PLAYER_HIT, OnHit);
        EventSystemService.Instance.AddListener(EventConstants.PLAYER_POWER_UP, OnPowerUp);
        EventSystemService.Instance.AddListener(EventConstants.KILL_ENEMY, OnKill);
    }

    private void OnDestroy() {
        EventSystemService.Instance.RemoveListener(EventConstants.SHOOT, OnShoot);
        EventSystemService.Instance.RemoveListener(EventConstants.PLAYER_HIT, OnHit);
        EventSystemService.Instance.RemoveListener(EventConstants.PLAYER_POWER_UP, OnPowerUp);
        EventSystemService.Instance.RemoveListener(EventConstants.KILL_ENEMY, OnKill);
    }

    private void OnShoot(object[] data) {
        shootObject.Play();
    }    
    
    private void OnHit(object[] data) {
        hitPlayer.Play();
    }    
    
    private void OnPowerUp(object[] data) {
        powerUp.Play();
    }
    
    private void OnKill(object[] data) {
        enemyDie.Play();
    }
}
