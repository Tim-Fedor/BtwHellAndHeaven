using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthLogic : MonoBehaviour, IShootable {
    public float maxHealth;
    public float currentHealth;

    private void Start() {
        currentHealth = maxHealth;
    }
    public void Shoot(float damage) {
        currentHealth -= damage;
        if (currentHealth <= 0) {
            EventSystemService.Instance.DispatchEvent(EventConstants.KILL_ENEMY);
            Destroy(gameObject);
        }
    }
}
