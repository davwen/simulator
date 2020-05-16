using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//This script handles the users ability to controll the camera, in ways such as panning and zooming.

public class CameraController : MonoBehaviour
{
    public new Camera camera;

    private Vector2 mousePos;

    private Vector2 scrollDelta;

    [Header("Zoom settings")]

    public float zoomSpeed;

    public int smoothness;

    public float nearest;

    public InputMaster controls;

    private bool btnDown;

    private Vector3 offset;

    public List<SpawnableObj> objs = new List<SpawnableObj>();

    private void Awake()
    {
        controls = new InputMaster();

        controls.Editor.dragCamera.performed += _ => 
        {
            offset = camera.ScreenToWorldPoint(controls.Editor.mousePos.ReadValue<Vector2>());
            btnDown = true;
        };
        
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

    private void Update()
    {
        mousePos = camera.ScreenToWorldPoint(controls.Editor.mousePos.ReadValue<Vector2>()) - transform.position; //Mouse pos inside camera, with propotions like world space.

        scrollDelta = controls.Editor.zoom.ReadValue<Vector2>();


        if(scrollDelta.y != 0) //The user scrolled
        {
            onScroll(scrollDelta.y);
            
        }
        
        if (btnDown)
        {
            dragCamera();
        }

     
        if(camera.orthographicSize < nearest)
        {
            camera.orthographicSize = nearest;
        }
    }

    void onScroll(float delta)
    {
        if (!EventSystem.current.IsPointerOverGameObject()) //If I wouldn't have checked this, it would be a pain to scroll lists.
        {
            if (delta < 0)
            {
                zoomCamera(zoomSpeed);
            }

            if (delta > 0)
            {
                zoomCamera(-zoomSpeed);
            }

        }

    }

    void dragCamera()
    {
        transform.position = new Vector3(-mousePos.x, -mousePos.y, -10) + offset;
        
    }

    void zoomCamera(float _stepLength)
    {
       
        if(_stepLength < 0f)
        {
            if(camera.orthographicSize + _stepLength > nearest)
            {
                StartCoroutine(smoothZoom(_stepLength));
            }
        }
        else
        {
            StartCoroutine(smoothZoom(_stepLength));
        }
        
    }

    IEnumerator smoothZoom(float _stepLength)
    {
        int steps = smoothness;

        float stepLength = _stepLength / steps;

        for (int i = 0; i < steps; i++)
        {
            camera.orthographicSize += stepLength;
            yield return new WaitForEndOfFrame();
        }
    }
}
