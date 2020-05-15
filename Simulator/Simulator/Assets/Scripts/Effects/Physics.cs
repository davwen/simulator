using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//THIS SCRIPT CONTAINS ALL OF THE GUIDELINES FOR EFFECT SCRIPTS.

//The rotation effect component.

public class Physics : Effect
{
    [HideInInspector]
    public const string EFFECT_KEY = "physics";
    [HideInInspector]
    public const string EFFECT_DISPLAY_NAME = "Physics";
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


    //Second - varaible keys. Always string.
    [Header("Keys")]
    public const string gravityValueKey = EFFECT_KEY + "_gravity_strength";

    public const string restrictXValueKey = EFFECT_KEY + "_restrict_x";
    public const string restrictYValueKey = EFFECT_KEY + "_restrict_y";
    public const string restrictRotationValueKey = EFFECT_KEY + "_restrict_rotation";

    //Third - variables needed for effect.
    private bool restrictX;
    private bool restrictY;
    private bool restrictRotation;
    private float gravityStrength;
    private Rigidbody2D rb;

    public override List<Value> GetNecessaryValues()
    {
        return new List<Value>(2) {
        new Value(gravityValueKey, Value.FLOAT_TYPE_KEY, "1", "Gravity strength"), 
        new Value(restrictXValueKey, Value.BOOL_TYPE_KEY, Value.FALSE_STRING, "Restrict X"),
        new Value(restrictYValueKey, Value.BOOL_TYPE_KEY, Value.FALSE_STRING, "Restrict Y"),
        new Value(restrictRotationValueKey, Value.BOOL_TYPE_KEY, Value.FALSE_STRING, "Restrict Rotation") };
    }

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
        restrictRotation = objectComp.GetBoolValue(restrictRotationValueKey);
        restrictX = objectComp.GetBoolValue(restrictXValueKey);
        restrictY = objectComp.GetBoolValue(restrictYValueKey);

        gravityStrength = objectComp.GetFloatValue(gravityValueKey);

        //Do loops here if needed

        if (isRunning)
        {
            rb.gravityScale = gravityStrength;
           
            if(!DragDrop.Instance.isDragging){
                if (!restrictRotation && !restrictX && !restrictY)
                {
                    rb.constraints = RigidbodyConstraints2D.None;
                }
                if (restrictRotation && restrictX && restrictY)
                {
                    rb.constraints = RigidbodyConstraints2D.FreezeAll;
                }
                if (restrictRotation && !restrictX && !restrictY)
                {
                    rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                }
                if (!restrictRotation && restrictX && !restrictY)
                {
                    rb.constraints = RigidbodyConstraints2D.FreezePositionX;
                }
                if (!restrictRotation && !restrictX && restrictY)
                {
                    rb.constraints = RigidbodyConstraints2D.FreezePositionY;
                }
                if (!restrictRotation && restrictX && restrictY)
                {
                    rb.constraints = RigidbodyConstraints2D.FreezePosition;
                }
                if (restrictRotation && restrictX && !restrictY)
                {
                    rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
                }
                if (restrictRotation && !restrictX && restrictY)
                {
                    rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
                }
            }
        }
    }

    public override void Begin()
    {
        //set isRunning variable
        isRunning = true;

        //Then do needed tasks
        if (restrictRotation)
        {
            rb.constraints = RigidbodyConstraints2D.None;
        }
        else
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }

    public override void Stop()
    {
        //set isRunning variable
        isRunning = false;

        //Then do needed tasks
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    public override void Pause()
    {
        //set isRunning variable
        isRunning = false;

        //Then do needed tasks
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    public override void Resume()
    {
        //set isRunning variable
        isRunning = true;

        //Then do needed tasks
        if (restrictRotation)
        {
            rb.constraints = RigidbodyConstraints2D.None;
        }
        else
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
}
