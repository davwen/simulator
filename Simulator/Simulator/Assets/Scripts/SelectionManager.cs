using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class SelectionManager : MonoBehaviour
{
    public static SelectionManager Instance { get; private set; }

    public List<Object> currentlySelected = new List<Object>();

    [Space(10)]

    [Header("Selection box")]

    public Canvas canvas;

    public Color baseColour;

    public Sprite backgroundImage;

    public InputMaster controls;

    public UnityAction onSelect;
    public UnityAction onDeselected;
    public UnityAction beforeDeselected;
    public UnityAction onDeselectedAll;
    public UnityAction onMultiSelectDone;

    private bool multiButtonDown;
    private bool multiButtonDownChecker;

    private GameObject selectionBox;

    private Vector2 startPos;

    private void Awake()
    {
        controls = new InputMaster();

        controls.Editor.select.performed += _ =>
        {
            if (ModeManager.Instance.currentMode == ModeManager.MODE_EDIT)
            {
                SelectWithMouse();
            }
            
        };

        controls.Editor.multiSelect.performed += _ => multiButtonDown = true;
        controls.Editor.multiSelect.canceled += _ => multiButtonDown = false;

        controls.Editor.deselect.performed += _ => DeselectAll();

        onMultiSelectDone += delegate
        {
            DeselectAll();

            for (int i = 0; i < ObjectManager.Instance.objects.Count; i++)
            {
                if (IsPointInRT(ObjectManager.Instance.objects[i].transform.position, selectionBox.GetComponent<RectTransform>()))
                {
                    SelectOne(ObjectManager.Instance.objects[i]);
                }
            }
        };

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else { Destroy(gameObject);  }

    }

    private void Update()
    {
        if (!DragDrop.Instance.isDragging && ModeManager.Instance.currentMode == ModeManager.MODE_EDIT && !EventSystem.current.IsPointerOverGameObject())
        {
            if (multiButtonDownChecker != multiButtonDown)
            {
                if (multiButtonDown)
                {
                    startPos = Input.mousePosition - new Vector3(Screen.width / 2, Screen.height / 2, 0);
                }
                else
                {
                    onMultiSelectDone();
                }
                multiButtonDownChecker = multiButtonDown;
            }


            if (multiButtonDown)
            {
                if (selectionBox == null)
                {
                    CreateUIRectangle(startPos, Input.mousePosition - new Vector3(Screen.width / 2, Screen.height / 2, 0));
                }

                if (selectionBox != null)
                {
                    CreateUIRectangle(startPos, Input.mousePosition - new Vector3(Screen.width / 2, Screen.height / 2, 0), selectionBox);

                    selectionBox.SetActive(true);
                }
            }
        }
       
        if(!multiButtonDown)
        {
            if(selectionBox != null)
            {
                selectionBox.SetActive(false);
            }
        }
    }

    public void SelectWithMouse()
    {
        TrySelect(GetMouseWorldSpacePosition());
    }

    public void SelectOne(Object obj)
    {
        if (!currentlySelected.Contains(obj) && obj != null)
        {
            currentlySelected.Add(obj);
        }

        if (onSelect != null)
        {
            onSelect();
        }
    }



    public void DeselectOne(Object objectToRemove, bool report = true)
    {
        if(beforeDeselected != null && report)
        {
            beforeDeselected();
        }

        currentlySelected.Remove(objectToRemove);

        if (onDeselected != null && report)
        {
            onDeselected();
        }
    }

    public void DeselectAll()
    {
        for (int i = 0; i < currentlySelected.Count; i++)
        {
            try
            {
                DeselectOne(currentlySelected[i]);
            }
            catch (ArgumentOutOfRangeException) { }
        }

        currentlySelected.Clear();

        onDeselectedAll();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private Vector2 GetMouseWorldSpacePosition()
    {
        Vector2 screenSpacePosition = controls.Editor.mousePos.ReadValue<Vector2>();

        Vector2 worldSpacePosition = Camera.main.ScreenToWorldPoint(screenSpacePosition);

        return worldSpacePosition;
    }

    public void TrySelect(Vector2 mousePosition)
    {
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, -Vector2.up);

        // If it hits something...
        if (hit.collider != null && !EventSystem.current.IsPointerOverGameObject())
        {
            Object obj = hit.transform.gameObject.GetComponent<Object>();

            if (!currentlySelected.Contains(obj))
            {
                DeselectAll();
            }

            SelectOne(obj);
            
        }
    }

    public void CreateUIRectangle(Vector2 startPosition, Vector2 endPosition, GameObject oldBox = null)
    {
        GameObject panel;

        canvas.renderMode = RenderMode.ScreenSpaceOverlay;

        if (oldBox == null)
        {
            panel = new GameObject("Panel");
            panel.AddComponent<CanvasRenderer>();
            panel.AddComponent<Image>().sprite = backgroundImage;
            panel.transform.SetParent(canvas.transform, false);
        }
        else
        {
            panel = oldBox;
        }

        Image image = panel.GetComponent<Image>();
        image.color = new Color(0, 0, 0, 0);
        RectTransform rect = panel.GetComponent<RectTransform>();

        rect.pivot = Vector2.zero;

        Vector2 position = new Vector2();

        if(endPosition.x > startPosition.x && endPosition.y > startPosition.y)
        {
            rect.sizeDelta = endPosition - startPosition;
            rect.pivot = Vector2.zero;
        }

        if (endPosition.x < startPosition.x && endPosition.y > startPosition.y)
        {
            rect.sizeDelta = new Vector2(endPosition.x * -1, endPosition.y) - new Vector2(startPosition.x * -1, startPosition.y);
            rect.pivot = Vector2.right;
        }

        if (endPosition.x < startPosition.x && endPosition.y < startPosition.y)
        {
            rect.sizeDelta = new Vector2(endPosition.x * -1, endPosition.y * -1) - new Vector2(startPosition.x * -1, startPosition.y * -1);
            rect.pivot = new Vector2(1, 1);
        }

        if (endPosition.x > startPosition.x && endPosition.y < startPosition.y)
        {
            rect.sizeDelta = new Vector2(endPosition.x, endPosition.y * -1) - new Vector2(startPosition.x, startPosition.y * -1);
            rect.pivot = new Vector2(0, 1);
        }

        if (endPosition == startPosition)
        {
            rect.sizeDelta = new Vector2(0, 0);
            rect.pivot = new Vector2(0.5f, 0.5f);
        }

        position = new Vector2(startPosition.x, startPosition.y);

        rect.anchoredPosition = position;

        image.color = baseColour;

        selectionBox = panel; 
    }

    private bool IsPointInRT(Vector2 point, RectTransform rt)
    {
        Vector3[] screenSpaceCorners = new Vector3[4];
        rt.GetWorldCorners(screenSpaceCorners);

        List<Vector3> worldSpaceCorners = new List<Vector3>();

        foreach(Vector3 corner in screenSpaceCorners)
        {
            worldSpaceCorners.Add(Camera.main.ScreenToWorldPoint(corner));
        }

        float leftSide = worldSpaceCorners[0].x;
        float rightSide = worldSpaceCorners[2].x;
        float topSide = worldSpaceCorners[1].y;
        float bottomSide = worldSpaceCorners[3].y;

        if (point.x >= leftSide &&
            point.x <= rightSide &&
            point.y >= bottomSide &&
            point.y <= topSide)
        {
            return true;
        }
        return false;
    }
}
