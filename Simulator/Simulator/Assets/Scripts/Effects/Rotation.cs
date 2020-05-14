using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//THIS SCRIPT CONTAINS ALL OF THE GUIDELINES FOR EFFECT SCRIPTS.

//The rotation effect component.


public class Rotation : Effect
{
    [HideInInspector]
    public const string EFFECT_KEY = "rotation";
    [HideInInspector]
    public const string EFFECT_DISPLAY_NAME = "Rotation";
    [HideInInspector]
    public const bool EFFECT_REMOVABLE = true;

    public override string GetEffectKey()
    {
        return EFFECT_KEY;
    }

    public override string GetEffectDisplayName()
    {
        return EFFECT_DISPLAY_NAME;
    }

    public override bool GetEffectRemovable()
    {
        return EFFECT_REMOVABLE;
    }

    //First - objectComp variable

    //Second - varaible keys. Always string.
    [Header("Keys")]
    public const string speedValueKey = EFFECT_KEY + "_speed";
    public const string rightValueKey = EFFECT_KEY + "_right_dir";

    //Third - variables needed for effect.
    private float speed;
    private bool dirRight;

    private Rigidbody2D r;

    public override List<Value> GetNecessaryValues()
    {
        return new List<Value>(2) { new Value(speedValueKey, Value.FLOAT_TYPE_KEY, "10", "Speed"),
        new Value(rightValueKey, Value.BOOL_TYPE_KEY, "true", "Rotate to right") };
    }

    void Start()
    {
        //Get the object component only once in the start for better performance.
        objectComp = GetComponent<Object>();

        if(objectComp == null)
        {
            print("You need an Object component attached to the object " + "\"" + gameObject.name + "\".");
        }

        r = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        //set all variables
        speed = objectComp.GetFloatValue(speedValueKey);
        dirRight = objectComp.GetBoolValue(rightValueKey);

        //Do loops here if needed
        if (isRunning)
        {
            if (!dirRight)
            {
                r.MoveRotation(transform.eulerAngles.z + speed);
            }
            else
            {
                r.MoveRotation(transform.eulerAngles.z + -speed);
            }
            
        }
    }

    public override void Begin()
    {
        //set isRunning variable
        isRunning = true;

        //Then do needed tasks
    }

    public override void Stop()
    {
        //set isRunning variable
        isRunning = false;

        //Then do needed tasks
    }

    public override void Pause()
    {
        //set isRunning variable
        isRunning = false;

        //Then do needed tasks
    }

    public override void Resume()
    {
        //set isRunning variable
        isRunning = true;

        //Then do needed tasks
    }
}
