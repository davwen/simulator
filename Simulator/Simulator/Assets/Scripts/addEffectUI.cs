using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

//This function is used to make the user able to add effects to objects via the games UI.
//It contains stuff like: adding options ("items") to the drop down, add functionality to the "Add" button.

public class AddEffectUI : MonoBehaviour
{
    [Tooltip("Write the name of the Class that holds the effect. Ex: \"rotation\".")]
    public List<string> availableEffectsString = new List<string>();

    private List<Type> availableEffects = new List<Type>();
    private List<Dropdown.OptionData> ddOptions = new List<Dropdown.OptionData>();

    public Dropdown dropDown;
    public Type currentlySelectedEffect;

    void Start()
    {
        AddEffectsToDropDown();
    }
     
    public void AddEffectsToDropDown()
    {
        //This function first adds all effects from the "availableEffectsString" list as Monobehaviours to the "availableEffects" list. 
        //Then it gets the "EFFECT_KEY" variable in all of those Monobehaviours in order to add them to the dropdown.

        availableEffects.Clear();
        for (int i = 0; i < availableEffectsString.Count; i++)
        {
            availableEffects.Add(Type.GetType(availableEffectsString[i]));
        }

        for (int i = 0; i < availableEffects.Count; i++)
        {
            Dropdown.OptionData option = new Dropdown.OptionData();

            option.text = Effect.GetDisplayName(availableEffects[i]);

            ddOptions.Add(option);
        }

        dropDown.ClearOptions();

        dropDown.AddOptions(ddOptions); //Here it actually adds the options to the drop down.

        currentlySelectedEffect = availableEffects[dropDown.value]; //After it has added all effect, it should assign the currentlySelectedEffect variable. Else it would be null from the beginning.
    }

    public void onDropDownChange()
    {
        currentlySelectedEffect = availableEffects[dropDown.value];
    }

    public void onAddBtnClick()
    {
        foreach(Object obj in SelectionManager.Instance.currentlySelected)
        {
            obj.AddEffect(currentlySelectedEffect);
        }
        
    }
}
