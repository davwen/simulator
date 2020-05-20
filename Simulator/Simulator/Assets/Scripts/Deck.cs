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
    public ListCreator ListCreator;


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

        dataToAdd.image = GameObjectToSprite.ConvertToSprite(obj.gameObject, ListCreator.itemPrefab.transform.localScale);

        objects.Add(dataToAdd);
        ListCreator.UpdateAll(new DeckAdapter(objects, this));
    }

    public void RemoveObject(int index)
    {
        objects.RemoveAt(index);
        //deckUIManager.UpdateUI();
    }

    public ObjectData GetObject(int index)
    {
        string objText = objects[index].data;

        return TextToObjectConverter.ConvertToObject(objText);
    }

    public void Select(int index)
    {
        selected = objects[index].data;
        spawningManager.clickSpawnMethod = Spawning.SpawnOptions.Object;
        spawningManager.objectToSpawn = GetObject(index);
        print(GetObject(index).values.Count);

        foreach(Value val in GetObject(index).values){
            print(val.key + ": " + val.value);
        }
    }
}


[System.Serializable]
public class DeckItemData
{
    public string name;
    public string data;
    public Sprite image;
}
