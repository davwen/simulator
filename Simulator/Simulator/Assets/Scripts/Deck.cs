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
    public DeckUI deckUIManager;


    public InputMaster controls;

    public void Awake()
    {
        controls = new InputMaster();

        controls.Editor.copy.performed += _ => {
            foreach (Object obj in SelectionManager.Instance.currentlySelected)
            {
                AddObject(obj);
            }
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

    public void AddObject(Object obj)
    {
        DeckItemData dataToAdd = new DeckItemData();

        dataToAdd.data = ObjectToTextConverter.ConvertToText(obj);

        dataToAdd.image = GameObjectToSprite.ConvertToSprite(obj.gameObject, deckUIManager.item.transform.localScale);

        objects.Add(dataToAdd);
        deckUIManager.UpdateUI();
    }

    public void RemoveObject(int index)
    {
        objects.RemoveAt(index);
        deckUIManager.UpdateUI();
    }

    public ObjectData GetObject(int index)
    {
        string objText = objects[index].data;

        return TextToObjectConverter.ConvertToObject(objText);
    }

    public void Select(int index)
    {
        selected = objects[index].data;
        spawningManager.objectToSpawn = TextToObjectConverter.ConvertToObject(selected);
        
    }
}
