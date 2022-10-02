using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayerController : MonoBehaviour {
    public AudioSource shootObject;
    public AudioSource hitPlayer;
    public AudioSource powerUp;
    void Start()
    {
        EventSystemService.Instance.AddListener(EventConstants.SHOOT, OnShoot);
        EventSystemService.Instance.AddListener(EventConstants.PLAYER_HIT, OnHit);
        EventSystemService.Instance.AddListener(EventConstants.PLAYER_POWER_UP, OnPowerUp);
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
}
