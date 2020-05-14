using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class Value
{
    public string displayName = "Untitled";
    public string key = "";
    public string type = "";
    public string value = "";
    

    public const string INTEGER_TYPE_KEY = "INTEGER";
    public const string FLOAT_TYPE_KEY = "FLOAT";
    public const string STRING_TYPE_KEY = "STRING";
    public const string BOOL_TYPE_KEY = "BOOL";

    public Value(string _key, string _type, string _value, string _displayName = "Untitled")
    {
        
        key = _key;
        type = _type;
        value = _value;
        displayName = _displayName;
    }

    public bool Equals(Value other)
    {
        return this.key == other.key && this.value == other.value && this.type == other.type && this.displayName == other.displayName;
    }

    public const string TRUE_STRING = "TRUE";
    public const string FALSE_STRING = "FALSE";
}


