using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class FloatingTooltip : MonoBehaviour
{
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
        Vector3 temp = Input.mousePosition;
        temp.z = offsetDistance;
        Vector3 targetPosition = Camera.main.ScreenToWorldPoint(temp);
        
        if (Vector3.Distance(transform.position, targetPosition) > 0.1f)
        {
            var uiTransform = transform;
                transform.position = Vector3.Lerp(uiTransform.position,targetPosition,Time.deltaTime * followSpeed);
        }
    }
}
