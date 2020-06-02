using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

//This script is a component that holds all of the values that the effects are going to use. 
//It also contains functions for getting/setting values and adding/removing effects.

public class Object : MonoBehaviour
{
    public List<Value> values;

    public bool isRunning = false;

    [Tooltip("Effects that the object should start with.")]
    public List<string> startEffects;

    public List<Type> currentEffects = new List<Type>();

    public List<string> effects = new List<string>();
   
    private void Awake()
    {
        for (int i = 0; i < startEffects.Count; i++)
        {
            AddEffect(Type.GetType(startEffects[i]));
        }
    }

    private void Start(){
        if(ObjectManager.Instance.isRunning){
            BeginAll();
        }
    }

    public void AddEffect(Type effect, bool addValues = true)
    {
        StartCoroutine(AddEffectIenu(effect, addValues));
    }

    private IEnumerator AddEffectIenu(Type effect, bool addValues)
    {
        if (Effect.GetFromType(effect, gameObject) == null)
        {
            gameObject.AddComponent(effect);

            if (addValues && gameObject != null)
            {
                yield return new WaitForEndOfFrame();
                Effect.GetFromType(effect, gameObject).AddNecessaryValues();
            }

            FindObjectOfType<ValuesListManager>().UpdateAdapter();
            FindObjectOfType<ValuesListManager>().UpdateList();

            if (isRunning)
            {
                BeginAll();
            }

            currentEffects.Add(effect);
            effects.Add(effect.Name);
        }

    }

    public void RemoveEffect(Type effect)
    {
        if (GetComponent(effect) != null) //checks if object even has the effect/component.
        {
            currentEffects.Remove(effect);
            effects.Remove(effect.Name);

            FindObjectOfType<ValuesListManager>().UpdateAdapter();
            FindObjectOfType<ValuesListManager>().UpdateList();

            Destroy(GetComponent(effect));

            RemoveValues(effect.GetField("EFFECT_KEY").GetValue(effect).ToString()); 
        }

    }


    public void BeginAll()
    {
        BroadcastMessage("Begin", SendMessageOptions.DontRequireReceiver);
        isRunning = true;
    }

    public void StopAll()
    {
        BroadcastMessage("Stop", SendMessageOptions.DontRequireReceiver);
        isRunning = false;
    }

    public void PauseAll()
    {
        BroadcastMessage("Pause", SendMessageOptions.DontRequireReceiver);
        isRunning = false;

    }

    public void ResumeAll()
    {
        BroadcastMessage("Resume", SendMessageOptions.DontRequireReceiver);
        isRunning = true;
    }


    public void SetValue(string key, Value value)
    {
        for (int i = 0; i < values.Count; i++)
        {
            if (values[i].key == key)
            {
                values[i] = value;
            }
        }
    }

    public void SetValue(string key, string value)
    {
        for (int i = 0; i < values.Count; i++)
        {
            if (values[i].key == key)
            {
                values[i].value = value;
            }
        }
    }


    public int GetIntValue(string key)
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
                    print("No input for " + values[i].type + " \"" + values[i].displayName + "\" (\"" + values[i].key + "\")" + ". Output will be: " + output.ToString());
                }
            }
        }

        return output;
    }



    public float GetFloatValue(string key, float baseVal = 0f)
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
                    print("No input for " + values[i].type + " \"" + values[i].displayName + "\" (\"" + values[i].key + "\")" + ". Output will be: " + output.ToString());
                }

            }
        }

        return output;
    }




    public string GetStringValue(string key)
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
                    print("No input for " + values[i].type + " \"" + values[i].displayName + "\" (\"" + values[i].key + "\")" + "\". Output will be: " + output.ToString());
                }

            }
        }

        return output;
    }

    public bool GetBoolValue(string key)
    {
        bool output = false;

        for (int i = 0; i < values.Count; i++)
        {
            if (values[i].key.Equals(key) && values[i].type.Equals(Value.BOOL_TYPE_KEY))
            {
                if (values[i].value.ToUpper() == Value.TRUE_STRING)
                {
                    output = true;
                }
                if (values[i].value.ToUpper() == Value.FALSE_STRING)
                {
                    output = false;
                }
                else
                {
                    if (output != true)
                    {
                        print("No input for " + values[i].type + " \"" + values[i].displayName + "\" (\"" + values[i].key + "\")" + "\". Output will be: " + output.ToString());
                    }
                }
            }
        }

        return output;
    }

    public void AddValues(List<Value> valuesToAdd)
    {
        for (int i = 0; i < valuesToAdd.Count; i++)
        {
            if (!values.Contains(valuesToAdd[i]))
            {
                values.Add(valuesToAdd[i]);
            }
        }
    }

    public void RemoveValues(string effectKey)
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