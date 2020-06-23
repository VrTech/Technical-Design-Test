using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotate : MonoBehaviour
{

    public float rotateSpeed = 10;
    private float _y = 0;
    private float _x = 0;

    // Update is called once per frame
    void Update()
    {
        _x += rotateSpeed;
        _y += rotateSpeed;
        transform.rotation = Quaternion.Euler(_x,_y,0);
    }
}
