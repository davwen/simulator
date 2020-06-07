using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The portal effect component.


public class Portal : Effect
{
    [HideInInspector]
    public const string EFFECT_KEY = "portal";
    [HideInInspector]
    public const string EFFECT_DISPLAY_NAME = "Portal";
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

    //Second - varaible keys. Always string.
    [Header("Keys")]
    public const string targetPositionXValueKey = EFFECT_KEY + "_target_position_x";
    public const string targetPositionYValueKey = EFFECT_KEY + "_target_position_y";
    public const string targetPositionIsInRelationToPortalPositionValueKey = EFFECT_KEY + "_position_is_in_relation_to_portal_position";
    public const string delayValueKey = EFFECT_KEY + "_delay";
    public const string preserveVelocityValueKey = EFFECT_KEY + "_preserve_velocity";

    //Third - variables needed for effect.
    private float targetPositionX;
    private float targetPositionY;
    private float delay;
    private bool preserveVelocity;
    public bool targetPositionIsInRelationToPortalPosition;

    public Collider2D coll;

    public override List<Value> GetNecessaryValues()
    {
        return new List<Value>(4) { new Value(targetPositionXValueKey, Value.FLOAT_TYPE_KEY, "0", "Target X position"),
        new Value(targetPositionYValueKey, Value.FLOAT_TYPE_KEY, "0", "Target Y position"),
        new Value(targetPositionIsInRelationToPortalPositionValueKey, Value.BOOL_TYPE_KEY, Value.TRUE_STRING, "Target position is in relation to portal position"),
        new Value(delayValueKey, Value.FLOAT_TYPE_KEY, "0", "Delay"),
        new Value(preserveVelocityValueKey, Value.BOOL_TYPE_KEY, Value.TRUE_STRING, "Preserve velocity") };
    }

    void Start()
    {
        //Get the object component only once in the start for better performance.
        objectComp = GetComponent<Object>();

        if(objectComp == null)
        {
            print("You need an Object component attached to the object " + "\"" + gameObject.name + "\".");
        }

        coll = GetComponent<Collider2D>(); //Gets any collider attached to the objects.
    }

    
    void FixedUpdate()
    {
        //set all variables
        targetPositionX = objectComp.GetFloatValue(targetPositionXValueKey);
        targetPositionY = objectComp.GetFloatValue(targetPositionYValueKey);
        delay = objectComp.GetFloatValue(delayValueKey);
        preserveVelocity = objectComp.GetBoolValue(preserveVelocityValueKey);
        targetPositionIsInRelationToPortalPosition = objectComp.GetBoolValue(targetPositionIsInRelationToPortalPositionValueKey);


        //Do loops here if needed
        if (isRunning)
        {
            
        }
    }

    private void OnCollisionStay2D(Collision2D collision){
        if(collision.gameObject.GetComponent<Object>() != null && isRunning){
            StartCoroutine(Teleport(collision.gameObject));
        }
    }

    private IEnumerator Teleport(GameObject objectToTeleport){
        yield return new WaitForSeconds(delay);
        
        if(targetPositionIsInRelationToPortalPosition){
            objectToTeleport.transform.position = transform.position + new Vector3(targetPositionX, targetPositionY, objectToTeleport.transform.position.z);
        }else{
            objectToTeleport.transform.position = new Vector3(targetPositionX, targetPositionY, objectToTeleport.transform.position.z);
        }
        
        
        if(!preserveVelocity){
            objectToTeleport.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            objectToTeleport.GetComponent<Rigidbody2D>().angularVelocity = 0;
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
