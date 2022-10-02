using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    private void Awake() {
        EventSystemService.Instance.AddListener(EventConstants.PLAYER_MAX_HEALTH, OnMaxHealth);
        EventSystemService.Instance.AddListener(EventConstants.PLAYER_UPDATE_HEALTH, OnHealthUpdate);
    }

    private void OnDestroy() {
        EventSystemService.Instance.RemoveListener(EventConstants.PLAYER_MAX_HEALTH, OnMaxHealth);
        EventSystemService.Instance.RemoveListener(EventConstants.PLAYER_UPDATE_HEALTH, OnHealthUpdate);
    }

    private void OnHealthUpdate(object[] data) {
        if (data != null && data.Length > 0 && data[0] is int) {
            SetHealth((int) data[0]);
        }
    }
    
    private void OnMaxHealth(object[] data) {
        if (data != null && data.Length > 0 && data[0] is int) {
            SetMaxHealth((int) data[0]);
        }
    }

    private void SetMaxHealth(int health) {
        slider.maxValue = health;
        slider.value = health;
        fill.color = gradient.Evaluate(1f);
    }

    private void SetHealth(int health) {
        slider.value = health;
        
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
