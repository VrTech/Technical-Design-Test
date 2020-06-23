using System;
using System.Data.Common;
using UnityEngine;


public class FaceToCamera : MonoBehaviour
{
    public bool useConstantScaling;
    private float _initialDistance;

    private void Start()
    {
        Vector3 size = transform.localScale;
        _initialDistance = Vector3.Distance(transform.position, Camera.main.transform.position) / size.x;
    }

    void Update() 
    {
        //Scaling on distance
        if (useConstantScaling)
        {
            float distance = Vector3.Distance(transform.position, Camera.main.transform.position);
            transform.localScale = Vector3.one * distance / _initialDistance;
        }

        //Facing Camera
        Transform thisTransform;
        (thisTransform = transform).LookAt(Camera.main.transform.position, transform.up);
        thisTransform.forward = -thisTransform.forward;
    }
}