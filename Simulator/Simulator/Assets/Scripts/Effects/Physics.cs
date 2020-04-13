using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//THIS SCRIPT CONTAINS ALL OF THE GUIDELINES FOR EFFECT SCRIPTS.

//The rotation effect component.

public class Physics : MonoBehaviour
{
    [HideInInspector]
    public const string EFFECT_KEY = "physics";
    [HideInInspector]
    public const string EFFECT_DISPLAY_NAME = "Physics";
    [HideInInspector]
    public const string REMOVABLE = "TRUE";

    //First - objectComp variable
    private Object objectComp;


    //Second - varaible keys. Always string.
    [Header("Keys")]
    public const string rotateValueKey = EFFECT_KEY + "_rotation_enabled";
    public const string gravityValueKey = EFFECT_KEY + "_gravity_strength";

    //Third - variables needed for effect.
    private bool rotateEnabled;
    private float gravityStrength;
    private Rigidbody2D rb;

    //Fourth - The values the effect needs.
    [Header("Values To Add/Remove")]

    [Tooltip("Values used by effect")]
    public List<Value> usedValues = new List<Value>(2) { new Value(rotateValueKey, Value.BOOL_TYPE_KEY, "true", "Rotation enabled"),
        new Value(gravityValueKey, Value.FLOAT_TYPE_KEY, "1", "Gravity strength") };

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

        rb = GetComponent<Rigidbody2D>(); //Gets the Rigidbody component attached to the object.
    }


    void Update()
    {
        //set all variables
        rotateEnabled = objectComp.getBoolValue(rotateValueKey);
        gravityStrength = objectComp.getFloatValue(gravityValueKey);

        //Do loops here if needed
        rb.freezeRotation = !isRunning;

        if (isRunning)
        {
            rb.gravityScale = gravityStrength;
            if (!rotateEnabled)
            {
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            }
            else
            {
                rb.constraints = RigidbodyConstraints2D.None;
            }
        }
        
    }

    public void Begin()
    {
        //set isRunning variable
        isRunning = true;

        //Then do needed tasks
        if (rotateEnabled)
        {
            rb.constraints = RigidbodyConstraints2D.None;
        }
        else
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }

    }

    public void Stop()
    {
        //set isRunning variable
        isRunning = false;

        //Then do needed tasks
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    public void Pause()
    {
        //set isRunning variable
        isRunning = false;

        //Then do needed tasks
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    public void Resume()
    {
        //set isRunning variable
        isRunning = true;

        //Then do needed tasks
        if (rotateEnabled)
        {
            rb.constraints = RigidbodyConstraints2D.None;
        }
        else
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }

    //Adds the values used for effect.
    public void AddUsedValues()
    {
        objectComp.addValues(usedValues);
    }
}
