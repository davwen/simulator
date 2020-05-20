using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckAdapter : ListAdapter
{
    private List<DeckItemData> items = new List<DeckItemData>();

    private Deck deck;

    public DeckAdapter(List<DeckItemData> _items, Deck _deck){
        items = _items;
        deck = _deck;
    }

    public override int GetCount(){
        return items.Count;
    }

    public override void OnItemInsert(ListItemData data){
        data.GetComponent<Image>("image_sprite").sprite = items[data.index].image;

        data.GetComponent<Button>("button_select").onClick.AddListener(delegate{deck.Select(data.index);});
    }

    public override void OnItemUpdate(ListItemData data){
        OnItemInsert(data);
    }

    public override void OnItemRemove(int index){

    }
}
