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
        _rigid = GetComponent<Rigidbody>();
        _collider = GetComponent<SphereCollider>();
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

        transform.Rotate(vertical * 90f, horizontal * 90f, 0);
    }
}
