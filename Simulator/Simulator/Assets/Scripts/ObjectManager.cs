using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor;

//This scripts manages and keeps track of every object in the scene.

public class ObjectManager : MonoBehaviour
{
    public static ObjectManager Instance { get; private set; }

    public List<Object> objects = new List<Object>();

    public bool isRunning;

    public InputMaster controls;

    public void Awake()
    {
        controls = new InputMaster();

        controls.Editor.begin.performed += ctx => beginAllObjects();
        controls.Editor.stop.performed += ctx => stopAllObjects();
        controls.Editor.pause.performed += ctx => pauseAllObjects();
        controls.Editor.resume.performed += ctx => resumeAllObjects();

        controls.Editor.togglePause.performed += ctx => togglePause();

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else { Destroy(gameObject); }
    }

    private void Start()
    {
        SelectionManager.Instance.onSelect += delegate
        {
            for (int i = 0; i < objects.Count; i++)
            {
                float alpha = 1f;

                if (!SelectionManager.Instance.currentlySelected.Contains(objects[i]))
                {
                    alpha = 0.5f;
                }

                SpriteRenderer sr = objects[i].GetComponent<SpriteRenderer>();

                Color currentColour = sr.color;
                currentColour.a = alpha;
                sr.color = currentColour;
            }
        };

        SelectionManager.Instance.onDeselected += delegate
        {
            try
            {
                for (int i = 0; i < objects.Count; i++)
                {
                    float alpha = 1f;

                    SpriteRenderer sr = objects[i].GetComponent<SpriteRenderer>();

                    Color currentColour = sr.color;
                    currentColour.a = alpha;
                    sr.color = currentColour;
                }
            }catch(MissingReferenceException) { }
           

        };
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void Update()
    {
        UpdateObjectList();
    }

    public void UpdateObjectList()
    {

        objects.Clear();
        objects.AddRange(FindObjectsOfType<Object>());

    }

    public void beginAllObjects()
    {
        //Loops thorough all objects and calls beginAll() on each one. Basically calls the Begin() function on all effects on all objects.
        for(int i = 0; i < objects.Count; i++)
        {
            objects[i].BeginAll();
        }

        isRunning = true;
    }

    public void stopAllObjects()
    {
        //Loops thorough all objects and calls stopAll() on each one.
        for (int i = 0; i < objects.Count; i++)
        {
            objects[i].StopAll();
        }

        isRunning = false;
    }

    public void pauseAllObjects()
    {
        //Loops thorough all objects and calls pauseAll() on each one.
        for (int i = 0; i < objects.Count; i++)
        {
            objects[i].PauseAll();
        }

        isRunning = false;
    }

    public void resumeAllObjects()
    {
        //Loops thorough all objects and calls resumeAll() on each one.
        for (int i = 0; i < objects.Count; i++)
        {
            objects[i].ResumeAll();
        }

        isRunning = true;
    }

    public void togglePause()
    {
        switch (isRunning)
        {
            case true:
                stopAllObjects();
                break;

            case false:
                beginAllObjects();
                break;
        }
    }
}