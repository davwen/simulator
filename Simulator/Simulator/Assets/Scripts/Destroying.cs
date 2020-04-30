using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


//This script handles the users ability to destroy objects.

public class Destroying : MonoBehaviour
{
    public InputMaster controls;


    private void Awake()
    {
        controls = new InputMaster();

        controls.Editor.destroy.performed += ctx => destoryObj();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    public void destoryObj()
    {
        //Sends a raycast and sees if it hits any object.
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //Calculates the mousePos in world space.
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y); //converts to Vector2

        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

        // If it hits something...
        if (hit.collider != null && !EventSystem.current.IsPointerOverGameObject() && ModeManager.Instance.currentMode == ModeManager.MODE_SPAWN)
        {
            Object obj = hit.transform.gameObject.GetComponent<Object>(); //Gets the Object component only once.

            if (obj != null) //Checks if an Object was hit.
            {
                Destroy(obj.gameObject);
                
            }
            
        }

        
    }


}
