using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outline : MonoBehaviour
{
    public Color color;

    public float thickness;

    public Material material;

    private GameObject outline;

    void Start(){
        GenerateOutline();
        HideOutline();
    }

    public void GenerateOutline(){
        GameObject obj = new GameObject();

        outline = Instantiate(obj, transform);

        Destroy(obj);

        SpriteRenderer sr = outline.AddComponent<SpriteRenderer>();

        sr.sprite = GetComponent<SpriteRenderer>().sprite;

        sr.color = color;

        sr.material = material;

        outline.transform.localScale *= thickness + 1;

        outline.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
    }
    
    public void HideOutline(){
        outline.GetComponent<SpriteRenderer>().color = new Color();
    }

    public void ShowOutline(){
        outline.GetComponent<SpriteRenderer>().color = color;
    }
}
