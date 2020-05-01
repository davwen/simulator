using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ListOrientation { LeftToRight, RightToLeft, UpToDown, DownToUp }
public enum HorizontalStartPoint { Middle, Left, Right }
public enum VerticalStartPoint { Center, Top, Bottom }

public class ListCreator : MonoBehaviour
{
    public GameObject itemPrefab;

    [Space(10)]

    public ListOrientation orientation;

    [Space(10)]

    public HorizontalStartPoint horizontalStartPoint;
    public VerticalStartPoint verticalStartPoint;

    [Space(10)]

    public GameObject parent;

    public CanvasGroup canvasGroup;

    public Vector2 offset;

    [Space(10)]

    public float offsetBetweenItems = 100;

    public Vector2 defaultScreenDimensions;

    private List<GameObject> currentItems = new List<GameObject>();

    [Space(10)]

    public AnimationCurve curve;

    /// <summary>Spawns items onto a parent in order to create a list.</summary>
    public void Create(ListAdapter adapter, bool informAdapter = true)
    {
        int length = adapter.GetCount();

        for(int i = 0; i < length; i++)
        {
            Vector2 position = new Vector2(0, 0);

            Vector2 screenSizeFactor = new Vector2(Screen.width, Screen.height) / defaultScreenDimensions;

            switch (orientation)
            {
                case ListOrientation.LeftToRight:
                    position = parent.transform.position + new Vector3((offset.x * screenSizeFactor.x) //Offset
                        + offsetBetweenItems * i * screenSizeFactor.x, //OffsetBetweenItems
                        offset.y * screenSizeFactor.y, 0);
                    break;
                case ListOrientation.RightToLeft:
                    position = parent.transform.position - new Vector3((offset.x * screenSizeFactor.x) //Offset
                        + offsetBetweenItems * i * screenSizeFactor.x, //OffsetBetweenItems
                        offset.y * screenSizeFactor.y, 0);
                    break;
                case ListOrientation.UpToDown:
                    position = parent.transform.position - new Vector3(-offset.x * screenSizeFactor.x, 
                        (offset.y * screenSizeFactor.y) //Offset
                        + offsetBetweenItems * i * screenSizeFactor.y, //OffsetBetweenItems
                        0);
                    break;
                case ListOrientation.DownToUp:
                    position = parent.transform.position + new Vector3(-offset.x * -screenSizeFactor.x,
                        (offset.y * screenSizeFactor.y) //Offset
                        + offsetBetweenItems * i * screenSizeFactor.y, //OffsetBetweenItems
                        0);
                    break;
            }

            Vector2 parentScale = Camera.main.WorldToScreenPoint(parent.transform.localScale);

            switch (verticalStartPoint)
            {
                case VerticalStartPoint.Bottom:
                    position -= new Vector2(0, parentScale.y / 2);
                    break;
                case VerticalStartPoint.Top:
                    position = position + new Vector2(0, parentScale.y / 2);
                    break;
            }

            switch (horizontalStartPoint)
            {
                case HorizontalStartPoint.Left:
                    position -= new Vector2(parentScale.x / 2, 0);
                    break;
                case HorizontalStartPoint.Right:
                    position += new Vector2(parentScale.x / 2, 0);
                    break;
            }

            GameObject itemToSpawn = itemPrefab;

            if(adapter.GetItemPrefab(i) != null)
            {
                itemToSpawn = adapter.GetItemPrefab(i);
            }

            GameObject lastItem = Instantiate(itemToSpawn, position, new Quaternion(0, 0, 0, 0), parent.transform);

            ListItem itemData = lastItem.GetComponent<ListItem>();
            itemData.index = i;

            currentItems.Add(lastItem);

            if (informAdapter)
            {
                adapter.OnItemInsert(new ListItemData(i, itemData.components));
            }

            lastItem.transform.localScale = new Vector3(0, 0, 0);
            LeanTween.scale(lastItem.GetComponent<RectTransform>(), new Vector3(1, 1, 1), 0.5f).setDelay((i + 1) * 0.1f).setEase(curve);
        }
    }

    /// <summary>Removes one item at a specified index.</summary>
    public void RemoveOne(ListAdapter adapter, int index, bool informAdapter = true)
    {
        Destroy(currentItems[index]);

        currentItems.RemoveAt(index);

        if (informAdapter)
        {
            adapter.OnItemRemove(index);
        } 
    }

    /// <summary>Removes all of the existing items.</summary>
    public void RemoveAll(ListAdapter adapter, bool informAdapter = true)
    {
        for (int i = 0; i < currentItems.Count; i++)
        {
            Destroy(currentItems[i]);

            if (informAdapter)
            {
                adapter.OnItemRemove(i);
            }
        }

        currentItems.Clear();
    }

    /// <summary>Updates the lists items - i.e., updating data if count haven't changed, else, just respawn list.</summary>
    public void UpdateAll(ListAdapter adapter, bool informAdapter = true)
    {
        if(adapter.GetCount() == currentItems.Count)
        {
            for (int i = 0; i < currentItems.Count; i++)
            {
                GameObject item = currentItems[i];

                ListItem itemData = item.GetComponent<ListItem>();
                itemData.index = i;

                if (informAdapter)
                {
                    adapter.OnItemUpdate(new ListItemData(i, itemData.components));
                }
            }
        }
        else
        {
            RemoveAll(adapter);
            Create(adapter);
        }
    }

    /// <summary>Calls RemoveAll(), the Create() immediately after.</summary>
    public void RecreateAll(ListAdapter adapter, bool informAdapter = true)
    {
         RemoveAll(adapter, informAdapter);
         Create(adapter, informAdapter);
    }
}

public class ListItemData
{
    public int index;
    public List<ListItemComponent> components;

    public ListItemData(int _index, List<ListItemComponent> _components)
    {
        index = _index;
        components = _components;
    }

    public T GetComponent<T>(string key)
    {

        for(int i = 0; i < components.Count; i++)
        {
            if(components[i].key.Equals(key))
            {
                return components[i].Object.GetComponent<T>();
            }
        }

        return default(T);
    }
}