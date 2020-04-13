using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This script should sit on every item in the spriteChooser (Object chooser). It assign an onClick listener.

public class SpriteListItem : MonoBehaviour
{

    public SpritesListUI listManager;

    public int index;


    public void onClick()
    {
        listManager.onItemClick(index);
    }
}
