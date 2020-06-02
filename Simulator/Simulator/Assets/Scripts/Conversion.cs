using System;

using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.IO;

using UnityEngine;


public class Conversion : MonoBehaviour
{
    public const string attrSeparator = ";";
    public const string arrayItemSeparator = ",";

    public const string arrayBegin = "[";
    public const string arrayEnd = "];";

    public const string attrBegin = "{";
    public const string attrEnd = "}";
}

public class ObjectToTextConverter : Conversion
{
    public static string ConvertToText(Object obj)
    {
        StringBuilder sb = new StringBuilder();

        sb.Append("Values" + arrayBegin);

        for (int i = 0; i < obj.values.Count; i++)
        {
            sb.Append(obj.values[i].key + attrBegin);
            sb.Append(obj.values[i].type + attrSeparator);
            sb.Append(obj.values[i].value + attrSeparator);
            sb.Append(obj.values[i].displayName + attrSeparator + attrEnd + arrayItemSeparator);
        }

        sb.Append(arrayEnd);

        sb.Append("StartEffects" + arrayBegin);

        for (int i = 0; i < obj.startEffects.Count; i++)
        {
            sb.Append(obj.startEffects[i] + arrayItemSeparator);
        }

        sb.Append(arrayEnd); 

        sb.Append("Effects" + arrayBegin);

        for (int i = 0; i < obj.effects.Count; i++)
        {
            sb.Append(obj.effects[i] + arrayItemSeparator);
        }

        sb.Append(arrayEnd);


        sb.Append("Sprite" + arrayBegin);

        sb.Append(Convert.ToBase64String(obj.gameObject.GetComponent<SpriteRenderer>().sprite.texture.EncodeToPNG()) + arrayItemSeparator);

        sb.Append(arrayEnd);


        return sb.ToString();
    }
}

public class TextToObjectConverter : Conversion
{
    public static ObjectData ConvertToObject(string text)
    {
        ObjectData obj = new ObjectData();

        string[] valuesString = getArrays(text)[0].values;

        List<Value> values = new List<Value>();

        foreach(string value in valuesString)
        {
            string[] attrs = getAttrs(value);

            values.Add(new Value(attrs[0], attrs[1], attrs[2], attrs[3]));
        }

        obj.values = values;


        List<string> sEffects = new List<string>(getArrays(text)[1].values);

        obj.startEffects = sEffects;


        string[] effectsString = getArrays(text)[2].values;

        List<Type> Effects = new List<Type>();

        foreach (string effect in effectsString)
        {
            Effects.Add(Type.GetType(effect));
        }

        obj.currentEffects = Effects;


        byte[] imageBytes = Convert.FromBase64String(getArrays(text)[3].values[0]);
        Texture2D tex = new Texture2D(1, 1);
        tex.LoadImage(imageBytes);
        Sprite sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 256);

        obj.sprite = sprite;

        return obj;

    }

    private static string[] getAttrs(string strObj)
    {
        Regex attrRx = new Regex(@"{[\s\S]*}",
         RegexOptions.Compiled | RegexOptions.IgnoreCase);

        string attrsMatch = attrRx.Matches(strObj)[0].Value;

        List<string> attrs = new List<string>(attrsMatch.Split(attrSeparator.ToCharArray()));

        attrs.Reverse();

        attrs.Add(strObj.Substring(0, strObj.IndexOf(attrBegin)));

        attrs.Reverse();

        for (int i = 0; i < attrs.Count; i++)
        {
            attrs[i] = Regex.Replace(attrs[i], (attrBegin + @"|" + attrEnd), "");
        }

        return attrs.ToArray();
    }

    private static TextArray[] getArrays(string strObj)
    {
        List<TextArray> output = new List<TextArray>();

        string arrayRx = @"\[(.*?)\]";

        List<string> names = new List<string>(Regex.Replace(strObj, arrayRx, "").Split(arrayEnd.ToCharArray()));

        names = new List<string> ( names.Where(x => !string.IsNullOrEmpty(x) || !string.IsNullOrWhiteSpace(x)) );

        for (int i = 0; i < names.Count; i++)
        {
            names[i] = Regex.Replace(names[i], (arrayBegin + @"|" + arrayEnd), "");

            TextArray arrayToAdd = new TextArray(names[i]);

            List<string> values = new List<string>(Regex.Matches(strObj, arrayRx)[i].Value.Split(arrayItemSeparator.ToCharArray()));
            values.RemoveAt(values.Count - 1);

            for(int ii = 0; ii < values.Count; ii++)
            {
                values[ii] = Regex.Replace(values[ii], @"\[|\]", "");
            }

            arrayToAdd.values = values.ToArray();

            output.Add(arrayToAdd);
        }

       

        return output.ToArray();
    }
}

class TextArray
{
    public string name;

    public string[] values;

    public TextArray(string _name)
    {
        name = _name;
    }
}

public class GameObjectToTexture : Conversion
{
    public static Texture2D ConvertToTexture(GameObject input)
    {
        SnapshotCamera ssc = SnapshotCamera.MakeSnapshotCamera();

        Texture2D output = ssc.TakeObjectSnapshot(input, Color.clear, new Vector3(0, 0, 1), input.transform.rotation, input.transform.localScale);
        return output;
    }
}

public class GameObjectToSprite : Conversion
{
    public static Sprite ConvertToSprite(GameObject input, Vector2 size)
    {
        SnapshotCamera ssc = SnapshotCamera.MakeSnapshotCamera();

        float sizeFactor = 1f;

        if(input.transform.localScale.y > input.transform.localScale.x)
        {
            sizeFactor = size.y / input.transform.localScale.y;
        }

        if (input.transform.localScale.x > input.transform.localScale.y)
        {
            sizeFactor = size.x / input.transform.localScale.x;
        }

        Texture2D texture = ssc.TakeObjectSnapshot(input, Color.clear, new Vector3(0, 0, 1), input.transform.rotation, input.transform.localScale * sizeFactor * 2);
        
        Sprite output = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f), 256);

        return output;
    }
}