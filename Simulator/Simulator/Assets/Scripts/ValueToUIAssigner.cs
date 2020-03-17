using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

//This script sits on every item in the UI values list. 
//It takes in a value and decides which prefab it should spawn. 
//Then it makes it so when any of the values in its UI changes, it changes the 
//values on the obejcts Object script. It also handles the remove function of effects.

public class ValueToUIAssigner : MonoBehaviour
{

    
    public Value assignedValue;
   
    public Object assignedObject;
   
    public Type assignedEffect;


    public Text titleText;

    [Header("For String")]
    public InputField inputField;

    [Header("For Bool")]
    public Toggle toggle;

    [Header("For Integer")]
    public InputField intInputField;

    [Header("For Float")]
    public InputField floatInputField;

    [Header("For Title")]
    public Button removeButton;

    public void setValueToUI()
    {
       
        if (assignedValue.type == Value.STRING_TYPE_KEY)
        {
            Value setTo = assignedValue;
            setTo.value = inputField.text;
            assignedObject.setValue(assignedValue.key, setTo);
        }

        if (assignedValue.type == Value.BOOL_TYPE_KEY)
        {
            Value setTo = assignedValue;
            setTo.value = toggle.isOn.ToString().ToLower();
            assignedObject.setValue(assignedValue.key, setTo);
        }

        if (assignedValue.type == Value.INTEGER_TYPE_KEY)
        {
            Value setTo = assignedValue;
            setTo.value = intInputField.text;
            assignedObject.setValue(assignedValue.key, setTo);
        }

        if (assignedValue.type == Value.FLOAT_TYPE_KEY)
        {
            Value setTo = assignedValue;
            setTo.value = floatInputField.text;
            assignedObject.setValue(assignedValue.key, setTo);
        }
    }

    private void Start()
    {
       
        if(!isValueEmpty(assignedValue))
        {
            titleText.text = assignedValue.displayName; //Sets the title on the item in the list.

            if (inputField != null)
            {
                inputField.text = assignedValue.value;
            }

            if (intInputField != null)
            {
                intInputField.text = assignedValue.value;
            }

            if (floatInputField != null)
            {
                floatInputField.text = assignedValue.value;
            }

            if (toggle != null)
            {
                toggle.isOn = assignedValue.value.ToUpper() == Object.TRUE_STRING;
            }
        }
        else //The item is a title.
        {
            removeButton.onClick.AddListener(btnOnClick);
        }
       
    }

    private void btnOnClick()
    {
        assignedObject.removeEffect(assignedEffect);
    }

    private bool isValueEmpty(Value value)
    {
        return value.key == "" && value.type == "" && value.value == "";
    }
}
