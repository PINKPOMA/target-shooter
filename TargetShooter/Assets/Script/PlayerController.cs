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
        var zAngle = rotation.z;
        
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.Rotate(-90f, yAngle, zAngle);
            return;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.Rotate(xAngle, -90f, zAngle);
            return;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.Rotate(90f, yAngle, zAngle);
            return;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Rotate(xAngle, 90f, zAngle);
            return;
        }
    }
}
