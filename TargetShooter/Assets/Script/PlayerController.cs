using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigid;
    private SphereCollider _collider;
    private Camera _camera;

    [SerializeField] private float speed;

    void Start()
    {
        _rigid = GetComponentInChildren<Rigidbody>();
        _collider = GetComponentInChildren<SphereCollider>();
        _camera = Camera.main;
    }

    void Update()
    {
        Move();
        if(Input.anyKeyDown)
            Rotate();
    }

    private void Move()
    {
        _rigid.velocity = transform.forward * speed;
    }

    private void Rotate()
    {
        var rotation = transform.rotation;
        var xAngle = rotation.x;
        var yAngle = rotation.y;
        float vertical = Input.GetAxisRaw("Vertical");
        float horizontal = Input.GetAxisRaw("Horizontal");
        
        xAngle = Mathf.Floor(xAngle + (90f * vertical));
        yAngle = Mathf.Floor(yAngle + (90f * horizontal));
        
        transform.Rotate(xAngle, yAngle, 0);
    }
}
