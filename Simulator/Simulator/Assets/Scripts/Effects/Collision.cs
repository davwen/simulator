using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//THIS SCRIPT CONTAINS ALL OF THE GUIDELINES FOR EFFECT SCRIPTS.

//The rotation effect component.

public class Collision : Effect
{
    [HideInInspector]
    public const string EFFECT_KEY = "collision";
    [HideInInspector]
    public const string EFFECT_DISPLAY_NAME = "Collision";
    [HideInInspector]
    public const bool EFFECT_REMOVABLE = false;

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


    [Header("Keys")]
    public const string triggerValueKey = EFFECT_KEY + "_is_trigger";
 

    public Collider2D coll;
    public bool isTrigger = false;

    public override List<Value> GetNecessaryValues()
    {
        return new List<Value>(1) { new Value(triggerValueKey, Value.BOOL_TYPE_KEY, Value.TRUE_STRING, "Enabled") };
    }

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
        isTrigger = objectComp.GetBoolValue(triggerValueKey);

        //Do loops here if needed
        if (isRunning)
        {
            if(coll == null){
                coll = GetComponent<Collider2D>();
            }
            coll.isTrigger = !isTrigger;
        }
    }

    public override void Begin()
    {
        //set isRunning variable
        isRunning = true;

        //Then do needed tasks
        coll.isTrigger = false;
    }

    public override void Stop()
    {
        //set isRunning variable
        isRunning = false;

        //Then do needed tasks
        coll.isTrigger = true;
    }

    public override void Pause()
    {
        //set isRunning variable
        isRunning = false;

        //Then do needed tasks
        coll.isTrigger = true;
    }

    public override void Resume()
    {
        //set isRunning variable
        isRunning = true;

        //Then do needed tasks
        coll.isTrigger = false;
    }
}
