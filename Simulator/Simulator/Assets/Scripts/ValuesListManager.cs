using System.Collections.Generic;
using System.Linq;
using MoreLinq;

using UnityEngine;
using UnityEngine.UI;


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

    public bool editable;

    public Button editButton;

    private void Start()
    {
        SelectionManager.Instance.onSelect += delegate { if (SelectionManager.Instance.currentlySelected.Count != 0) { MakeEditAvailable(); } };
        SelectionManager.Instance.onSelect += UpdateAdapter;

        SelectionManager.Instance.onDeselectedAll += HideList;
        SelectionManager.Instance.onDeselectedAll += MakeEditInavailable;
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
        UpdateAdapter();

        if (adapter != null && adapterValuesChecker != adapter.values)
        {
            
            UpdateList();

            adapterValuesChecker = adapter.values;
        }
    }

    private void MakeEditInavailable()
    {
        editable = false;

        TweeningManager.Instance.Animate(editButton.gameObject, AnimationType.ScaleOut, "bouncy", 0.3f, 0f);
        TweeningManager.Instance.Animate(editButton.gameObject, AnimationType.FadeOutWithImage, "linear", 0.1f, 0.2f);
    }

    private void MakeEditAvailable()
    {
        editable = true;

        TweeningManager.Instance.Animate(editButton.gameObject, AnimationType.ScaleIn, "bouncy", 0.3f, 0f);
        TweeningManager.Instance.Animate(editButton.gameObject, AnimationType.FadeInWithImage, "linear", 0.1f, 0.2f);
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
        TweeningManager.Instance.Animate(listCreator.canvasGroup.gameObject, AnimationType.ScaleOut, "linear", 0.3f, 0f);
        TweeningManager.Instance.Animate(listCreator.canvasGroup.gameObject, AnimationType.FadeOutWithCanvasGroup, "linear", 0.1f, 0f);
    }

    public void ShowList()
    {
        TweeningManager.Instance.Animate(listCreator.canvasGroup.gameObject, AnimationType.ScaleIn, "bouncy", 0.3f, 0f);
        TweeningManager.Instance.Animate(listCreator.canvasGroup.gameObject, AnimationType.FadeInWithCanvasGroup, "linear", 0.1f, 0.2f);
    }
}
