using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListItem : MonoBehaviour
{
    [HideInInspector]
    public int index;

    public List<ListItemComponent> components;
}
