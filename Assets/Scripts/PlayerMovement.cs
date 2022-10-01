using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float movementSpeed = 5f;
    
    [SerializeField]
    private Rigidbody2D _rb;
    [SerializeField]
    private Camera _cam;

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

        Vector2 lookDir = _mousePos - _rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        _rb.rotation = angle;
    }
}
