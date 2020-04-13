using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckItem : MonoBehaviour
{

    public DeckUI deckUIManager;

    public int index;


    public void onClick()
    {
        deckUIManager.onItemClick(index);
    }
}
