using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public List<string> objects = new List<string>();

    [Space(10)]

    public string selected;

    [Space(10)]

    public Spawning spawningManager;
    public Select selectionManager;


    public InputMaster controls;

    private void Awake()
    {
        controls = new InputMaster();

        controls.Editor.copy.performed += _ => addObject(selectionManager.currentlySelected);
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    public void addObject(Object obj)
    {
        objects.Add(ObjectToTextConverter.Convert(obj));
    }

    public void removeObject(int index)
    {
        objects.RemoveAt(index);
    }

    public ObjectData getObject(int index)
    {
        string objText = objects[index];

        return TextToObjectConverter.Convert(objText);
    }

    public void select(int index)
    {
        selected = objects[index];
        spawningManager.ObjectToSpawn = TextToObjectConverter.Convert(selected);
        
    }
}
