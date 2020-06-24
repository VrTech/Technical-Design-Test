 using System.Collections;
using System.Collections.Generic;
 using UnityEngine;

public class ToggleMovement : MonoBehaviour
{

    public bool isToggled;
    public Vector3 togglePosition;
    public float speed;
    
    private RectTransform _rectTransform;
    
    private Vector3 _initialPosition;
    private float _counter;
    private bool _lastToggleValue;

    private Vector3 _targetPos;
    
    void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        _initialPosition = _rectTransform.anchoredPosition;
        _targetPos = isToggled?  togglePosition:_initialPosition;
    }

    void Update()
    {
        if (_lastToggleValue != isToggled)
        {
            _lastToggleValue = isToggled;
            _targetPos = isToggled?  togglePosition:_initialPosition;
            _counter = 0;
        }
        
        if (Vector3.Distance(_rectTransform.anchoredPosition, _targetPos) > 0.1f)
        {
            _counter += Time.deltaTime;
            _rectTransform.anchoredPosition = Vector3.Lerp(_rectTransform.anchoredPosition, _targetPos, _counter * speed);
        }
    }

    public void Trigger()
    {
        isToggled = !isToggled;
    }
}
