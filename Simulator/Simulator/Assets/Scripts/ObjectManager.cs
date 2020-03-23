using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

//This scripts manages and keeps track of every object in the scene.

public class ObjectManager : MonoBehaviour
{
    public List<Object> objects = new List<Object>();

    public bool isRunning;

    public InputMaster controls;

    private void Awake()
    {
        controls = new InputMaster();

        controls.Editor.begin.performed += ctx => beginAllObjects();
        controls.Editor.stop.performed += ctx => stopAllObjects();
        controls.Editor.pause.performed += ctx => pauseAllObjects();
        controls.Editor.resume.performed += ctx => resumeAllObjects();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }


    void Update()
    {

        objects.Clear();
        objects.AddRange(FindObjectsOfType<Object>());

    }

    public void beginAllObjects()
    {
        //Loops thorough all objects and calls beginAll() on each one. Basically calls the Begin() function on all effects on all objects.
        for(int i = 0; i < objects.Count; i++)
        {
            objects[i].beginAll();
        }

        isRunning = true;
    }

    public void stopAllObjects()
    {
        //Loops thorough all objects and calls stopAll() on each one.
        for (int i = 0; i < objects.Count; i++)
        {
            objects[i].stopAll();
        }

        isRunning = false;
    }

    public void pauseAllObjects()
    {
        //Loops thorough all objects and calls pauseAll() on each one.
        for (int i = 0; i < objects.Count; i++)
        {
            objects[i].pauseAll();
        }

        isRunning = false;
    }

    public void resumeAllObjects()
    {
        //Loops thorough all objects and calls resumeAll() on each one.
        for (int i = 0; i < objects.Count; i++)
        {
            objects[i].resumeAll();
        }

        isRunning = true;
    }
}