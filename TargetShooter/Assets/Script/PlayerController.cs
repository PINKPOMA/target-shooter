using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigid;
    private SphereCollider _collider;
    private Camera _camera;
    private bool _isRotate;

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
        {
            Rotate();
        }
    }

    private void Move()
    {
        _rigid.velocity = transform.forward * speed;
    }

    private void Rotate()
    {
        #region Rotation Variables
        
        var rotation = transform.rotation;
        float xAngle = rotation.x;
        float yAngle = rotation.y;
        
        #endregion
        
        float vertical = Input.GetAxisRaw("Vertical");
        float horizontal = Input.GetAxisRaw("Horizontal");
        
        if (!_isRotate)
        {
            StartCoroutine(DoRotate(vertical, horizontal));
        }
    }

    IEnumerator DoRotate(float vertical, float horizontal)
    {
        _isRotate = true;
        transform.DOLocalRotate(new Vector3(vertical * 90f * -1f, horizontal * 90f, 0f), 0.1f, RotateMode.LocalAxisAdd);
        yield return new WaitForSeconds(0.1f);
        _isRotate = false;
    }
}
