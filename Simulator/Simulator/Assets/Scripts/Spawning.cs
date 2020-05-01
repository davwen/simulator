using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


//This script handles the users ability to insert objects to the scene.

public class Spawning : MonoBehaviour
{
    public GameObject objectBase;

    [Header("Objects")]

    public SpawnableObj sObjToSpawn;

    public GameObject gameObjectToSpawn;

    public ObjectData objectToSpawn;

    [Space(10)]

    public float zLevel;

    public Vector2 mousePos;

    [Space(10)]

    public DragDrop dragDropManager;

    public InputMaster controls;

    [HideInInspector]
    public SpawnOptions clickSpawnMethod = SpawnOptions.SpawnableObject;


    private void Awake()
    {
        controls = new InputMaster();

        controls.Editor.spawn.performed += ctx => Spawn(clickSpawnMethod);
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }


    public void Spawn(SpawnOptions method, bool isPasting = false)
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
       
        if(ModeManager.Instance.currentMode == ModeManager.MODE_SPAWN || isPasting)
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                StartCoroutine(SpawnIenu(method));
            }
        }
    }

    public void SelectNewSObj(SpawnableObj obj)
    {
        sObjToSpawn = obj;
    }

    private IEnumerator SpawnIenu(SpawnOptions method)
    {
        GameObject lastObj = null;

        switch (method)
        {
            case SpawnOptions.SpawnableObject:
                lastObj = Instantiate(objectBase, new Vector3(mousePos.x, mousePos.y, zLevel), new Quaternion(0, 0, 0, 0));
                SpriteRenderer sr = lastObj.GetComponent<SpriteRenderer>();

                if (sr != null && sObjToSpawn.sprite != null)
                {
                    sr.sprite = sObjToSpawn.sprite;
                }

                lastObj.AddComponent<PolygonCollider2D>().isTrigger = true; //Adds a collider.

                SelectionManager.Instance.DeselectAll();
                break;

            case SpawnOptions.GameObject:
                lastObj = Instantiate(gameObjectToSpawn);

                yield return new WaitForEndOfFrame();

                lastObj.transform.position = new Vector3(mousePos.x, mousePos.y, zLevel);

                SelectionManager.Instance.DeselectAll();

                break;

            case SpawnOptions.Object:

                lastObj = Instantiate(objectBase, new Vector3(mousePos.x, mousePos.y, zLevel), new Quaternion(0, 0, 0, 0));

                Object objComp = lastObj.GetComponent<Object>();

                objectToSpawn.setValue(Orientation.xPosValueKey, mousePos.x.ToString());
                objectToSpawn.setValue(Orientation.yPosValueKey, mousePos.y.ToString());

                objComp.values = objectToSpawn.values;
                objComp.startEffects = objectToSpawn.startEffects;
                objComp.currentEffects = objectToSpawn.currentEffects;

                yield return new WaitForEndOfFrame();

                lastObj.GetComponent<SpriteRenderer>().sprite = objectToSpawn.sprite;

                lastObj.AddComponent<PolygonCollider2D>();

                break;
        }
        

    }

    public enum SpawnOptions
    {
        SpawnableObject,
        GameObject,
        Object
    }
}


