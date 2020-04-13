using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyPaste : MonoBehaviour
{
    public GameObject copiedObj;

    public Select selectionManager;

    public Spawning spawningManager;

    public InputMaster controls;

    void Awake()
    {
        controls = new InputMaster();

        controls.Editor.copy.performed += _ => copy();
        controls.Editor.paste.performed += _ => paste();
    }

    private void copy()
    {
        copiedObj = selectionManager.currentlySelected.gameObject;
    }

    private void paste()
    {
        spawningManager.gameObjectToSpawn = copiedObj;
        spawningManager.trySpawn(Spawning.SpawnOptions.GameObject, true);
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }
}
