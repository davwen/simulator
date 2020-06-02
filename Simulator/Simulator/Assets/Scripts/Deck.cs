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
    public ListCreator listCreator;

    public InputMaster controls;

    private DeckAdapter adapter;

    private Coroutine coroutine;

    public void Awake()
    {
        adapter = new DeckAdapter(objects, this);

        controls = new InputMaster();

        controls.Editor.copy.performed += _ => {
            foreach (Object obj in SelectionManager.Instance.currentlySelected)
            {
                AddObject(obj);
            }
        };

        ModeManager.Instance.onModeChange += delegate
        {
            switch (ModeManager.Instance.currentMode)
            {
                case ModeManager.MODE_SPAWN:
                    TweeningManager.Instance.Animate(listCreator.canvasGroup.gameObject, AnimationType.ScaleIn, "bouncy", 0.3f, 0f);
                    TweeningManager.Instance.Animate(listCreator.canvasGroup.gameObject, AnimationType.FadeInWithCanvasGroup, "linear", 0.1f, 0.2f);
                    break;

                case ModeManager.MODE_EDIT:
                    TweeningManager.Instance.Animate(listCreator.canvasGroup.gameObject, AnimationType.ScaleOut, "linear", 0.3f, 0f);
                    TweeningManager.Instance.Animate(listCreator.canvasGroup.gameObject, AnimationType.FadeOutWithCanvasGroup, "linear", 0.1f, 0f);
                    break;
            }
        };

        listCreator.UpdateAll(adapter);
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
        if(coroutine != null){
            StopCoroutine(coroutine);
        }
        
        coroutine = StartCoroutine(AddObjectIenu(obj));
    }

    private IEnumerator AddObjectIenu(Object obj){
        DeckItemData dataToAdd = new DeckItemData();

        dataToAdd.data = ObjectToTextConverter.ConvertToText(obj);

        dataToAdd.image = GameObjectToSprite.ConvertToSprite(obj.gameObject, listCreator.itemPrefab.transform.localScale);

        objects.Add(dataToAdd);
        
        adapter.items = objects;

        if(ModeManager.Instance.currentMode == ModeManager.MODE_EDIT){
            TweeningManager.Instance.Animate(listCreator.canvasGroup.gameObject, AnimationType.ScaleIn, "bouncy", 0.3f, 0f);
            TweeningManager.Instance.Animate(listCreator.canvasGroup.gameObject, AnimationType.FadeInWithCanvasGroup, "linear", 0.1f, 0.2f);
            yield return new WaitForSeconds(0.5f);
        }
        
        listCreator.UpdateAll(adapter);

        if(ModeManager.Instance.currentMode == ModeManager.MODE_EDIT){
            yield return new WaitForSeconds(1.4f);
            TweeningManager.Instance.Animate(listCreator.canvasGroup.gameObject, AnimationType.ScaleOut, "linear", 0.3f, 0f);
            TweeningManager.Instance.Animate(listCreator.canvasGroup.gameObject, AnimationType.FadeOutWithCanvasGroup, "linear", 0.1f, 0f); 
        }

        yield return new WaitForSeconds(0.3f);

        if(ModeManager.Instance.currentMode == ModeManager.MODE_SPAWN){
            TweeningManager.Instance.Animate(listCreator.canvasGroup.gameObject, AnimationType.ScaleIn, "bouncy", 0.3f, 0f);
            TweeningManager.Instance.Animate(listCreator.canvasGroup.gameObject, AnimationType.FadeInWithCanvasGroup, "linear", 0.1f, 0.2f);
        }
    }

    public void RemoveObject(int index)
    {
        objects.RemoveAt(index);
        
        adapter.items = objects;
        listCreator.UpdateAll(adapter);
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
    }
}


[System.Serializable]
public class DeckItemData
{
    public string name;
    public string data;
    public Sprite image;
}
