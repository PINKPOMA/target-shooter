using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    [Header("Speed")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float speedUpValue;
    [Space]
    [Header("Text")]
    [SerializeField] TextMeshProUGUI speedText;

    void Start()
    {
        _rigid = GetComponent<Rigidbody>();
        _collider = GetComponent<SphereCollider>();
        _camera = Camera.main;
        speedText.text = moveSpeed.ToString();
    }

    void Update()
    {
        Move();
        if(Input.anyKeyDown)
        {
            TryRotate();
        }
    }

    private void Move()
    {
        _rigid.velocity = transform.forward * moveSpeed;
    }

    private void TryRotate()
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
            StartCoroutine(Rotate(vertical, horizontal));
        }
    }

    private IEnumerator Rotate(float vertical, float horizontal)
    {
        _isRotate = true;
        Vector3 rotateValue = new Vector3(vertical * 90f * -1f, horizontal * 90f, 0f);
        transform.DOLocalRotate(rotateValue, rotationSpeed, RotateMode.LocalAxisAdd);
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
                SceneManager.LoadScene("GameOver");
                return;
            case "Target":
                Destroy(other.gameObject);
                moveSpeed += speedUpValue;
                GameObject.FindWithTag("Generater").GetComponent<TargetGenerator>().Generate();
                speedText.text = moveSpeed.ToString();
                return;
        }
    }
}
