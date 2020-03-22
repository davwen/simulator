using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Spawning : MonoBehaviour
{
    public GameObject objectBase;

    public SpawnableObj sObjToSpawn;

    public float zLevel;

    public Vector2 mousePos;

    public DragDrop dragDropManager;

    void Start()
    {
        
    }

    
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //Sends a raycast to see if any UI is in the way for placing.

        RaycastHit2D hit = Physics2D.Raycast(mousePos, -Vector2.up);

        bool hitUI = false;

        if(hit.collider != null)
        {
            print(hit.collider.gameObject.name);
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("UI"))
            {
                hitUI = true;
            }
        }

        print(EventSystem.current.IsPointerOverGameObject());

        if (Input.GetMouseButtonDown(0) && FindObjectOfType<ModeManager>().currentMode == ModeManager.MODE_SPAWN && !EventSystem.current.IsPointerOverGameObject())
        {
            Spawn();
        }


    }

    public void selectNewSObj(SpawnableObj obj)
    {
        sObjToSpawn = obj;
    }

    public void Spawn()
    {
        
        GameObject lastObj = Instantiate(objectBase, new Vector3(mousePos.x, mousePos.y, zLevel), new Quaternion(0, 0, 0, 0));
        SpriteRenderer sr = lastObj.GetComponent<SpriteRenderer>();

        if(sr != null && sObjToSpawn.sprite != null)
        {
            sr.sprite = sObjToSpawn.sprite;
        }

        FindObjectOfType<Select>().onDeselect();


    }
}
