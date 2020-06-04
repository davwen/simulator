using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//The black hole effect component.


public class BlackHole : Effect
{
    [HideInInspector]
    public const string EFFECT_KEY = "blackHole";
    [HideInInspector]
    public const string EFFECT_DISPLAY_NAME = "Black hole";
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
    public const string strengthValueKey = EFFECT_KEY + "_strength";
    public const string rangeValueKey = EFFECT_KEY + "_range";
    public const string destroyOnCollisionValueKey = EFFECT_KEY + "_destroy_on_collision";

    //Third - variables needed for effect.
    private float strength;
    private float range;
    private bool destroyOnCollision;
    public List<GameObject> objectsWithinRange = new List<GameObject>();

    public override List<Value> GetNecessaryValues()
    {
        return new List<Value>(3) { new Value(strengthValueKey, Value.FLOAT_TYPE_KEY, "10", "Strength"),
        new Value(rangeValueKey, Value.FLOAT_TYPE_KEY, "5", "Range"),
        new Value(destroyOnCollisionValueKey, Value.BOOL_TYPE_KEY, "true", "Destroy on impact") };
    }

    void Start()
    {
        //Get the object component only once in the start for better performance.
        objectComp = GetComponent<Object>();

        if(objectComp == null)
        {
            print("You need an Object component attached to the object " + "\"" + gameObject.name + "\".");
        }
    }

    
    void FixedUpdate()
    {
        //set all variables
        strength = objectComp.GetFloatValue(strengthValueKey);
        range = objectComp.GetFloatValue(rangeValueKey);
        destroyOnCollision = objectComp.GetBoolValue(destroyOnCollisionValueKey);

        //Do loops here if needed
        if (isRunning)
        {
            Object[] allObjects = ObjectManager.Instance.objects.ToArray();

            for(int i = 0; i < allObjects.Length; i++){
                if(Vector2.Distance(allObjects[i].transform.position, transform.position) <= range && !objectsWithinRange.Contains(allObjects[i].gameObject) && allObjects[i].gameObject != gameObject){
                    objectsWithinRange.Add(allObjects[i].gameObject);
                }
                
                if(Vector2.Distance(allObjects[i].transform.position, transform.position) > range){
                    objectsWithinRange.Remove(allObjects[i].gameObject);
                }
            }

            for(int i = 0; i < objectsWithinRange.Count; i++) {
                float dist = Vector3.Distance(objectsWithinRange[i].transform.position, transform.position);
                
                Vector2 v = objectsWithinRange[i].transform.position - transform.position;
                objectsWithinRange[i].GetComponent<Rigidbody2D>().AddForce(v.normalized * (float)(1.0 - dist) * strength);
                
            }
        }
    }

    public override void Begin()
    {

    }

    public override void Stop()
    {

    }

    public override void Pause()
    {

    }

    public override void Resume()
    {

    }
}
