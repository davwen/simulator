using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

//This script is a component that holds all of the values that the effects are going to use. 
//It also contains functions for getting/setting values and adding/removing effects.

public class Object : MonoBehaviour
{
    public const string TRUE_STRING = "TRUE";
    public const string FALSE_STRING = "FALSE";


    public List<Value> values;

    public bool isRunning = false;

    [Tooltip("Effects that the object should start with.")]
    public List<string> startEffects;

    public List<Type> currentEffects = new List<Type>();

    public List<string> Effects = new List<string>();
   
    private void Awake()
    {

        for (int i = 0; i < startEffects.Count; i++)
        {
            addEffect(Type.GetType(startEffects[i]));
        }


    }

    private void Update()
    {
        Effects.Clear();

        foreach(Type type in currentEffects)
        {
            Effects.Add(type.ToString());
        }

        Effects = Effects.Distinct().ToList();

        values = values.Distinct().ToList();

        try
        {
            foreach (Type type in currentEffects)
            {
                if (GetComponent(type) == null)
                {
                    addEffect(type, false);
                }
            }
        } catch (InvalidOperationException) { }
        
    }

    public void addEffect(Type effect, bool addValues = true)
    {
        StartCoroutine(addEffectIenu(effect, addValues)); //Uses coroutine to be able to use a delay between Invoke and the rest.

    }

    private IEnumerator addEffectIenu(Type effect, bool addValues)
    {
        if (GetComponent(effect) == null) //checks if object already has the effect/component.
        {
            gameObject.AddComponent(effect);

            MonoBehaviour comp = GetComponent(effect) as MonoBehaviour;

            if (addValues)
            {
                comp.Invoke("AddUsedValues", 0f); 

                yield return new WaitForEndOfFrame(); //I'm using a delay to be certain that Invoke is done before executing the rest of the code.
            }

            FindObjectOfType<ValuesListManager>().UpdateAdapter();
            FindObjectOfType<ValuesListManager>().UpdateList();

            if (isRunning)
            {
                beginAll(); //If I i don't begin all the newly added component will not start.

            }

            currentEffects.Add(effect);
        }

    }

    public void removeEffect(Type effect)
    {
        if (GetComponent(effect) != null) //checks if object even has the effect/component.
        {
            currentEffects.Remove(effect);

            FindObjectOfType<ValuesListManager>().UpdateAdapter();
            FindObjectOfType<ValuesListManager>().UpdateList();

            Destroy(GetComponent(effect));

            removeValues(effect.GetField("EFFECT_KEY").GetValue(effect).ToString());



            
        }

    }


    public void beginAll()
    {
        BroadcastMessage("Begin", SendMessageOptions.DontRequireReceiver);
        isRunning = true;
    }

    public void stopAll()
    {
        BroadcastMessage("Stop", SendMessageOptions.DontRequireReceiver);
        isRunning = false;
    }

    public void pauseAll()
    {
        BroadcastMessage("Pause", SendMessageOptions.DontRequireReceiver);
        isRunning = false;

    }

    public void resumeAll()
    {
        BroadcastMessage("Resume", SendMessageOptions.DontRequireReceiver);
        isRunning = true;
    }


    public void setValue(string key, Value value)
    {
        for (int i = 0; i < values.Count; i++)
        {
            if (values[i].key == key)
            {
                values[i] = value;
            }
        }
    }

    public void setValue(string key, string value)
    {
        for (int i = 0; i < values.Count; i++)
        {
            if (values[i].key == key)
            {
                values[i].value = value;
            }
        }
    }


    public int getIntValue(string key)
    {
        int output = 0;

        for (int i = 0; i < values.Count; i++)
        {
            if (values[i].key.Equals(key) && values[i].type.Equals(Value.INTEGER_TYPE_KEY))
            {
                try
                {
                    output = int.Parse(values[i].value);
                }
                catch (FormatException)
                {
                    print("No input for " + "(" + values[i].type + ") " + "\"" + values[i].displayName + "\" (\"" + values[i].key + "\")" + ". Output will be: " + output.ToString());
                }
            }
        }

        return output;
    }



    public float getFloatValue(string key, float baseVal = 0f)
    {
        float output = baseVal;


        for (int i = 0; i < values.Count; i++)
        {

            if (values[i].key.Equals(key) && values[i].type.Equals(Value.FLOAT_TYPE_KEY))
            {
                try
                {
                    output = float.Parse(values[i].value);
                }
                catch (FormatException)
                {
                    print("No input for " + "(" + values[i].type + ") " + "\"" + values[i].displayName + "\" (\"" + values[i].key + "\")" + ". Output will be: " + output.ToString());
                }

            }
        }

        return output;
    }




    public string getStringValue(string key)
    {
        string output = "";

        for (int i = 0; i < values.Count; i++)
        {
            if (values[i].key.Equals(key) && values[i].type.Equals(Value.STRING_TYPE_KEY))
            {
                try
                {
                    output = values[i].value;
                }
                catch (FormatException)
                {
                    print("No input for " + "(" + values[i].type + ") " + "\"" + values[i].displayName + "\" (\"" + values[i].key + "\")" + "\". Output will be: " + output.ToString());
                }

            }
        }

        return output;
    }

    public bool getBoolValue(string key)
    {
        bool output = false;

        for (int i = 0; i < values.Count; i++)
        {
            if (values[i].key.Equals(key) && values[i].type.Equals(Value.BOOL_TYPE_KEY))
            {
                if (values[i].value.ToUpper() == TRUE_STRING)
                {
                    output = true;
                }
                if (values[i].value.ToUpper() == FALSE_STRING)
                {
                    output = false;
                }
                else
                {
                    if (output != true)
                    {
                        print("No input for " + "(" + values[i].type + ") " + "\"" + values[i].displayName + "\" (\"" + values[i].key + "\")" + "\". Output will be: " + output.ToString());
                    }
                }
            }
        }

        return output;
    }

    public void addValues(List<Value> valuesToAdd)
    {
        for (int i = 0; i < valuesToAdd.Count; i++)
        {
            if (!values.Contains(valuesToAdd[i]))
            {
                values.Add(valuesToAdd[i]);
            }
        }
    }

    public void removeValues(string effectKey)
    {
        values.RemoveAll(item => item.key.StartsWith(effectKey)); //Removes every value that starts with specific EFFECT_KEY value
    }


}

public class ObjectData
{
    public List<Value> values = new List<Value>();

    public List<Type> currentEffects = new List<Type>();

    public List<string> startEffects = new List<string>();

    public Sprite sprite;

    public void setValue(string key, string value)
    {
        for (int i = 0; i < values.Count; i++)
        {
            if (values[i].key == key)
            {
                values[i].value = value;
            }
        }
    }
}