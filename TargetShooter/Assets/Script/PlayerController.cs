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
    private float _maxPos = 250;
    
    private bool _isRotate;

    [Header("rotation")]
    [SerializeField] private float rotationSpeed = 0.1f;
    [SerializeField] private float rotationDelay = 0.15f;
    [Space]
    [Header("Speed")]
    [SerializeField] private int moveSpeed;
    [SerializeField] private int speedUpValue;
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

        if (OverMaxPos())
        {
            // TODO 죽음 처리하기
        }
        
        /*if (transform.position.x >= _maxPos || transform.position.x <= _maxPos * 1 || 
            transform.position.y >= _maxPos || transform.position.y <= _maxPos * 1 || 
            transform.position.z >= _maxPos || transform.position.z <= _maxPos * 1)
            SceneManager.LoadScene("GameOver");*/

    }
    
    private bool OverMaxPos()
    {
        var pos = transform.position;
        if(Mathf.Abs(pos.x) >= _maxPos) return true;
        if(Mathf.Abs(pos.y) >= _maxPos) return true;
        if(Mathf.Abs(pos.z) >= _maxPos) return true;
        return false;
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
                GameOver();
                return;
            case "Target":
                Destroy(other.gameObject);
                moveSpeed += speedUpValue;
                GameObject.FindWithTag("Generater").GetComponent<TargetGenerator>().Generate();
                speedText.text = moveSpeed.ToString();
                return;
        }
    }

    void GameOver()
    {
        Ranking.Instance.SetRank(moveSpeed);
        SceneManager.LoadScene("GameOver");
    }
}
