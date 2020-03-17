using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//THIS SCRIPT CONTAINS ALL OF THE GUIDELINES FOR EFFECT SCRIPTS.

//The rotation effect component.

public class Collision : MonoBehaviour
{
    [HideInInspector]
    public const string EFFECT_KEY = "collision";
    [HideInInspector]
    public const string EFFECT_DISPLAY_NAME = "Collision";

    //First - objectComp variable
    private Object objectComp;

    //Second - varaible keys. Always string.
    [Header("Keys")]

    //Third - variables needed for effect.
    private Collider2D coll;

    //Fourth - The values the effect needs.
    [Header("Values To Add/Remove")]

    [Tooltip("Values used by effect")]
    public List<Value> usedValues = new List<Value>(0) {};


    //Last - isRunning varaible
    [Header("Inspect")]
    public bool isRunning = false;

    void Start()
    {
        //Get the object component only once in the start for better performance.
        objectComp = GetComponent<Object>();

        if (objectComp == null)
        {
            print("You need an Object component attached to the object " + "\"" + gameObject.name + "\".");
        }

        coll = GetComponent<Collider2D>(); //Gets any collider attached to the objects.
    }


    void Update()
    {
        //set all variables
       

        //Do loops here if needed

    }

    public void Begin()
    {
        //set isRunning variable
        isRunning = true;

        //Then do needed tasks
        coll.isTrigger = false;
    }

    public void Stop()
    {
        //set isRunning variable
        isRunning = false;

        //Then do needed tasks
        coll.isTrigger = true;
    }

    public void Pause()
    {
        //set isRunning variable
        isRunning = false;

        //Then do needed tasks
        coll.isTrigger = true;
    }

    public void Resume()
    {
        //set isRunning variable
        isRunning = true;

        //Then do needed tasks
        coll.isTrigger = false;
    }

    //Adds the values used for effect.
    public void AddUsedValues()
    {
        objectComp.addValues(usedValues);
    }
}
