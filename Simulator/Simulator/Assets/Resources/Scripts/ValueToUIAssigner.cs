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
    public InputField stringInputField;
    private string stringValCheck;

    [Header("For Bool")]
    public Toggle toggle;
    private string boolValCheck;

    [Header("For Integer")]
    public InputField intInputField;
    private string intValCheck;

    [Header("For Float")]
    public InputField floatInputField;
    private string floatValCheck;

    [Header("For Title")]
    public Button removeButton;
    

    private List<Button> btnsWithListeners = new List<Button>();

    public void setValueToUI()
    {
       
        if (assignedValue.type == Value.STRING_TYPE_KEY)
        {
            Value setTo = assignedValue;
            setTo.value = stringInputField.text;
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
        assignValueToUI(assigningMethod.withAssignedValue);
    }

    private void btnOnClick()
    {
        assignedObject.removeEffect(assignedEffect);
    }

    private bool isValueEmpty(Value value)
    {
        return value.key == "" && value.type == "" && value.value == "";
    }

    private void Update()
    {
        assignValueToUI(assigningMethod.withUpdatedFromObj);

    }

    private void assignValueToUI(string method)
    {
        Value valToAssign = new Value("", "", "", "");

        if(method == assigningMethod.withUpdatedFromObj)
        {
            if (stringInputField != null) //String
            {
                valToAssign.value = assignedObject.getStringValue(assignedValue.key);
            }

            if (intInputField != null) //Integer
            {
                valToAssign.value = assignedObject.getIntValue(assignedValue.key).ToString();
            }

            if (floatInputField != null) //Float
            {
                valToAssign.value = assignedObject.getFloatValue(assignedValue.key).ToString();
            }

            if (toggle != null) //Bool
            {
                valToAssign.value = (assignedObject.getBoolValue(assignedValue.key).ToString().ToUpper() == Object.TRUE_STRING).ToString();
            }
        }
        else
        {
            valToAssign.value = assignedValue.value;
        }

        valToAssign.key = assignedValue.key;
        valToAssign.displayName = assignedValue.displayName;

        if (!isValueEmpty(valToAssign))
        {
            titleText.text = valToAssign.displayName; //Sets the title on the item in the list.

            if (stringInputField != null && stringValCheck != valToAssign.value) //String
            {
                stringInputField.text = valToAssign.value;

                stringValCheck = valToAssign.value;
            }

            if (intInputField != null && intValCheck != valToAssign.value) //Integer
            {
                intInputField.text = valToAssign.value;

                intValCheck = valToAssign.value;
            }

            if (floatInputField != null && floatValCheck != valToAssign.value) //Float
            {
                floatInputField.text = valToAssign.value;

                floatValCheck = valToAssign.value;
            }

            if (toggle != null && boolValCheck != valToAssign.value) //Bool
            {
                toggle.isOn = valToAssign.value.ToUpper() == Object.TRUE_STRING;

                boolValCheck = valToAssign.value;
            }
        }
        else //The item is a title.
        {
            if(removeButton != null)
            {
                if (!btnsWithListeners.Contains(removeButton))
                {
                    removeButton.onClick.AddListener(btnOnClick);
                }

                btnsWithListeners.Add(removeButton);
            }
          
        }


    }
}

public class assigningMethod
{
    public const string withAssignedValue = "ASSIGNED";
    public const string withUpdatedFromObj = "UPDATED";
}
