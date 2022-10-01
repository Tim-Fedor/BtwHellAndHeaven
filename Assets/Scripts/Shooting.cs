using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {
    
    public float bulletForce = 20f;
    [SerializeField]
    private Transform _firePoint;
    [SerializeField] 
    private GameObject _bulletPrefab;
    
    private void Update()
    {
        if (Input.GetButtonDown("Fire1")) {
            Shoot();
        }    
    }

    private void Shoot() {
        var bullet = Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);
        var rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(_firePoint.up * bulletForce, ForceMode2D.Impulse);

    }
}
