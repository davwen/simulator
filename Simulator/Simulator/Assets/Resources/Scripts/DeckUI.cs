using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckUI : MonoBehaviour
{
    public List<string> Objects = new List<string>();
    private List<string> ObjectsChecker = new List<string>();

    public GameObject item;

    public Vector2 offset;

    public int standardScreenWidth;

    public GameObject parent;

    public Deck deckManager;

    public CanvasGroup canvasGroup;

    public float offsetBetween;

    public Spawning spawnManager;


    private void Start()
    {
        SpawnUI(Objects);

    }

    public void SpawnUI(List<string> Objs, bool removeOld = true)
    {
        if (removeOld)
        {
            removeUIofObj();
        }

        List<string> effects = new List<string>();

        //Goes through every value in the list to then instantiate an item and then apply all the values to that item as well as instantiating title items.

        for (int i = 0; i < Objs.Count; i++)
        {
            GameObject lastItem = spawnItem(item, i);

            DeckItem itemComp = lastItem.GetComponent<DeckItem>();

            itemComp.deckUIManager = this;
            itemComp.index = i;
        }
    }


    public void removeUIofObj()
    {
        int childs = parent.transform.childCount;
        for (int i = 0; i < childs; i++)
        {
            Destroy(parent.transform.GetChild(i).gameObject); //Destroys every list item.
        }

     
    }

    private GameObject spawnItem(GameObject ui, int index) //Spawns item in list
    {
        RectTransform itemRectTrans = ui.GetComponent<RectTransform>();

        RectTransform parentRectTrans = parent.GetComponent<RectTransform>();

        GameObject lastItem = Instantiate(ui, new Vector2(parentRectTrans.position.x + offset.x +

            itemRectTrans.rect.width * index * (Screen.width / standardScreenWidth) + (20 * index), parentRectTrans.position.y - offset.y),

            new Quaternion(0, 0, 0, 0), //Sets rotation to zero.
            parent.transform);

        return lastItem;
    }

    public void onItemClick(int i) //One Of the items in the list was clicked.
    {
        deckManager.select(i);

        spawnManager.clickSpawnMethod = Spawning.SpawnOptions.Object;
    }

    public void onModeChange(string mode) //Called from the modeManager script
    {
        switch (mode)
        {
            case ModeManager.MODE_SPAWN:
                canvasGroup.alpha = 1;
                break;

            case ModeManager.MODE_EDIT:
                canvasGroup.alpha = 0;
                break;
        }
    }

    private void Update()
    {
        Objects = deckManager.objects;

        if(ObjectsChecker.Count != Objects.Count)
        {
            SpawnUI(Objects);
            print("changed");

            ObjectsChecker = Objects;
        }
    }

    private void Awake()
    {
        Objects = deckManager.objects;
    }

}
