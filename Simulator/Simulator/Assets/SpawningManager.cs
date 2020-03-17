using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningManager : MonoBehaviour
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

        if (Input.GetMouseButtonDown(0) && FindObjectOfType<ModeManager>().currentMode == ModeManager.MODE_SPAWN)
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
