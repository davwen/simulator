using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckItem : MonoBehaviour
{
    public int index;

    [Space(10)]

    public DeckUI deckUIManager;

    public Image image;


    public void onClick()
    {
        deckUIManager.onItemClick(index);
    }

    public void onRemoveClick()
    {
        deckUIManager.onItemRemoveClick(index);
    }
}
