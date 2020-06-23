using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ToolTip : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        GameObject tooltip = GameObject.FindWithTag("Tooltip");
        tooltip.GetComponent<CanvasGroup>().alpha = 1;
        TMPro.TextMeshProUGUI tooltipText = tooltip.GetComponentInChildren<TMPro.TextMeshProUGUI>();
        tooltipText.text = name;
        // Debug.Log(name+ " IN");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GameObject tooltip = GameObject.FindWithTag("Tooltip");
        tooltip.GetComponent<CanvasGroup>().alpha = 0;
        TMPro.TextMeshProUGUI tooltipText = tooltip.GetComponentInChildren<TMPro.TextMeshProUGUI>();
        tooltipText.text = "";
        // Debug.Log(name+ " OUT");
    }
}
