using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//THIS SCRIPT CONTAINS ALL OF THE GUIDELINES FOR EFFECT SCRIPTS.

//The colour effect component.

public class Colour : MonoBehaviour
{
    [HideInInspector]
    public const string EFFECT_KEY = "colour";
    [HideInInspector]
    public const string EFFECT_DISPLAY_NAME = "Colour";
    [HideInInspector]
    public const string EFFECT_REMOVABLE = Object.TRUE_STRING;

    //First - objectComp variable
    private Object objectComp;


    //Second - varaible keys. Always string.
    [Header("Keys")]
    public const string RValueKey = EFFECT_KEY + "_r";
    public const string GValueKey = EFFECT_KEY + "_g";
    public const string BValueKey = EFFECT_KEY + "_b";

    //Third - variables needed for effect.
    private float R = 255;
    private float G = 255;
    private float B = 255;

    private SpriteRenderer sr;

    [HideInInspector]
    public bool considerIsRunning = false;

    //Fourth - The values the effect needs.
    [Header("Values To Add/Remove")]

    [Tooltip("Values used by effect")]
    public List<Value> usedValues = new List<Value>(3) { new Value(RValueKey, Value.FLOAT_TYPE_KEY, "255", "Red"),
        new Value(GValueKey, Value.FLOAT_TYPE_KEY, "255", "Green"),
        new Value(BValueKey, Value.FLOAT_TYPE_KEY, "255", "Blue")};


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

        sr = GetComponent<SpriteRenderer>(); //Get the spriteRenderer once only.
    }


    void Update()
    {
        //set all variables
        R = objectComp.getFloatValue(RValueKey);
        G = objectComp.getFloatValue(GValueKey);
        B = objectComp.getFloatValue(BValueKey);

        //Do loops here if needed
        if (isRunning || !considerIsRunning)
        {
            sr.color = new Color(R / 255, G / 255, B / 255, sr.color.a); //Deviding by 255 because else the max is 1 which is less convenient.

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