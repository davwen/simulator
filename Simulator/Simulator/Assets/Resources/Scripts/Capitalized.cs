using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capitalization
{
    public string Capitalize(string input)
    {
        return input.Substring(0, 1).ToUpper() + input.Substring(1).ToLower();
    }
}
