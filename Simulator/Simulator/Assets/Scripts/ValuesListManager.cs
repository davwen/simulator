﻿using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using MoreLinq;

public class ValuesListManager : MonoBehaviour
{
    public ListCreator listCreator;

    public GameObject floatPrefab;
    public GameObject integerPrefab;
    public GameObject stringPrefab;
    public GameObject boolPrefab;
    public GameObject titlePrefab;

    [HideInInspector]
    public ValuesAdapter adapter;

    private List<Value> adapterValuesChecker;

    private void Start()
    {
        SelectionManager.Instance.onSelect += ShowList;
        SelectionManager.Instance.onSelect += UpdateAdapter;
        SelectionManager.Instance.onDeselectedAll += HideList;
        SelectionManager.Instance.onDeselected += UpdateAdapter;
        SelectionManager.Instance.onDeselected += UpdateList;


        ModeManager.Instance.onModeChange += delegate
        {
            if (ModeManager.Instance.currentMode != ModeManager.MODE_EDIT)
            {
                HideList();
                SelectionManager.Instance.DeselectAll();
            }
        };
    }

    private void Update()
    {
        if (adapter != null && adapterValuesChecker != adapter.values)
        {
            UpdateAdapter();
            UpdateList();

            adapterValuesChecker = adapter.values;
        }
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

        List<Value> values = new List<Value>();

        foreach (Object obj in SelectionManager.Instance.currentlySelected)
        {
            values.AddRange(obj.values);
        }

        List<int> test = new List<int>() { 1, 2, 3, 3, 4, 2 };

        values.RemoveAll(x => GetOccurences(x, values) != SelectionManager.Instance.currentlySelected.Count);

        values = values.DistinctBy(x => x.key).ToList();

        adapter = new ValuesAdapter(values, SelectionManager.Instance.currentlySelected.ToArray(), floatPrefab, integerPrefab, boolPrefab, stringPrefab, titlePrefab);
    }

    public static int GetOccurences(Value search, List<Value> list, bool controlWithValue = false)
    {
        int occurences = 0;

        for (int i = 0; i < list.Count; i++)
        {
            if(list[i].key == search.key && !controlWithValue || controlWithValue && list[i].key == search.key && list[i].value == search.value)
            {
                occurences++;
            }
            
        }

        return occurences;
    }

    public int GetOccurences(int search, List<int> list)
    {
        var g = list.GroupBy(i => i).ToList();

        for (int i = 0; i < g.Count(); i++)
        {
            if (list[i] == search)
            {
                return g[i].Count() + 1;
            }

        }

        return 0;
    }

    public void HideList()
    {
        TweeningManager.Instance.ScaleOut(listCreator.canvasGroup.gameObject, TweeningManager.Instance.GetAnimation("scale"));
    }

    public void ShowList()
    {
        TweeningManager.Instance.ScaleIn(listCreator.canvasGroup.gameObject, TweeningManager.Instance.GetAnimation("retarding_scale"));
        TweeningManager.Instance.FadeIn(listCreator.canvasGroup, TweeningManager.Instance.GetAnimation("fade"));
    }
}
