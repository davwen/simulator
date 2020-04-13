using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The orientation effect component.


public class Orientation : MonoBehaviour
{
    [HideInInspector]
    public const string EFFECT_KEY = "orientation";
    [HideInInspector]
    public const string EFFECT_DISPLAY_NAME = "Orientation";
    [HideInInspector]
    public const string REMOVABLE = "FALSE";


    //First - objectComp variable
    private Object objectComp;

    //Second - varaible keys. Always string.
    [Header("Keys")]
    public const string xPosValueKey = EFFECT_KEY + "_x_pos";
    public const string yPosValueKey = EFFECT_KEY + "_y_pos";
    public const string rotValueKey = EFFECT_KEY + "_rotation";
    public const string widthValueKey = EFFECT_KEY + "_width";
    public const string heightValueKey = EFFECT_KEY + "_height";

    //Third - variables needed for effect.
    private float xPos;
    private float xPosChecker;

    private float yPos;
    private float yPosChecker;

    private float rot;
    private float rotChecker;

    private float width;
    private float widthChecker;

    private float height;
    private float heightChecker;


    private Vector3 transPosChecker;
    private Vector3 transScaleChecker;
    private Vector3 transRotChecker;

    private int frame;

    private const int checkRate = 7;

    //Fourth - The values the effect needs.
    [Header("Values To Add/Remove")]

    [Tooltip("Values used by effect")]
    public List<Value> usedValues = new List<Value>(5) {
        new Value(xPosValueKey, Value.FLOAT_TYPE_KEY, "0", "X position"),
        new Value(yPosValueKey, Value.FLOAT_TYPE_KEY, "0", "Y position"),
        new Value(rotValueKey, Value.FLOAT_TYPE_KEY, "0", "Rotation"),
        new Value(widthValueKey, Value.FLOAT_TYPE_KEY, "1", "Width"),
        new Value(heightValueKey, Value.FLOAT_TYPE_KEY, "1", "Height")};


    //Last - isRunning variable
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
    }


    void Update()
    {
        
        //set all variables
        xPos = objectComp.getFloatValue(xPosValueKey);
        yPos = objectComp.getFloatValue(yPosValueKey);

        rot = objectComp.getFloatValue(rotValueKey);

        width = objectComp.getFloatValue(widthValueKey);
        height = objectComp.getFloatValue(heightValueKey);

        //Do loops here if needed

        if (frame % checkRate == 1 && frame != 0) //Check every checkRate frame. I do this because of performance.
        {
            if (transScaleChecker != transform.localScale)
            {
                objectComp.setValue(widthValueKey, transform.localScale.x.ToString("f1"));
                objectComp.setValue(heightValueKey, transform.localScale.y.ToString("f1"));
                transScaleChecker = transform.localScale;
            }

            if (transRotChecker != transform.eulerAngles)
            {
                objectComp.setValue(rotValueKey, transform.eulerAngles.z.ToString("f1"));
                transRotChecker = transform.eulerAngles;
            }

            if (transPosChecker != transform.position)
            {
                objectComp.setValue(xPosValueKey, transform.position.x.ToString("f3"));
                objectComp.setValue(yPosValueKey, transform.position.y.ToString("f3"));
                transPosChecker = transform.position;
            }
        }

        if (xPosChecker != xPos) //xPos was changed
        {
            transform.position = new Vector3(xPos, transform.position.y, transform.position.z);

            xPosChecker = xPos;

            
        }

        if (yPosChecker != yPos) //yPos was changed
        {
            transform.position = new Vector3(transform.position.x, yPos, transform.position.z);

            yPosChecker = yPos;
            
        }

        if (rotChecker != rot) //rot was changed
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, rot);

            rotChecker = rot;

        }

        if (widthChecker != width) //width was changed
        {
            transform.localScale = new Vector3(width, transform.localScale.y, transform.localScale.z);

            widthChecker = width;

        }

        if (heightChecker != height) //height was changed
        {
            transform.localScale = new Vector3(transform.localScale.x, height, transform.localScale.z);

            heightChecker = height;

        }
        


        frame++;

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
