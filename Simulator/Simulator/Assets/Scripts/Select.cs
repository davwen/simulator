using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;

//This script handles the users ability to select and edit objects when they click on them.

public class Select : MonoBehaviour
{
    public Object currentlySelected;

    public ListCreator valuesListCreator;

    public float deselectedAlpha = 0.5f;

    public InputMaster controls;

    public GameObject baseObj;

    private void Awake()
    {
        controls = new InputMaster();

        controls.Editor.select.performed += ctx =>
        {
            if (FindObjectOfType<ModeManager>().currentMode == ModeManager.MODE_EDIT)
            {
                checkClick();
            }
        };

        controls.Editor.deselect.performed += ctx => onDeselect();
       
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }


    void checkClick()
    {
        //Sends a raycast and sees if it hits any object.
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //Calculates the mousePos in world space.
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y); //converts to Vector2

        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

        // If it hits something...
        if (hit.collider != null && !EventSystem.current.IsPointerOverGameObject())
        {
            Object obj = hit.transform.gameObject.GetComponent<Object>(); //Gets the Object component only once.

            if (obj != null) //Checks if an Object was hit.
            {
                onDeselect(); //First deselects
                currentlySelected = obj;
                onSelect(currentlySelected); //Then selects
            }
            else
            {
                if(hit.transform.gameObject.layer != SortingLayer.GetLayerValueFromName("UI")) //I do this because the objects shouldn't be deselected when the user clicks on UI.
                {
                    currentlySelected = null;
                    onDeselect();
                }
             
            }
        }
    }

    public virtual void onSelect(Object selected) //An object has been selected.
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Object");

        for(int i = 0; i < objects.Length; i++)
        {
            if(objects[i] != selected.gameObject)
            {
                SpriteRenderer sr = objects[i].GetComponent<SpriteRenderer>();
                sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, deselectedAlpha);
            }
        }

    }
    public void onDeselect() //An object has been selected.
    {

        GameObject[] objects = GameObject.FindGameObjectsWithTag("Object");

        //Sets alpha to max on all objects.
        for (int i = 0; i < objects.Length; i++)
        {
           
            SpriteRenderer sr = objects[i].GetComponent<SpriteRenderer>();
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1f);

            
        }
        currentlySelected = null;
    }

    public void onModeChange(string mode)
    {
        switch (mode)
        {
            case ModeManager.MODE_SPAWN:
                onDeselect();
                break;
        }
    }
}
