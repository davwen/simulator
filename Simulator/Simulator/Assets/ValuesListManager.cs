using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValuesListManager : Select
{
    [Space(20)]

    public ListCreator listCreator;

    public GameObject floatPrefab;
    public GameObject integerPrefab;
    public GameObject stringPrefab;
    public GameObject boolPrefab;
    public GameObject titlePrefab;

    private ValuesAdapter adapter;

    private Object currentlySelectedChecker;

    public void Update()
    {
        if (currentlySelectedChecker != currentlySelected && currentlySelected != null)
        {
            UpdateAdapter();

            currentlySelectedChecker = currentlySelected;
        }

        UpdateList();
    }

    public void UpdateList()
    {
        if (adapter != null)
        {
            listCreator.UpdateAll(adapter);
        }
    }

    public void UpdateAdapter()
    {
        if(currentlySelected != null)
        {
            adapter = new ValuesAdapter(currentlySelected.values, currentlySelected, floatPrefab, integerPrefab, boolPrefab, stringPrefab, titlePrefab);
        }
        
    }
}
