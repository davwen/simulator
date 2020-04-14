using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public List<DeckItemData> objects = new List<DeckItemData>();

    [Space(10)]

    public string selected;

    [Space(10)]

    public Spawning spawningManager;
    public Select selectionManager;
    public DeckUI deckUIManager;


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
        DeckItemData dataToAdd = new DeckItemData();

        dataToAdd.data = ObjectToTextConverter.ConvertToText(obj);

        dataToAdd.image = GameObjectToSprite.ConvertToSprite(obj.gameObject, deckUIManager.item.transform.localScale);

        objects.Add(dataToAdd);
        deckUIManager.UpdateUI();
    }

    public void removeObject(int index)
    {
        objects.RemoveAt(index);
        deckUIManager.UpdateUI();
    }

    public ObjectData getObject(int index)
    {
        string objText = objects[index].data;

        return TextToObjectConverter.ConvertToObject(objText);
    }

    public void select(int index)
    {
        selected = objects[index].data;
        spawningManager.ObjectToSpawn = TextToObjectConverter.ConvertToObject(selected);
        
    }
}
