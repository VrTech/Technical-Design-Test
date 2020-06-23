using System;
using UnityEngine;
using System.Collections;

public class MouseLook : MonoBehaviour
{
    public GameObject uiObject;
    
    //Mouse Control
    public float sensitivityX = 15F;
    public float sensitivityY = 15F;
    private float _rotationX = 0F;
    private float _rotationY = 0F;
    private Quaternion _originalRotation;
    
    //Movement
    public float movementSpeed;

    //Detect Cursor
    private bool _isUsingMouse;
    
    //Active Object
    RaycastHit _hit;
    private GameObject _activeObject;
    private CanvasGroup _uiGroup;
    private Coroutine _fading;

    void Start()
    {
        _uiGroup = uiObject.GetComponent<CanvasGroup>();
        _originalRotation = transform.rotation;
        
        //Disable Mouse Cursor
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    void Update()
    {
        //Read the mouse input axis
        MouseControl();

        //Player Movement
        Movement();
        
        //Detect Cursor Enter/Exit
        DetectCursor();
        
        //Get Active Object
        GetActiveObject();
    }

    private void MouseControl()
    {
        if (_isUsingMouse) return;
        _rotationX += Input.GetAxis("Mouse X") * sensitivityX;
        _rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
        Quaternion xQuaternion = Quaternion.AngleAxis(_rotationX, Vector3.up);
        Quaternion yQuaternion = Quaternion.AngleAxis(_rotationY, -Vector3.right);
        transform.localRotation = _originalRotation * xQuaternion * yQuaternion;
    }

    private void Movement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * movementSpeed);
        }
        
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-Vector3.forward * movementSpeed);
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * movementSpeed);
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(-Vector3.left * movementSpeed);
        }
    }

    private void DetectCursor()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _isUsingMouse = !_isUsingMouse;
            Cursor.visible = _isUsingMouse;
            Cursor.lockState = _isUsingMouse ? CursorLockMode.None  : CursorLockMode.Locked;
        }
    }

    private void GetActiveObject()
    {
        if (Physics.Raycast(transform.position, transform.forward, out _hit))
        {
            if (_hit.transform.CompareTag("World"))
            {
                if (!_activeObject )
                {
                    print("Found an object - distance: " + _hit.distance + " name:" + _hit.collider.name);
                    _activeObject = _hit.transform.gameObject;
                    UpdateInformation();
                    FadeUI();
                }
            }
        }
        else if(_activeObject)
        {
            _activeObject = null;
            FadeUI();
        }
    }


    
    
    private void UpdateInformation()
    {
        GroupDetails details = _activeObject.GetComponent<GroupDetails>();
    }
    
    private void FadeUI()
    {
        if(_fading != null) StopCoroutine(_fading);
        _fading = StartCoroutine(Fading());
    }

    IEnumerator Fading()
    {
        float start = _activeObject ? 0 : 1;
        float end = _activeObject ? 1 : 0;
        float timer = 0;
        float duration = _activeObject?0.6f:0.2f;

        while (Math.Abs(_uiGroup.alpha - end) > 0)
        {
            timer += Time.deltaTime;
            float value = Mathf.Lerp(start, end, timer/duration);
            _uiGroup.alpha = value;
            yield return null;
        }
        
    }
}