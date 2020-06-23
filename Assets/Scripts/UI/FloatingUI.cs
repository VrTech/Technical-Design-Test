using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class FloatingUI : MonoBehaviour
{

    public Transform player;
    public float offsetDistance;
    public float followSpeed;

    private void Start()
    {
        //Hide at first
        GetComponent<CanvasGroup>().alpha = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) > 0.1f)
        {
            var uiTransform = transform;
            transform.position = Vector3.Lerp(uiTransform.position,player.position + (player.forward * offsetDistance),Time.deltaTime * followSpeed);
        }
    }
}
