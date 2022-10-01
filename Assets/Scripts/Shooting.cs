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
        var dir = _firePoint.parent.localScale.y < 0 ? -_firePoint.up : _firePoint.up;
        rb.AddForce(dir * bulletForce, ForceMode2D.Impulse);

    }
}
