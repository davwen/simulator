using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Globalization;
using System.Text;

//This script is a component that holds all of the values that the effects are going to use. 
//It also contains functions for getting/setting values and adding/removing effects.

public class Object : MonoBehaviour
{
    public const string TRUE_STRING = "TRUE";
    public const string FALSE_STRING = "FALSE";

    public List<Value> values;

    public bool isRunning = false;

    private void Update()
    {
       
    }

    public void addEffect(Type effect)
    {
        StartCoroutine(addEffectIenu(effect)); //Uses coroutine to be able to use a delay between Invoke and the rest.

    }

    private IEnumerator addEffectIenu(Type effect)
    {
        if (GetComponent(effect) == null) //checks if object already has the effect/component.
        {
            gameObject.AddComponent(effect);

            MonoBehaviour comp = GetComponent(effect) as MonoBehaviour;

            comp.Invoke("AddUsedValues", 0f); //I'm using a delay to be certain that Invoke is done before executing the rest of the code.

            yield return new WaitForEndOfFrame();

            FindObjectOfType<ValuesListUI>().updateList(this); //Finds the list and calls update.

            if (isRunning)
            {
                beginAll(0f); //If I i don't begin all the newly added component will not start.

            }
        }
       
    }

    public void removeEffect(Type effect)
    {
        if (GetComponent(effect) != null) //checks if object even has the effect/component.
        {
            Destroy(GetComponent(effect));

            removeValues(effect.GetField("EFFECT_KEY").GetValue(effect).ToString());

            FindObjectOfType<ValuesListUI>().updateList(this); //Finds the list and calls update.
        }

    }


    public void beginAll(float delay)
    {
        MonoBehaviour[] allComponents = GetComponents<MonoBehaviour>();

        for(int i = 0; i < allComponents.Length; i++)
        {
            try
            {
                allComponents[i].Invoke("Begin", delay);
                isRunning = true;
            }catch(Exception e) { print(e); }
            
        }
        
    }

    public void stopAll(float delay)
    {
        MonoBehaviour[] allComponents = GetComponents<MonoBehaviour>();

        for (int i = 0; i < allComponents.Length; i++)
        {
            try
            {
                allComponents[i].Invoke("Stop", delay);
                isRunning = false;
            }
            catch (Exception e) { print(e); }

        }

    }

    public void pauseAll(float delay)
    {
        MonoBehaviour[] allComponents = GetComponents<MonoBehaviour>();

        for (int i = 0; i < allComponents.Length; i++)
        {
            try
            {
                allComponents[i].Invoke("Pause", delay);
                isRunning = false;
            }
            catch (Exception e) { print(e); }

        }

    }

    public void resumeAll(float delay)
    {
        MonoBehaviour[] allComponents = GetComponents<MonoBehaviour>();

        for (int i = 0; i < allComponents.Length; i++)
        {
            try
            {
                allComponents[i].Invoke("Resume", delay);
                isRunning = true;
            }
            catch (Exception e) { print(e); }

        }

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


    public int getIntValue(string key)
    {
        int output = 0;

        for(int i = 0; i < values.Count; i++)
        {
            if(values[i].key == key && values[i].type == Value.INTEGER_TYPE_KEY)
            {
                try
                {
                    output = int.Parse(values[i].value);
                }
                catch (FormatException)
                {
                    print("No input for \"" + values[i].key + "\". Output will be " + output.ToString());
                }
            }
        }

        return output;
    }

    

    public float getFloatValue(string key)
    {
        float output = 0.0f;

        for (int i = 0; i < values.Count; i++)
        {
            if (values[i].key == key && values[i].type == Value.FLOAT_TYPE_KEY)
            {
                try
                {
                    output = float.Parse(values[i].value.Replace(".", ",")); //The float.Parse() function uses the local mark character for parsing decimal numbers. So use , in Sweden. Ex: 19,2 not 19.2
                }
                catch (FormatException)
                {
                    print("No input for \"" + values[i].key + "\". Output will be " + output.ToString());
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
            if (values[i].key == key && values[i].type == Value.STRING_TYPE_KEY)
            {
                try
                {
                    output = values[i].value;
                }
                catch (FormatException)
                {
                    print("No input for \"" + values[i].key + "\". Output will be " + output.ToString());
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
            if (values[i].key == key && values[i].type == Value.BOOL_TYPE_KEY)
            {
                if(values[i].value.ToUpper() == TRUE_STRING)
                {
                    output = true;
                }
                if (values[i].value.ToUpper() == FALSE_STRING)
                {
                    output = false;
                }
                else
                {
                    if(output != true)
                    {
                        print("No input for \"" + values[i].key + "\". Output will be " + output.ToString());
                    }
                }
            }
        }

        return output;
    }

    public void addValues(List<Value> valuesToAdd)
    {
        for(int i = 0; i < valuesToAdd.Count; i++)
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
