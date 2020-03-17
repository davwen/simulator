using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

//This scripts manages and keeps track of every object in the scene.

public class ObjectManager : MonoBehaviour
{
    public List<Object> objects = new List<Object>();

    public bool isRunning;

    void Start()
    {
        //Adds all of the currently existing objects.
        
    }

    
    void Update()
    {
        //Debug
        if (Input.GetKeyUp("b"))
        {
            beginAllObjects();
        }
        if (Input.GetKeyUp("s"))
        {
            stopAllObjects();
        }
        if (Input.GetKeyUp("p"))
        {
            pauseAllObjects();
        }
        if (Input.GetKeyUp("r"))
        {
            resumeAllObjects();
        }

        objects.Clear();
        objects.AddRange(FindObjectsOfType<Object>());

    }

    public void beginAllObjects()
    {
        //Loops thorough all objects and calls beginAll() on each one. Basically calls the Begin() function on all effects on all objects.
        for(int i = 0; i < objects.Count; i++)
        {
            objects[i].beginAll(0f);
        }

        isRunning = true;
    }

    public void stopAllObjects()
    {
        //Loops thorough all objects and calls stopAll() on each one.
        for (int i = 0; i < objects.Count; i++)
        {
            objects[i].stopAll(0f);
        }

        isRunning = false;
    }

    public void pauseAllObjects()
    {
        //Loops thorough all objects and calls pauseAll() on each one.
        for (int i = 0; i < objects.Count; i++)
        {
            objects[i].pauseAll(0f);
        }

        isRunning = false;
    }

    public void resumeAllObjects()
    {
        //Loops thorough all objects and calls resumeAll() on each one.
        for (int i = 0; i < objects.Count; i++)
        {
            objects[i].resumeAll(0f);
        }

        isRunning = true;
    }
}