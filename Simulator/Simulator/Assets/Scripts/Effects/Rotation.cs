using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//THIS SCRIPT CONTAINS ALL OF THE GUIDELINES FOR EFFECT SCRIPTS.

//The rotation effect component.


public class Rotation : MonoBehaviour
{
    [HideInInspector]
    public const string EFFECT_KEY = "rotation";
    [HideInInspector]
    public const string EFFECT_DISPLAY_NAME = "Rotation";


    //First - objectComp variable
    private Object objectComp;

    //Second - varaible keys. Always string.
    [Header("Keys")]
    public const string speedValueKey = EFFECT_KEY + "_speed";
    public const string rightValueKey = EFFECT_KEY + "_right_dir";

    //Third - variables needed for effect.
    private float speed;
    private bool dirRight;

    //Fourth - The values the effect needs.
    [Header("Values To Add/Remove")]

    [Tooltip("Values used by effect")]
    public List<Value> usedValues = new List<Value>(2) { new Value().createValue(speedValueKey, Value.FLOAT_TYPE_KEY, "10", "Speed"),
        new Value().createValue(rightValueKey, Value.BOOL_TYPE_KEY, "true", "Rotate to right") };

    
    //Last - isRunning variable
    [Header("Inspect")]
    public bool isRunning = false;

  
    void Start()
    {
        //Get the object component only once in the start for better performance.
        objectComp = GetComponent<Object>();

        if(objectComp == null)
        {
            print("You need an Object component attached to the object " + "\"" + gameObject.name + "\".");
        }
    }

    
    void Update()
    {
        //set all variables
        speed = objectComp.getFloatValue(speedValueKey);
        dirRight = objectComp.getBoolValue(rightValueKey);

        //Do loops here if needed
        if (isRunning)
        {
            if (!dirRight)
            {
                transform.Rotate(new Vector3(0, 0, speed * Time.deltaTime)); //It should only rotate on the z-axis.
            }
            else
            {
                transform.Rotate(new Vector3(0, 0, -speed * Time.deltaTime)); //It should only rotate on the z-axis.
            }
            
        }
    }

    public void Begin()
    {
        //set isRunning variable
        isRunning = true;

        //Then do needed tasks
    }

    public void Stop()
    {
        //set isRunning variable
        isRunning = false;

        //Then do needed tasks
    }

    public void Pause()
    {
        //set isRunning variable
        isRunning = false;

        //Then do needed tasks
    }

    public void Resume()
    {
        //set isRunning variable
        isRunning = true;

        //Then do needed tasks
    }

    //Adds the values used for effect.
    public void AddUsedValues()
    {
        objectComp.addValues(usedValues);
    }
}
