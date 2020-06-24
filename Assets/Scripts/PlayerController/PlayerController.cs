using System;
using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    #region VARIABLES

    [Header("References")]
    public GameObject UIObject;
    
    //Mouse Control
    [Header("Player Settings")]
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
    private GameObject _activeWorld;
    private CanvasGroup _uiGroup;
    private UIManager _uiManager;
    private Coroutine _fading;
    
    //Show Info
    private bool _isDisplayed;

    #endregion

    #region UNITY METHODS
    
    void Start()
    {
        _uiManager = UIObject.GetComponent<UIManager>();
        _uiGroup = UIObject.GetComponent<CanvasGroup>();
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

        //Get Active Object
        GetActiveObject();
        
        //Select Active Object
        SelectActiveObject();

        //Show/Hide Info
        DisplayInformation();
    }

    #endregion

    #region METHODS

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
        if (_isUsingMouse) return;
        
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

    private void GetActiveObject()
    {
        if (Physics.Raycast(transform.position, transform.forward, out _hit))
        {
            if (_hit.transform.CompareTag("World"))
            {
                if (!_activeWorld )
                {
                    _activeWorld = _hit.transform.gameObject;
                }
            }
        }
        else if(_activeWorld)
        {
            _activeWorld = null;
        }
    }

    private void SelectActiveObject()
    {
        if (_activeWorld)
        {
            //Select world with a mouse click
            if (_isUsingMouse || !Input.GetMouseButtonDown(0)) return;
            ToggleMouse();
            ToggleDescription();
        }
    }

    private void DisplayInformation()
    {
        if (!_isDisplayed && _activeWorld)
        {
            _isDisplayed = true;
            GroupDetails details = _activeWorld.GetComponent<GroupDetails>();
            _uiManager.UpdateUserInfo(details);
            FadeUI();
        }
        else if(_isDisplayed && !_activeWorld)
        {
            _isDisplayed = false;
            FadeUI();
        }
    }
    
    public void ToggleMouse()
    {
        _isUsingMouse = !_isUsingMouse;
        Cursor.visible = _isUsingMouse;
        Cursor.lockState = _isUsingMouse ? CursorLockMode.None  : CursorLockMode.Locked;
    }
    
    public void ToggleDescription()
    {
        GroupDetails details = _activeWorld.GetComponent<GroupDetails>();
        _uiManager.ToggleDescription();
        _uiManager.UpdateDescription(details.groupDescription);
    }
    
    private void FadeUI()
    {
        if(_fading != null) StopCoroutine(_fading);
        _fading = StartCoroutine(Fading());
    }

    IEnumerator Fading()
    {
        float start = _activeWorld ? 0 : 1;
        float end = _activeWorld ? 1 : 0;
        float timer = 0;
        float duration = _activeWorld?0.6f:0.2f;

        while (Math.Abs(_uiGroup.alpha - end) > 0)
        {
            timer += Time.deltaTime;
            float value = Mathf.Lerp(start, end, timer/duration);
            _uiGroup.alpha = value;
            yield return null;
        }
        
    }

    #endregion
}