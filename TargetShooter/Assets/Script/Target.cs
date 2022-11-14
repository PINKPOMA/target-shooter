using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private float rotspeed;
    void Update()
    {
        transform.Rotate(new Vector3(rotspeed *Time.deltaTime, 0,rotspeed *Time.deltaTime ));
    }
}
