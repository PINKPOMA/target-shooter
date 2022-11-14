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

    [Header("rotation")]
    [SerializeField] private float rotationSpeed = 0.1f;
    [SerializeField] private float rotationDelay = 0.15f;
    [Space]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float speedUpValue;

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
        _rigid.velocity = transform.forward * moveSpeed;
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
        transform.DOLocalRotate(new Vector3(vertical * 90f * -1f, horizontal * 90f, 0f), rotationSpeed, RotateMode.LocalAxisAdd);
        yield return new WaitForSeconds(rotationDelay);
        _isRotate = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
       
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Wall":
                Destroy(gameObject);
                return;
            case "Target":
                Destroy(other.gameObject);
                moveSpeed += speedUpValue;
                GameObject.FindWithTag("Generater").GetComponent<TargetGenerator>().Generate();
                return;
        }
    }
}
