using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckUI : MonoBehaviour
{
    public List<DeckItemData> Objects = new List<DeckItemData>();
    private List<DeckItemData> ObjectsChecker = new List<DeckItemData>();

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

        ModeManager.Instance.onModeChange += delegate
        {
            switch (ModeManager.Instance.currentMode)
            {
                case ModeManager.MODE_SPAWN:
                    TweeningManager.Instance.Animate(canvasGroup.gameObject, AnimationType.ScaleIn, "bouncy", 0.3f, 0f);
                    TweeningManager.Instance.Animate(canvasGroup.gameObject, AnimationType.FadeInWithCanvasGroup, "linear", 0.1f, 0.2f);
                    break;

                case ModeManager.MODE_EDIT:
                    TweeningManager.Instance.Animate(canvasGroup.gameObject, AnimationType.ScaleOut, "linear", 0.3f, 0f);
                    TweeningManager.Instance.Animate(canvasGroup.gameObject, AnimationType.FadeOutWithCanvasGroup, "linear", 0.1f, 0f);
                    break;
            }
        };
    }

    public void SpawnUI(List<DeckItemData> Objs, bool removeOld = true)
    {
        if (removeOld)
        {
            RemoveUIofObj();
        }

        //Goes through every value in the list to then instantiate an item and then apply all the values to that item as well as instantiating title items.

        for (int i = 0; i < Objs.Count; i++)
        {
            GameObject lastItem = spawnItem(item, i);

            DeckItem itemComp = lastItem.GetComponent<DeckItem>();

            itemComp.deckUIManager = this;
            itemComp.index = i;


            Image imageComp = itemComp.image;

            if(imageComp != null)
            {
                imageComp.sprite = Objs[i].image;
            }
        }
    }


    public void RemoveUIofObj()
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

            itemRectTrans.rect.width * index * (Screen.width / standardScreenWidth) + (offsetBetween * index), parentRectTrans.position.y - offset.y),

            new Quaternion(0, 0, 0, 0), //Sets rotation to zero.
            parent.transform);

        return lastItem;
    }

    public void onItemClick(int i) //One Of the items in the list was clicked.
    {
        deckManager.Select(i);

        spawnManager.clickSpawnMethod = Spawning.SpawnOptions.Object;
    }

    public void onItemRemoveClick(int i) //One Of the items in the list was clicked.
    {
        deckManager.RemoveObject(i);
    }

    public void UpdateUI()
    {
        Objects = deckManager.objects;

        if(ObjectsChecker != Objects)
        {
            SpawnUI(Objects);
            print("changed");
        }
    }

    private void Awake()
    {
        Objects = deckManager.objects;
    }

}
