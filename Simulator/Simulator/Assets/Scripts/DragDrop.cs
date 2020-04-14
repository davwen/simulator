using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is used to handle the Drag n' Drop system (for GameObjects).

public class DragDrop : MonoBehaviour
{
    
    public bool isDragging = false;

    [HideInInspector]
    public bool isMouseInside = false;

    [HideInInspector]
    public Vector2 mousePos;

    public float speed;

    public Select selectionManager;

    public InputMaster controls;

    private bool isMouseDown;
    private bool isMouseDownCheck;

    private Vector3 offset;

    private void Awake()
    {
        controls = new InputMaster();

        controls.Editor.drag.performed += ctx => isMouseDown = true;
        controls.Editor.drag.canceled += ctx => isMouseDown = false;
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }


    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //Translates the mouse position to a world position.

        isDragging = isMouseDown;

        if (isMouseDownCheck != isMouseDown && selectionManager.currentlySelected != null) //A change with the mouse has happened.
        {
            isMouseInside = isMouseInsideCheck(selectionManager.currentlySelected);
            offset = new Vector3(mousePos.x, mousePos.y, 0) - selectionManager.currentlySelected.transform.position;

            isMouseDownCheck = isMouseDown;
        }

        if (isDragging && selectionManager.currentlySelected != null && isMouseInside && FindObjectOfType<ModeManager>().currentMode == ModeManager.MODE_EDIT) //Should the selected object go towards the mouse.
        {
            Rigidbody2D selectedBody = selectionManager.currentlySelected.gameObject.GetComponent<Rigidbody2D>();

            stopRigidbody(selectedBody);

            selectionManager.currentlySelected.transform.position += ((new Vector3(mousePos.x, mousePos.y, 0) - selectionManager.currentlySelected.transform.position) - offset) * Time.deltaTime * speed;

        }

        if (!isDragging && selectionManager.currentlySelected != null) //The user is not draging anymore. Switch to dynamic rigidbody.
        {
            Rigidbody2D selectedBody = selectionManager.currentlySelected.gameObject.GetComponent<Rigidbody2D>();

            selectedBody.isKinematic = false;
        }

       
    }

    private void stopRigidbody(Rigidbody2D body)
    {
        body.isKinematic = true;
        body.velocity = Vector2.zero;
    }

    private bool isMouseInsideCheck(Object obj) //Is the mouse inside the object?
    {
        bool result = false;

        if(obj != null)
        {
            SpriteRenderer sr = obj.GetComponent<SpriteRenderer>();

            result = mousePos.x > sr.bounds.min.x && mousePos.x < sr.bounds.max.x
                && mousePos.y > sr.bounds.min.y && mousePos.y < sr.bounds.max.y;
        }

        return result;
      
    }
}