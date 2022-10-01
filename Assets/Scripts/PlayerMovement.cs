using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float movementSpeed = 5f;
    public SpriteRenderer gun;
    
    [SerializeField]
    private Rigidbody2D _rb;
    [SerializeField]
    private Camera _cam;
    [SerializeField]
    private Rigidbody2D _gun;
    [SerializeField]
    private Transform _body;
    

    private Vector2 _movement;
    private Vector2 _mousePos;
    
    void Update() {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");

        _mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);
    }
    
    void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + _movement * movementSpeed * Time.deltaTime);
        _gun.MovePosition(_rb.position + _movement * movementSpeed * Time.deltaTime);

        Vector2 lookDir = _mousePos - _rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        _gun.rotation = angle;

        if (_movement.x > 0) {
            var scale = _body.localScale;
            scale.x = 1;
            _body.localScale = scale;
        } else if (_movement.x < 0) {
            var scale = _body.localScale;
            scale.x = -1;
            _body.localScale = scale;
        }

        if ((lookDir.x < 0 && gun.transform.localScale.y > 0) || ((lookDir.x > 0) && gun.transform.localScale.y < 0)) {
            gun.transform.localScale = new Vector3(gun.transform.localScale.x, -gun.transform.localScale.y, gun.transform.localScale.z);
        }
    }
}
