using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {
    
    public float bulletForce = 20f;
    [SerializeField]
    private Transform _firePoint;
    [SerializeField] 
    private GameObject _bulletPrefab;

    private bool _canFire = true;
    
    void Start()
    {
        EventSystemService.Instance.AddListener(EventConstants.GAME_OVER, OnLose);
    }
    
    void OnDestroy()
    {
        EventSystemService.Instance.RemoveListener(EventConstants.GAME_OVER, OnLose);
    }

    private void OnLose(object[] data) {
        _canFire = false;
    }
    
    private void Update()
    {
        if (!_canFire) {
            return;
        }
        
        if (Input.GetButtonDown("Fire1")) {
            Shoot();
        }    
    }

    private void Shoot() {
        var bullet = Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);
        var scale = bullet.transform.localScale;
        if(_firePoint.parent.localScale.y < 0) {
            scale.y = scale.y < 0 ? scale.y : -scale.y;
        }
        else if(_firePoint.parent.localScale.y > 0){
            scale.y = scale.y > 0 ? scale.y : -scale.y;
        }
        bullet.transform.localScale = scale;
        var rb = bullet.GetComponent<Rigidbody2D>();
        var dir = _firePoint.parent.localScale.y < 0 ? -_firePoint.up : _firePoint.up;
        rb.AddForce(dir * bulletForce, ForceMode2D.Impulse);

        EventSystemService.Instance.DispatchEvent(EventConstants.SHOOT);
    }
}
