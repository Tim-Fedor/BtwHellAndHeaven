using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthLogic : MonoBehaviour, IShootable {
    public float maxHealth = 20f;
    public float currentHealth;
    public Animator anim;

    private void Start() {
        currentHealth = maxHealth;
    }
    public void Shoot(float damage) {
        currentHealth -= damage;
        if (currentHealth <= 0) {
            EventSystemService.Instance.DispatchEvent(EventConstants.KILL_ENEMY);
            Destroy(gameObject);
        }
        else {
            anim.Play("Hit");
        }
    }
    
}
