using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FontManager : MonoBehaviour
{
    public List<ProjectFont> fonts = new List<ProjectFont>();

    private List<ProjectFont> fontsChecker = new List<ProjectFont>();

    void Awake()
    {
        AssignFonts();
    }

    void AssignFonts()
    {
        FontManagerReciever[] texts = FindObjectsOfType<FontManagerReciever>();

        for (int i = 0; i < texts.Length; i++)
        {
            Font fontToAssign = new Font();

            foreach (ProjectFont font in fonts)
            {
                if (font.key == texts[i].fontKey)
                {
                    fontToAssign = font.font;
                }
            }

            texts[i].font = fontToAssign;
        }
    }

    void Update()
    {

        AssignFonts();

        fontsChecker = fonts;

    }
}

[System.Serializable]
public class ProjectFont
{
    public string key;
    public Font font;
}
