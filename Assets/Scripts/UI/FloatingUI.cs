﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class FloatingUI : MonoBehaviour
{

    public Transform player;
    public bool hideWhenStart;
    public float offsetDistance;
    public float followSpeed;

    private void Start()
    {
        //Hide at first
        if(hideWhenStart)
            GetComponent<CanvasGroup>().alpha = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) > 0.1f)
        {
            Vector3 targetPosition = player.position + (player.forward * offsetDistance);
                var uiTransform = transform;
                transform.position = Vector3.Lerp(uiTransform.position,targetPosition,Time.deltaTime * followSpeed);
        }
    }
}
