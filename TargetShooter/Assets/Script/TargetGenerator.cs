using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class TargetGenerator : MonoBehaviour
{
    [SerializeField] private float xpos;
    [SerializeField] private float ypos;
    [SerializeField] private float zpos;
    [SerializeField] private GameObject target;

    private void Start()
    {
        Generate();
    }

    public void Generate()
    {
        Instantiate(target, new Vector3(Random.Range(-xpos,xpos),Random.Range(-ypos,ypos),
            Random.Range(-zpos,zpos)), Quaternion.identity);
    }
}
