using System;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class SpritesListAdapter : ListAdapter
{
    private List<SpawnableObj> items = new List<SpawnableObj>();

    public SpritesListAdapter(List<SpawnableObj> _items){
        items = _items;
    }

    public override int GetCount(){
        return items.Count;
    }

    public override void OnItemInsert(ListItemData data){
        MonoBehaviour.print(data.GetComponent<Text>("text_label"));
        data.GetComponent<Text>("text_label").text = items[data.index].label;

        data.GetComponent<Image>("image_sprite").sprite = items[data.index].sprite;

        data.GetComponent<Button>("button_select").onClick.AddListener(delegate{Spawning.Instance.SelectNewSObj(items[data.index]);});
    }

    public override void OnItemUpdate(ListItemData data){
        OnItemInsert(data);
    }

    public override void OnItemRemove(int index){

    }
}

[System.Serializable]
public class SpawnableObj
{
    public string label;
    public Sprite sprite;
}