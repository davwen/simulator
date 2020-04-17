using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValuesAdapter : ListAdapter
{
    public const string TYPE_TITLE = "TITLE";

    public List<Value> values;
    public Object assignedObject;

    private List<string> effects = new List<string>();

    GameObject floatPrefab;
    GameObject integerPrefab;
    GameObject boolPrefab;
    GameObject stringPrefab;
    GameObject titlePrefab;

    public ValuesAdapter(List<Value> _values, Object _assignedObject, GameObject _floatPrefab, GameObject _integerPrefab, GameObject _boolPrefab, GameObject _stringPrefab, GameObject _titlePrefab)
    {
        values = _values;
        assignedObject = _assignedObject;
        effects.Clear();

        floatPrefab = _floatPrefab;
        integerPrefab = _integerPrefab;
        boolPrefab = _boolPrefab;
        stringPrefab = _stringPrefab;
        titlePrefab = _titlePrefab;

        for(int i = 0; i < values.Count; i++)
        {
            string effectName = values[i].key.Split('_')[0];

            if (!effects.Contains(effectName))
            {
                effects.Add(effectName);
                values.Insert(i, new Value("", TYPE_TITLE, "", Type.GetType(new Capitalization().Capitalize(effectName)).GetField("EFFECT_DISPLAY_NAME").GetValue(this).ToString()));
            }
        }
    }

    public override int GetCount()
    {
        return values.Count;
    }

    public override void OnItemInsert(ListItemData data)
    {
        data.GetComponent<Text>("text_title").text = values[data.index].displayName;

        if (values[data.index].type.Equals(Value.BOOL_TYPE_KEY))
        {
            data.GetComponent<Toggle>("toggle").isOn = values[data.index].value == Object.TRUE_STRING;

            data.GetComponent<Toggle>("toggle").onValueChanged.AddListener(delegate { assignedObject.setValue(values[data.index].key, data.GetComponent<Toggle>("toggle").isOn.ToString().ToUpper()); });
        }

        if (values[data.index].type.Equals(Value.FLOAT_TYPE_KEY) || values[data.index].type.Equals(Value.INTEGER_TYPE_KEY) || values[data.index].type.Equals(Value.STRING_TYPE_KEY))
        {
            data.GetComponent<InputField>("input").text = values[data.index].value;
            data.GetComponent<InputField>("input").onValueChanged.AddListener(delegate { assignedObject.setValue(values[data.index].key, data.GetComponent<InputField>("input").text); });
        }

      
    }

    public override void OnItemRemove(int index)
    {

    }

    public override void OnItemUpdate(ListItemData data)
    {
        OnItemInsert(data);
    }

    public override GameObject GetItemPrefab(int index)
    {
        if (values[index].type.Equals(Value.FLOAT_TYPE_KEY))
        {
            return floatPrefab;
        }
        if (values[index].type.Equals(Value.INTEGER_TYPE_KEY))
        {
            return boolPrefab;
        }
        if (values[index].type.Equals(Value.STRING_TYPE_KEY))
        {
            return stringPrefab;
        }
        if (values[index].type.Equals(Value.BOOL_TYPE_KEY))
        {
            return boolPrefab;
        }
        if (values[index].type.Equals(TYPE_TITLE))
        {
            return titlePrefab;
        }

        return default;
    }
}
