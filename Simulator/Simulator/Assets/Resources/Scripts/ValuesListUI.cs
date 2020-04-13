using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

//This is a script that spawns list according to a list of values. Used in the user interface for changing values.

public class ValuesListUI : MonoBehaviour
{

    public GameObject stringItemUI;
    public GameObject integerItemUI;
    public GameObject floatItemUI;
    public GameObject boolItemUI;
    public GameObject titleItemUI;

    public Vector2 offset;

    [Tooltip("Use the Reference Resolution used in the Canvas Scaler.")]
    public float standardScreenHeight = 1080f;

    public GameObject parent;

    public CanvasGroup canvasGroup;

    public string effectDisplayNameKey = "EFFECT_DISPLAY_NAME";

    public void makeUIofObj(Object obj)
    {
        SpawnUI(obj.values, obj);
        canvasGroup.alpha = 1; //Shows the list UI.
    }

    public void updateList(Object obj)
    {
        SpawnUI(obj.values, obj);
    }

    public void removeUIofObj(bool hide = false)
    {
        int childs = parent.transform.childCount;
        for (int i = 0; i < childs; i++)
        {
            GameObject.Destroy(parent.transform.GetChild(i).gameObject); //Destroys every list item.
        }

        if (hide)
        {
            canvasGroup.alpha = 0; //Hides the list UI.
        }
        
    }

    public void SpawnUI(List<Value> ValuesToDisplay, Object obj, bool removeOld = true)
    {
        //Removes all children before inserting any new.
        if (removeOld)
        {
            removeUIofObj();
        }
       

        List<string> effects = new List<string>();

        //Goes through every value in the list to then instantiate an item and then apply all the values to that item as well as instantiating title items.

        for (int i = 0; i < ValuesToDisplay.Count; i++)
        {
            GameObject uiItem = floatItemUI; //Float is the most commonly used value type.

            //Selects the correct prefab based on value type.
            if (ValuesToDisplay[i].type == Value.STRING_TYPE_KEY)
            {
                uiItem = stringItemUI;
            }

            if (ValuesToDisplay[i].type == Value.INTEGER_TYPE_KEY)
            {
                uiItem = integerItemUI;
            }
            
            if (ValuesToDisplay[i].type == Value.FLOAT_TYPE_KEY)
            {
                uiItem = floatItemUI;
            }

            if (ValuesToDisplay[i].type == Value.BOOL_TYPE_KEY)
            {
                uiItem = boolItemUI;
            }

            string effectKey = ValuesToDisplay[i].key.Split("_".ToCharArray()[0])[0]; //Gets the first part of the value key. Ex: rotation_speed = rotation
            string effectName = Type.GetType(new Capitalization().Capitalize(effectKey)).GetField(effectDisplayNameKey).GetValue(this).ToString();

            GameObject lastTitleItem = null;

            if (!effects.Contains(effectKey)) //Checks if it is the first time seeing a key with this beginning, else every item would get its own title.
            {
                //If so, make it spawn a title item.
                lastTitleItem = spawnItem(titleItemUI, i);


                effects.Add(effectKey); //Adds to list

            }

            GameObject lastItem = spawnItem(uiItem, i); //Spawns an item


            ValueToUIAssigner assigner = lastItem.GetComponent<ValueToUIAssigner>(); //The component to assign the value to.
            if(assigner != null)
            {
                assigner.assignedObject = obj;
                assigner.assignedValue = ValuesToDisplay[i];
            }
          

            if(lastTitleItem != null)
            {
                Text titleText = lastTitleItem.GetComponentInChildren<Text>();
                if (titleText != null)
                {
                    titleText.text = effectName;

                }

                assigner = lastTitleItem.GetComponent<ValueToUIAssigner>(); //Assigns the Obj variable on the titleItem.

                if (assigner != null)
                {
                    assigner.assignedObject = obj;
                    assigner.assignedEffect = Type.GetType(new Capitalization().Capitalize(effectKey));
                }
                
                Button removeBtn = assigner.removeButton;

                if(removeBtn != null)
                {
                    if (assigner.assignedEffect.GetField("REMOVABLE").GetValue(this).ToString() == "FALSE")
                    {
                        removeBtn.gameObject.SetActive(false);
                    }
                }
            }
        }
    }

    private GameObject spawnItem(GameObject ui, int index) //Spawns item in list
    {
        RectTransform itemRectTrans = ui.GetComponent<RectTransform>();

        GameObject lastItem = Instantiate(ui, new Vector2(offset.x, Screen.height //Uses screen.height here to get the list to start from the top of its parent.
            - offset.y -

            itemRectTrans.rect.height * index / (standardScreenHeight / Screen.height)), //Calculates to y pos according to how many items have 
                                                                                     //currently been spawned. Then does some dividing to 
                                                                                     //be able to work with all sceen sizes.
            new Quaternion(0, 0, 0, 0), //Sets rotation to zero.
            parent.transform);

        return lastItem;
    }

    public void onModeChange(string mode)
    {
        switch (mode)
        {
            case ModeManager.MODE_SPAWN:
                canvasGroup.alpha = 0;
                break;
        }
    }
}
