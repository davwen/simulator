using UnityEngine;
using System;
using System.Collections.Generic;

public abstract class Effect : MonoBehaviour
{
    public abstract string GetEffectKey();

    public abstract string GetEffectDisplayName();

    public abstract bool GetEffectRemovable();

    public abstract List<Value> GetNecessaryValues();

    public bool isRunning;

    public Object objectComp;

    public static void AddFromString(string input, GameObject target)
    {
        Type type = Type.GetType(input);

        if (type.IsSubclassOf(typeof(Effect)))
        {
            target.AddComponent(type);
        }
    }

    public static void AddFromType(Type input, GameObject target)
    {
        Type type = input;

        if (type.IsSubclassOf(typeof(Effect)))
        {
            target.AddComponent(type);
        }
    }

    public static Effect GetFromString(string input, GameObject target)
    {
        Type type = Type.GetType(input);

        if (type.IsSubclassOf(typeof(Effect)))
        {
            return target.GetComponent(type) as Effect;
        }
        else
        {
            return null;
        }
    }

    public static Effect GetFromType(Type input, GameObject target)
    {
        Type type = input;

        var comps = target.GetComponents<Effect>();

        foreach(var comp in comps)
        {
            if(comp.GetType() == type)
            {
                return comp;
            }
        }

        return null;
       
    }

    public static string GetDisplayName(Type input)
    {
        Type type = input;

        if (type.IsSubclassOf(typeof(Effect)))
        {
            return type.GetField("EFFECT_DISPLAY_NAME").GetValue(null).ToString();
        }

        return null;
    }

    public static string GetKey(Type input)
    {
        Type type = input;

        if (type.IsSubclassOf(typeof(Effect)))
        {
            return type.GetField("EFFECT_KEY").GetValue(null).ToString();
        }

        return null;
    }

    public static bool GetRemovable(Type input, bool backup = true)
    {
        Type type = input;

        if (type.IsSubclassOf(typeof(Effect)))
        {
            return type.GetField("EFFECT_REMOVABLE").GetValue(null).ToString() == Value.TRUE_STRING;
        }

        return backup;
    }

    public void AddNecessaryValues()
    {
        if(GetNecessaryValues() != null && objectComp != null)
        {
            objectComp.AddValues(GetNecessaryValues());
        }
    }

    public abstract void Begin();

    public abstract void Stop();

    public virtual void Pause() { }

    public virtual void Resume() { }
}