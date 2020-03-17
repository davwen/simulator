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

    public Value createValue(string _key, string _type, string _value, string _displayName = "Untitled")
    {
        Value valToReturn = new Value();
        valToReturn.key = _key;
        valToReturn.type = _type;
        valToReturn.value = _value;
        valToReturn.displayName = _displayName;

        return valToReturn;
    }
}
