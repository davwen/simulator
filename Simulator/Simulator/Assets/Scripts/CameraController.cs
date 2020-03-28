using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    public Vector2 mouseDelta;

    public float sensitivity;

    public InputMaster controls;

    private bool btnDown;


    private void Awake()
    {
        controls = new InputMaster();
        controls.Editor.dragCamera.performed += _ => btnDown = true;
        controls.Editor.dragCamera.canceled += _ => btnDown = false;
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    void Start()
    {
        
    }

    private void Update()
    {
        mouseDelta = controls.Editor.mouseDelta.ReadValue<Vector2>() * -1;

        if (btnDown)
        {
            dragCamera();
        }
    }

    void dragCamera()
    {
        
        transform.Translate((mouseDelta * (sensitivity / 100f)));
    }
}
