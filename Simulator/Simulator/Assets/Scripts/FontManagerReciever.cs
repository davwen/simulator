using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FontManagerReciever : MonoBehaviour
{
    public Text text;

    public string fontKey;

    [HideInInspector]
    public Font font;
    private Font fontChecker;

    void Update()
    {
        if(fontChecker != font)
        {
            text.font = font;

            fontChecker = font;
        }
    }
}
