using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This script spawns all UI for the sprites chooser (object chooser)

public class SpritesListUI : MonoBehaviour
{
  
    public List<SpawnableObj> Objects;

    public GameObject item;

    public Vector2 offset;

    public int standardScreenWidth;

    public GameObject parent;

    public Spawning spawningManager;

    public CanvasGroup canvasGroup;

    private void Start()
    {
        SpawnUI(Objects, false);
        
    }

    public void SpawnUI(List<SpawnableObj> Objs, bool removeOld = true)
    {
       

        //Removes all children before inserting any new.
        if (removeOld)
        {
            //removeUIofObj();
        }


        List<string> effects = new List<string>();

        //Goes through every value in the list to then instantiate an item and then apply all the values to that item as well as instantiating title items.

        for (int i = 0; i < Objs.Count; i++)
        {
            GameObject lastItem = spawnItem(item, i);

            Image img = lastItem.GetComponentsInChildren<Image>()[1]; //It takes the second in the array because else the bg of the item would change.

            if(img != null)
            {
                img.sprite = Objs[i].sprite;
            }

            Text label = lastItem.GetComponentInChildren<Text>();

            if (label != null)
            {
                label.text = Objs[i].label;
            }

            SpriteListItem itemScript = lastItem.GetComponent<SpriteListItem>();

            if (itemScript != null)
            {
                itemScript.listManager = this;
                itemScript.index = i;
            }

        }
    }

    private GameObject spawnItem(GameObject ui, int index) //Spawns item in list
    {
        RectTransform itemRectTrans = ui.GetComponent<RectTransform>();

        RectTransform parentRectTrans = parent.GetComponent<RectTransform>();

        GameObject lastItem = Instantiate(ui, new Vector2(parentRectTrans.position.x + offset.x +
             
            itemRectTrans.rect.width * index * (Screen.width / standardScreenWidth), parentRectTrans.position.y - offset.y),

            new Quaternion(0, 0, 0, 0), //Sets rotation to zero.
            parent.transform);

        return lastItem;
    }

    public void onItemClick(int i)
    {
        spawningManager.selectNewSObj(Objects[i]);
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
    
}

[System.Serializable]
public class SpawnableObj
{
    public string label;
    public Sprite sprite;
    public Vector2[] colliderPoints;
}

